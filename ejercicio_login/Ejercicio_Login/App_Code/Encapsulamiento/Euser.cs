using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Euser
/// </summary>
public class Euser
{
    public Euser()
    {
        
    }
    private String nombre;
    private String username;
    private String clave;
    private String telefono;
    private String email;
    private String profesion;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Username { get => username; set => username = value; }
    public string Clave { get => clave; set => clave = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public string Email { get => email; set => email = value; }
    public string Profesion { get => profesion; set => profesion = value; }
}