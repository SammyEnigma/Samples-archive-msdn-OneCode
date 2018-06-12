﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="VBASPNetCRUDXmlInGridView._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Xml-based CRUD Code Sample</title>
    <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.5.1.min.js"></script>
    <script type="text/javascript">


        $(function () {

            // Find each row of the GridView
            $("tr").each(function () {

                // Find each table cell of the row and find the second linkbutton,
                // Add the confirm dialog before deleting.
                $(this).find("td:eq(0)>a:eq(1)").click(function () {

                    return confirm("Are you sure to delete?");
                });

            });
        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>
            Xml-based CRUD Code Sample——</h2>
        <asp:GridView ID="GridView1" runat="server" Width="70%" AutoGenerateDeleteButton="True"
            AutoGenerateEditButton="True" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None"
            BorderWidth="1px" CellPadding="3" CellSpacing="2" OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FFF1D4" />
            <SortedAscendingHeaderStyle BackColor="#B95C30" />
            <SortedDescendingCellStyle BackColor="#F1E5CE" />
            <SortedDescendingHeaderStyle BackColor="#93451F" />
        </asp:GridView>
    </div>
    <p>
        Id：<asp:TextBox ID="tbId" runat="server"></asp:TextBox>
    </p>
    <p>
        author：<asp:TextBox ID="tbAuthor" runat="server"></asp:TextBox>
    </p>
    <p>
        title：<asp:TextBox ID="tbTitle" runat="server"></asp:TextBox>
    </p>
    <p>
        genre：<asp:TextBox ID="tbGenre" runat="server"></asp:TextBox>
    </p>
    <p>
        price：<asp:TextBox ID="tbPrice" runat="server"></asp:TextBox>
    </p>
    <p>
        publishdate：<asp:TextBox ID="tbPublishDate" runat="server"></asp:TextBox>
    </p>
    <p>
        description：<asp:TextBox ID="tbDescription" runat="server"></asp:TextBox>
    </p>
    <asp:Button ID="btnInsert" runat="server" Height="26px" OnClick="btnInsert_Click"
        Text="Insert" Width="141px" />
    </form>
</body>
</html>
