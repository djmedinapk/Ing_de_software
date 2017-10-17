using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class view_restaurar_contraseña : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        L_respuesta.Text = "";
    }

    protected void B_recuperar_Click(object sender, EventArgs e)
    {
        DAOResetPass reset = new DAOResetPass();
        System.Data.DataTable validez = reset.GenerarToken(TResetPassUser.Text);

        if (int.Parse(validez.Rows[0]["id"].ToString()) > 0 && int.Parse(validez.Rows[0]["estado_session"].ToString()) == 1 )
        {
            EuserToken token = new EuserToken();
            token.Id = int.Parse(validez.Rows[0]["id"].ToString());
            token.User_name = validez.Rows[0]["username"].ToString();
            token.Estado = int.Parse(validez.Rows[0]["estado_session"].ToString());
            token.Correo = validez.Rows[0]["correo"].ToString();
            String Token_json = JsonConvert.SerializeObject(token);
            String userToken = encriptar(Token_json);
            reset.AlmacenarToken(userToken, token.Id);
            Correo correo = new Correo();
            String mensaje = "Para continuar con su restablecimiento de contraseña, por favor ingrese al siguiente link: " 
                + "http://localhost:52200/View/nueva_contraseña.aspx?" + userToken + "  El link funcionara por los próximos 60 minutos después de enviado este correo, después de eso tendrá que volver a solicitar la recuperación de contraseña. "
                +" Atentamente, el equipo de FOROUDEC";
            correo.enviarCorreo(token.Correo, userToken, mensaje);
            L_respuesta.ForeColor = System.Drawing.Color.Green;
            L_respuesta.Text = "Se ha enviado un link de acceso a su correo electrónico";
            reset.ActualizarEstado(token.User_name);
        }
        else if (int.Parse(validez.Rows[0]["estado_session"].ToString()) == 2)
        {
            L_respuesta.ForeColor = System.Drawing.Color.Blue;
            L_respuesta.Text = "Ya existe una solicitud de restablecimiento, por favor revise su correo electrónico";
        }
        else
        {
            L_respuesta.ForeColor = System.Drawing.Color.Red;
            L_respuesta.Text = "El usuario digitado no se encuentra registrado";
        }
    }

    private string encriptar(string input)
    {
        SHA256CryptoServiceProvider provider = new SHA256CryptoServiceProvider();

        byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        byte[] hashedBytes = provider.ComputeHash(inputBytes);

        StringBuilder output = new StringBuilder();

        for (int i = 0; i < hashedBytes.Length; i++)
            output.Append(hashedBytes[i].ToString("x2").ToLower());

        return output.ToString();
    }
}