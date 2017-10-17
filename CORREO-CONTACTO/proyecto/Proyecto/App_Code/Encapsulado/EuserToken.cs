using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EuserToken
/// </summary>
public class EuserToken
{
    public EuserToken()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    private Int32 id;
    private String nombre;
    private String correo;
    private String user_name;
    private Int32 estado;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Correo { get => correo; set => correo = value; }
    public string User_name { get => user_name; set => user_name = value; }
    public int Estado { get => estado; set => estado = value; }

}