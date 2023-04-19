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
    public partial class FormSiniestro : Form
    {
        //instancia de la clase para validar solo letras y numeros
        Validacion v = new Validacion();
        //Conecta con la BD
        private SqlConnection connect = new SqlConnection("Server=(Local);Database=SegurosIrapuato;Trusted_Connection=True;");
        //Instancia clases del proyecto
        conexion con = new conexion();

        public FormSiniestro()
        {
            InitializeComponent();
            //Carga en el combobox los ID's de los Autos registrados
            con.cmbCV(cmbAuto);
            //Carga en el combobox los ID's de los ajustadores registrados
            con.cmbAj(cmbAjustador);
            //limitar el numero de caracteres que permite el textbox 
            txtID.MaxLength = 5;
            txtCosto.MaxLength = 7;
            //Impide que se pueda escribir en el combobox
            this.cmbAjustador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAuto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdNestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //quita la fila extra del dgv
            dgvAccidentes.AllowUserToAddRows = false;

        }

        private void FormSiniestro_Load(object sender, EventArgs e)
        {
            //carga datos en el data grid view
            dgvAccidentes.DataSource = con.MostrarSiniestro();
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo permite escribir numeros
            v.textbox2(e);
        }

        private void txtIDA_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo permite escribir numeros
            v.textbox2(e);
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo permite escribir numeros
            v.textbox2(e);
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo permite escribir numeros
            v.textbox2(e);
        }

        private void txtIDAj_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo permite escribir numeros
            v.textbox2(e);
        }

        private void dgvAccidentes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //asigna en que celda se colocara el dato del textbox
            DataGridViewRow Fila = dgvAccidentes.Rows[e.RowIndex];
            txtID.Text = Convert.ToString(Fila.Cells[0].Value);
            txtCosto.Text = Convert.ToString(Fila.Cells[1].Value);
            dtpFecha.Text = Convert.ToString(Fila.Cells[2].Value);
            cmdNestado.Text = Convert.ToString(Fila.Cells[3].Value);
            cmbAuto.Text = Convert.ToString(Fila.Cells[4].Value);
            cmbAjustador.Text = Convert.ToString(Fila.Cells[5].Value);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //verifica que todas las casillas esten llenas
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtCosto.Text) || string.IsNullOrEmpty(dtpFecha.Text) || string.IsNullOrEmpty(cmdNestado.Text) || string.IsNullOrEmpty(cmbAuto.Text) || string.IsNullOrEmpty(cmbAjustador.Text))
            {

                MessageBox.Show("Debe completar la informacion");

                return;
            }

            //Verifica que el ID que se esta ingresando no se encuentre ya registrado
            SqlCommand comando = new SqlCommand("Select ID_S from Siniestro where ID_S = @ID", connect);
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

            //Calcula nueva poliza a partir del nuevo estado 
            int poliza;
            if (cmdNestado.Text == "Bueno")
            {
                poliza = 12000;
            }
            else if (cmdNestado.Text == "Regular")
            {
                poliza = 12600;
            }
            else if (cmdNestado.Text == "Malo")
            {
                poliza = 13200;
            }
            else
            {
                MessageBox.Show("Estado no valido seleccione otro");
                cmdNestado.Text = "";
                return;

            }

            //Instrucciones para realizar en insert de nuevos datos
            //funcion sql para insertar en los campos los valores los valores siguientes
            string query = "INSERT INTO Siniestro (ID_S,Costo,Fecha,N_Estado,A_ID,Aj_ID) VALUES(@id,@costo,@fecha,@estado,@idauto,@idajustador)";
            //abre coneccion
            connect.Open();
            //crea comando para que el programa sepa de donde tomara los valores de la funcion insert
            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@id", txtID.Text);
            cmd.Parameters.AddWithValue("@costo", txtCosto.Text);
            cmd.Parameters.AddWithValue("@fecha", dtpFecha.Text);
            cmd.Parameters.AddWithValue("@estado", cmdNestado.Text);
            cmd.Parameters.AddWithValue("@idauto", cmbAuto.Text);
            cmd.Parameters.AddWithValue("@idajustador", cmbAjustador.Text);
            cmd.ExecuteNonQuery();
            //cierra coneccion
            connect.Close();
            //confirma que los datos se agregaron
            MessageBox.Show("Datos Insertados");
            //muestra la tabla con el nuevo datos o datos
            dgvAccidentes.DataSource = con.MostrarSiniestro();

            //Actualiza la poliza del auto
            if (con.Actualizarpoliza(cmdNestado.Text, poliza.ToString(), cmbAuto.Text))
            {
                MessageBox.Show("Poliza actualizada");
                dgvAccidentes.DataSource = con.MostrarSiniestro();
            }
            else MessageBox.Show("No se han actualizado la poliza");

            //limpia los datos 
            txtID.Text = null;
            txtCosto.Text = null;
            dtpFecha.Text = null;
            cmdNestado.Text = null;
            cmbAuto.Text = null;
            cmbAjustador.Text = null;


        }

        private void btnEdit_Click(object sender, EventArgs e)

        {
            //verifica que todas las casillas esten llenas
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtCosto.Text) || string.IsNullOrEmpty(dtpFecha.Text) || string.IsNullOrEmpty(cmdNestado.Text) || string.IsNullOrEmpty(cmbAuto.Text) || string.IsNullOrEmpty(cmbAjustador.Text))
            {

                MessageBox.Show("Debe completar la informacion");

                return;
            }

            //Calcula nueva poliza a partir del nuevo estado 
            int poliza;
            if (cmdNestado.Text == "Bueno")
            {
                poliza = 12000;
            }
            else if (cmdNestado.Text == "Regular")
            {
                poliza = 12600;
            }
            else if (cmdNestado.Text == "Malo")
            {
                poliza = 13200;
            }
            else
            {
                MessageBox.Show("Estado no valido seleccione otro");
                cmdNestado.Text = "";
                return;
            }

            //Actualiza los datos del siniestro
            if (con.ActualizarS(txtID.Text, txtCosto.Text, dtpFecha.Text, cmdNestado.Text, cmbAuto.Text, cmbAjustador.Text))
            {
                MessageBox.Show("Datos actualizados");
                dgvAccidentes.DataSource = con.MostrarSiniestro();
            }
            else MessageBox.Show("No se han actualizado");

            //Actualiza la poliza del auto
            if (con.Actualizarpoliza(cmdNestado.Text, poliza.ToString(), cmbAuto.Text))
            {
                MessageBox.Show("Poliza actualizada");
                dgvAccidentes.DataSource = con.MostrarSiniestro();
            }
            else MessageBox.Show("No se han actualizado la poliza");

            //limpia los datos 
            txtID.Text = null;
            txtCosto.Text = null;
            dtpFecha.Text = null;
            cmdNestado.Text = null;
            cmbAuto.Text = null;
            cmbAjustador.Text = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //verifica que el textbox del ID no este vacio
            if (string.IsNullOrEmpty(txtID.Text))
            {

                MessageBox.Show("Ingrese ID del siniestro a eliminar");

                return;
            }

            //Elimina registro
            if (con.EliminarS(txtID.Text))
            {
                MessageBox.Show("Datos eliminados");
                dgvAccidentes.DataSource = con.MostrarSiniestro();
            }
            else MessageBox.Show("No se han eliminado");

            //limpia los datos 
            txtID.Text = null;
            txtCosto.Text = null;
            dtpFecha.Text = null;
            cmdNestado.Text = null;
            cmbAuto.Text = null;
            cmbAjustador.Text = null;
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            //instruccion para buscar un registro con determinada ID
            try
            {
                dgvAccidentes.DataSource = con.BuscarS(txtID.Text);
            }
            catch
            {
                return;
            }
        }
    }
}
