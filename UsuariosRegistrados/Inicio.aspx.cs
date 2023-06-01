using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UsuariosRegistrados
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        GestorBBDD gestor;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtContraseña.Text))
            {
                lblMensaje.Text = "Error en el login, campos vacios";
                return;
            }
            try
            {
                gestor = GestorBBDD.Instancia;
                gestor.Conectar();

                string mail = txtEmail.Text;
                int logeo = gestor.Login(mail, txtContraseña.Text);
                if (logeo > 0)
                {
                    bool verificado = gestor.ObtenerUsuarioVerificado(mail).HasRows;
                    gestor.CerrarConexion();
                    if (verificado)
                    {
                        Session["Email"] = txtEmail.Text;
                        Response.Redirect("Menu.aspx");
                    }
                    else
                    {
                        lblMensaje.Text = "Error en el login, campos correctos, pero usuario no validado";
                    }
                } 
                else
                {
                    gestor.CerrarConexion();
                    lblMensaje.Text = "Error en el login, campos incorrectos"; 
                }
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