using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EjemDB
{
    class Empleado
    {
        //
        private int codigo_emp;
        private string nombre_emp;
        private string apellido_emp;
        private double sueldo_emp;
        private string nombre_dep;
        private string ciudad_dep;
        private int codigo_proy;

        //
        public int getCodigo_emp()
        {
            return codigo_emp;
        }

        public void setCodigo_emp(int codigo_emp)
        {
            this.codigo_emp = codigo_emp;
        }

        public string getNombre_emp()
        {
            return nombre_emp;
        }

        public void setNombre_emp(string nombre_emp)
        {
            this.nombre_emp = nombre_emp;
        }

        public string getApellido_emp()
        {
            return apellido_emp;
        }

        public void setApellido_emp(string apellido_emp)
        {
            this.apellido_emp = apellido_emp;
        }

        public double getSueldo_emp()
        {
            return sueldo_emp;
        }

        public void setSueldo_emp(double sueldo_emp)
        {
            this.sueldo_emp = sueldo_emp;
        }

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

        public int getCodigo_proy()
        {
            return codigo_proy;
        }

        public void setCodigo_proy(int codigo_proy)
        {
            this.codigo_proy = codigo_proy;
        }

        //
        public Empleado() { }

        public Empleado(int codigo_emp, string nombre_emp, string apellido_emp, 
            double sueldo_emp, string nombre_dep, string ciudad_dep, int codigo_proy)
        {
            this.codigo_emp = codigo_emp;
            this.nombre_emp = nombre_emp;
            this.apellido_emp = apellido_emp;
            this.sueldo_emp = sueldo_emp;
            this.nombre_dep = nombre_dep;
            this.ciudad_dep = ciudad_dep;
            this.codigo_proy = codigo_proy;
        }

        //





    }
}
