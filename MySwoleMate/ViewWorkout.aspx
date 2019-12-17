<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MySwoleMate.Master" AutoEventWireup="true" CodeBehind="ViewWorkout.aspx.cs" Inherits="MySwoleMate.ViewWorkout" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="first">
        <div class="container">
            <div class="row">
                <div class="col-xs-10">
                    <h1>Assigned Workout</h1>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-10">
                    <h1 id="TraineeName" runat="server" class="text-center"></h1>
                    <h3 id="WorkoutName" runat="server" class="text-center"></h3>
                    <h3 id="Step1" runat="server" class="text-center"></h3>
                    <h3 id="Step2" runat="server" class="text-center"></h3>
                    <h3 id="Step3" runat="server" class="text-center"></h3>
                    <h3 id="Step4" runat="server" class="text-center"></h3>
                    <h3 id="Step5" runat="server" class="text-center"></h3>

                    <asp:HyperLink ID="AssignHyper" Text="Assign Workout" runat="server" 
                        CssClass="btn-success center-block text-center btn-lg"></asp:HyperLink>
                    <a href="~/Trainees.aspx" runat="server" class="btn btn-default center-block">Back</a>
                </div>
                <div>
                    
                </div>
            </div>
        </div>
    </section>
</asp:Content>