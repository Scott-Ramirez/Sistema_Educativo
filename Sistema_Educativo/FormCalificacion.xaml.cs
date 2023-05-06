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
using System.Windows.Shapes;
using AccesoDatos;
using Entidades;
using LogicaNegocio;

namespace Sistema_Educativo
{
    /// <summary>
    /// Lógica de interacción para FormCalificacion.xaml
    /// </summary>
    public partial class FormCalificacion : Window
    {
        List<Calificaciones> liscal = new List<Calificaciones>();
        public FormCalificacion()
        {
            InitializeComponent();
            //Quitar botones del fromulario de minimizar-maximizar-cerrar
            this.WindowStyle = WindowStyle.None;
            // Centrar el formulario
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //Listar los datos de la tabla al iniciar 
            ListarCalificaciones();
        }

        //SECCION  mostrar datos en una tabla
        public void ListarCalificaciones()
        {
            CalificacionLN calificacionLN = new CalificacionLN();   
            ListaCalificacionesDtg.ItemsSource = calificacionLN.ListarCalificacionesLN();
            liscal = (List<Calificaciones>)ListaCalificacionesDtg.ItemsSource;
        }

        private void click_cerrar(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();
        }


        //SECCION tabla datagrid  del formulario mostrando datos de la BD
        private void ListaCalificacionesDtg_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (ListaCalificacionesDtg.SelectedItem != null)
            {
                Calificaciones calificaciones = (Calificaciones)ListaCalificacionesDtg.SelectedItem;
                
                
            }

        }


    }
}
