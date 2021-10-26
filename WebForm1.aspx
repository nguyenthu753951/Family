<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="controller.WebForm1" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="display:flex;justify-content:center;align-items:center;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Width="100%">
                <LocalReport ReportPath="Report\Report1.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource2" Name="DataSet1" />
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" Name="DataSet2" />
                        <rsweb:ReportDataSource DataSourceId="ObjectDataSource4" Name="DataSet3" />
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>
            <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="controller.DOANONLINEDataSetTableAdapters.HOA_DONTableAdapter" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_MA_HD" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="MA_HD" Type="String" />
                    <asp:Parameter Name="TONG_TIEN_HD" Type="Double" />
                    <asp:Parameter Name="NGAY_LAP_HD" Type="DateTime" />
                    <asp:Parameter Name="MA_NV" Type="Int64" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="TONG_TIEN_HD" Type="Double" />
                    <asp:Parameter Name="NGAY_LAP_HD" Type="DateTime" />
                    <asp:Parameter Name="MA_NV" Type="Int64" />
                    <asp:Parameter Name="Original_MA_HD" Type="String" />
                </UpdateParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="controller.DOANONLINEDataSetTableAdapters.DON_HANGTableAdapter" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_MA_DH" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="MA_DH" Type="String" />
                    <asp:Parameter Name="PHI_GIAO_HANG" Type="Decimal" />
                    <asp:Parameter Name="NGAY_LAP_HD" Type="DateTime" />
                    <asp:Parameter Name="NGAY_HEN_GIAO" Type="DateTime" />
                    <asp:Parameter Name="MA_KH" Type="String" />
                    <asp:Parameter Name="MA_TX" Type="String" />
                    <asp:Parameter Name="LOAI" Type="String" />
                    <asp:Parameter Name="HINH_ANH" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="PHI_GIAO_HANG" Type="Decimal" />
                    <asp:Parameter Name="NGAY_LAP_HD" Type="DateTime" />
                    <asp:Parameter Name="NGAY_HEN_GIAO" Type="DateTime" />
                    <asp:Parameter Name="MA_KH" Type="String" />
                    <asp:Parameter Name="MA_TX" Type="String" />
                    <asp:Parameter Name="LOAI" Type="String" />
                    <asp:Parameter Name="HINH_ANH" Type="String" />
                    <asp:Parameter Name="Original_MA_DH" Type="String" />
                </UpdateParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="controller.DOANONLINEDataSetTableAdapters.CT_DONHANGTableAdapter" UpdateMethod="Update">
                <DeleteParameters>
                    <asp:Parameter Name="Original_MA_MON_AN" Type="String" />
                    <asp:Parameter Name="Original_MA_DH" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="MA_MON_AN" Type="String" />
                    <asp:Parameter Name="MA_DH" Type="String" />
                    <asp:Parameter Name="SL" Type="Int32" />
                    <asp:Parameter Name="GIABAN" Type="Decimal" />
                    <asp:Parameter Name="TEN_MON" Type="String" />
                    <asp:Parameter Name="HINH_ANH" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="SL" Type="Int32" />
                    <asp:Parameter Name="GIABAN" Type="Decimal" />
                    <asp:Parameter Name="TEN_MON" Type="String" />
                    <asp:Parameter Name="HINH_ANH" Type="String" />
                    <asp:Parameter Name="Original_MA_MON_AN" Type="String" />
                    <asp:Parameter Name="Original_MA_DH" Type="String" />
                </UpdateParameters>
            </asp:ObjectDataSource>
        </div>
    </form>
</body>
</html>
