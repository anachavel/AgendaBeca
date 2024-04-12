using System;
using System.Data;
using System.Data.SqlClient;

namespace AgendaBeca
{
    public partial class Form1 : Form
    {
        private string conexionBD = "Server=WINAPPR1JVTCMTM\\SQLEXPRESS;Database=AgendaBeca;Trusted_Connection=True;";
        private int existeId = -1; // La inicializo con un número negativo para indicar que no hay Id cargada

        public Form1()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexionBD))
                {
                    string datos = "select Id, Nombre, FechaNacimiento, Observaciones from Contactos";
                    SqlDataAdapter adapter = new SqlDataAdapter(datos, connection);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewDatos.DataSource = table;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error al cargar los datos:" + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            String nombre = textBoxNombre.Text;
            DateTime fechaNacimiento = dateTimePickerFechaNacimiento.Value;
            String telefono = textBoxTelefono.Text;
            String observaciones = textBoxObservaciones.Text;

            if (nombre.Length > 100)
            {
                MessageBox.Show("El nombre no puede tener más de 100 caracteres.");
                return;
            }

            if (telefono.Length != 9)
            {
                MessageBox.Show("El teléfono debe de tener exactamente 9 caracteres.");
                return;
            }

            if (observaciones.Length > 500)
            {
                MessageBox.Show("Las observaciones no pueden tener más de 500 caracteres.");
                return;
            }

            if (existeId == -1)
            {
                CrearContacto(nombre, fechaNacimiento, telefono, observaciones);
            }
            else
            {
                //ModificarDatos(existeId, nombre, fechaNacimiento, telefono, observaciones)
            }
        }

        private void CrearContacto (string nombre, DateTime fechaNacimiento, string telefono, string observaciones)
        {
            using (SqlConnection connection = new SqlConnection(conexionBD))
            {
                connection.Open();
                string accion = "insert into Contactos (Nombre, Telefono, FechaNacimiento, Observaciones) values (@Nombre, @Telefono, @FechaNacimiento, @Observaciones)";
                SqlCommand command = new SqlCommand(accion, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Telefono", telefono);
                command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                command.Parameters.AddWithValue("@Observaciones", observaciones);
                command.ExecuteNonQuery();
                CargarDatos();
                LimpiarCampos();

                MessageBox.Show("El contacto se ha creado correctamente.");
            }
        }

        private void buttonModificar_Click_1(object sender, EventArgs e)
        {
            /*if (dataGridViewDatos.SelectedRows.Count > 0)
            {
                existeId = Convert.ToInt32(dataGridViewDatos.SelectedRows[0].Cells["Id"].Value);
                ModificarDatos(existeId);
            }*/
        }

        private void ModificarDatos(int existeId, string nombre, DateTime fechaNacimiento, string observaciones)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexionBD))
                {
                    connection.Open();
                    string accion = "update Nombre, Telefono, FechaNacimiento from Contactos where Id = @Id";
                    SqlCommand command = new SqlCommand(accion, connection);
                    command.Parameters.AddWithValue("@Id", existeId);
                    command.ExecuteNonQuery();
                    CargarDatos();
                    LimpiarCampos();

                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("No ha sido posible modificar los datos: " + ex.Message);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            /*if (dataGridViewDatos.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewDatos.SelectedRows[0].Cells["Id"].Value);
                EliminarContacto(id);
            }*/
        }

        private void EliminarContacto(int id)
        {
            /*try
            {
                using (SqlConnection connection = new SqlConnection(conexionBD))
                {
                    connection.Open();
                    string accion = "delete * from Contactos where Id = @Id";
                    SqlCommand command = new SqlCommand(accion, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                    CargarDatos();
                    LimpiarCampos();

                    MessageBox.Show("Se ha eliminado el contacto correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha producido un error al crear el contacto: " + ex);
            }*/
        }

        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            existeId = -1;
            textBoxNombre.Clear();
            textBoxTelefono.Clear();
            textBoxObservaciones.Clear();
            dateTimePickerFechaNacimiento.Value = DateTime.Now;
        }
    }
}
