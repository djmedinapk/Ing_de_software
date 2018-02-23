using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;


public class MAC
{
    public MAC()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public String mac()
    {

        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

        String sMacAddress = string.Empty;

        foreach (NetworkInterface adapter in nics)
        {

            if (sMacAddress == String.Empty) // only return MAC Address from first card    
            {

                IPInterfaceProperties properties = adapter.GetIPProperties();

                sMacAddress = adapter.GetPhysicalAddress().ToString();

            }

        }
        return sMacAddress;

    }


    public String ip()
    {
        string IP4Address = String.Empty;

        foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
        {
            if (IPA.AddressFamily == AddressFamily.InterNetwork)
            {
                IP4Address = IPA.ToString();
                break;
            }
        }

        return IP4Address;
    }



}


