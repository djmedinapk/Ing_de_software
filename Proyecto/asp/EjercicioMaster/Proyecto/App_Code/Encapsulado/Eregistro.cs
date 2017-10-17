using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Eregistro
/// </summary>
public class Eregistro
{
    public Eregistro()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    private String username;
    private String password;
    private String correo;

    public string Username { get => username; set => username = value; }
    public string Password { get => password; set => password = value; }
    public string Correo { get => correo; set => correo = value; }
}