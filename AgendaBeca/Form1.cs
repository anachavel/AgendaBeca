using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;

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
                    string datos = "SELECT Id, Nombre, FechaNacimiento, Telefono, Observaciones FROM Contactos";
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

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridViewDatos.SelectedRows[0].Cells["Id"].Value);
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
            CrearContacto(id, nombre, fechaNacimiento, telefono, observaciones);
        }

        private void CrearContacto(int id, string nombre, DateTime fechaNacimiento, string telefono, string observaciones)
        {
            existeId = id;
            using (SqlConnection connection = new SqlConnection(conexionBD))
            {
                connection.Open();
                SqlTransaction transaccion = null;

                try
                {
                    transaccion = connection.BeginTransaction();

                    // Crear comando SQL en la transacción
                    SqlCommand command = connection.CreateCommand();
                    command.Transaction = transaccion;

                    if (existeId == -1)
                    {
                        // Crear contacto
                        string accion = "INSERT INTO Contactos (Nombre, Telefono, FechaNacimiento, Observaciones) VALUES (@Nombre, @Telefono, @FechaNacimiento, @Observaciones)";
                    }
                    else
                    {
                        // Actuaizar contacto
                        command.CommandText = "UPDATE Contactos SET Nombre = @Nombre, FechaNacimiento = @FechaNacimiento, Telefono = @Telefono, Observaciones = @Observaciones WHERE Id = @Id";
                        command.Parameters.AddWithValue("@Id", existeId);
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Telefono", telefono);
                        command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                        command.Parameters.AddWithValue("@Observaciones", observaciones);
                        command.ExecuteNonQuery();
                        CargarDatos();

                        // Commmit de la transacción
                        transaccion.Commit();

                        MessageBox.Show("El contacto se ha creado correctamente.");
                    }
                }
                catch (Exception ex)
                {
                    //Rollback
                    if (transaccion != null)
                    {
                        transaccion.Rollback();
                    }

                    MessageBox.Show("Error al guardar el contacto: " + ex.Message);
                }
            }
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            if (dataGridViewDatos.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewDatos.SelectedRows[0].Cells["Id"].Value);
                textBoxId.Text = id.ToString();
                textBoxNombre.Text = dataGridViewDatos.SelectedRows[0].Cells["Nombre"].Value.ToString();
                dateTimePickerFechaNacimiento.Value = Convert.ToDateTime(dataGridViewDatos.SelectedRows[0].Cells["FechaNacimiento"].Value);
                textBoxTelefono.Text = dataGridViewDatos.SelectedRows[0].Cells["Telefono"].Value.ToString();
                textBoxObservaciones.Text = dataGridViewDatos.SelectedRows[0].Cells["Observaciones"].Value.ToString();

                string nombre = textBoxNombre.Text;
                DateTime fechaNacimiento = dateTimePickerFechaNacimiento.Value;
                string telefono = textBoxTelefono.Text;
                string observaciones = textBoxObservaciones.Text;

                //ModificarDatos(id, nombre, fechaNacimiento, telefono, observaciones);
            }
        }

        private void ModificarDatos(int id, string nombre, DateTime fechaNacimiento, string telefono, string observaciones)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conexionBD))
                {
                    connection.Open();
                    string accion = "UPDATE Contactos SET Nombre = @Nombre, FechaNacimiento = @FechaNacimiento, Telefono = @Telefono, Observaciones = @Observaciones WHERE Id = @Id";
                    SqlCommand command = new SqlCommand(accion, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    command.Parameters.AddWithValue("@FechaNacimiento", fechaNacimiento);
                    command.Parameters.AddWithValue("@Telefono", telefono);
                    command.Parameters.AddWithValue("@Observaciones", observaciones);
                    command.ExecuteNonQuery();
                    CargarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No ha sido posible modificar los datos: " + ex.Message);
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridViewDatos.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridViewDatos.SelectedRows[0].Cells["Id"].Value);
                EliminarContacto(id);
            }
        }

        private void EliminarContacto(int id)
        {
            using (SqlConnection connection = new SqlConnection(conexionBD))
            {
                connection.Open();
                SqlTransaction transaccion = null;

                try
                {
                    transaccion = connection.BeginTransaction();

                    // Crear un comando SQL en la transacción
                    SqlCommand command = connection.CreateCommand();
                    command.Transaction = transaccion;

                    command.CommandText = "DELETE FROM Contactos WHERE Id = @Id";
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                    CargarDatos();
                    LimpiarCampos();

                    // Commit de la transacción
                    transaccion.Commit();

                    MessageBox.Show("Se ha eliminado el contacto correctamente.");
                }
                catch (Exception ex)
                {
                    // Rollback
                    if (transaccion != null)
                    {
                        transaccion.Rollback();
                    }

                    MessageBox.Show("Se ha producido un error al eliminar el contacto: " + ex);
                }

            }
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

