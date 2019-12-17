using MySwoleMate.DAL;
using MySwoleMate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


                                        /*   Business Logic Layer: Glue between DAL and Web Forms                 */
                                       /*   Methods                                                              */
                                      /*                                                                        */
                                     /*                                                                        */


namespace MySwoleMate.BLL
{//You have created the WorkoutDAL class to grab information from the database and the WorkoutBLL which will pass the data to and from the WorkoutDAL to the Web Forms application. It's time to now see the data from the user's perspective.
    public class TraineeBLL
    {
        // Business Logic Layer provides the glue between the Data Access Layer and the Web Forms application

        //Instance of the Data Access Layer class for Trainees
        private TraineeDAL data;

        //Constructor that accepts a connectionString from the Presentation Layer,
        //Use the connectionString to pass into a new instance of the Data Access Layer class
        //TraineeDAL
        public TraineeBLL(string connectionString)
        {
            data = new TraineeDAL(connectionString);
        }
        
        //Gets all Trainees in a List of TraineeViewModel
        public List<TraineeViewModel> GetAllTrainees()
        {
            //return the List<TraineeViewModel> from TraineeDAL
            //Here you will need to use the methods you create in 
            //Dive 1 in order to display the Height and proper cell phone display
            List<TraineeViewModel> trainees = data.GetTrainees();
            foreach(var item in trainees)
            {
                //for each item take the Height and CellNbr values,
                //use the HeightDisplay and PhoneDisplay methods
                //and store the returned values from the methods
                //into the HeightDisplay and PhoneDisplay properties of the item.
                //The DisplayHeight is done for you.
                item.DisplayHeight = HeightDisplay(item.Height);
                item.DisplayCellNbr= PhoneDisplay(item.CellNbr); 
            }
            return trainees;
        }

        //Returns ViewModel of Trainee by the Id
        public TraineeViewModel GetTraineeById(int id)
        {
            return data.GetTraineeById(id);
        }

        //Edits the Trainee accepting a TraineeViewModel
        public int EditTrainee(TraineeViewModel edit)
        {
            return data.EditTrainee(edit);
        }

        //Adds a new Trainee
        public int AddTrainee(TraineeViewModel add)
        {
            return data.AddTrainee(add);
        }

        //Deletes a trainee by the Id, Delete only needs the id of Trainee
        public int DeleteTrainee(int id)
        {
            return data.DeleteTrainee(id);
        }

        //You can create the private methods for HeightDisplay and PhoneDisplay below.
        //The HeightDisplay method signature has been given to you.
        private string HeightDisplay(int height)
        {
            //store the displayed height
            string heightDisplay = "";



            //perform the calculations to separate feet and height (hint: this is a great 
            //time to use the % (modulus) operator
            string feet = (height / 12).ToString() + " ft. ";
            string inches = (height % 12).ToString() + " in. ";

            heightDisplay = feet + inches; 

            return heightDisplay;
        }
        private string PhoneDisplay(string phone)
        {
            

            return Regex.Replace(phone, @"(\d{3})(\d{3})(\d{4})", "$1-$2-$3");

           
        }
    }
}
