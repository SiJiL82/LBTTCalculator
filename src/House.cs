using System;
using System.Collections.Generic;

namespace LBTTCalculator
{
    //Class to hold details on the house and calculate the LBTT value
    public class House
    {
        //Variable to store the house value in
        private double Value {get; set;}
        //Variable to store the calculated LBTT value in.
        //Initialise to 0 so additional tax can be added on.
        private double LBTTValue {get; set;} = 0;

        //Public method to prompt user for the house value, calculate the LBTT and print the resulting value.
        public void SetHouseValueAndCalculateLBTT()
        {
            SetHouseValueFromConsole();  
            
            CalculateLBTTValue();        

            PrintLBTTValue();
        }

        //Method to calculate the LBTT value for the house value.
        public void CalculateLBTTValue()
        {
            //Put all the different tax bands into a list.
            List<LBTTBand> lbttBands = new List<LBTTBand>();
            lbttBands.Add(new LBTTBand(0, 145000, 0));
            lbttBands.Add(new LBTTBand(145000, 250000, 2));
            lbttBands.Add(new LBTTBand(250000, 325000, 5));
            lbttBands.Add(new LBTTBand(325000, 750000, 10));
            lbttBands.Add(new LBTTBand(750000, double.MaxValue, 12));

            //Loop through each tax band from the list, and calculate how much tax needs to be paid on the amount of the value in that band.
            foreach(LBTTBand lbttBand in lbttBands)
            {
                //Check if the house value is greater than the lower bound, so some tax needs to be calculated for this band.
                if(Value > lbttBand.lower)
                {
                    //Get the minimum value of either the whole band range, or the difference between the value and the lower bound, to work out the value of the house that falls into this band.
                    double calcValue = Math.Min(lbttBand.upper - lbttBand.lower, Value - lbttBand.lower);
                    //Calculate the percentage of the above value, based on the rate for this band
                    double taxThisBand = (calcValue / 100.0) * lbttBand.rate;
                    //Add the tax for this band to the total value.
                    LBTTValue += taxThisBand;
                }
            }
        }
        
        //Method to prompt the user for input to set the house value.
        protected void SetHouseValueFromConsole()
        {
            Console.WriteLine("Enter the house value:");
            string input = Console.ReadLine();

            //Check the value entered is a number.
            double value;
            if(double.TryParse(input, out value))
            {
                //Set the house value to the input value if it parses OK
                SetValue(value);
            }
            else
            {
                //Display an error message if the value isn't a valid number.
                Console.WriteLine("Please enter a valid house value.");
            }
        }

        //Method to write the calculated LBTT value out to the console.
        private void PrintLBTTValue()
        {
            Console.WriteLine($"LBTT Value: £{LBTTValue}");
        }

        public void SetValue(double value)
        {
            Value = value;
        }

        public double GetLBBTValue()
        {
            return LBTTValue;
        }
    }
}