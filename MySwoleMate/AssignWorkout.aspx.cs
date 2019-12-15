using MySwoleMate.BLL;
using MySwoleMate.Models; 
using System;
using System.Configuration; 
using System.Web.UI;


namespace MySwoleMate
{
    public partial class AssignWorkout : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MySwoleMateConnectionString"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Show Trainee Name at top
                TraineeBLL Tbll = new TraineeBLL(connectionString);
                TraineeViewModel trainee = Tbll.GetTraineeById(Convert.ToInt32(Request.QueryString["TraineeID"]));
                TraineeName.Text = trainee.FirstName + " " + trainee.LastName;

                //Bind DropDownList to text to the WorkoutName and the value to
                //the WorkoutID associated with the name
                WorkoutBLL bll = new WorkoutBLL(connectionString);

                WorkoutsDDL.DataSource = bll.GetAllWorkouts();
                WorkoutsDDL.DataTextField = "WorkoutName";
                WorkoutsDDL.DataValueField = "WorkoutID";
                WorkoutsDDL.DataBind();

                WorkoutsDDL.Items.Insert(0, "-- Select a Workout --");
            }
        }

        protected void AssignWorkoutButton_Click(object sender, EventArgs e)
        {
            TraineeBLL bll = new TraineeBLL(connectionString);
            TraineeViewModel trainee = bll.GetTraineeById(Convert.ToInt32(Request.QueryString["TraineeID"]));

            //Set WorkoutID Foreign Key in Trainee to selected workout
            trainee.WorkoutID = Convert.ToInt32(WorkoutsDDL.SelectedValue);
            //Pass trainee to commit edits
            bll.EditTrainee(trainee);
            //Redirect back to the Trainees page
            Response.Redirect("~/Trainees.aspx");
        }

    }
}