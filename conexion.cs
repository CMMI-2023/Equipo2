using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Seguros_Irapuato
{
    class conexion
    {
        //coneccion a la Base de datos
        private SqlConnection connect = new SqlConnection("Server=(Local);Database=SegurosIrapuato; Trusted_Connection=True;");

        public DataTable MostrarAj()
        {
            //Abre coneccion
            connect.Open();
            //Comando para seleccionar todos los datos de la tabla
            SqlCommand cmd = new SqlCommand("select ID_Aj as ID, Nombre from Ajustador", connect);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            //declara la tabla con una variable
            DataTable table = new DataTable();
            ad.Fill(table);
            //cierra coneccion
            connect.Close();
            //regresa tabla
            return table;

        }

        public DataTable MostrarCliente()
        {
            //Abre coneccion
            connect.Open();
            //Comando para seleccionar todos los datos de la tabla
            SqlCommand cmd = new SqlCommand("Select ID_C as ID,Nombre,Direccion,Telefono,Aj_ID as Ajustador from Cliente", connect);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            //declara la tabla con una variable
            DataTable table = new DataTable();
            ad.Fill(table);
            //cierra coneccion
            connect.Close();
            //regresa tabla
            return table;

        }
        public DataTable MostrarSiniestro()
        {
            //Abre coneccion
            connect.Open();
            //Comando para seleccionar todos los datos de la tabla
            SqlCommand cmd = new SqlCommand("Select ID_S as ID,Costo,Fecha,N_Estado as Estado,A_ID as ID_Auto ,Aj_ID as ID_Ajustador from Siniestro", connect);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            //declara la tabla con una variable
            DataTable table = new DataTable();
            ad.Fill(table);
            //cierra coneccion
            connect.Close();
            //regresa tabla
            return table;

        }

        public DataTable MostrarVehiculo()
        {
            //Abre coneccion
            connect.Open();
            //Comando para seleccionar todos los datos de la tabla
            SqlCommand cmd = new SqlCommand("Select ID_A as ID,Placas,Marca,Modelo,Año,Kilometraje,Estado,C_ID as Cliente,Poliza from Autos", connect);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            //declara la tabla con una variable
            DataTable table = new DataTable();
            ad.Fill(table);
            //cierra coneccion
            connect.Close();
            //regresa tabla
            return table;

        }

        public DataTable MostrarPoliza2()
        {
            //Abre coneccion
            connect.Open();
            //Comando para seleccionar todos los datos de la tabla
            SqlCommand cmd = new SqlCommand("Select ID_A as ID_Auto,Estado,Tazaf as Taza_fija,Poliza from Autos", connect);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            //declara la tabla con una variable
            DataTable table = new DataTable();
            ad.Fill(table);
            //cierra coneccion
            connect.Close();
            //regresa tabla
            return table;

        }

        public bool Actualizaraj(string ID_Aj, string Nombre)
        {
            //Abre coneccion
            connect.Open();
            //toma los campos que actualizara y asigna la nueva cadena que recivira
            SqlCommand cmd = new SqlCommand(string.Format("update Ajustador set Nombre = '{0}' where ID_Aj = {1}", new string[] { Nombre, ID_Aj }), connect);
            int FilasAfectadas = cmd.ExecuteNonQuery();
            //cierra conexion
            connect.Close();
            //condicion para asegurar que hubo un cambio
            if (FilasAfectadas > 0) return true;
            else return false;

        }
        public bool ActualizarC(string ID_C, string Nombre, string Direccion, string Telefono)
        {
            //Abre coneccion
            connect.Open();
            //toma los campos que actualizara y asigna la nueva cadena que recivira
            SqlCommand cmd = new SqlCommand(string.Format("update Cliente set Nombre = '{0}', Direccion = '{1}', Telefono = '{2}' where ID_C = {3}", new string[] { Nombre, Direccion, Telefono, ID_C }), connect);
            int FilasAfectadas = cmd.ExecuteNonQuery();
            //cierra conexion
            connect.Close();
            //condicion para asegurar que hubo un cambio
            if (FilasAfectadas > 0) return true;
            else return false;

        }
        public bool ActualizarV(string ID_A, string Marca, string Modelo, string Año, string Kilometraje, string Placas, string Tazaf, string Estado, string Poliza, string C_ID)
        {
            //Abre coneccion
            connect.Open();
            //toma los campos que actualizara y asigna la nueva cadena que recivira
            SqlCommand cmd = new SqlCommand(string.Format("update Autos set Marca = '{0}', Modelo = '{1}', Año = '{2}', Kilometraje = '{3}', Placas = '{4}', Tazaf = '{5}', Estado = '{6}', C_ID = '{7}' , Poliza='{8}' where ID_A = {9}", new string[] { Marca, Modelo, Año, Kilometraje, Placas, Tazaf, Estado, C_ID, Poliza, ID_A }), connect);
            int FilasAfectadas = cmd.ExecuteNonQuery();
            //cierra conexion
            connect.Close();
            //condicion para asegurar que hubo un cambio
            if (FilasAfectadas > 0) return true;
            else return false;

        }
        public bool ActualizarS(string ID_S, string Costo, string Fecha, string N_Estadp, string A_ID, string Aj_ID)
        {
            //Abre coneccion
            connect.Open();
            //toma los campos que actualizara y asigna la nueva cadena que recivira
            SqlCommand cmd = new SqlCommand(string.Format("update Siniestro set Costo = '{0}', Fecha = '{1}', N_Estado = '{2}', A_ID = '{3}', Aj_ID = '{4}' where ID_S = {5}", new string[] { Costo, Fecha, N_Estadp, A_ID, Aj_ID, ID_S }), connect);
            int FilasAfectadas = cmd.ExecuteNonQuery();
            //cierra conexion
            connect.Close();
            //condicion para asegurar que hubo un cambio
            if (FilasAfectadas > 0) return true;
            else return false;

        }
        public bool Actualizarpoliza(string Estado, string Poliza, string ID_A)
        {
            //Abre coneccion
            connect.Open();
            //toma los campos que actualizara y asigna la nueva cadena que recivira
            SqlCommand cmd = new SqlCommand(string.Format("update Autos set Estado='{0}', Poliza = '{1}' where ID_A = {2}", new string[] { Estado, Poliza, ID_A }), connect);
            int FilasAfectadas = cmd.ExecuteNonQuery();
            //cierra conexion
            connect.Close();
            //condicion para asegurar que hubo un cambio
            if (FilasAfectadas > 0) return true;
            else return false;

        }

        public bool Eliminaraj(string ID_Aj)
        {
            //Abre coneccion
            connect.Open();
            //toma los datos de la id seleccionada y los elimina
            SqlCommand cmd = new SqlCommand(string.Format("delete from Ajustador where ID_Aj = {0}", ID_Aj), connect);
            int FilasAfectadas = cmd.ExecuteNonQuery();
            //Cierra coneccion
            connect.Close();
            //condicion para asegurar que se elimino
            if (FilasAfectadas > 0) return true;
            else return false;
        }

        public bool EliminarC(string ID_C)
        {
            //Abre coneccion
            connect.Open();
            //toma los datos de la id seleccionada y los elimina
            SqlCommand cmd = new SqlCommand(string.Format("delete from Cliente where ID_C = {0}", ID_C), connect);
            int FilasAfectadas = cmd.ExecuteNonQuery();
            //Cierra coneccion
            connect.Close();
            //condicion para asegurar que se elimino
            if (FilasAfectadas > 0) return true;
            else return false;
        }
        public bool EliminarS(string ID_S)
        {
            //Abre coneccion
            connect.Open();
            //toma los datos de la id seleccionada y los elimina
            SqlCommand cmd = new SqlCommand(string.Format("delete from Siniestro where ID_S = {0}", ID_S), connect);
            int FilasAfectadas = cmd.ExecuteNonQuery();
            //Cierra coneccion
            connect.Close();
            //condicion para asegurar que se elimino
            if (FilasAfectadas > 0) return true;
            else return false;
        }
        public bool EliminarV(string ID_A)
        {
            //Abre coneccion
            connect.Open();
            //toma los datos de la id seleccionada y los elimina
            SqlCommand cmd = new SqlCommand(string.Format("delete from Autos where ID_A = {0}", ID_A), connect);
            int FilasAfectadas = cmd.ExecuteNonQuery();
            //Cierra coneccion
            connect.Close();
            //condicion para asegurar que se elimino
            if (FilasAfectadas > 0) return true;
            else return false;
        }
        public bool EliminarTV(string ID_A)
        {
            //Abre coneccion
            connect.Open();
            //toma los datos de la id seleccionada y los elimina
            SqlCommand cmd = new SqlCommand(string.Format("delete from Autos where C_ID = {0}", ID_A), connect);
            int FilasAfectadas = cmd.ExecuteNonQuery();
            //Cierra coneccion
            connect.Close();
            //condicion para asegurar que se elimino
            if (FilasAfectadas > 0) return true;
            else return false;
        }
        public bool EliminarTS(string A_ID)
        {
            //Abre coneccion
            connect.Open();
            //toma los datos de la id seleccionada y los elimina
            SqlCommand cmd = new SqlCommand(string.Format("delete from Siniestro where A_ID = {0}", A_ID), connect);
            int FilasAfectadas = cmd.ExecuteNonQuery();
            //Cierra coneccion
            connect.Close();
            //condicion para asegurar que se elimino
            if (FilasAfectadas > 0) return true;
            else return false;
        }
        public bool EliminarTAS(string A_ID)
        {
            //Abre coneccion
            connect.Open();
            //toma los datos de la id seleccionada y los elimina
            SqlCommand cmd = new SqlCommand(string.Format("delete from Siniestro where A_ID in ({0})", A_ID), connect);
            int FilasAfectadas = cmd.ExecuteNonQuery();
            //Cierra coneccion
            connect.Close();
            //condicion para asegurar que se elimino
            if (FilasAfectadas > 0) return true;
            else return false;
        }
        //hacer que los productos aparezcan en el combobox 

        public void cmbaj(ComboBox cb, string Aj_ID)
        {
            //limpia combobox
            cb.Items.Clear();
            //Abre conexion
            connect.Open();
            //Comando para seleccionar todos los datos de la tabla
            SqlCommand cmd = new SqlCommand(string.Format("select * from Cliente where Aj_ID={0}", Aj_ID), connect);
            //lee datos de la tabla
            SqlDataReader dr = cmd.ExecuteReader();
            //Condicion para asegurarse que tenga valores
            while (dr.Read())
            {
                //agrega al combobox los datos leidos apartir del item 1
                cb.Items.Add(dr[1].ToString());
            }
            //Cierra coneccion
            connect.Close();
            //En el item 0 aparece texto que indica que elijja un producto 
            cb.Items.Insert(0, "Clientes");
            cb.SelectedIndex = 0;
        }
        public void cmbAcc(ComboBox cb, string A_ID)
        {
            //limpia combobox
            cb.Items.Clear();
            //Abre conexion
            connect.Open();
            //Comando para seleccionar todos los datos de la tabla
            SqlCommand cmd = new SqlCommand(string.Format("select * from Siniestro where A_ID={0}", A_ID), connect);
            //lee datos de la tabla
            SqlDataReader dr = cmd.ExecuteReader();
            //Condicion para asegurarse que tenga valores
            while (dr.Read())
            {
                //agrega al combobox los datos leidos apartir del item 1
                cb.Items.Add(dr[1].ToString());
            }
            //Cierra coneccion
            connect.Close();
            //En el item 0 aparece texto que indica que elijja un producto 
            cb.Items.Insert(0, "Accidentes");
            cb.SelectedIndex = 0;
        }
        public void cmbCV(ComboBox cb)
        {
            //limpia combobox
            cb.Items.Clear();
            //Abre conexion
            connect.Open();
            //Comando para seleccionar todos los datos de la tabla
            SqlCommand cmd = new SqlCommand("select * from Cliente", connect);
            //lee datos de la tabla
            SqlDataReader dr = cmd.ExecuteReader();
            //Condicion para asegurarse que tenga valores
            while (dr.Read())
            {
                //agrega al combobox los datos leidos apartir del item 1
                cb.Items.Add(dr[0].ToString());
            }
            //Cierra coneccion
            connect.Close();
            //En el item 0 aparece texto que indica que elijja un producto 
            cb.Items.Insert(0, "");
            cb.SelectedIndex = 0;
        }

        public void cmbC(ComboBox cb, string C_ID)
        {
            //limpia combobox
            cb.Items.Clear();
            //Abre conexion
            connect.Open();
            //Comando para seleccionar todos los datos de la tabla
            SqlCommand cmd = new SqlCommand(string.Format("select * from Autos where C_ID={0}", C_ID), connect);
            //lee datos de la tabla
            SqlDataReader dr = cmd.ExecuteReader();
            //Condicion para asegurarse que tenga valores
            while (dr.Read())
            {
                //agrega al combobox los datos leidos apartir del item 1
                cb.Items.Add(dr[1].ToString());
            }
            //Cierra coneccion
            connect.Close();
            //En el item 0 aparece texto que indica que elijja un producto 
            cb.Items.Insert(0, "Autos");
            cb.SelectedIndex = 0;
        }
        public void cmbAj(ComboBox cb)
        {
            //limpia combobox
            cb.Items.Clear();
            //Abre conexion
            connect.Open();
            //Comando para seleccionar todos los datos de la tabla
            SqlCommand cmd = new SqlCommand("select * from Ajustador", connect);
            //lee datos de la tabla
            SqlDataReader dr = cmd.ExecuteReader();
            //Condicion para asegurarse que tenga valores
            while (dr.Read())
            {
                //agrega al combobox los datos leidos apartir del item 1
                cb.Items.Add(dr[0].ToString());
            }
            //Cierra coneccion
            connect.Close();
            //En el item 0 aparece texto que indica que elijja un producto 
            cb.Items.Insert(0, "");
            cb.SelectedIndex = 0;
        }
        public void cmbAuto(ComboBox cb)
        {
            //limpia combobox
            cb.Items.Clear();
            //Abre conexion
            connect.Open();
            //Comando para seleccionar todos los datos de la tabla
            SqlCommand cmd = new SqlCommand("select * from Cliente", connect);
            //lee datos de la tabla
            SqlDataReader dr = cmd.ExecuteReader();
            //Condicion para asegurarse que tenga valores
            while (dr.Read())
            {
                //agrega al combobox los datos leidos apartir del item 1
                cb.Items.Add(dr[0].ToString());
            }
            //Cierra coneccion
            connect.Close();
            //En el item 0 aparece texto que indica que elijja un producto 
            cb.Items.Insert(0, "");
            cb.SelectedIndex = 0;
        }
        public string[] valores(string ID_A)
        {
            //Abre coneccion
            connect.Open();
            //toma todo del producto que tenga el valor que se le asignara a la variable nombre
            SqlCommand cmd = new SqlCommand(string.Format("select ID_A from Autos where C_ID={0}", ID_A), connect);
            SqlDataReader dr = cmd.ExecuteReader();
            string[] resultado = null;
            //ciclo para asignar valores leidos a una cadena
            List<string> list = new List<string>();
            while (dr.Read())
            {
                list.Add(dr[0].ToString());
            }
            resultado = list.ToArray();
            //cierra coneccion
            connect.Close();
            return resultado;
        }
 
        public DataTable BuscarAj(string ID_Aj)
        {
            //Abre coneccion
            connect.Open();
            //Comando para seleccionar todos los datos de la tabla
            SqlCommand cmd = new SqlCommand(string.Format("Select * from Ajustador where ID_Aj = {0}", ID_Aj), connect);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            //declara la tabla con una variable
            DataTable table = new DataTable();
            ad.Fill(table);
            //cierra coneccion
            connect.Close();
            //regresa tabla
            return table;

        }
        public DataTable BuscarC(string ID_C)
        {
            //Abre coneccion
            connect.Open();
            //Comando para seleccionar todos los datos de la tabla
            SqlCommand cmd = new SqlCommand(string.Format("Select * from Cliente where ID_C = {0}", ID_C), connect);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            //declara la tabla con una variable
            DataTable table = new DataTable();
            ad.Fill(table);
            //cierra coneccion
            connect.Close();
            //regresa tabla
            return table;

        }
        public DataTable BuscarV(string ID_A)
        {
            //Abre coneccion
            connect.Open();
            //Comando para seleccionar todos los datos de la tabla
            SqlCommand cmd = new SqlCommand(string.Format("Select * from Autos where ID_A = {0}", ID_A), connect);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            //declara la tabla con una variable
            DataTable table = new DataTable();
            ad.Fill(table);
            //cierra coneccion
            connect.Close();
            //regresa tabla
            return table;

        }
        public DataTable BuscarS(string ID_S)
        {
            //Abre coneccion
            connect.Open();
            //Comando para seleccionar todos los datos de la tabla
            SqlCommand cmd = new SqlCommand(string.Format("Select * from Autos where ID_S = {0}", ID_S), connect);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            //declara la tabla con una variable
            DataTable table = new DataTable();
            ad.Fill(table);
            //cierra coneccion
            connect.Close();
            //regresa tabla
            return table;
        }
        public DataTable BuscarP(string A_ID)
        {
            //Abre coneccion
            connect.Open();
            //Comando para seleccionar todos los datos de la tabla
            SqlCommand cmd = new SqlCommand(string.Format("Select * from Siniestro where A_ID = {0} order by Fecha desc", A_ID), connect);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            //declara la tabla con una variable
            DataTable table = new DataTable();
            ad.Fill(table);
            //cierra coneccion
            connect.Close();
            //regresa tabla
            return table;

        }
        public DataTable BuscarpA(string ID_A)
        {
            //Abre coneccion
            connect.Open();
            //Comando para seleccionar todos los datos de la tabla
            SqlCommand cmd = new SqlCommand(string.Format("Select ID_A as ID_Auto,Estado,Tazaf as Taza_fija,Poliza from Autos where ID_A = {0}", ID_A), connect);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            //declara la tabla con una variable
            DataTable table = new DataTable();
            ad.Fill(table);
            //cierra coneccion
            connect.Close();
            //regresa tabla
            return table;

        }



    }
}
