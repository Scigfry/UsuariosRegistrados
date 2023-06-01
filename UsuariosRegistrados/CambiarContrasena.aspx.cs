using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsuariosRegistrados
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        GestorBBDD gestor;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string email = Session["Email"] as string;
            
            string pwdOld = txtPasswordOld.Text;
            string password = txtPassword.Text;
            string repetirPassword = txtRepetirPassword.Text;

            lblMensaje.Text = "";

            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(pwdOld) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(repetirPassword))
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

            try
            {
                gestor = GestorBBDD.Instancia;
                gestor.Conectar();
                // Llamar al método para verificar que la contraseña coincide
                if (gestor.ValidateOldPassword(email, pwdOld))
                {
                    // Actualizamos contraseñas
                    gestor.UpdateUserPassword(email, password);
                    lblMensaje.Text = "Se ha actualizado la contraseña";
                    Session["Email"] = "";
                    gestor.CerrarConexion();
                    Response.Redirect("Inicio.aspx");
                }
                else
                {
                    lblError.Text = "La contraseña no es correcta";
                }
                lblError.Text = "";
                gestor.CerrarConexion();
            }
            catch (System.Threading.ThreadAbortException i)
            {
                //Es una respuesta normal por lo que 0 problemas
            }
            catch (Exception ex)
            {
                throw new DatabaseException(ex.Message, ex);
            }
        }
    }
}