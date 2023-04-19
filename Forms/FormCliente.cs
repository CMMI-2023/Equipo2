using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Seguros_Irapuato.Forms
{
    public partial class FormCliente : Form
    {
        //instancia de la clase para validar solo letras y numeros
        Validacion v = new Validacion();
        //Conecta con la BD
        private SqlConnection connect = new SqlConnection("Server=(Local);Database=SegurosIrapuato;Trusted_Connection=True;");
        //Instancia clases del proyecto
        conexion con = new conexion();
        public FormCliente()
        {
            InitializeComponent();
            //Carga en el combobox los ID's de los ajustadores registrados
            con.cmbAj(cmbAj);
            //limitar el numero de caracteres que permite el textbox 
            txtID.MaxLength = 5;
            txtNombre.MaxLength = 30;
            txtDomicilio.MaxLength = 50;
            txtTelefono.MaxLength = 10;
            //Impide que se pueda escribir en el combobox
            this.cmbAj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //quita la fila extra del dgv
            dgvClientes.AllowUserToAddRows = false;

        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo permite escribir numeros
            v.textbox2(e);
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo permite escribir numeros
            v.textbox2(e);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo permite escribir letras
            v.textbox1(e);
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //asigna en que celda se colocara el dato del textbox
            DataGridViewRow Fila = dgvClientes.Rows[e.RowIndex];
            txtID.Text = Convert.ToString(Fila.Cells[0].Value);
            txtNombre.Text = Convert.ToString(Fila.Cells[1].Value);
            txtDomicilio.Text = Convert.ToString(Fila.Cells[2].Value);
            txtTelefono.Text = Convert.ToString(Fila.Cells[3].Value);
            //busca los Autos que esten registrados con el ID de ese Cliente y los coloca en el combobox
            con.cmbC(cmbAutos,txtID.Text);

        }

        private void FormCliente_Load(object sender, EventArgs e)
        {
            //carga datos en el data grid view
            dgvClientes.DataSource = con.MostrarCliente();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //verifica que todas las casillas esten llenas
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrEmpty(txtDomicilio.Text) || string.IsNullOrEmpty(cmbAj.Text) || cmbAj.Text == "--Ajustadores--")
            {

                MessageBox.Show("Debe completar la informacion");

                return;
            }

            //Verifica que el ID que se esta ingresando no se encuentre ya registrado
            SqlCommand comando = new SqlCommand("Select ID_C from Cliente where ID_C = @ID", connect);
            comando.Parameters.AddWithValue("@ID", txtID.Text);
            connect.Open();
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                connect.Close();
                MessageBox.Show("ID no valida");
                return;
            }
            connect.Close();

            //Instrucciones para realizar en insert de nuevos datos
            //funcion sql para insertar en los campos los valores los valores siguientes
            string query = "INSERT INTO Cliente (ID_C,Nombre,Direccion,Telefono,Aj_ID) VALUES(@id,@nombre,@direccion,@telefono,@Aj_ID)";
            //abre coneccion
            connect.Open();
            //crea comando para que el programa sepa de donde tomara los valores de la funcion insert
            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@id", txtID.Text);
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd.Parameters.AddWithValue("@direccion", txtDomicilio.Text);
            cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
            cmd.Parameters.AddWithValue("@Aj_ID", cmbAj.Text);
            cmd.ExecuteNonQuery();
            //cierra coneccion
            connect.Close();
            //confirma que los datos se agregaron
            MessageBox.Show("Datos Insertados");
            //muestra la tabla con el nuevo datos o datos
            dgvClientes.DataSource = con.MostrarCliente();

            //limpia los datos 
            txtNombre.Text = null;
            txtID.Text = null;
            txtDomicilio.Text = null;
            txtTelefono.Text = null;
            cmbAj.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //verifica que todas las casillas esten llenas
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtTelefono.Text) || string.IsNullOrEmpty(txtDomicilio.Text) || string.IsNullOrEmpty(cmbAj.Text) || cmbAj.Text == "--Ajustadores--")
            {

                MessageBox.Show("Debe completar la informacion");

                return;
            }
            
            //instruccion para actualizar registro
            if (con.ActualizarC(txtID.Text, txtNombre.Text, txtDomicilio.Text,txtTelefono.Text))
            {
                MessageBox.Show("Datos actualizados");
                dgvClientes.DataSource = con.MostrarCliente();
            }
            else MessageBox.Show("No se han actualizado");

            //limpia los datos 
            txtNombre.Text = null;
            txtID.Text = null;
            txtDomicilio.Text = null;
            txtTelefono.Text = null;
            cmbAj.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //verifica que el textbox del ID no este vacio
            if (string.IsNullOrEmpty(txtID.Text))
            {

                MessageBox.Show("Inglese ID de cliente a eliminar");

                return;
            }

            //Intrucciones para obtener en una cadena los ID´s de los siniestros relacionados con los autos de este cliente
            string[] resultados = null;                
               resultados = con.valores(txtID.Text);

               string ids = "";
               for (int i = 0; i < resultados.Length; i++)
               {
                   if (ids == "")
                   {
                       ids = resultados[i].ToString();
                   }
                  else
                  {
                      ids = ids + "," + resultados[i].ToString();
                  }
               }
               Console.WriteLine(ids);


            //Instruccion para eliminar los siniestros de los autos del cliente
             if (con.EliminarTAS(ids))
             {
                 MessageBox.Show("Siniestros del cliente eliminados");
             }
            else MessageBox.Show("No se han eliminado");

             //Instruccion para eliminar los autos del cliente
               if (con.EliminarTV(txtID.Text))
               {
                   MessageBox.Show("Autos del cliente eliminados");
               }
               else MessageBox.Show("No se han eliminado");
            
            //Instucciones para eliminar clientes
            try
            {
                if (con.EliminarC(txtID.Text))
                {
                    MessageBox.Show("Datos eliminados");
                    dgvClientes.DataSource = con.MostrarCliente();
                }
                else MessageBox.Show("No se han eliminado");

                //limpia los datos 
                txtNombre.Text = null;
                txtID.Text = null;
                txtDomicilio.Text = null;
                txtTelefono.Text = null;
                cmbAj.Text = "";
            }
            catch
            {
                //limpia los datos 
                txtNombre.Text = null;
                txtID.Text = null;
                txtDomicilio.Text = null;
                txtTelefono.Text = null;
                cmbAj.Text = "";
            }
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            //instruccion para buscar un registro con determinada ID
            try
            {
                dgvClientes.DataSource = con.BuscarC(txtID.Text);
            }
            catch
            {
                return;
            }
            con.cmbC(cmbAutos, txtID.Text);
        }

        private void cmbAutos_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbAj_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
