using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Eusuario
/// </summary>
public class Eusuario
{
    public Eusuario()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    private Int32 userId;
    private String session;
    private String ip;
    private String mac;


    public string Session { get => session; set => session = value; }
    public string Ip { get => ip; set => ip = value; }
    public string Mac { get => mac; set => mac = value; }
    public int UserId { get => userId; set => userId = value; }
}