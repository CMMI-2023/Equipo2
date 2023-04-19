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
    public partial class FormAjustador : Form
    {
        //instancia de la clase para validar solo letras y numeros
        Validacion v = new Validacion();
        //Conecta con la BD
        private SqlConnection connect = new SqlConnection("Server=(Local);Database=SegurosIrapuato;Trusted_Connection=True;");
        //Instancia clases del proyecto
        conexion con = new conexion();

        public FormAjustador()
        {
            InitializeComponent();
            //limitar el numero de caracteres que permite el textbox 
            txtID.MaxLength = 5;
            txtNombre.MaxLength = 30;
            //quita la fila extra del dgv
            dgvAjustadores.AllowUserToAddRows = false;
        }

        
        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo permite escribir numeros
            v.textbox2(e);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo permite escribir letras
            v.textbox1(e);
        }

        private void FormAjustador_Load(object sender, EventArgs e)
        {
            //carga datos en el data grid view
            dgvAjustadores.DataSource = con.MostrarAj();
        }

        private void dgvAjustadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
                //asigna en que celda se colocara el dato del textbox al dar clic en un elemento del dgv
                DataGridViewRow Fila = dgvAjustadores.Rows[e.RowIndex];
                txtID.Text = Convert.ToString(Fila.Cells[0].Value);
                txtNombre.Text = Convert.ToString(Fila.Cells[1].Value);
                //busca los clientes que esten registrados con el ID de ese ajustador y los coloca en el combobox
                con.cmbaj(cmbClientes, txtID.Text);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //verifica que todas las casillas esten llenas
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtNombre.Text))
            {

                MessageBox.Show("Debe completar la informacion");

                return;
            }

            //Verifica que el ID que se esta ingresando no se encuentre ya registrado
            SqlCommand comando = new SqlCommand("Select ID_Aj from Ajustador where ID_Aj = @ID", connect);
            comando.Parameters.AddWithValue("@ID", txtID.Text);
            connect.Open();
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                connect.Close();
                MessageBox.Show("ID no valida");
                return;
            }

            //Instrucciones para realizar en insert de nuevos datos
            connect.Close();
            //funcion sql para insertar en los campos los valores los valores siguientes
            string query = "INSERT INTO Ajustador (ID_Aj,Nombre) VALUES(@id,@nombre)";
            //abre coneccion
            connect.Open();
            //crea comando para que el programa sepa de donde tomara los valores de la funcion insert
            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@id",Convert.ToInt32(txtID.Text));
            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
            cmd.ExecuteNonQuery();
            //cierra coneccion
            connect.Close();
            //confirma que los datos se agregaron
            MessageBox.Show("Datos Insertados");
            //muestra la tabla con el nuevo datos o datos
            dgvAjustadores.DataSource = con.MostrarAj();
 
            //limpia los datos 
            txtNombre.Text = null;
            txtID.Text = null;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //verifica que todas las casillas esten llenas
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtNombre.Text))
            {

                MessageBox.Show("Debe completar la informacion");

                return;
            }
            
            //Instrucciones para editar el registro
            if (con.Actualizaraj(txtID.Text, txtNombre.Text))
            {
                MessageBox.Show("Datos actualizados");
                dgvAjustadores.DataSource = con.MostrarAj();
            }
            else MessageBox.Show("No se han actualizado");

            //limpia los datos 
            txtNombre.Text = null;
            txtID.Text = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Verifica que el campo ID no este vacion para tener la referencia de que eliminar
            if (string.IsNullOrEmpty(txtID.Text))
            {

                MessageBox.Show("Ingrese ID del Ajustador a eliminar");

                return;
            }

            //Verifica que el ID que se esta ingresando no se encuentre ya registrado
            SqlCommand comando = new SqlCommand("Select Aj_ID from Cliente where Aj_ID = @ID", connect);
            comando.Parameters.AddWithValue("@ID", txtID.Text);
            connect.Open();
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                connect.Close();
                MessageBox.Show("Cambie ajustador de los clientes y siniestros antes de continuar");
                return;
            }

            try
            {
                //Instrucciones para eliminar ajustadores siempre y cuando ya no tengan otros registros dependientes de este
                if (con.Eliminaraj(txtID.Text))
                {
                    MessageBox.Show("Datos eliminados");
                    dgvAjustadores.DataSource = con.MostrarAj();
                }
                else MessageBox.Show("No se han eliminado");
            }
            catch
            {
                txtNombre.Text = null;
                txtID.Text = null;
                
            }

            //limpia los datos 
            txtNombre.Text = null;
            txtID.Text = null;
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            //instruccion para buscar un registro con determinada ID
            try
            {
                dgvAjustadores.DataSource = con.BuscarAj(txtID.Text);
            } 
            catch
            {
                return;
            }
            con.cmbaj(cmbClientes, txtID.Text);
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
