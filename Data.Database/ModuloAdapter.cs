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
    public class ModuloAdapter:Adapter
    {
        public List<Modulo> GetAll()
        {
            List<Modulo> modulos = new List<Modulo>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdModulos = new SqlCommand("select * from modulos", SqlConn);

                SqlDataReader drModulos = cmdModulos.ExecuteReader();

                while (drModulos.Read())
                {
                    Modulo mdl = new Modulo();
                    mdl.ID = (int)drModulos["id_modulo"];
                    mdl.Descripcion = (string)drModulos["desc_modulo"];

                    modulos.Add(mdl);
                }
                drModulos.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de modulos", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return modulos;
        }

        public Modulo GetOne(int ID)
        {
            Modulo mdl = new Modulo();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulos = new SqlCommand("select * from modulos where id_modulo = @id", SqlConn);
                cmdModulos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModulos = cmdModulos.ExecuteReader();

                if (drModulos.Read())
                {
                    mdl.ID = (int)drModulos["id_modulo"];
                    mdl.Descripcion = (string)drModulos["desc_modulo"];
                }
                drModulos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de modulos", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return mdl;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete modulos where id_modulo = @id", SqlConn);

                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


       protected void Update(Modulo modulo)
       {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE modulos SET desc_modulo = @desc_modulo " +
                    "WHERE id_modulo=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = modulo.ID;
                cmdSave.Parameters.Add("@desc_modulo", SqlDbType.VarChar, 50).Value = modulo.Descripcion;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar el modulo", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
       }
        protected void Insert(Modulo modulo)
       {
           try
           {
               this.OpenConnection();
               SqlCommand cmdSave = new SqlCommand(
                   "INSERT INTO modulos (desc_modulo)" +
                   "values(@desc_modulo)" +
                   "select @@identity", SqlConn);

               cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = modulo.ID;
               cmdSave.Parameters.Add("@desc_modulo", SqlDbType.VarChar, 50).Value = modulo.Descripcion;

               modulo.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
           }
           catch (Exception Ex)
           {
               Exception ExcepcionManejada = new Exception("Error al insertar el modulo", Ex);
               throw ExcepcionManejada;
           }
           finally
           {
               this.CloseConnection();
           }

       }

       public void Save(Modulo modulo)
       {
           if (modulo.State == BusinessEntity.States.New)
           {
               this.Insert(modulo);
           }
           else if (modulo.State == BusinessEntity.States.Deleted)
           {
               this.Delete(modulo.ID);
           }
           else if (modulo.State == BusinessEntity.States.Modified)
           {
               this.Update(modulo);
           }
           modulo.State = BusinessEntity.States.Unmodified;
       }

    }
}
