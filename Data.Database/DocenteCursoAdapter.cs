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
    public class DocenteCursoAdapter:Adapter
    {
        public List<DocenteCurso> GetAll()
        {
            List<DocenteCurso> docentes_cursos = new List<DocenteCurso>();
            try
            {
                this.OpenConnection();

                SqlCommand cmdDocenteCursos = new SqlCommand("select * from docentes_cursos", SqlConn);

                SqlDataReader drDocenteCursos = cmdDocenteCursos.ExecuteReader();

                while (drDocenteCursos.Read())
                {
                    DocenteCurso docCurso = new DocenteCurso();
                    docCurso.ID = (int)drDocenteCursos["id_dictado"];
                    docCurso.IDCurso = (int)drDocenteCursos["id_curso"];
                    docCurso.IDDocente = (int)drDocenteCursos["id_docente"];
                    docCurso.SetTipoCargoById((int)drDocenteCursos["cargo"]);

                    docentes_cursos.Add(docCurso);
                }
                drDocenteCursos.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de docentes cursos", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }


            return docentes_cursos;
        }

        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso docCurso = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocenteCursos = new SqlCommand("select * from docentes_cursos where id_dictado = @id", SqlConn);
                cmdDocenteCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocenteCursos = cmdDocenteCursos.ExecuteReader();

                if (drDocenteCursos.Read())
                {
                    docCurso.ID = (int)drDocenteCursos["id_dictado"];
                    docCurso.IDCurso = (int)drDocenteCursos["id_curso"];
                    docCurso.IDDocente = (int)drDocenteCursos["id_docente"];
                    docCurso.SetTipoCargoById((int)drDocenteCursos["cargo"]);
                }
                drDocenteCursos.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de docentes cursos", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return docCurso;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete docentes_cursos where id_dictado = @id", SqlConn);

                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar el docente_curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


       protected void Update(DocenteCurso docCurso)
       {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos SET " +
                    "id_curso = @id_curso, " +
                    "id_docente = @id_docente, " +
                    "cargo = @cargo " +
                    "WHERE id_dictado=@id", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = docCurso.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docCurso.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docCurso.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docCurso.GetIDTipoCargo();

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al actualizar el docente_curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
       }
        protected void Insert(DocenteCurso docCurso)
       {
           try
           {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand(
                    "INSERT INTO docentes_cursos (id_curso, id_docente, cargo)" +
                    "values(@id_curso, @id_docente, @cargo)" +
                    "select @@identity", SqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = docCurso.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = docCurso.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = docCurso.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = docCurso.GetIDTipoCargo();

                docCurso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
           }
           catch (Exception Ex)
           {
               Exception ExcepcionManejada = new Exception("Error al insertar el docente_curso", Ex);
               throw ExcepcionManejada;
           }
           finally
           {
               this.CloseConnection();
           }

       }

       public void Save(DocenteCurso docCurso)
       {
           if (docCurso.State == BusinessEntity.States.New)
           {
               this.Insert(docCurso);
           }
           else if (docCurso.State == BusinessEntity.States.Deleted)
           {
               this.Delete(docCurso.ID);
           }
           else if (docCurso.State == BusinessEntity.States.Modified)
           {
               this.Update(docCurso);
           }
           docCurso.State = BusinessEntity.States.Unmodified;
       }

    }
}
