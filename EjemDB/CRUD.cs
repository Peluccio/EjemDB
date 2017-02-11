using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace EjemDB
{
    public partial class CRUD : Form
    {
        public CRUD()
        {
            InitializeComponent();
            textBoxCodigoCliente.Focus();
        }
                
        ClassDB DB = new ClassDB();
        Cliente db = new Cliente();
        int res = -1;

        //Operaciones CRUD. ###############################################################
        //Buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (textBoxCodigoCliente.Text == "")
            {
                MessageBox.Show
                   ("Se debe seleccionar un código a buscar.", "Advertencia",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBoxCodigoCliente.Focus();
            }
            else
            { 
            SqlDataReader resultadoConsulta;
            string consulta = "SELECT * FROM cliente WHERE codigo_cli=" + textBoxCodigoCliente.Text;

            //Llama el método buscarCliente que se encuentra en la clase y le envía la consulta a ejecutar.
            //  El resultado de la búsqueda se asigna a resultadoConsulta, onjeto de lectura de datos.
            resultadoConsulta = db.buscarCliente(consulta);

            if (resultadoConsulta.Read())
            {
                //Si se encontró un regístro con las especificacíones proporcionadas, se
                //toma cada uno de los atributos y se coloca el contenido en los diferentes controles.
                textBoxCodigoCliente.Text = resultadoConsulta.GetInt32(0).ToString();
                textBoxNombreCliente.Text = resultadoConsulta.GetString(1).ToString();
                textBoxRFCCliente.Text = resultadoConsulta.GetString(2).ToString();
                textBoxDireccionCliente.Text = resultadoConsulta.GetString(3).ToString();
                textBoxCiudadCliente.Text = resultadoConsulta.GetString(4).ToString();
                textBoxTelefonoCliente.Text = resultadoConsulta.GetString(5).ToString();

                textBoxCodigoCliente.BackColor = Color.White;
                textBoxNombreCliente.BackColor = Color.White;
                textBoxRFCCliente.BackColor = Color.White;
                textBoxDireccionCliente.BackColor = Color.White;
                textBoxCiudadCliente.BackColor = Color.White;
                textBoxTelefonoCliente.BackColor = Color.White;

                }
            else
            {
                MessageBox.Show
                    ("No se encontró ningún regístro con ésas especificacíones.", "Advertencia",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxCodigoCliente.Focus();
                    
            }
            resultadoConsulta.Close();
            Cliente.conn.Close();
            }
        }

        //Mostrar todos.
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            DataSet datos = new DataSet();

            //Llamar al método de la clase que ejecutará la consulta, para ello requiere el nombre de la Tabla
            //y el atributo a considerar para ordenar los datos de manera ascendente.
            datos = db.ConsultaTabla("cliente", "codigo_cli");

            //Lena el DataGridView con los datos obtenidos de la consulta.
            dataGridView1.DataSource = datos.Tables["cliente"];
            
            //Nombrar columnas del dataGridView.
            dataGridView1.Columns[0].HeaderText = "Código";
            dataGridView1.Columns[1].HeaderText = "Nombre";
            dataGridView1.Columns[2].HeaderText = "RFC";
            dataGridView1.Columns[3].HeaderText = "Dirección";
            dataGridView1.Columns[4].HeaderText = "Ciudad";
            dataGridView1.Columns[5].HeaderText = "Teléfono";
        }

        //Editar
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (textBoxCodigoCliente.Text == "" || textBoxNombreCliente.Text == "" || textBoxRFCCliente.Text == "" ||
                textBoxDireccionCliente.Text == "" || textBoxCiudadCliente.Text == "" || textBoxTelefonoCliente.Text == "")
            {
                MessageBox.Show
                   ("Se debe introducir el código del dato y después editarlo.", "Advertencia",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBoxCodigoCliente.Focus();
                                
                textBoxCodigoCliente.BackColor = Color.Red;
                textBoxNombreCliente.BackColor = Color.LightPink;
                textBoxRFCCliente.BackColor = Color.LightPink;
                textBoxDireccionCliente.BackColor = Color.LightPink;
                textBoxCiudadCliente.BackColor = Color.LightPink;
                textBoxTelefonoCliente.BackColor = Color.LightPink;
                //Actualizar la tabla.
                Cargar();
            }
            else { 
                try
                {
                    string editar = "UPDATE cliente SET nombre_cli='" + textBoxNombreCliente.Text + "',RFC_cli='" + textBoxRFCCliente.Text +
                       "',direccion_cli='" + textBoxDireccionCliente.Text + "',ciudad_cli='" + textBoxCiudadCliente.Text + "',telefono_cli='" + 
                       textBoxTelefonoCliente.Text + "' WHERE codigo_cli =" + textBoxCodigoCliente.Text;                                  
               
                    res = DB.ABM(editar);

                    if (res == 1)
                    {
                        MessageBox.Show
                            ("Se ha editado el registro correctamente.", "Ediciones", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Actualizar la tabla.
                        Cargar();

                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ClassDB.conn.Close();
                }
            }
        }

        //Crear
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (textBoxNombreCliente.Text == "" || textBoxRFCCliente.Text == "" || 
                textBoxDireccionCliente.Text == "" || textBoxCiudadCliente.Text == "" || 
                textBoxTelefonoCliente.Text == "")
            {
                MessageBox.Show
                   ("Se deben introducir datos.", "Advertencia",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBoxCodigoCliente.Enabled = false;
                textBoxNombreCliente.Focus();

                textBoxNombreCliente.BackColor = Color.LightPink;
                textBoxRFCCliente.BackColor = Color.LightPink;
                textBoxDireccionCliente.BackColor = Color.LightPink;
                textBoxCiudadCliente.BackColor = Color.LightPink;
                textBoxTelefonoCliente.BackColor = Color.LightPink;
            }
            else
            {
                try
                {
                    string crear = "INSERT INTO cliente VALUES('" + textBoxNombreCliente.Text + "','" + textBoxRFCCliente.Text + "','" +
                        textBoxDireccionCliente.Text + "','" + textBoxCiudadCliente.Text + "','" + textBoxTelefonoCliente.Text + "')";

                    res = DB.ABM(crear);

                    if (res == 1)
                    {
                        MessageBox.Show
                            ("Se ha agregado el registro correctamente.", "Altas", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        textBoxCodigoCliente.BackColor = Color.White;
                        textBoxNombreCliente.BackColor = Color.White;
                        textBoxRFCCliente.BackColor = Color.White;
                        textBoxDireccionCliente.BackColor = Color.White;
                        textBoxCiudadCliente.BackColor = Color.White;
                        textBoxTelefonoCliente.BackColor = Color.White;
                        Cargar();
                    }                
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ClassDB.conn.Close();
                }
            }
        }

        //Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (textBoxCodigoCliente.Text == "")
            {
                MessageBox.Show
                   ("Introduzca el código que desea eliminar.", "Advertencia",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBoxCodigoCliente.Focus();

            }
            else
            {
                try
                {
                    string eliminar = "DELETE FROM cliente WHERE codigo_cli=" + textBoxCodigoCliente.Text;

                    res = DB.ABM(eliminar);

                    if (res == 1)
                    {
                        MessageBox.Show
                            ("Se ha eliminado el registro correctamente.", "Bajas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Actualizar la tabla.
                        Cargar();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    ClassDB.conn.Close();
                }
            }
        }
        //Fin operaciones CRUD. ###############################################################

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            
            cmbNombreCliente.Text = "";

            textBoxCodigoCliente.Clear();
            textBoxNombreCliente.Clear();
            textBoxRFCCliente.Clear();
            textBoxDireccionCliente.Clear();
            textBoxCiudadCliente.Clear();
            textBoxTelefonoCliente.Clear();

            textBoxCodigoCliente.Focus();
            textBoxCodigoCliente.Enabled = true;

            textBoxCodigoCliente.BackColor = Color.White;
            textBoxNombreCliente.BackColor = Color.White;
            textBoxRFCCliente.BackColor = Color.White;
            textBoxDireccionCliente.BackColor = Color.White;
            textBoxCiudadCliente.BackColor = Color.White;
            textBoxTelefonoCliente.BackColor = Color.White;

            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Seguro que desea salir?", "Advertencia", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                Dispose();                
            }
            else
            {
                textBoxCodigoCliente.Focus();
            }
           
        }

        //Validaciones ########################.
        private void textBoxCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Enter ||
                (e.KeyChar == 46) || (e.KeyChar == 8) )
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Código no válido. Sólo se permiten números", "Nota",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
        }

        private void textBoxNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Enter ||
               (e.KeyChar == 46) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Sólo se permiten letras", "Nota",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
        }

        private void textBoxTelefonoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Enter ||
               (e.KeyChar == 46) || (e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Sólo se permiten números", "Nota",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
            }
        }

        private void textBoxCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                btnBuscar.Focus();
            }
        }

        private void textBoxNombreCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                textBoxRFCCliente.Focus();
            }
        }

        private void textBoxRFCCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                textBoxDireccionCliente.Focus();
            }
        }

        private void textBoxDireccionCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                textBoxCiudadCliente.Focus();
            }
        }

        private void textBoxCiudadCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                textBoxTelefonoCliente.Focus();
            }
        }

        private void textBoxTelefonoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                btnBuscar.Focus();
            }
        }
        //Fin validaciones ########################.

        //Actualizar la tabla automaticamente.
        private void Cargar()
        {
            using (SqlConnection conn = new SqlConnection
                ("Initial Catalog = Proyectos; Data Source = Octavio-PC\\SQLEXPRESS; Integrated Security = SSPI;"))
            {
                DataTable dt = new DataTable();
                string query = "SELECT * FROM cliente";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = System.DateTime.Now.ToString();
        }

        private void CRUD_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        //ComboBox
        private void comboBox1_Click(object sender, EventArgs e)
        {
            cmbNombreCliente.Items.Clear();

            try
            {
                DataSet ds = new DataSet();
                //ds = DB.buscarCliente("SELECT nombre_cli from cliente", "Cliente");
                ds = db.buscarCliente("SELECT nombre_cli from cliente", "Cliente");

                foreach (DataRow row in ds.Tables["Cliente"].Rows)
                {
                    cmbNombreCliente.Items.Add(row["nombre_cli"].ToString());
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ClassDB.conn.Close();
            }
        }

        //Seleccionar cliente por nombre y llenar los textBox correspondientes.
        private void cmbNombreCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = db.buscarCliente("SELECT * FROM cliente WHERE nombre_cli ='" + cmbNombreCliente.Text +
                    " ' ", "cliente");

                foreach (DataRow row in ds.Tables["cliente"].Rows)
                {
                    textBoxCodigoCliente.Text = row["codigo_cli"].ToString();
                    textBoxNombreCliente.Text = row["nombre_cli"].ToString();
                    textBoxRFCCliente.Text = row["RFC_cli"].ToString();
                    textBoxDireccionCliente.Text = row["direccion_cli"].ToString();
                    textBoxCiudadCliente.Text = row["ciudad_cli"].ToString();
                    textBoxTelefonoCliente.Text = row["telefono_cli"].ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ClassDB.conn.Close();
            }
        }
    }
}
