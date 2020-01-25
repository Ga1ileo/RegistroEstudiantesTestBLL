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
using RegistroEF2.UI.Consulta;
using RegistroEF2.UI.Registros;

namespace RegistroEF2
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

        private void RegistroButton_Click(object sender, RoutedEventArgs e)
        {
            rPersonas rpersonas = new rPersonas();
            rpersonas.Show();
        }

        private void ConsultaButton_Click(object sender, RoutedEventArgs e)
        {
            cPersonas cpersonas = new cPersonas();
            cpersonas.Show();
        }
    }
}
