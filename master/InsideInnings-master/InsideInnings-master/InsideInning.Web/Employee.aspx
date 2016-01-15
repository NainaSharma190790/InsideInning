<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Employee.aspx.cs" Inherits="InsideInning.Web.Employee" %>

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
        .auto-style3 {
            height: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td>First Name</td>
                <td>
                    <asp:TextBox ID="EmployeeFirstName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Last Name</td>
                <td>
                    <asp:TextBox ID="EmployeeLastName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>EmailAddress</td>
                <td>
                    <asp:TextBox ID="EmployeeEmail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="EmployeePassword" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">EmployeeType</td>
                <td class="auto-style3">
                    <asp:RadioButton ID="RadioBtnAdmin" runat="server" GroupName="EmpType" Text="Admin" />
                    <asp:RadioButton ID="RadioBtnStaff" runat="server" GroupName="EmpType" Text="Staff" />
                </td>
            </tr>
            <tr>
                <td>IsActive</td>
                <td>
                    <asp:CheckBox ID="IsActive" runat="server" Text="IsActive" />
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Button ID="Save" runat="server" OnClick="Save_Click" Text="Save" />
                    <asp:Button ID="Cancel" runat="server" OnClick="Cancel_Click" Text="Cancel" />
                </td>
                <td class="auto-style2">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
