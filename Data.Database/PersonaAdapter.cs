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
    public class PersonaAdapter:Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas INNER JOIN usuarios ON usuarios.id_persona = personas.id_persona INNER JOIN planes on planes.id_plan = personas.id_plan", SqlConn);

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona p = this.InstanciarPersona(drPersonas);

                    personas.Add(p);
                }
                drPersonas.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return personas;
        }

        public List<Persona> GetAll(Persona.TipoPersonas tipoPersonas)
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas INNER JOIN usuarios ON usuarios.id_persona = personas.id_persona INNER JOIN planes on planes.id_plan = personas.id_plan where tipo_persona = @tipo_persona", SqlConn);
                cmdPersonas.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = (int) tipoPersonas;

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona persona = this.InstanciarPersona(drPersonas);

                    personas.Add(persona);
                }
                drPersonas.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return personas;
        }

        public Persona GetOne(int ID)
        {
            Persona persona = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas INNER JOIN usuarios ON usuarios.id_persona = personas.id_persona INNER JOIN planes on planes.id_plan = personas.id_plan where personas.id_persona = @id", SqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {
                    persona = this.InstanciarPersona(drPersonas);

                    drPersonas.Close();
                }
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la persona", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return persona;
        }

        public void Delete(Persona p)
        {
            SqlTransaction transaction = this.BeginTransaction();
            try
            {
                this.DeleteUsuario(transaction, p.Usuario);
                this.DeletePersona(transaction, p);

                transaction.Commit();
            }
            catch (Exception Ex)
            {
                transaction.Rollback();
                Exception ExcepcionManejada = new Exception("Error al eliminar la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected Persona Update(Persona persona)
        {
            SqlTransaction transaction = this.BeginTransaction();
            try
            {
                this.UpdatePersona(transaction, persona);
                this.UpdateUsuario(transaction, persona.Usuario);
                transaction.Commit();
            }
            catch (Exception Ex)
            {
                transaction.Rollback();
                Exception ExcepcionManejada = new Exception("Error al actualizar la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return persona;
        }

        protected Persona Insert(Persona persona)
        {
            SqlTransaction transaction = this.BeginTransaction();
            try
            {
                persona = this.InsertPersona(transaction, persona);
                persona.Usuario = this.InsertUsuario(transaction, persona.ID, persona.Usuario);
                transaction.Commit();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return persona;
        }

        public Persona Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.New)
            {
                return this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                return this.Update(persona);
            }
            return null;
        }

        private Persona InstanciarPersona(SqlDataReader drPersonas)
        {
            Usuario usuario = new Usuario(
                (int)drPersonas["id_usuario"],
                (string)drPersonas["nombre_usuario"],
                (string)drPersonas["clave"],
                (string)drPersonas["nombre"],
                (string)drPersonas["apellido"],
                (string)drPersonas["email"],
                (bool)drPersonas["habilitado"],
                (int)drPersonas["id_persona"]
            );
            Plan pln = new Plan((int)drPersonas["id_plan"], (string)drPersonas["desc_plan"], (int)drPersonas["id_especialidad"]);
            Persona persona = new Persona(
                (int)drPersonas["id_persona"],
                (string)drPersonas["apellido"],
                (string)drPersonas["direccion"],
                (string)drPersonas["email"],
                (DateTime)drPersonas["fecha_nac"],
                (int)drPersonas["id_plan"],
                (int)drPersonas["legajo"],
                (string)drPersonas["nombre"],
                (string)drPersonas["telefono"],
                (int)drPersonas["tipo_persona"],
                usuario, pln
            );

            return persona;
        }

        #region Delete/Update/Insert Persona
        private void DeletePersona(SqlTransaction transaction, Persona p)
        {
            SqlCommand cmdDelete = new SqlCommand(
                "delete personas where id_persona = @id", 
                SqlConn,
                transaction
            );

            cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = p.ID;

            cmdDelete.ExecuteNonQuery();
        }

        private void UpdatePersona(SqlTransaction transaction, Persona persona)
        {
            SqlCommand cmdSave = new SqlCommand("UPDATE personas SET " +
                "nombre = @nombre, " +
                "apellido = @apellido, " +
                "direccion = @direccion, " +
                "email = @email, " +
                "telefono = @telefono, " +
                "fecha_nac = @fecha_nac, " +
                "legajo = @legajo, " +
                "tipo_persona = @tipo_persona, " +
                "id_plan = @id_plan " +
                "WHERE id_persona=@id", 
                SqlConn,
                transaction
            );

            cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
            cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
            cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
            cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
            cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
            cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
            cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
            cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
            cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
            cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;

            cmdSave.ExecuteNonQuery();
        }

        private Persona InsertPersona(SqlTransaction transaction, Persona persona)
        {
            SqlCommand cmdSave = new SqlCommand(
                "INSERT INTO personas (nombre,apellido,direccion,email,telefono,fecha_nac,legajo,tipo_persona,id_plan)" +
                "values(@nombre,@apellido,@direccion,@email,@telefono,@fecha_nac,@legajo,@tipo_persona,@id_plan)" +
                "select @@identity", 
                SqlConn,
                transaction
            );

            cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
            cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
            cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
            cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
            cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
            cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
            cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
            cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
            cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
            cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;

            persona.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            return persona;
        }
        #endregion

        #region Delete/Update/Insert Usuario
        private void DeleteUsuario(SqlTransaction transaction, Usuario u)
        {
            try
            {
                SqlCommand cmdDelete = new SqlCommand(
                    "delete usuarios where id_usuario = @id",
                    SqlConn,
                    transaction
                );

                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = u.ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el usuario", Ex);
                throw ExcepcionManejada;
            }
        }

        private void UpdateUsuario(SqlTransaction transaction, Usuario usuario)
        {
            try
            {
                SqlCommand cmdSave = new SqlCommand(
                    "UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave," +
                    "habilitado = @habilitado, nombre=@nombre, apellido=@apellido, email=@email " +
                    "WHERE id_usuario=@id", 
                    SqlConn,
                    transaction
                );

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar el usuario", Ex);
                throw ExcepcionManejada;
            }
        }

        private Usuario InsertUsuario(SqlTransaction transaction, int idPersona, Usuario usuario)
        {
            try
            {
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO usuarios (nombre_usuario,clave,habilitado,nombre,apellido,email,id_persona)" +
                    "values(@nombre_usuario,@clave,@habilitado,@nombre,@apellido,@email,@id_persona)" +
                    "select @@identity", 
                    SqlConn,
                    transaction
                );


                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = usuario.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = usuario.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = usuario.Email;
                cmdSave.Parameters.Add("@id_persona", SqlDbType.VarChar, 50).Value = idPersona;

                usuario.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
                usuario.IdPersona = idPersona;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar el usuario", Ex);
                throw ExcepcionManejada;
            }

            return usuario;

        }
        #endregion

    }
}
