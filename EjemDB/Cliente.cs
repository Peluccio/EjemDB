using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EjemDB
{
    class Cliente
    {
        //
        private int codigo_cli;
        private string nombre_cli;
        private string RFC_cli;
        private string direccion_cli;
        private string ciudad_cli;
        private string telefono_cli;

        //
        public int getCodigo_cli()
        {
            return codigo_cli;
        }

        public void setCodigo_cli(int codigo_cli)
        {
            this.codigo_cli = codigo_cli;
        }

        public string getNombre_cli()
        {
            return nombre_cli;
        }

        public void setNombre_cli(string nombre_cli)
        {
            this.nombre_cli = nombre_cli;
        }

        public string getRFC_cli()
        {
            return RFC_cli;
        }

        public void setRFC_cli(string RFC_cli)
        {
            this.RFC_cli = RFC_cli;
        }

        public string getDireccion_cli()
        {
            return direccion_cli;
        }

        public void setDireccion_cli(string direccion_cli)
        {
            this.direccion_cli = direccion_cli;
        }

        public string getCiudad_cli()
        {
            return ciudad_cli;
        }

        public void setCiuadad_cli(string ciudad_cli)
        {
            this.ciudad_cli = ciudad_cli;
        }

        public string getTelefono_cli()
        {
            return telefono_cli;
        }

        public void setTelefono_cli(string telefono_cli)
        {
            this.telefono_cli = telefono_cli;
        }


        //
        public Cliente() { }

        public Cliente(int codigo_cli, string nombre_cli, string RFC_cli, 
            string direccion_cli, string ciudad_cli, string telefono_cli)
        {
            this.codigo_cli = codigo_cli;
            this.nombre_cli = nombre_cli;
            this.RFC_cli = RFC_cli;
            this.direccion_cli = direccion_cli;
            this.ciudad_cli = ciudad_cli;
            this.telefono_cli = telefono_cli;
        }

        //
        //Se define la cadena de conexión a la base de datos.
        public static SqlConnection conn = new SqlConnection
        ("Initial Catalog = Proyectos; Data Source = Octavio-PC\\SQLEXPRESS; Integrated Security = SSPI;");
        
        //Método que ejecutará la consulta de los registros de una tabla.
        public DataSet ConsultaTabla(string cliente, string codigo_cli)
        {
            //Se genera un objeto de la clase DataSet (almacén de datos, representa una base de datos
            // en memoria y desconecta del proveedor de datos, contiene tablas y sus relaciones)
            DataSet dS = new DataSet();

            //Se genera un objeto Adaptador (adaptador entre un objeto DataSet y sus operaciones
            //físicas en la base de datos (select, insert, update, delete)).
            SqlDataAdapter adapter = new SqlDataAdapter();

            //Se crea la cadena que contiene la consulta en lenguage SQL.
            string consulta = "SELECT * FROM " + cliente + " ORDER BY " + codigo_cli + " ASC";

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
        }

        public SqlDataReader buscarCliente(string codigoConsulta)
        {
            //Se genera un objeto Command que nos va a permitir ejecutar la sentencia SQL sobre la
            //fuente de datos a la que estamos accediendo (conexcion).
            SqlCommand command = new SqlCommand(codigoConsulta, conn);

            conn.Open();

            //Crea el objeto lector de datos.
            SqlDataReader sqldr = command.ExecuteReader();

            //Regresa objeto con datos leídos.
            return sqldr; 
        }

        //BuscarCliente
        //Éste método recíbe como parámetros el código de la consulta y el nombre
        //de la tabla de donde se tomarán los datos.
        public DataSet buscarCliente(string query, string tabla)
        {
            DataSet conjuntosDatos = new DataSet();

            SqlCommand command = new SqlCommand(query, conn);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;

            conn.Open();

            adapter.Fill(conjuntosDatos, tabla);

            conn.Close();

            return conjuntosDatos;
        
        }
        


    }
}
