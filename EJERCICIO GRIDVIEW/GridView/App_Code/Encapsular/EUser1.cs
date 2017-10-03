using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de EUser1
/// </summary>
public class EUser1
{
    public EUser1()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    private String nombre;
    private String apellido;
    private String correo;
    private String contrasena;
    private String sexo;
    private String marca;
    private String referencia;
    private String url;
    private String fecha;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Apellido { get => apellido; set => apellido = value; }

    public string Contrasena { get => contrasena; set => contrasena = value; }

    public string Url { get => url; set => url = value; }
    public string Correo { get => correo; set => correo = value; }
    public string Sexo { get => sexo; set => sexo = value; }
    public string Marca { get => marca; set => marca = value; }
    public string Referencia { get => referencia; set => referencia = value; }
    public string Fecha { get => fecha; set => fecha = value; }
}