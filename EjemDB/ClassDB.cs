using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EjemDB
{
    class ClassDB
    {
        //Se define la cadena de conexión a la base de datos.
        public static SqlConnection conn = new SqlConnection
        ("Initial Catalog = Proyectos; Data Source = Octavio-PC\\SQLEXPRESS; Integrated Security = SSPI;");

        /*//Método que ejecutará la consulta de los registros de una tabla.
        public DataSet ConsulTab(string cliente, string codigo_cli)
        {
            //Se genera un objeto de la clase DataSet (almacén de datos, representa una base de datos
            // en memoria y desconecta del proveedor de datos, contiene tablas y sus relaciones)
            DataSet dS = new DataSet();

            //Se genera un objeto Adaptador (adaptador entre un objeto DataSet y sus operaciones
            //físicas en la base de datos (select, insert, update, delete)).
            SqlDataAdapter adapter = new SqlDataAdapter();

            //Se crea la cadena que contiene la consulta en lenguage SQL.
            string consulta = "SELECT * FROM " + cliente + " ORDER BY " + codigo_cli + " ASC" ;

            //Se genera un objeto Command que nos va a permitir ejecutar la sentencia SQL sobre la
            //fuente de datos a la que estamos accediendo (conexión).
            SqlCommand command = new SqlCommand(consulta, conn);

            //Se asigna al adptador el comando a ejecutar.
            adapter.SelectCommand = command;

            //Se abre la conexión de la DB.
            conn.Open();

            //Se obtienen los datos de la consulta ejecutada.
            adapter.Fill(dS, cliente);

            //Secierra la conexión.
            conn.Close();

            //Retorna los datos obtenidos.
            return dS;
        } */

        //
        public int ABM(string instruction)
        {
            int result = 1;
            //Asigna al comando la instrucción SQL y la conexión a utilizar.
            SqlCommand command = new SqlCommand(instruction, conn);

            //Abre la conexión a la base de datos.
            conn.Open();

            //Ejecuta la instrución SQL y ésta devuelve 1 = éxito, 0 = error.
            result = command.ExecuteNonQuery();

            conn.Close();

            return result;
        }

    }


}
