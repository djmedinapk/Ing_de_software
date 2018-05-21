using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Persistence
{
    public class PsqlServicios
    {

        //public DataSet ver_post_home_categoria(string orden)
        //{
        //    DataSet datos = new DataSet();

        //    //using (ForoUdecEntities1 db = new ForoUdecEntities1())
        //    //{
        //    //    var a = db.f_listar_post_home_servicios(orden).ToList();
        //    //    ConverToDataTable salida = new ConverToDataTable();
        //    //    datos = salida.ConvertToDataTable(a);
        //    //}

                        
        //        return datos;
        //}

        //public DataTable login(String username, String pass)
        //{
        //    DataTable datos = new DataTable();

        //    using (ForoUdecEntities1 db = new ForoUdecEntities1())
        //    {

        //        var a = db.f_loggin(username,pass).ToList();
        //        ConverToDataTable salida = new ConverToDataTable();
        //        datos = salida.ConvertToDataTable(a);

        //    }

        //        return datos;
        //}

        //public DataTable validarToken(String token, String fuente)
        //{
        //    //ejemplo base de datos con token
        //    DataTable tokens = new DataTable();
        //    tokens.Columns.Add("Id");
        //    tokens.Columns.Add("token");
        //    tokens.Columns.Add("fuente");
        //    ///fin- ejemplo
        //    ///tabla de datos ejemplo de respuesta del postgres
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("respuesta");
        //    ///fin-ejemplo

        //    DataRow row = tokens.NewRow();
        //    row["Id"] = 1;
        //    row["token"] = "21sad81asda328as15d1bsd8b4a121d8g44j21lji513j-app";
        //    row["fuente"] = "Ionic";
        //    tokens.Rows.Add(row);
        //    DataRow row2 = tokens.NewRow();
        //    row2["Id"] = 2;
        //    row2["token"] = "11221312ds2d1asd5qd1321daaf32sse24213412321da-mtb";
        //    row2["fuente"] = "mtb-competence";
        //    tokens.Rows.Add(row2);

        //    for (int i = 0; i < tokens.Rows.Count; i++)
        //    {
        //        if (tokens.Rows[i][1].ToString() == token && tokens.Rows[i][2].ToString() == fuente)
        //        {
        //            DataRow auxrow = dt.NewRow();
        //            auxrow["respuesta"] = "true";
        //            dt.Rows.Add(auxrow);
        //        }
        //    }

        //    return dt;
        //}
    }
}
