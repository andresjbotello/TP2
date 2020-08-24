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
    public class ModuloUsuarioAdapter : Adapter
    {
        public List<ModuloUsuario> GetAll()
        {
            List<ModuloUsuario> modulos_usuarios = new List<ModuloUsuario>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdModulosUsuarios = new SqlCommand("select * from modulos_usuarios", SqlConn);

                SqlDataReader drModulosUsuarios = cmdModulosUsuarios.ExecuteReader();

                while (drModulosUsuarios.Read())
                {
                    ModuloUsuario modUsr = new ModuloUsuario();                  
                    modUsr.ID = (int)drModulosUsuarios["id_modulo_usuario"];
                    modUsr.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    modUsr.IdModulo = (int)drModulosUsuarios["id_modulo"];
                    modUsr.PermiteAlta = (bool)drModulosUsuarios["alta"];
                    modUsr.PermiteBaja = (bool)drModulosUsuarios["baja"];
                    modUsr.PermiteModificacion = (bool)drModulosUsuarios["modificacion"];
                    modUsr.PermiteConsulta = (bool)drModulosUsuarios["consulta"];

                    modulos_usuarios.Add(modUsr);
                }
                drModulosUsuarios.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de modulos usuarios", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return modulos_usuarios;
        }

        public ModuloUsuario GetOne(int ID)
        {
            ModuloUsuario modUsr = new ModuloUsuario();
            try
            {
                this.OpenConnection();
                SqlCommand cmdModulosUsuarios = new SqlCommand("select * from modulos_usuarios where id_modulo_usuario = @id", SqlConn);
                cmdModulosUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drModulosUsuarios = cmdModulosUsuarios.ExecuteReader();

                if (drModulosUsuarios.Read())
                {
                    modUsr.ID = (int)drModulosUsuarios["id_modulo_usuario"];
                    modUsr.IdUsuario = (int)drModulosUsuarios["id_usuario"];
                    modUsr.IdModulo = (int)drModulosUsuarios["id_modulo"];
                    modUsr.PermiteAlta = (bool)drModulosUsuarios["alta"];
                    modUsr.PermiteBaja = (bool)drModulosUsuarios["baja"];
                    modUsr.PermiteModificacion = (bool)drModulosUsuarios["modificacion"];
                    modUsr.PermiteConsulta = (bool)drModulosUsuarios["consulta"];
                }
                drModulosUsuarios.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de modulos usuarios", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return modUsr;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete modulos_usuarios where id_modulo_usuario = @id", SqlConn);

                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar registro en modulos_usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Update(ModuloUsuario modUsr)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE modulos_usuarios SET " +
                    "id_modulo = @id_modulo, " +
                    "id_usuario = @id_usuario, " +
                    "alta = @alta, " +
                    "baja = @baja," +
                    "modificacion = @modificacion," +
                    "consulta = @consulta" +
                    "WHERE id_modulo_usuario = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = modUsr.ID;                
                cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = modUsr.IdModulo;
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = modUsr.IdUsuario;
                cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = modUsr.PermiteAlta;
                cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = modUsr.PermiteBaja;
                cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = modUsr.PermiteModificacion;
                cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = modUsr.PermiteConsulta;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar registro de modulos_usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(ModuloUsuario modUsr)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO modulos_usuarios (id_modulo, id_usuario, alta, baja, modificacion, consulta)" +
                    "values(@id_modulo, @id_usuario, @alta, @baja, @modificacion, @consulta)" +
                    "select @@identity", SqlConn);

                cmdSave.Parameters.Add("@id_modulo", SqlDbType.Int).Value = modUsr.IdModulo;
                cmdSave.Parameters.Add("@id_usuario", SqlDbType.Int).Value = modUsr.IdUsuario;
                cmdSave.Parameters.Add("@alta", SqlDbType.Bit).Value = modUsr.PermiteAlta;
                cmdSave.Parameters.Add("@baja", SqlDbType.Bit).Value = modUsr.PermiteBaja;
                cmdSave.Parameters.Add("@modificacion", SqlDbType.Bit).Value = modUsr.PermiteModificacion;
                cmdSave.Parameters.Add("@consulta", SqlDbType.Bit).Value = modUsr.PermiteConsulta;

                modUsr.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar registro de modulos_usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(ModuloUsuario modUsr)
        {
            if (modUsr.State == BusinessEntity.States.New)
            {
                this.Insert(modUsr);
            }
            else if (modUsr.State == BusinessEntity.States.Deleted)
            {
                this.Delete(modUsr.ID);
            }
            else if (modUsr.State == BusinessEntity.States.Modified)
            {
                this.Update(modUsr);
            }
            modUsr.State = BusinessEntity.States.Unmodified;
        }

    }
}
