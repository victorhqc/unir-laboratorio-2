using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PedidosFarmacia
{
    public class Pedido
    {
        private string nombre;
        private string tipo;
        private Int32 cantidad;
        private string distribuidor;
        private List<string> sucursales;

        public Pedido(string nombre, string tipo, Int32 cantidad, string distribuidor, List<string> sucursales)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.cantidad = cantidad;
            this.distribuidor = distribuidor;
            this.sucursales = sucursales;
        }

        public string Nombre()
        {
            return this.nombre;
        }

        public string Tipo()
        {
            return this.tipo;
        }

        public Int32 Cantidad()
        {
            return this.cantidad;
        }

        public string Distribuidor()
        {
            return this.distribuidor;
        }

        public List<string> Sucursales()
        {
            return this.sucursales;
        }

        public string Direccion()
        {
            string direccion = "";
            Int32 index = 0;
            foreach (string sucursal in this.sucursales)
            {
                if (index < this.sucursales.Count - 1)
                {
                    direccion += $", {SucursalDireccion(sucursal)}";
                } else
                {
                    direccion += $" y para la situada en {SucursalDireccion(sucursal)}";
                }

                index++;
            }

            return direccion.Substring(2);
        }

        string SucursalDireccion(string sucursal)
        {
            switch (sucursal)
            {
                case "principal":
                    return "Calle de la Rosa n. 28";
                case "secundaria":
                    return "Calle Alcazabilla n. 3";
                default:
                    return "Desconocida";
            }
        }
    }
}
