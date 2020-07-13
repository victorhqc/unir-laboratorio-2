using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PedidosFarmacia
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Pedido pedido;

        public Window1()
        {
            InitializeComponent();
        }

        public void SetPedido(Pedido pedido)
        {
            this.pedido = pedido;
            this.SetTitle();
            this.SetDescription();
        }

        private void SetTitle()
        {
            this.Title = $"Pedido al distribuidor {this.pedido.Distribuidor()}";
        }

        private void SetDescription()
        {
            DescripcionTextBlock.Text = $"{this.pedido.Cantidad()} unidades del {this.pedido.Tipo()} {this.pedido.Nombre()}";
            DireccionTextBlock.Text = $"Para la farmacia situada en {this.pedido.Direccion()}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ConfirmacionLabel.Content = "Pedido enviado!";
        }
    }
}
