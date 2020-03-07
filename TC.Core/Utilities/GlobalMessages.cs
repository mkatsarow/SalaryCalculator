namespace TC.Core.Utilities
{
    public static class GlobalMessages
    {
        internal const string welcomeMessage = "Welcome to TaxCalculator!";
        internal const string enterSalaryMsg = "Enter your gross salary: ";
        internal const string netSalaryResult = "\t" + "Your NET salary is: {0:f2} IDR";

        //Exception messages 
        internal const string invalidInput = "\t" + "Invalid gross salary. Please enter pisitive number!";
        internal const string invalidDecimal = "\t" + "Please enter positive number!";
    }
}
