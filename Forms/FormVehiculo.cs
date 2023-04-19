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
    public partial class FormVehiculo : Form
    {
        //instancia de la clase para validar solo letras y numeros
        Validacion v = new Validacion();
        //Conecta con la BD
        private SqlConnection connect = new SqlConnection("Server=(Local);Database=SegurosIrapuato;Trusted_Connection=True;");
        //Instancia clases del proyecto
        conexion con = new conexion();
        public FormVehiculo()
        {
            InitializeComponent();
            //Carga en el combobox los ID's de los Clientes registrados
            con.cmbAuto(cmbIDC);
            //limitar el numero de caracteres que permite el textbox 
            txtIDV.MaxLength = 5;
            txtMarca.MaxLength = 20;
            txtModelo.MaxLength = 20;
            txtAño.MaxLength = 4;
            txtKilom.MaxLength = 7;
            txtPlaca.MaxLength = 20;
            //Impide que se pueda escribir en el combobox
            this.cmbIDC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //quita la fila extra del dgv
            bgvVehiculos.AllowUserToAddRows = false;

        }

        private void txtIDV_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo permite escribir numeros
            v.textbox2(e);
        }

        private void txtIDC_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo permite escribir numeros
            v.textbox2(e);
        }

        private void txtAño_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo permite escribir numeros
            v.textbox2(e);
        }

        private void txtKilom_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo permite escribir numeros
            v.textbox2(e);
        }

        private void bgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //asigna en que celda se colocara el dato del textbox
            DataGridViewRow Fila = bgvVehiculos.Rows[e.RowIndex];
            txtIDV.Text = Convert.ToString(Fila.Cells[0].Value);
            txtPlaca.Text = Convert.ToString(Fila.Cells[1].Value);
            txtMarca.Text = Convert.ToString(Fila.Cells[2].Value);
            txtModelo.Text = Convert.ToString(Fila.Cells[3].Value);
            txtAño.Text = Convert.ToString(Fila.Cells[4].Value);
            txtKilom.Text = Convert.ToString(Fila.Cells[5].Value);
            cmbE.Text = Convert.ToString(Fila.Cells[6].Value);
            cmbIDC.Text = Convert.ToString(Fila.Cells[7].Value);
            //busca los Accidentes que esten registrados con el ID de ese Auto y los coloca en el combobox
            con.cmbAcc(cmbAccident,txtIDV.Text);
        }

        private void FormVehiculo_Load(object sender, EventArgs e)
        {
            //carga datos en el data grid view
            bgvVehiculos.DataSource = con.MostrarVehiculo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //verifica que todas las casillas esten llenas
            if (string.IsNullOrEmpty(txtIDV.Text) || string.IsNullOrEmpty(txtMarca.Text) || string.IsNullOrEmpty(txtModelo.Text) || string.IsNullOrEmpty(txtAño.Text) || string.IsNullOrEmpty(txtKilom.Text) || string.IsNullOrEmpty(txtPlaca.Text) || string.IsNullOrEmpty(cmbE.Text) || string.IsNullOrEmpty(cmbIDC.Text))
            {

                MessageBox.Show("Debe completar la informacion");

                return;
            }

            //Verifica que el ID que se esta ingresando no se encuentre ya registrado
            SqlCommand comando = new SqlCommand("Select ID_A from Autos where ID_A = @ID", connect);
            comando.Parameters.AddWithValue("@ID", txtIDV.Text);
            connect.Open();
            SqlDataReader registro = comando.ExecuteReader();
            if (registro.Read())
            {
                connect.Close();
                MessageBox.Show("ID no valida");
                return;
            }
            connect.Close();

            //Calcula la Poliza y se le da valor a taza fija
            int taza = 12000;
            int poliza;
            if (cmbE.Text == "Bueno")
            {
                poliza = 12000;
            }
            else if (cmbE.Text == "Regular")
            {
                poliza = 12600;
            }
            else if (cmbE.Text=="Malo")
            {
                poliza = 13200;
            }
            else
            {
                MessageBox.Show("Estado no valido seleccione otro");
                cmbE.Text = "";
                return;
                
            }

            //Instrucciones para realizar en insert de nuevos datos
            //funcion sql para insertar en los campos los valores los valores siguientes
            string query = "INSERT INTO Autos (ID_A,Marca,Modelo,Año,Kilometraje,Placas,Tazaf,Estado,C_ID,Poliza) VALUES(@id,@marca,@modelo,@año,@kilometraje,@placas,@Tazaf,@Estado,@C_ID,@Poliza)";
            //abre coneccion
            connect.Open();
            //crea comando para que el programa sepa de donde tomara los valores de la funcion insert
            SqlCommand cmd = new SqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@id", txtIDV.Text);
            cmd.Parameters.AddWithValue("@marca", txtMarca.Text);
            cmd.Parameters.AddWithValue("@modelo", txtModelo.Text);
            cmd.Parameters.AddWithValue("@año", txtAño.Text);
            cmd.Parameters.AddWithValue("@kilometraje", txtKilom.Text);
            cmd.Parameters.AddWithValue("@placas", txtPlaca.Text);
            cmd.Parameters.AddWithValue("@Tazaf", taza.ToString());
            cmd.Parameters.AddWithValue("@Estado", cmbE.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@C_ID", cmbIDC.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@Poliza",poliza.ToString());
            cmd.ExecuteNonQuery();
            //cierra coneccion
            connect.Close();
            //confirma que los datos se agregaron
            MessageBox.Show("Datos Insertados");
            //muestra la tabla con el nuevo datos o datos
            bgvVehiculos.DataSource = con.MostrarVehiculo();
  
            //limpia los datos 
            txtIDV.Text = null;
            txtMarca.Text = null;
            txtModelo.Text = null;
            txtAño.Text = null;
            txtKilom.Text = null;
            txtPlaca.Text = null;
            cmbE.Text = null;
            cmbIDC.Text = null;
            cmbAccident.Text = null;
         

        }

        private void cmbIDC_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //verifica que todas las casillas esten llenas
            if (string.IsNullOrEmpty(txtIDV.Text) || string.IsNullOrEmpty(txtMarca.Text) || string.IsNullOrEmpty(txtModelo.Text) || string.IsNullOrEmpty(txtAño.Text) || string.IsNullOrEmpty(txtKilom.Text) || string.IsNullOrEmpty(txtPlaca.Text) || string.IsNullOrEmpty(cmbE.Text) || string.IsNullOrEmpty(cmbIDC.Text))
            {

                MessageBox.Show("Debe completar la informacion");

                return;
            }

            //Vuelve a calcula la Poliza y se le da valor a taza fija
            int taza = 12000;
            int poliza;
            if (cmbE.Text == "Bueno")
            {
                poliza = 12000;
            }
            else if (cmbE.Text == "Regular")
            {
                poliza = 12600;
            }
            else if (cmbE.Text == "Malo")
            {
                poliza = 13200;
            }
            else
            {
                MessageBox.Show("Estado no valido seleccione otro");
                cmbE.Text = "";
                return;

            }

            //instruccion para actualizar registro
            if (con.ActualizarV(txtIDV.Text, txtMarca.Text, txtModelo.Text, txtAño.Text, txtKilom.Text, txtPlaca.Text,taza.ToString(), cmbE.Text, poliza.ToString(), cmbIDC.Text))
            {
                MessageBox.Show("Datos actualizados");
                bgvVehiculos.DataSource = con.MostrarVehiculo();
            }
            else MessageBox.Show("No se han actualizado");

            //limpia los datos 
            txtIDV.Text = null;
            txtMarca.Text = null;
            txtModelo.Text = null;
            txtAño.Text = null;
            txtKilom.Text = null;
            txtPlaca.Text = null;
            cmbE.Text = null;
            cmbIDC.Text = null;
            cmbAccident.Text = null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //verifica que el textbox del ID no este vacio
            if (string.IsNullOrEmpty(txtIDV.Text))
            {

                MessageBox.Show("Ingrese ID de Auto a eliminar");

                return;
            }

            //Elimina los Sinietros que tengan el ID de este vehiculo
            if (con.EliminarTS(txtIDV.Text))
            {
                MessageBox.Show("Siniestros del auto eliminados");
            }
            else MessageBox.Show("No se han eliminado");

            //Elimina el vehiculo
            if (con.EliminarV(txtIDV.Text))
            {
                MessageBox.Show("Datos eliminados");
                bgvVehiculos.DataSource = con.MostrarVehiculo();
            }
            else MessageBox.Show("No se han eliminado");

            //limpia los datos 
            txtIDV.Text = null;
            txtMarca.Text = null;
            txtModelo.Text = null;
            txtAño.Text = null;
            txtKilom.Text = null;
            txtPlaca.Text = null;
            cmbE.Text = null;
            cmbIDC.Text = null;
            cmbAccident.Text = null;
        }

        private void btnSeach_Click(object sender, EventArgs e)
        {
            //instruccion para buscar un registro con determinada ID
            try
            {
                bgvVehiculos.DataSource = con.BuscarV(txtIDV.Text);
            }
            catch
            {
                return;
            }
            con.cmbAcc(cmbAccident, txtIDV.Text);
        }

        private void cmbAccident_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            //solo permite escribir letras
            v.textbox1(e);
        }
    }
}
