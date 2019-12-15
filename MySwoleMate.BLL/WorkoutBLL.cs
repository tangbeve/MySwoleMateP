using MySwoleMate.DAL;
using MySwoleMate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MySwoleMate.BLL
{
    public class WorkoutBLL
    {
        private WorkoutDAL data;

        public WorkoutBLL(string connectionString)
        {
            data = new WorkoutDAL(connectionString);
        }
        public List<WorkoutViewModel> GetAllWorkouts()
        {
            List<WorkoutViewModel> workouts = data.GetWorkouts();
            foreach (var item in workouts)
            {
                item.DisplayExercise1 = ExerciseDisplay(item.Exercise1, item.Exercise1Sets, item.Exercise1Reps);
                item.DisplayExercise2 = ExerciseDisplay(item.Exercise2, item.Exercise2Sets, item.Exercise2Reps);
                item.DisplayExercise3 = ExerciseDisplay(item.Exercise3, item.Exercise3Sets, item.Exercise3Reps);
                item.DisplayExercise4 = ExerciseDisplay(item.Exercise4, item.Exercise4Sets, item.Exercise4Reps);
                item.DisplayExercise5 = ExerciseDisplay(item.Exercise5, item.Exercise5Sets, item.Exercise5Reps);
            }
            return workouts;
        }
        public WorkoutViewModel GetWorkoutById(int id)
        {
            return data.GetWorkoutById(id);
        }
        public int EditWorkout(WorkoutViewModel edit)
        {
            return data.EditWorkout(edit);
        }
        public int AddWorkout(WorkoutViewModel add)
        {
            return data.AddWorkout(add);
        }
        public int DeleteWorkout(int id)
        {
            return data.DeleteWorkout(id);
        }
        public string ExerciseDisplay(string exercise, int reps, int sets)
        {
            return exercise + " " + sets + " x " + reps;
        }
    }
}
