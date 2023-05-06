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
    /// Lógica de interacción para FormAlumno.xaml
    /// </summary>
    public partial class FormAlumno : Window
    {
        //Instancia de la lista 
        List<Alumno> lisal = new List<Alumno>();
        //Constructor del formulario
        public FormAlumno()
        {
            InitializeComponent();
            //Quitar botones del fromulario de minimizar-maximizar-cerrar
            this.WindowStyle = WindowStyle.None;
            // Centrar el formulario
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //Listar los datos de la tabla al iniciar 
            ListarAlumno();

        }

        // SECCION  resetear campos del formulario 
        public void LimpiarCampos()
        {
            Alumno alumno = new Alumno();
            nombre_1.Text = alumno.Primer_Nombre;
            nombre_2.Text = alumno.Segundo_Nombre;
            apellido_1.Text = alumno.Primer_Apellido;
            apellido_2.Text = alumno.Segundo_Apellido;
            telefono_txt.Text = alumno.Telefono;
            celular_txt.Text = alumno.Celular;
            direccion_txt.Text = alumno.Direccion;
            correo_txt.Text = alumno.Email;
            fecha_nac.Text = alumno.Fecha_Nacimiento;
            Obsertxt.Text = alumno.Observaciones;

        }

        //SECCION boton cerrar 
        private void clickCerrar(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();
            mainWindow.Show();

        }

        //SECCION llenar campo del formulario al hacer click en una fila de la tabla 
        public void llenarCampos(Alumno alumno)
        {
            nombre_1.Text = alumno.Primer_Nombre;
            nombre_2.Text = alumno.Segundo_Nombre;
            apellido_1.Text = alumno.Primer_Apellido;
            apellido_2.Text = alumno.Segundo_Apellido;
            telefono_txt.Text = alumno.Telefono;
            celular_txt.Text = alumno.Celular;
            direccion_txt.Text = alumno.Direccion;
            correo_txt.Text = alumno.Email;
            fecha_nac.Text = alumno.Fecha_Nacimiento;
            Obsertxt.Text = alumno.Observaciones;

        }

        //SECCION  mostrar datos en una tabla
        public void ListarAlumno()
        {
            AlumnoLN alumnoLN = new AlumnoLN();
            ListaAlumnoDtg.ItemsSource = alumnoLN.ListarAlumnosLN();
            lisal = (List<Alumno>)ListaAlumnoDtg.ItemsSource;
        }


        //SECCION tabla datagrid  del formulario mostrando datos de la BD
        private void ListaAlumnoDtg_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (ListaAlumnoDtg.SelectedItem != null)
            {
                Alumno alumno = (Alumno)ListaAlumnoDtg.SelectedItem;
                id_txt.Text = alumno.Id_Alumno.ToString();
                nombre_1.Text = alumno.Primer_Nombre;
                nombre_2.Text = alumno.Segundo_Nombre;
                apellido_1.Text = alumno.Primer_Apellido;
                apellido_2.Text = alumno.Segundo_Apellido;
                telefono_txt.Text = alumno.Telefono;
                celular_txt.Text = alumno.Celular;
                direccion_txt.Text = alumno.Direccion;
                correo_txt.Text = alumno.Email;
                fecha_nac.Text = alumno.Fecha_Nacimiento;
                Obsertxt.Text = alumno.Observaciones;
            }

        }

        //SECCION boton Agregar del formulario 
        private void click_AgregarDatos(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nombre_1.Text) || string.IsNullOrEmpty(nombre_2.Text) || string.IsNullOrEmpty(apellido_1.Text) || string.IsNullOrEmpty(apellido_2.Text) || string.IsNullOrEmpty(telefono_txt.Text) || string.IsNullOrEmpty(celular_txt.Text) || string.IsNullOrEmpty(direccion_txt.Text) || string.IsNullOrEmpty(correo_txt.Text) || string.IsNullOrEmpty(fecha_nac.Text) || string.IsNullOrEmpty(Obsertxt.Text))
            {
                MessageBox.Show("Estimado(a) usuario, todos los campos del formulario requieren estar completados!!!");
            }
            else
            {
                Alumno alumno = new Alumno();
                alumno.Primer_Nombre = nombre_1.Text;
                alumno.Segundo_Nombre = nombre_2.Text;
                alumno.Primer_Apellido = apellido_1.Text;
                alumno.Segundo_Apellido = apellido_2.Text;
                alumno.Telefono = telefono_txt.Text;
                alumno.Celular = celular_txt.Text;
                alumno.Direccion = direccion_txt.Text;
                alumno.Email = correo_txt.Text;
                alumno.Fecha_Nacimiento = fecha_nac.Text.ToString();
                alumno.Observaciones = Obsertxt.Text;

                AlumnoLN alumnoLN = new AlumnoLN();
                alumnoLN.InsertarAlumnoLN(alumno);
                LimpiarCampos();
                MessageBox.Show("LOS DATOS SE AGREGARON CORRECTAMENTE");
                ListarAlumno();
            }

        }

        //SECCION LIMPIAR CAPOS DEL FORMULARIO
        private void click_LimpiarCampo_txt(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        //SECCION BOTON DE FILTRADO
        private void click_FiltrarDatos(object sender, RoutedEventArgs e)
        {
            if (filtro_txt.Text == "")
            {
                MessageBox.Show("¡¡¡CAMPO DE BUSQUEDA VACIO!!!");
                ListaAlumnoDtg.ItemsSource = lisal;

            }
            else
            {
                var lisal2 = (List<Alumno>)ListaAlumnoDtg.ItemsSource;
                var filtrado = from alumno in lisal2
                               where alumno.Primer_Apellido == filtro_txt.Text || alumno.Segundo_Apellido == filtro_txt.Text || alumno.Primer_Nombre == filtro_txt.Text || alumno.Segundo_Nombre == filtro_txt.Text
                               select alumno;

                ListaAlumnoDtg.ItemsSource = filtrado;
            }

        }

        // SECCION BOTON LIMPIAR CAMPOS DE BUSQUEDA 
        private void click_limpiar_filtro(object sender, RoutedEventArgs e)
        {
            filtro_txt.Text = "";
            ListarAlumno();
        }


        //SECCION ACTUALIZAR ALUMNO 
        private void click_actualizar_alumnos(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nombre_1.Text) || string.IsNullOrEmpty(nombre_2.Text) || string.IsNullOrEmpty(apellido_1.Text) || string.IsNullOrEmpty(apellido_2.Text) || string.IsNullOrEmpty(telefono_txt.Text) || string.IsNullOrEmpty(celular_txt.Text) || string.IsNullOrEmpty(direccion_txt.Text) || string.IsNullOrEmpty(correo_txt.Text) || string.IsNullOrEmpty(fecha_nac.Text) || string.IsNullOrEmpty(Obsertxt.Text))
            {
                MessageBox.Show("Debe seleccional un registro de la tabla para poder actualizar");
            }
            else
            {
                Alumno alumno = new Alumno();
                alumno.Id_Alumno = Convert.ToInt32(id_txt.Text);
                alumno.Primer_Nombre = nombre_1.Text;
                alumno.Segundo_Nombre = nombre_2.Text;
                alumno.Primer_Apellido = apellido_1.Text;
                alumno.Segundo_Apellido = apellido_2.Text;
                alumno.Telefono = telefono_txt.Text;
                alumno.Celular = celular_txt.Text;
                alumno.Direccion = direccion_txt.Text;
                alumno.Email = correo_txt.Text;
                alumno.Fecha_Nacimiento = fecha_nac.Text.ToString();
                alumno.Observaciones = Obsertxt.Text;

                AlumnoLN alumnoLN = new AlumnoLN();
                alumnoLN.ActualizarAlumnoLN(alumno);

                LimpiarCampos();
                MessageBox.Show("LOS DATOS SE ACTUALIZARON CORRECTAMENTE");
                ListarAlumno();
            }
        }

        // SECCION ELIMINAR ALUMNO O REGISTRO 
        private void click_eliminar_alumnos(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(id_txt.Text))
            {
                MessageBox.Show("Debe seleccionar un registro de la tabla para poder eliminar.");
            }
            else
            {
                if (MessageBox.Show("¿Está seguro de que desea eliminar el registro?", "Confirmación", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    AlumnoLN alumnoLN = new AlumnoLN();
                    alumnoLN.EliminarAlumnoLN(id_txt.Text);

                    LimpiarCampos();
                    MessageBox.Show("El registro se eliminó correctamente.");
                    ListarAlumno();
                }
            }
        }
    }
}
