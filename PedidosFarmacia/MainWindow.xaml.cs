using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PedidosFarmacia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AceptarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!this.Validate_Form())
            {
                return;
            }

            Pedido pedido = new Pedido(
                this.Medicamento_Name(),
                this.Medicamento_Type(),
                this.Medicamento_Amount(),
                this.Medicamento_Distributor(),
                this.Medicamento_Branch()
            );


            Window1 win = new Window1();
            win.SetPedido(pedido);
            win.ShowInTaskbar = false;
            win.Owner = Application.Current.MainWindow;
            win.Show();
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Hello Cancelar");
        }

        private bool Validate_Form()
        {
            bool isValid = true;
            ErrorTextBlock.Visibility = Visibility.Hidden;

            if (!this.Validate_Name())
            {
                isValid = false;
                this.show_error("El nombre es incorrecto, porfavor revisa que hayas ingresado un nombre al medicamento.");
            }

            if (isValid && !this.Validate_Type())
            {
                isValid = false;
                this.show_error("Por favor, elige un tipo de medicamento.");
            }

            if (isValid && !this.Validate_Amount())
            {
                isValid = false;
                this.show_error("La cantidad ingresada debe ser una cantidad positiva, y no debe tener decimales.");
            }

            if (isValid && !this.Validate_Distributor())
            {
                isValid = false;
                this.show_error("Por favor, elige un distribuidor");
            }

            if (isValid && !this.Validate_Branch())
            {
                isValid = false;
                this.show_error("Por favor, elige una sucursal");
            }

            return isValid;
        }

        private bool Validate_Name()
        {
            return this.Medicamento_Name().Length > 0;
        }

        private string Medicamento_Name()
        {
            return NombreTextBox.Text;
        }

        private bool Validate_Type()
        {
            string value = this.Medicamento_Type();

            return value != null;
        }

        private string Medicamento_Type()
        {
            ComboBoxItem item = (ComboBoxItem)MedicamentoComboBox.SelectedItem;
            if (item == null)
            {
                return null;
            }

            return item.Content.ToString();
        }

        private bool Validate_Amount()
        {
            Int32 value = this.Medicamento_Amount();
            return value > 0;
        }

        private Int32 Medicamento_Amount()
        {
            try
            {
                string value = CantidadTextBox.Text;
                int num = Int32.Parse(value);

                return num;
            }
            catch (FormatException)
            {
                return -1;
            }
        }

        private bool Validate_Distributor()
        {
            return this.Medicamento_Distributor() != null;
        }

        private string Medicamento_Distributor()
        {
            if (CofarmaRadioButton.IsChecked == true)
            {
                return CofarmaRadioButton.Content.ToString();
            }

            if (EmpsepharRadioButton.IsChecked == true)
            {
                return EmpsepharRadioButton.Content.ToString();
            }

            if (CemefarRadioButton.IsChecked == true)
            {
                return CemefarRadioButton.Content.ToString();
            }

            return null;
        }

        private bool Validate_Branch()
        {
            return this.Medicamento_Branch().Count > 0;
        }

        private List<string> Medicamento_Branch()
        {
            List<string> sucursales = new List<string>();

            if (PrincipalCheckBox.IsChecked == true)
            {
                sucursales.Add("principal");
            }

            if (SecundariaCheckBox.IsChecked == true)
            {
                sucursales.Add("secundaria");
            }

            return sucursales;
        }

        private void show_error(string e)
        {
            ErrorTextBlock.Visibility = Visibility.Visible;
            ErrorTextBlock.Text = e;
        }
    }
}
