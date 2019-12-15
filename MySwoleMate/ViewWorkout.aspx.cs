using MySwoleMate.BLL;
using MySwoleMate.Models; 
using System;
using System.Collections.Generic;
using System.Configuration; 

namespace MySwoleMate
{
    public partial class ViewWorkout : System.Web.UI.Page
    {
        TraineeBLL Tbll = new TraineeBLL(ConfigurationManager.ConnectionStrings["MySwoleMateConnectionString"].ToString());
        WorkoutBLL Wbll = new WorkoutBLL(ConfigurationManager.ConnectionStrings["MySwoleMateConnectionString"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TraineeViewModel trainee = Tbll.GetTraineeById(Convert.ToInt32(Request.QueryString["TraineeID"]));
                TraineeName.InnerText = trainee.FirstName + " " + trainee.LastName;

                WorkoutViewModel workout = Wbll.GetWorkoutById(Convert.ToInt32(trainee.WorkoutID));

                WorkoutName.InnerText = trainee.WorkoutID.ToString();
                if (trainee.WorkoutID == 0)
                {
                    WorkoutName.InnerText = "This trainee has not been assigned a workout";
                }
                else
                {
                    WorkoutName.InnerText = workout.WorkoutName;
                    Step1.InnerText = workout.DisplayExercise1;
                    Step2.InnerText = workout.DisplayExercise2;
                    Step3.InnerText = workout.DisplayExercise3;
                    Step4.InnerText = workout.DisplayExercise4;
                    Step5.InnerText = workout.DisplayExercise5;
                }

                AssignHyper.NavigateUrl = "~/AssignWorkout.aspx?TraineeID=" + trainee.TraineeID;
            }
        }

        protected void Assign_DataBinding(object sender, EventArgs e)
        {

        }
    }
}