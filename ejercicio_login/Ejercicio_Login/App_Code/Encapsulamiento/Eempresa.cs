using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Eempresa
/// </summary>
public class Eempresa
{
    public Eempresa()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }

    private String username;
    private String nombre_empresa;
    private String cargo_empresa;
    private String tiempo_empresa;
    private String jefe_empresa;

    public string Nombre_empresa { get => nombre_empresa; set => nombre_empresa = value; }
    public string Cargo_empresa { get => cargo_empresa; set => cargo_empresa = value; }
    public string Tiempo_empresa { get => tiempo_empresa; set => tiempo_empresa = value; }
    public string Jefe_empresa { get => jefe_empresa; set => jefe_empresa = value; }
    public string Username { get => username; set => username = value; }
}