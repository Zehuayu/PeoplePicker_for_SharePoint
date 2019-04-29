﻿<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PickerDemoUserControl.ascx.cs" Inherits="PeoplePicking.PickerDemo.PickerDemoUserControl" %>

<table style="width: 700px; height: 300px;" >
    
    <td valign="top" style="width: 25%; border: solid 1px #cbcbcb">
         <div style="height: 25px;" class="t1">
        <span style="line-height: 25px">公司人员选择（XX公司）</span>
    </div>
    <div style="overflow: auto; height: 254px; width: 200px;">
    <table style="height: 229px">
        <tr>
            <td>
                <asp:TreeView ID="TreeView1" BackColor="WindowFrame"  runat="server" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" Width="194px" Height="222px" AutoGenerateDataBindings="true"  Font-Size="18px" style="margin-top: 0px">
                </asp:TreeView>
            </td>       
        </tr>
    </table>
    </div>
    </td>

    <td valign="top" style="width: 25%; border: solid 1px #cbcbcb">
         <div style="height: 25px;" class="t1">
        <span style="line-height: 25px">员工名称（XX公司）</span>
    </div>
    <div style="overflow: auto; height: 254px; width: 200px;">
    <table style="height: 230px; width: 200px;">
        <tr>
            <td>
                <asp:ListBox ID="ListBox1" Font-Size="18px" BackColor="WindowFrame" runat="server" Width="192px" Height="204px" style="margin-left: 0px">
                </asp:ListBox>
                <asp:Button ID="Pick1" runat="server" Text="To Right" OnClick="Pick1_Click" />

                <asp:Button ID="allpick" runat="server" Text="ALL2Right" OnClick="allpick_Click" />
            </td>       
        </tr>
    </table>
    </div>
    </td>
     <td valign="top" style="width: 25%; border: solid 1px #cbcbcb">
         <div style="height: 25px;" class="t1">
        <span style="line-height: 25px">挑选的员工（XX公司）</span>
    </div>
    <div style="overflow: auto; height: 254px; width: 200px;">
    <table style="height: 230px; width: 200px;">
        <tr>
            <td>
                <asp:ListBox ID="ListBox2" BackColor="WindowFrame" Font-Size="18px" runat="server" Width="189px" Height="203px" style="margin-left: 0px">
                </asp:ListBox>
                <asp:Button ID="Pick2" runat="server" Text="清空" />
                
            </td>       
        </tr>
    </table>
    </div>
    </td>
    
    
   
   
</table>

