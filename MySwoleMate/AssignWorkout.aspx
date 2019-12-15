<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MySwoleMate.Master" AutoEventWireup="true" CodeBehind="AssignWorkout.aspx.cs" Inherits="MySwoleMate.AssignWorkout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="first">
        <div class="container">
            <div class="row">
                <div class="col-xs-10">
                    <h1>Assign a 5-Step Workout</h1>
                </div>
                <div class="col-xs-2">
                    <a href="~/Default.aspx" runat="server" class="btn btn-success">Home</a>
                </div>
            </div>
            <div>
                <asp:Label ID="TraineeName" runat="server" CssClass="h2"></asp:Label>
            </div>
            <div class="row">
                <div class="col-xs-6 col-xs-offset-2 text-center">
                    <asp:DropDownList ID="WorkoutsDDL" runat="server" CssClass="form-control" ></asp:DropDownList>
                    <div class="has-error">
                        <span class="help-block">
                            <asp:RequiredFieldValidator ID="WorkoutRequired" runat="server" ErrorMessage="Please Select a Workout"
                                ControlToValidate="WorkoutsDDL" InitialValue="-- Select a Workout --" Display="Dynamic" 
                                ValidationGroup="AllValidators"></asp:RequiredFieldValidator>
                        </span>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <div class="col-xs-4 col-xs-offset-4">
                    <asp:Button ID="AssignWorkoutButton" runat="server" Text="Submit" CssClass="btn btn-success"
                            ValidationGroup="AllValidators" OnClick="AssignWorkoutButton_Click" />
                    <a href="~/Trainees.aspx" runat="server" class="btn btn-default">Back</a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>