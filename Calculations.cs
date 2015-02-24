using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sleep_Laboratory_DataBase
{
    class Calculations
    {
        /// <summary>
        /// This class contains all the calculations that need to be carried out by the application
        /// </summary>
        /// <param name="Height"></param>
        /// <param name="Weight"></param>
        /// <returns></returns>

        public double CalculateBMI(double Height, double Weight)
        {
            /// BMI Calculator
            /// Calculates the Body Mass Index using input height and weight data
            /// It then returns the calculated value to the caller
            double heightInMeters = Height / 100; // Convert Height from cm to meters
            // BMI calculation is BMI equals weight over height in meters squared
            double BMI = Weight / (heightInMeters * heightInMeters);

            return BMI; // return the value of BMI to caller
        }
    }
}
