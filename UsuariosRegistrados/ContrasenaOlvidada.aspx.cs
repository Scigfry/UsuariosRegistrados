using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsuariosRegistrados
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        GestorBBDD gestor;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPregunta_Click(object sender, EventArgs e)
        {
            // Obtener el valor del email del TextBox
            string email = txtEmail.Text;
            string pregunta = "";

            // Guardar el email en la sesión
            Session["Email"] = email;
            try
            {
                gestor = GestorBBDD.Instancia;
                gestor.Conectar();
                // Obtener la pregunta oculta para el email proporcionado
                pregunta = gestor.ObtenerPregunta(email);
                gestor.CerrarConexion();
            } 
            catch (Exception ex)
            {
                throw new ConnectionException("Error al conectarse a la BBDD.", ex);
            }

            // Mostrar la pregunta en el Label
            labelPregunta.Text = pregunta;
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            // Obtener el valor del email de la sesión
            string email = Session["Email"] as string;
            string pwd = "";

            // Obtener la respuesta proporcionada por el usuario
            string respuesta = txtRespuesta.Text;
            try
            {
                gestor = GestorBBDD.Instancia;
                gestor.Conectar();
                // Verificar la respuesta para el email proporcionado
                pwd = gestor.VerificarRespuesta(email, respuesta);
                gestor.CerrarConexion();
            } 
            catch (Exception ex)
            {
                throw new ConnectionException("Error al conectarse a la BBDD.", ex);
            }
            if (pwd.Equals(""))
            {
                //No es la respuesta correcta
                lblContrasena.Text = "No es la respuesta correcta";
            }
            else
            {
                lblContrasena.Text = "Tu contraseña es:\t" + pwd;
            }
        }
    }
}