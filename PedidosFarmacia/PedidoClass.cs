using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
