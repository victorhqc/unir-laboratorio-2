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
            Console.WriteLine("Hello Aceptar");
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

            if (isValid && !this.Validate_Provider())
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
            string value = NombreTextBox.Text;

            return value.Length > 0;
        }

        private bool Validate_Provider()
        {
            ComboBoxItem item = (ComboBoxItem)MedicamentoComboBox.SelectedItem;

            return item != null;
        }

        private bool Validate_Amount()
        {
            try
            {
                string value = CantidadTextBox.Text;
                int num = Int32.Parse(value);

                return num > 0;
            } catch(FormatException)
            {
                return false;
            }
        }

        private bool Validate_Distributor()
        {
            return CofarmaRadioButton.IsChecked == true
                || EmpsepharRadioButton.IsChecked == true
                || CemefarRadioButton.IsChecked == true;
        }

        private bool Validate_Branch()
        {
            return PrincipalCheckBox.IsChecked == true
                || SecundariaCheckBox.IsChecked == true;
        }

        private void show_error(string e)
        {
            ErrorTextBlock.Visibility = Visibility.Visible;
            ErrorTextBlock.Text = e;
        }
    }
}
