using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Euser
/// </summary>
public class Euser
{
    private String nombre;
    private String apellido;
    private String correo;
    public Euser()
    {
    
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Apellido { get => apellido; set => apellido = value; }
    public string Correo { get => correo; set => correo = value; }
}