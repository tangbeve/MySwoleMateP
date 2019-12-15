using MySwoleMate.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySwoleMate.DAL
{
    public class WorkoutDAL
    {
        private string _connectionString;

        public WorkoutDAL(string connectionstring)
        {
            _connectionString = connectionstring;
        }

        public List<WorkoutViewModel> GetWorkouts()
        {
            string sqlQuery = "Select * FROM Workout";

            List<WorkoutViewModel> workouts = new List<WorkoutViewModel>();


            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        WorkoutViewModel temp = new WorkoutViewModel()
                        {
                            WorkoutID = Convert.ToInt32(reader["WorkoutID"]),
                            WorkoutName = reader["WorkoutName"].ToString(), 
                            Exercise1 = reader["Exercise1"].ToString(),
                            Exercise1Sets = Convert.ToInt32(reader["Exercise1Sets"]),
                            Exercise1Reps = Convert.ToInt32(reader["Exercise1Reps"]),
                            Exercise2 = reader["Exercise2"].ToString(),
                            Exercise2Sets = Convert.ToInt32(reader["Exercise2Sets"]),
                            Exercise2Reps = Convert.ToInt32(reader["Exercise2Reps"]),
                            Exercise3 = reader["Exercise3"].ToString(),
                            Exercise3Sets = Convert.ToInt32(reader["Exercise3Sets"]),
                            Exercise3Reps = Convert.ToInt32(reader["Exercise3Reps"]),
                            Exercise4 = reader["Exercise4"].ToString(),
                            Exercise4Sets = Convert.ToInt32(reader["Exercise4Sets"]),
                            Exercise4Reps = Convert.ToInt32(reader["Exercise4Reps"]),
                            Exercise5 = reader["Exercise5"].ToString(),
                            Exercise5Sets = Convert.ToInt32(reader["Exercise5Sets"]),
                            Exercise5Reps = Convert.ToInt32(reader["Exercise5Reps"]),


                        };

                        workouts.Add(temp);
                    }
                }
            }
            return workouts;

        }

        public WorkoutViewModel GetWorkoutById(int id)
        {
            WorkoutViewModel workout = new WorkoutViewModel();
            string sqlQuery = "Select * from Workout where WorkoutID=@ID";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        workout.WorkoutID = Convert.ToInt32(reader["WorkoutID"]);
                        workout.WorkoutName = reader["WorkoutName"].ToString(); 
                        workout.Exercise1 = reader["Exercise1"].ToString();
                        workout.Exercise1Sets = Convert.ToInt32(reader["Exercise1Sets"]);
                        workout.Exercise1Reps = Convert.ToInt32(reader["Exercise1Reps"]);
                        workout.Exercise2 = reader["Exercise2"].ToString();
                        workout.Exercise2Sets = Convert.ToInt32(reader["Exercise2Sets"]);
                        workout.Exercise2Reps = Convert.ToInt32(reader["Exercise2Reps"]);
                        workout.Exercise3 = reader["Exercise3"].ToString();
                        workout.Exercise3Sets = Convert.ToInt32(reader["Exercise3Sets"]);
                        workout.Exercise3Reps = Convert.ToInt32(reader["Exercise3Reps"]);
                        workout.Exercise4 = reader["Exercise4"].ToString();
                        workout.Exercise4Sets = Convert.ToInt32(reader["Exercise4Sets"]);
                        workout.Exercise4Reps = Convert.ToInt32(reader["Exercise4Reps"]);
                        workout.Exercise5 = reader["Exercise5"].ToString();
                        workout.Exercise5Sets = Convert.ToInt32(reader["Exercise5Sets"]);
                        workout.Exercise5Reps = Convert.ToInt32(reader["Exercise5Reps"]);
                    }
                }
            }
            return workout;
        }
        public int AddWorkout(WorkoutViewModel add)
        {
            string sqlQuery = "INSERT into Workout (WorkoutName, Exercise1, Exercise1Sets, Exercise1Reps," +
                "Exercise2, Exercise2Sets, Exercise2Reps," + "Exercise3, Exercise3Sets, Exercise3Reps," +
                "Exercise4, Exercise4Sets, Exercise4Reps," + "Exercise5, Exercise5Sets, Exercise5Reps) VALUES(@WorkoutName, @Exercise1, @Exercise1Sets, @Exercise1Reps," +
                "@Exercise2, @Exercise2Sets, @Exercise2Reps," + "@Exercise3, @Exercise3Sets, @Exercise3Reps," +
                "@Exercise4, @Exercise4Sets, @Exercise4Reps," + "@Exercise5, @Exercise5Sets, @Exercise5Reps)";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@WorkoutName", SqlDbType.VarChar).Value = add.WorkoutName; 
                cmd.Parameters.Add("@Exercise1", SqlDbType.VarChar).Value = add.Exercise1;
                cmd.Parameters.Add("@Exercise1Sets", SqlDbType.Int).Value = add.Exercise1Sets;
                cmd.Parameters.Add("@Exercise1Reps", SqlDbType.Int).Value = add.Exercise1Reps;
                cmd.Parameters.Add("@Exercise2", SqlDbType.VarChar).Value = add.Exercise2;
                cmd.Parameters.Add("@Exercise2Sets", SqlDbType.Int).Value = add.Exercise2Sets;
                cmd.Parameters.Add("@Exercise2Reps", SqlDbType.Int).Value = add.Exercise2Reps;
                cmd.Parameters.Add("@Exercise3", SqlDbType.VarChar).Value = add.Exercise3;
                cmd.Parameters.Add("@Exercise3Sets", SqlDbType.Int).Value = add.Exercise3Sets;
                cmd.Parameters.Add("@Exercise3Reps", SqlDbType.Int).Value = add.Exercise3Reps;
                cmd.Parameters.Add("@Exercise4", SqlDbType.VarChar).Value = add.Exercise4;
                cmd.Parameters.Add("@Exercise4Sets", SqlDbType.Int).Value = add.Exercise4Sets;
                cmd.Parameters.Add("@Exercise4Reps", SqlDbType.Int).Value = add.Exercise4Reps;
                cmd.Parameters.Add("@Exercise5", SqlDbType.VarChar).Value = add.Exercise5;
                cmd.Parameters.Add("@Exercise5Sets", SqlDbType.Int).Value = add.Exercise5Sets;
                cmd.Parameters.Add("@Exercise5Reps", SqlDbType.Int).Value = add.Exercise5Reps;
                return cmd.ExecuteNonQuery(); 
            }
        }
        public int EditWorkout(WorkoutViewModel edit)
        {
            string sqlQuery = "Update Workout Set WorkoutName=@WorkoutName, Exercise1=@Exercise1, Exercise1Sets=@Exercise1Sets, Exercise1Reps=@Exercise1Reps, " +
                "Exercise2=@Exercise2, Exercise2Sets=@Exercise2Sets, Exercise2Reps=@Exercise2Reps, " +
                "Exercise3=@Exercise3, Exercise3Sets=@Exercise3Sets, Exercise3Reps=@Exercise3Reps, " +
                "Exercise4=@Exercise4, Exercise4Sets=@Exercise4Sets, Exercise4Reps=@Exercise4Reps, " +
                "Exercise5=@Exercise5, Exercise5Sets=@Exercise5Sets, Exercise5Reps=@Exercise5Reps  Where WorkoutID=@ID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = edit.WorkoutID;
                cmd.Parameters.Add("@WorkoutName", SqlDbType.Int).Value = edit.WorkoutName; 
                cmd.Parameters.Add("@Exercise1", SqlDbType.VarChar).Value = edit.Exercise1;
                cmd.Parameters.Add("@Exercise1Sets", SqlDbType.Int).Value = edit.Exercise1Sets;
                cmd.Parameters.Add("@Exercise1Reps", SqlDbType.Int).Value = edit.Exercise1Reps;
                cmd.Parameters.Add("@Exercise2", SqlDbType.VarChar).Value = edit.Exercise2;
                cmd.Parameters.Add("@Exercise2Sets", SqlDbType.Int).Value = edit.Exercise2Sets;
                cmd.Parameters.Add("@Exercise2Reps", SqlDbType.Int).Value = edit.Exercise2Reps;
                cmd.Parameters.Add("@Exercise3", SqlDbType.VarChar).Value = edit.Exercise3;
                cmd.Parameters.Add("@Exercise3Sets", SqlDbType.Int).Value = edit.Exercise3Sets;
                cmd.Parameters.Add("@Exercise3Reps", SqlDbType.Int).Value = edit.Exercise3Reps;
                cmd.Parameters.Add("@Exercise4", SqlDbType.VarChar).Value = edit.Exercise4;
                cmd.Parameters.Add("@Exercise4Sets", SqlDbType.Int).Value = edit.Exercise4Sets;
                cmd.Parameters.Add("@Exercise4Reps", SqlDbType.Int).Value = edit.Exercise4Reps;
                cmd.Parameters.Add("@Exercise5", SqlDbType.VarChar).Value = edit.Exercise5;
                cmd.Parameters.Add("@Exercise5Sets", SqlDbType.Int).Value = edit.Exercise5Sets;
                cmd.Parameters.Add("@Exercise5Reps", SqlDbType.Int).Value = edit.Exercise5Reps;
                return cmd.ExecuteNonQuery();

            }
        }

        public int DeleteWorkout(int id)
        {

            string sqlQuery = "DELETE from Workout Where WorkoutID=@ID";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
