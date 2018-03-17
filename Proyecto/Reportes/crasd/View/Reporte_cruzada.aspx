<%@ Page Language="C#" AutoEventWireup="true" CodeFile="~/Controller/Reporte_cruzada.aspx.cs" Inherits="View_Reporte_cruzada" %>

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
    
        <CR:CrystalReportViewer ID="CRVpuntuacion" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="50px" ReportSourceID="CRSpuntuacion" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="350px" />
        <CR:CrystalReportSource ID="CRSpuntuacion" runat="server">
            <Report FileName="C:\Users\juandavid\Documents\crasd\Reportes\CruzadoReport.rpt">
            </Report>
        </CR:CrystalReportSource>
    
    </div>
    </form>
</body>
</html>
