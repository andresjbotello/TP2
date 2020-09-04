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

                SqlCommand cmdPersonas = new SqlCommand("select * from personas", SqlConn);

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona persona = new Persona();
                    persona.ID = (int)drPersonas["id_persona"];
                    persona.Nombre = (string)drPersonas["nombre"];
                    persona.Apellido = (string)drPersonas["apellido"];
                    persona.Direccion = (string)drPersonas["direccion"];
                    persona.Email = (string)drPersonas["email"];
                    persona.Telefono = (string)drPersonas["telefono"];
                    persona.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    persona.Legajo = (int)drPersonas["legajo"];
                    persona.SetTipoPersonaById((int)drPersonas["tipo_persona"]);
                    persona.IDPlan = (int)drPersonas["id_plan"];

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

        public List<Persona> GetAll(Persona.TipoPersonas tipoPersonas)
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas where tipo_persona = @tipo_persona", SqlConn);
                cmdPersonas.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = (int) tipoPersonas;

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona persona = new Persona();
                    persona.ID = (int)drPersonas["id_persona"];
                    persona.Nombre = (string)drPersonas["nombre"];
                    persona.Apellido = (string)drPersonas["apellido"];
                    persona.Direccion = (string)drPersonas["direccion"];
                    persona.Email = (string)drPersonas["email"];
                    persona.Telefono = (string)drPersonas["telefono"];
                    persona.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    persona.Legajo = (int)drPersonas["legajo"];
                    persona.SetTipoPersonaById((int)drPersonas["tipo_persona"]);
                    persona.IDPlan = (int)drPersonas["id_plan"];

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
                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona = @id", SqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {
                    persona.ID = (int)drPersonas["id_persona"];
                    persona.Nombre = (string)drPersonas["nombre"];
                    persona.Apellido = (string)drPersonas["apellido"];
                    persona.Direccion = (string)drPersonas["direccion"];
                    persona.Email = (string)drPersonas["email"];
                    persona.Telefono = (string)drPersonas["telefono"];
                    persona.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    persona.Legajo = (int)drPersonas["legajo"];
                    persona.SetTipoPersonaById((int)drPersonas["tipo_persona"]);
                    persona.IDPlan = (int)drPersonas["id_plan"];

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

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona = @id", SqlConn);

                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
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
            try
            {
                this.OpenConnection();
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
                    "WHERE id_persona=@id", SqlConn);

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
            catch (Exception Ex)
            {
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
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO personas (nombre,apellido,direccion,email,telefono,fecha_nac,legajo,tipo_persona,id_plan)" +
                    "values(@nombre,@apellido,@direccion,@email,@telefono,@fecha_nac,@legajo,@tipo_persona,@id_plan)" +
                    "select @@identity", SqlConn);

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
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                return this.Update(persona);
            }
            return null;
        }

    }
}
