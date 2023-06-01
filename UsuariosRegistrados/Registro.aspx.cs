using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsuariosRegistrados
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        GestorBBDD gestor;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                gestor = GestorBBDD.Instancia;
                gestor.Conectar();
                string email = txtEmail.Text;
                string nombre = txtNombre.Text;
                string apellidos = txtApellidos.Text;
                string password = txtPassword.Text;
                string repetirPassword = txtRepetirPassword.Text;
                string galdera = txtGaldera.Text;
                string erantzuna = txtErantzuna.Text;

                lblMensaje.Text = "";

                // Validar que los campos no estén vacíos
                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellidos) || string.IsNullOrEmpty(password) 
                    || string.IsNullOrEmpty(repetirPassword) || string.IsNullOrEmpty(galdera) || string.IsNullOrEmpty(erantzuna))
                {
                    lblError.Text = "Hay campos vacíos";
                    return;
                }

                // Validar que las contraseñas coincidan
                if (password != repetirPassword)
                {
                    // Mostrar mensaje de error indicando que las contraseñas no coinciden
                    lblError.Text = "Las contraseñas no coinciden.";
                    return;
                }

                Random random = new Random();
                int egiaztatzeZenbakia = random.Next(1000000, 10000000);

                // Llamar al método para insertar el usuario en la base de datos
                int registrosAfectados = gestor.InsertarUsuario(email, nombre, apellidos, galdera, erantzuna, egiaztatzeZenbakia, password);

                lblError.Text = "";

                // Verificar si se insertó correctamente
                if (registrosAfectados > 0)
                {
                    // Mostrar mensaje de éxito en el control lblMensaje
                    lblMensaje.Text = "Registro completado exitosamente. Hora de acceder al hipervínculo para verificar";
                    string url = "egiaztatu.aspx?erab=" + email + "&egZenb=" + egiaztatzeZenbakia;
                    HyperLink1.NavigateUrl = url;
                    HyperLink1.Visible = true;
                }
                else
                {
                    // Mostrar mensaje de error en el control lblMensaje
                    lblMensaje.Text = "Error al registrar el usuario.";
                }
                gestor.CerrarConexion();
            }
            catch (Exception ex)
            {
                // Manejar excepción o mostrar mensaje de error
            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {

        }
    }
}