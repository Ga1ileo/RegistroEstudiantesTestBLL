using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using RegistroEF2.BLL;
using RegistroEF2.Entidades;

namespace RegistroEF2.UI.Registros
{
    /// <summary>
    /// Interaction logic for rPersonas.xaml
    /// </summary>
    public partial class rPersonas : Window
    {
        public rPersonas()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            FechaNacimientoDatePicker.Text = DateTime.Now.ToString();
        }

        private Persona LlenaClase()
        {
            //int id;
            Persona persona = new Persona();
           // persona.PersonaID = int.TryParse(IdTextBox.Text, id);
            persona.Nombre = NombreTextBox.Text;
            persona.Cedula = CedulaTextBox.Text;
            persona.Direccion = DireccionTextBox.Text;

            return persona;
        }

        private void LlenaCampo(Persona persona)
        {
            IdTextBox.Text = persona.PersonaID.ToString();
            NombreTextBox.Text = persona.Nombre;
            TelefonoTextBox.Text = persona.Telefono;
            CedulaTextBox.Text = persona.Cedula;
            DireccionTextBox.Text = persona.Direccion;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Persona persona = PersonasBLL.Buscar(Validar.ValidarEntero(IdTextBox.Text));
            return (persona != null);   
        }

        private bool ValidaR()
        {
            bool paso = true;

            if (NombreTextBox.Text == string.Empty)
            {
               NombreTextBox.Focus();
               paso = false;
            }

            if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                DireccionTextBox.Focus();
            }

            if (string.IsNullOrWhiteSpace(CedulaTextBox.Text.Replace("-", "")))
            {
               CedulaTextBox.Focus();
                paso = false;
            }

                return paso;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Persona persona = new Persona();


            Limpiar();

            persona = PersonasBLL.Buscar(Validar.ValidarEntero(IdTextBox.Text));

            if (persona != null)
            {
               MessageBox.Show("persona encontrada");
                  LlenaCampo(persona);
            }
            else
            {
                 MessageBox.Show("Persona no encontrada");
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Persona persona;
            bool paso = false;

            if (!ValidaR())
                return;

            persona = LlenaClase();

            if (Validar.ValidarEntero(IdTextBox.Text) == 0)
                paso = PersonasBLL.Guardar(persona);
            else
            {
                 if (!ExisteEnLaBaseDeDatos())
                 {
                      MessageBox.Show("NO SE PUEDE MODIFICAR, la persona No la han creado", "Fallo", MessageBoxButton.OK);
                      return;
                 }
                    paso = PersonasBLL.Modificar(persona);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Existo", MessageBoxButton.OK);
            }

            else
              MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButton.OK);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            Validar.ValidarEntero(IdTextBox.Text);
            Limpiar();

                if (PersonasBLL.Eliminar(Validar.ValidarEntero(IdTextBox.Text)))
                    MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK);
                else
                   MessageBox.Show("No se puede eliminar una persona que no existe");
        }
    }
}



