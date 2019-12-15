<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MySwoleMate.Master" AutoEventWireup="true" CodeBehind="Workouts.aspx.cs" Inherits="MySwoleMate.Workouts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="first">
        <div class="container">
            <div class="row">
                <div class="col-xs-10">
                    <h1>Workout Plan</h1>
                </div>
                <div class="col-xs-2">
                    <a href="~/AddWorkout.aspx" runat="server" class="btn btn-success">Add New Workout</a>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 text-center">
                    <asp:GridView ID="WorkoutList" runat="server" CssClass="table table-bordered text-left"
                        AutoGenerateColumns="False" OnRowDeleting="WorkoutList_RowDeleting" DataKeyNames="WorkoutID">
                        <Columns>
                            <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="WorkoutID"
                                DataNavigateUrlFormatString="~/EditWorkout.aspx?WorkoutID={0}" ControlStyle-CssClass="btn btn-success btn-xs"
                                ItemStyle-CssClass="text-center" />
                            <asp:TemplateField ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <%--The Delete functionality is --%>
                                    <asp:Button runat="server" ID="DeleteButton" CommandName="Delete"
                                        CssClass="btn btn-xs btn-default" Text="Delete"
                                        OnClientClick="if(!confirm('Are you sure you wish to delete this trainee?')) return false;" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="WorkoutName" HeaderText="Workout" />
                            <asp:BoundField DataField="DisplayExercise1" HeaderText="Step 1" />
                            <asp:BoundField DataField="DisplayExercise2" HeaderText="Step 2" />
                            <asp:BoundField DataField="DisplayExercise3" HeaderText="Step 3" />
                            <asp:BoundField DataField="DisplayExercise4" HeaderText="Step 4" />
                            <asp:BoundField DataField="DisplayExercise5" HeaderText="Step 5" />
                           
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
