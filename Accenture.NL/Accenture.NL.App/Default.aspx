<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Accenture.NL.Presentacion._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h4>Users</h4>

        <div class="row" style="max-height:200px; overflow:auto">
            <div class="col-md-12">
                <asp:GridView ID="grdUser" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                    OnRowCommand="grdUser_RowCommand" CssClass="table">
                    <Columns>
                        <asp:TemplateField HeaderText="Id" ItemStyle-HorizontalAlign="Left" Visible="false">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Id")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Name")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User-Name" ItemStyle-HorizontalAlign="Left"
                            ItemStyle-Width="20%">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "UserName")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Email")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField CommandName="Post" HeaderText="Post" 
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  ControlStyle-CssClass="fa fa-comments-o" />
                        <asp:ButtonField CommandName="Album" HeaderText="Album"   
                            ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ControlStyle-CssClass="fa fa-image" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row" runat="server" id="divPosts" style="padding-top:2%">
            <div class="col-md-6">
                <h4>Posts</h4>
                <asp:GridView ID="grdPosts" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                    CssClass="table" OnRowCommand="grdPosts_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Id" ItemStyle-HorizontalAlign="Left" Visible="false">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Id")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Id" ItemStyle-HorizontalAlign="Left" Visible="false">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Comments")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Title" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="40%">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Title")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Body" ItemStyle-HorizontalAlign="Left"
                            ItemStyle-Width="55%">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Body")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField ItemStyle-Width="5%" CommandName="Comment" ItemStyle-HorizontalAlign="Center" 
                            ControlStyle-CssClass="fa fa-commenting" HeaderText="Comment"  />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-6">
                <h4>Comments</h4>
                <asp:GridView ID="grdComments" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                    CssClass="table">
                    <Columns>
                        <asp:TemplateField HeaderText="Name" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Name")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Email")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Body" ItemStyle-HorizontalAlign="Left"
                            ItemStyle-Width="60%">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Body")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="row" runat="server" id="divAlbums" style="padding-top:2%">
            <div class="col-md-5">
                <h4>Albums</h4>
                <asp:GridView ID="grdAlbum" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                    CssClass="table" OnRowCommand="grdAlbum_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Id" ItemStyle-HorizontalAlign="Left" Visible="false">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Id")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Title" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Title")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField CommandName="Photo" HeaderText="Photos" ItemStyle-HorizontalAlign="Center" 
                            ControlStyle-CssClass="fa fa-picture-o"/>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-7">
                <h4>Photos</h4>
                <asp:GridView ID="grdPhoto" runat="server" AutoGenerateColumns="false" DataKeyNames="Id"
                    CssClass="table">
                    <Columns>
                        <asp:TemplateField HeaderText="Title" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Title")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField HeaderText="Url" ItemStyle-HorizontalAlign="Left">
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "Url")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>

        </div>
    </div>



</asp:Content>
