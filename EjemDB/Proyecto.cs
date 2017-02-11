using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EjemDB
{
    class Proyecto
    {
        //
        private int codigo_proy;
        private string nombre_proy;
        private double precio_proy;
        private string fecha_inicio_proy;
        private string fecha_prev_proy;
        private string fecha_fin_proy;
        private string codigo_cliente;

        //
        public int getCodigo_proy()
        {
            return codigo_proy;
        }

        public void setCodigo_proy(int codigo_proy)
        {
            this.codigo_proy = codigo_proy;
        }

        public string getNombre_proy()
        {
            return nombre_proy;
        }

        public void setNombre_proy(string nombre_proy)
        {
            this.nombre_proy = nombre_proy;
        }

        public double getPrecio_proy()
        {
            return precio_proy;
        }

        public void setPrecio_proy(double precio_proy)
        {
            this.precio_proy = precio_proy;
        }

        public string getFecha_inicio_proy()
        {
            return fecha_inicio_proy;
        }

        public void setFecha_inicio_proy(string fecha_inicio_proy)
        {
            this.fecha_inicio_proy = fecha_inicio_proy;
        }

        public string getFecha_prev_proy()
        {
            return fecha_prev_proy;
        }

        public void setFecha_prev_proy(string fecha_prev_proy)
        {
            this.fecha_prev_proy = fecha_prev_proy;
        }

        public string getFecha_fin_proy()
        {
            return fecha_fin_proy;
        }

        public void setFecha_fin_proy(string fecha_fin_proy)
        {
            this.fecha_fin_proy = fecha_fin_proy;
        }

        public string getCodigo_cliente()
        {
            return codigo_cliente;
        }

        public void setCodigo_cliente(string codigo_cliente)
        {
            this.codigo_cliente = codigo_cliente;
        }

        //
        public Proyecto() { }

        public Proyecto(int codigo_proy, string nombre_proy, double precio_proy, string fecha_inicio_proy, 
            string fecha_prev_proy, string fecha_fin_proy, string codigo_cliente)
        {
            this.codigo_proy = codigo_proy;
            this.nombre_proy = nombre_proy;
            this.precio_proy = precio_proy;
            this.fecha_inicio_proy = fecha_inicio_proy;
            this.fecha_prev_proy = fecha_prev_proy;
            this.fecha_fin_proy = fecha_fin_proy;
            this.codigo_cliente = codigo_cliente;
        }
    }
}
