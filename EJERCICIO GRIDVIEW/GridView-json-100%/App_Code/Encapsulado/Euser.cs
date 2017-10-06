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
    private String contrasena;
    private String pais;
    private String depto;
    private String fecha;
    private String sexo;
    private String url;
    private Boolean info;
    private Boolean acept;
    public Euser()
    {
    
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Apellido { get => apellido; set => apellido = value; }
    public string Correo { get => correo; set => correo = value; }
    public string Contrasena { get => contrasena; set => contrasena = value; }
    public string Pais { get => pais; set => pais = value; }
    public string Depto { get => depto; set => depto = value; }
    public string Fecha { get => fecha; set => fecha = value; }
    public string Sexo { get => sexo; set => sexo = value; }
    public string Url { get => url; set => url = value; }
    public bool Info { get => info; set => info = value; }
    public bool Acept { get => acept; set => acept = value; }
}