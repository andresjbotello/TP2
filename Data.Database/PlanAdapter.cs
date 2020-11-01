using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PlanAdapter:Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("select * from planes inner join especialidades on especialidades.id_especialidad = planes.id_especialidad", SqlConn);

                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                while (drPlanes.Read())
                {
                    Plan pln = new Plan();
                    pln.ID = (int)drPlanes["id_plan"];
                    pln.Descripcion = (string)drPlanes["desc_plan"];
                    pln.IDEspecialidad = (int)drPlanes["id_especialidad"];

                    pln.Especialidad = new Especialidad((int)drPlanes["id_especialidad"], (string)drPlanes["desc_especialidad"]);

                    planes.Add(pln);
                }
                drPlanes.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return planes;
        }

        public Business.Entities.Plan GetOne(int ID)
        {
            Plan pln = new Plan();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPlanes = new SqlCommand("select * from planes where id_plan = @id", SqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                if (drPlanes.Read())
                {
                    pln.ID = (int)drPlanes["id_plan"];
                    pln.Descripcion = (string)drPlanes["desc_plan"];
                    pln.IDEspecialidad = (int)drPlanes["id_especialidad"];
                }
                drPlanes.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return pln;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete planes where id_plan = @id", SqlConn);

                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


       protected void Update(Plan plan)
       {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE planes SET desc_plan = @desc_plan, id_especialidad = @id_especialidad " +
                    "WHERE id_plan=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar el plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
       }
        protected void Insert(Plan plan)
       {
           try
           {
               this.OpenConnection();
               SqlCommand cmdSave = new SqlCommand(
                   "INSERT INTO planes (desc_plan,id_especialidad)" +
                   "values(@desc_plan,@id_especialidad)" +
                   "select @@identity", SqlConn);

               cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
               cmdSave.Parameters.Add("@desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
               cmdSave.Parameters.Add("@id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;

               plan.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
           }
           catch (Exception Ex)
           {
               Exception ExcepcionManejada = new Exception("Error al insertar el plan", Ex);
               throw ExcepcionManejada;
           }
           finally
           {
               this.CloseConnection();
           }

       }

       public void Save(Plan plan)
       {
           if (plan.State == BusinessEntity.States.New)
           {
               this.Insert(plan);
           }
           else if (plan.State == BusinessEntity.States.Deleted)
           {
               this.Delete(plan.ID);
           }
           else if (plan.State == BusinessEntity.States.Modified)
           {
               this.Update(plan);
           }
           plan.State = BusinessEntity.States.Unmodified;
       }

    }
}
