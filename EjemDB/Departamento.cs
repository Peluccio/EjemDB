using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EjemDB
{
    class Departamento
    {
        //
        private string nombre_dep;
        private string ciudad_dep;
        private string telefono_dep;

        //
        public string getNombre_dep()
        {
            return nombre_dep;
        }

        public void setNombre_dep(string nombre_dep)
        {
            this.nombre_dep = nombre_dep;
        }

        public string getCiudad_dep()
        {
            return ciudad_dep;
        }

        public void setCiudad_dep(string ciudad_dep)
        {
            this.ciudad_dep = ciudad_dep;
        }

        public string getTelefono_dep()
        {
            return telefono_dep;
        }

        public void setTelefono_dep(string telefono_dep)
        {
            this.telefono_dep = telefono_dep;
        }

        //
        public Departamento() { }

        public Departamento(string nombre_dep, string ciudad_dep, string telefono_dep)
        {
            this.nombre_dep = nombre_dep;
            this.ciudad_dep = ciudad_dep;
            this.telefono_dep = telefono_dep;
        }

        //



    }
}
