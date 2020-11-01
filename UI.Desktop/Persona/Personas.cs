using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Personas : Form
    {
        private Persona _persona;
        public Persona Persona { get => _persona; set => _persona = value; }

        public Personas(Persona p)
        {
            InitializeComponent();
            Persona = p;
            bool e = Validaciones.Permisos(Persona);
            tsbNuevo.Enabled = e;
            tsbEditar.Enabled = e;
            tsbEliminar.Enabled = e;
            this.dgvPersonas.AutoGenerateColumns = false;
            this.dgvPersonas.MultiSelect = false;
            this.dgvPersonas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Listar();
        }


        public void Listar()
        {
            PersonaLogic pl = new PersonaLogic();
            this.dgvPersonas.DataSource = pl.GetAll().ConvertAll<DataGridObject>(new Converter<Persona, DataGridObject>(PersonaToDataGridObject));
        }

        private static DataGridObject PersonaToDataGridObject(Persona p)
        {
            return new DataGridObject(p);
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonaDesktop pd = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            pd.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if(this.dgvPersonas.SelectedRows.Count > 0) 
            {
                int ID = ((DataGridObject)this.dgvPersonas.SelectedRows[0].DataBoundItem).Id;
                PersonaDesktop pd = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                pd.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Elija una fila para editarla");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvPersonas.SelectedRows.Count > 0)
            {
                int ID = ((DataGridObject)this.dgvPersonas.SelectedRows[0].DataBoundItem).Id;
                PersonaDesktop pd = new PersonaDesktop(ID, ApplicationForm.ModoForm.Baja);
                pd.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Elija una fila para eliminarla");
            }
        }
    }

    class DataGridObject
    {
        int _id;

        string _usuario;

        string _nombre;

        string _apellido;

        string _direccion;

        string _email;

        string _telefono;

        DateTime _fechaNacimiento;

        int _legajo;

        string _tipoPersona;

        string _plan;

        string _habilitado;

        public DataGridObject(Persona p)
        {
            this.Id = p.ID;
            this.Usuario = p.Usuario.NombreUsuario;
            this.Nombre = p.Nombre;
            this.Apellido = p.Apellido;
            this.Direccion = p.Direccion;
            this.Email = p.Email;
            this.Telefono = p.Telefono;
            this.FechaNacimiento = p.FechaNacimiento;
            this.Legajo = p.Legajo;
            this.TipoPersona = p.TipoPersona.ToString();
            this.Plan = p.Plan.Descripcion;
            this.Habilitado = (p.Usuario.Habilitado) ? "Si" : "No";
        }

        public int Id { get => _id; set => _id = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Email { get => _email; set => _email = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public DateTime FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        public int Legajo { get => _legajo; set => _legajo = value; }
        public string TipoPersona { get => _tipoPersona; set => _tipoPersona = value; }
        public string Plan { get => _plan; set => _plan = value; }
        public string Habilitado { get => _habilitado; set => _habilitado = value; }
    }
}
