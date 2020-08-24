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
    public class AlumnoInscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAll()
        {
            List<AlumnoInscripcion> alumnos_inscripciones = new List<AlumnoInscripcion>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdAlumnosInscripciones = new SqlCommand("select * from alumnos_inscripciones", SqlConn);

                SqlDataReader drAlumnosInscripciones = cmdAlumnosInscripciones.ExecuteReader();

                while (drAlumnosInscripciones.Read())
                {
                    AlumnoInscripcion aluInscri = new AlumnoInscripcion();
                    aluInscri.ID = (int)drAlumnosInscripciones["id_inscripcion"];
                    aluInscri.IDAlumno = (int)drAlumnosInscripciones["id_alumno"];
                    aluInscri.IDCurso = (int)drAlumnosInscripciones["id_curso"];
                    aluInscri.Condicion = (string)drAlumnosInscripciones["condicion"];
                    aluInscri.Nota = (int)drAlumnosInscripciones["nota"];

                    alumnos_inscripciones.Add(aluInscri);
                }
                drAlumnosInscripciones.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de alumnos inscripciones", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return alumnos_inscripciones;
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion aluInscri = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnosInscripciones = new SqlCommand("select * from alumnos_inscripciones where id_inscripcion = @id", SqlConn);
                cmdAlumnosInscripciones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumnosInscripciones = cmdAlumnosInscripciones.ExecuteReader();

                if (drAlumnosInscripciones.Read())
                {
                    aluInscri.ID = (int)drAlumnosInscripciones["id_inscripcion"];
                    aluInscri.IDAlumno = (int)drAlumnosInscripciones["id_alumno"];
                    aluInscri.IDCurso = (int)drAlumnosInscripciones["id_curso"];
                    aluInscri.Condicion = (string)drAlumnosInscripciones["condicion"];
                    aluInscri.Nota = (int)drAlumnosInscripciones["nota"];
                }
                drAlumnosInscripciones.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de alumnos inscripciones", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return aluInscri;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete alumnos_inscripciones where id_inscripcion = @id", SqlConn);

                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar registro en alumnos_inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Update(AlumnoInscripcion aluInscri)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones SET " +
                    "id_alumno = @id_alumno, " +
                    "id_curso = @id_curso, " +
                    "condicion = @condicion, " +
                    "nota = @nota" +
                    "WHERE id_inscripcion = @id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = aluInscri.ID;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = aluInscri.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = aluInscri.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar).Value = aluInscri.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = aluInscri.Nota;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar registro de alumnos_inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(AlumnoInscripcion aluInscri)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO alumnos_inscripciones (id_alumno, id_curso, condicion, nota)" +
                    "values(@id_alumno, @id_curso, @condicion, @nota)" +
                    "select @@identity", SqlConn);

                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = aluInscri.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = aluInscri.IDCurso;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar).Value = aluInscri.Condicion;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = aluInscri.Nota;

                aluInscri.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al insertar registro de alumnos_inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(AlumnoInscripcion aluInscri)
        {
            if (aluInscri.State == BusinessEntity.States.New)
            {
                this.Insert(aluInscri);
            }
            else if (aluInscri.State == BusinessEntity.States.Deleted)
            {
                this.Delete(aluInscri.ID);
            }
            else if (aluInscri.State == BusinessEntity.States.Modified)
            {
                this.Update(aluInscri);
            }
            aluInscri.State = BusinessEntity.States.Unmodified;
        }

    }
}
