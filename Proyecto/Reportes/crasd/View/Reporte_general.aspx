<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/Reporte_general.aspx.cs" Inherits="View_Reporte_general" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <CR:CrystalReportViewer ID="CRVusuario" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="Id" Height="50px" ReportSourceID="CRSusuario" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" ToolPanelView="None" />
        sadsadasd<CR:CrystalReportSource ID="CRSusuario" runat="server">
            <report filename="C:\Users\juandavid\Documents\crasd\Reportes\GeneralReport.rpt">
            </report>
        </CR:CrystalReportSource>
    
    </div>
    </form>
</body>
</html>
