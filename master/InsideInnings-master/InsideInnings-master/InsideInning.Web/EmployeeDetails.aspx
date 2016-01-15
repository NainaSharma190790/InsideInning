<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeDetails.aspx.cs" Inherits="InsideInning.Web.EmployeeDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <img alt="" src="Images/index.jpg" style="height: 129px; width: 130px" /><table class="auto-style1">
            <tr>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
        </div>
        <table class="auto-style1">
            <tr>
                <td>Marital Status</td>
                <td>
                    <asp:RadioButton ID="RadioBtnMarried" runat="server" GroupName="MaritalStatus" Text="Married" />
                    <asp:RadioButton ID="RadioBtnSingle" runat="server" GroupName="MaritalStatus" Text="Single" />
                </td>
            </tr>
            <tr>
                <td>Gender</td>
                <td>
                    <asp:RadioButton ID="RadioBtnMale" runat="server" GroupName="Gender" Text="Male" />
                    <asp:RadioButton ID="RadioBtnFeMale" runat="server" GroupName="Gender" Text="Female" />
                </td>
            </tr>
            <tr>
                <td>&nbsp;Date Of Birth</td>
                <td>
                    <asp:Calendar ID="DOBCal" runat="server"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>Date Of Aniversary</td>
                <td>
                    <asp:Calendar ID="DOACal" runat="server"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Contact Number</td>
                <td class="auto-style2">
                    <asp:TextBox ID="ContactTxtbox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Land Line No.</td>
                <td>
                    <asp:TextBox ID="lanlinetxtbox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Comapany Profile</td>
                <td>
                    <asp:TextBox ID="CompanyProfilrTxtbox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Joinning Date</td>
                <td>
                    <asp:Calendar ID="JoinCal" runat="server"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>IsActive</td>
                <td>
                    <asp:CheckBox ID="CheckIsActive" runat="server" Text="IsActive" />
                </td>
            </tr>
        </table>
        <table class="auto-style1">
            <tr>
                <td>
                    <asp:Button ID="BtnSave" runat="server" Font-Bold="True" Text="Save" OnClick="BtnSave_Click" />
                    <asp:Button ID="BtnCancel" runat="server" Font-Bold="True" Text="Cancel" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
