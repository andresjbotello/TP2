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
    public class MateriaAdapter:Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("select * from materias", SqlConn);

                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mtr = new Materia();
                    mtr.ID = (int)drMaterias["id_materia"];
                    mtr.IDPlan = (int)drMaterias["id_plan"];
                    mtr.HSTotales = (int)drMaterias["hs_totales"];
                    mtr.HSSemanales = (int)drMaterias["hs_semanales"];
                    mtr.Descripcion = (string)drMaterias["desc_materia"];

                    materias.Add(mtr);
                }
                drMaterias.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return materias;
        }

        public Business.Entities.Materia GetOne(int ID)
        {
            Materia mtr = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMateria = new SqlCommand("select * from materias where id_materia = @id", SqlConn);
                cmdMateria.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMateria = cmdMateria.ExecuteReader();

                if (drMateria.Read())
                {
                    mtr.ID = (int)drMateria["id_materia"];
                    mtr.IDPlan = (int)drMateria["id_plan"];
                    mtr.Descripcion = (string)drMateria["desc_materia"];
                    mtr.HSSemanales = (int)drMateria["hs_semanales"];
                    mtr.HSTotales = (int)drMateria["hs_totales"];

                    drMateria.Close();
                }
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return mtr;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete materias where id_materia = @id", SqlConn);

                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE materias SET desc_materia = @desc_materia, hs_semanales = @hs_semanales," +
                    "hs_totales = @hs_totales, id_plan=@id_plan" +
                    "WHERE id_materia=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IDPlan;
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HSSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HSTotales;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO materias (desc_materia,hs_semanales,hs_totales,id_plan)" +
                    "values(@desc_materia,@hs_semanales,@hs_totales,@id_plan)" +
                    "select @@identity", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IDPlan;
                cmdSave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HSSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HSTotales;
               
                materia.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.New)
            {
                this.Insert(materia);
            }
            else if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                //this.Update(materia);
            }
            materia.State = BusinessEntity.States.Unmodified;
        }


    }
}
