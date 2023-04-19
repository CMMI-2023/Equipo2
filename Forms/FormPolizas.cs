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
    public partial class FormPolizas : Form
    {
        //instancia de la clase para validar solo letras y numeros
        Validacion v = new Validacion();
        //Conecta con la BD
        private SqlConnection connect = new SqlConnection("Server=(Local);Database=SegurosIrapuato;Trusted_Connection=True;");
        //Instancia clases del proyecto
        conexion con = new conexion();
        public FormPolizas()
        {
            InitializeComponent();
            //limitar el numero de caracteres que permite el textbox 
            txtIDA.MaxLength = 5;
            //quita la fila extra del dgv
            dgvVehiculos.AllowUserToAddRows = false;
        }

        private void FormPolizas_Load(object sender, EventArgs e)
        {
            //carga datos en el data grid view
            dgvVehiculos.DataSource = con.MostrarPoliza2();
        }

        private void txtIDA_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo permite escribir numeros
            v.textbox2(e);
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            //instruccion para buscar un registro con determinada ID
            try
            {
                dgvVehiculos.DataSource = con.BuscarpA(txtIDA.Text);
            }
            catch
            {
                return;
            }


        }

        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //asigna en que celda se colocara el dato del textbox
            DataGridViewRow Fila = dgvVehiculos.Rows[e.RowIndex];
            txtIDA.Text = Convert.ToString(Fila.Cells[0].Value);
            txtEstado.Text = Convert.ToString(Fila.Cells[1].Value);
            txtTasa.Text = Convert.ToString(Fila.Cells[2].Value);
            txtTotal.Text = Convert.ToString(Fila.Cells[3].Value);

            //Busca los siniestros con el ID del Auto, los cuenta y coloca el numero en el txtNaccidentes 
            SqlCommand comando = new SqlCommand("Select Count(*) from Siniestro where A_ID = @ID",connect);
            comando.Parameters.AddWithValue("@ID", txtIDA.Text);
            connect.Open();
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                txtNaccidentes.Text = Convert.ToString(registro[0]);
            }
            
            connect.Close();
        }

        private void btnhist_Click(object sender, EventArgs e)
        {
            //coloca los accidentes del auto seleccionado en el Dgv
            dgvVehiculos.DataSource = con.BuscarP(txtIDA.Text);
            lblH.Text = "Historial Auto";
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            //vuelve a mostrar todas las polizas
            lblH.Text = "Polizas";
            dgvVehiculos.DataSource = con.MostrarPoliza2();
            txtIDA.Text = null;
            txtEstado.Text = null;
            txtNaccidentes.Text = null;
            txtTasa.Text = null;
            txtTotal.Text = null;
           
        }
    }
}
