using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Eestudios
/// </summary>
public class Eestudios
{
    public Eestudios()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    private String username;
    private String nivel_estudio;
    private String nombre_instituto;
    private String ciudad_instituto;
    private String año_fin;

    public string Nivel_estudio { get => nivel_estudio; set => nivel_estudio = value; }
    public string Nombre_instituto { get => nombre_instituto; set => nombre_instituto = value; }
    public string Ciudad_instituto { get => ciudad_instituto; set => ciudad_instituto = value; }
    public string Año_fin { get => año_fin; set => año_fin = value; }
    public string Username { get => username; set => username = value; }
}