using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsuariosRegistrados
{
    public partial class WebForm3 : Page
    {
        GestorBBDD gestor;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Crear una instancia de la clase GestorBBDD
            gestor = GestorBBDD.Instancia;
            gestor.Conectar();

            // Obtener los parámetros de la URL (erab y egZenb)
            string email = Request.QueryString["erab"];
            string egiaztatzeZenbakia = Request.QueryString["egZenb"];

            // Realizar la verificación de la identificación y el número de verificación
            int verificado = ComprobarUsuario(email, egiaztatzeZenbakia);

            if (verificado > 0)
            {
                // Mostrar un mensaje de éxito en la página
                lblMessage.Visible = true;
                lblMessage.Text = "Verificación exitosa. Puede acceder a la aplicación.";
            }
            else
            {
                // Mostrar un mensaje de error en la página
                lblMessage.Visible = true;
                lblMessage.Text = "Error de verificación. Por favor, intente nuevamente.";
            }
            gestor.CerrarConexion();
        }

        private int ComprobarUsuario(string email, string egiaztatzeZenbakia)
        {
            

            try
            {
                // Verificar la identificación y el número de verificación utilizando la función ComprobarUsuario
                return gestor.ComprobarUsuario(email, egiaztatzeZenbakia);
            }
            catch (Exception ex)
            {
                // Manejar la excepción, mostrar un mensaje de error si es necesario
                // y devolver false en caso de error de verificación
                return 0;
            }
        }
    }
}