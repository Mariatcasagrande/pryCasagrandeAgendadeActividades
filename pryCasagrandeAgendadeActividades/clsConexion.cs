using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryCasagrandeAgendadeActividades
{
    internal class clsConexion
    {
        string cadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Alumno\\source\\repos\\pryCasagrandeAgendadeActividades\\pryCasagrandeAgendadeActividades\\Base_de_Datos\\Database11.accdb";

        OleDbConnection coneccionBaseDatos;
        
        OleDbCommand comandoBaseDatos;

        OleDbDataReader lectorDataReader;

        public string nombreBaseDeDatos;
       
        public void ConectarBD()
        {
            try
            {
                coneccionBaseDatos = new OleDbConnection(cadenaConexion);
                nombreBaseDeDatos = coneccionBaseDatos.DataSource;
                coneccionBaseDatos.Open();

                //MessageBox.Show("Conectado a " + nombreBaseDeDatos);
            }
            catch (Exception error)
            {
                MessageBox.Show("Tiene un errorcito - " + error.Message);
            }

        }
        public void AgregarABase(string Actividad, DateTime Fecha, string Observacion)
        {
            comandoBaseDatos = new OleDbCommand();
            comandoBaseDatos.Connection = coneccionBaseDatos;
            comandoBaseDatos.CommandType = System.Data.CommandType.Text;

            comandoBaseDatos.CommandText = $"INSERT INTO Actividades (Asunto,Fecha,Observación) VALUES ('{Actividad}','{Fecha}','{Observacion}')";

            lectorDataReader = comandoBaseDatos.ExecuteReader();

            MessageBox.Show("SE AGREGO CON EXITO");  
        }

        public void AgregaraTabla(DataGridView Grilla)
        {
            comandoBaseDatos = new OleDbCommand();
            comandoBaseDatos.Connection = coneccionBaseDatos;
            comandoBaseDatos.CommandType = System.Data.CommandType.Text;

            comandoBaseDatos.CommandText = "SELECT * FROM Actividades";

            lectorDataReader = comandoBaseDatos.ExecuteReader();
            Grilla.Rows.Clear();
            while (lectorDataReader.Read())
            {
                Grilla.Rows.Add(lectorDataReader[1], lectorDataReader[2], lectorDataReader[3]);
            }
        }
        public void Eliminar(string asunto)
        {
            try
            {
                coneccionBaseDatos = new OleDbConnection(cadenaConexion);
                coneccionBaseDatos.Open();
                comandoBaseDatos = new OleDbCommand();
                comandoBaseDatos.Connection = coneccionBaseDatos;
                comandoBaseDatos.CommandText = $"DELETE FROM Actividades WHERE Asunto = '{asunto}'";
                comandoBaseDatos.ExecuteReader();
            }
            catch
            {
                MessageBox.Show("Tiene un errorcito - ");
            }
        }

    }
}
