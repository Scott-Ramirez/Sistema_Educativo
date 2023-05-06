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

namespace Sistema_Educativo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void clickAlumno(object sender, RoutedEventArgs e)
        {
            FormAlumno formAlumno = new FormAlumno();
            this.Close();
            formAlumno.Show();
        }

        private void clickCalificacion(object sender, RoutedEventArgs e)
        {
            FormCalificacion formCalificacion = new FormCalificacion();
            this.Close();
            formCalificacion.Show();
        }

        private void clickReporte(object sender, RoutedEventArgs e)
        {
            FormReportes formReportes = new FormReportes();
            this.Close();
            formReportes.Show();
        }
    }
}
