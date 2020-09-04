<%@ Page Title="" Language="C#" MasterPageFile="~/AlgonquinMasterPage2.master" AutoEventWireup="true" CodeFile="XmlSchemalValidator.aspx.cs" Inherits="XmlSchemalValidator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h1>XML Validator</h1>
            <table>
                <tr>
                    <td>
                        <label for="schemaFile">Schema: </label>
                    </td>
                    <td>
                        <asp:FileUpload ID="schemaFile" AllowMultiple="false"  name="schemaFile" runat="server" /></td>
                </tr>
                <tr>
                    <td>
                        <label for="xmlFile">Xml: </label>
                    </td>
                    <td>
                        <asp:FileUpload ID="xmlFile" name="xmlFile" runat="server" AllowMultiple="false"/></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button runat="server" ID="submit"  OnClick="submit_Click" Text="Validate" /></td>
                </tr>
            </table>
            <br />
            <p><asp:Label ID="lblMessage" runat="server" Font-Bold="true"></asp:Label></p>
            <br />
            <asp:Table ID="tblErrors" runat="server" CssClass="table">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Element</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Type</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Line</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Column</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Message</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
</asp:Content>

