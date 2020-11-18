using System;

namespace Moment_2___Programmering_i_CSharp
{
    class Program
    {
        public static void Main()
        {
            // Bool and while-loop is created and allows the user to restart the application without the client exiting
            bool loop = true;
            while (loop)
            {
                // Int-variables being instanced to use as input variables for the user
                int year, month, day;
                // try/catch is created and used to handle exeptions if user input is wrong or blank
                try
                {
                    Console.Write("\n\n Find the day for a given date :\n");
                    Console.Write("------------------------------------\n");

                    // int-variables as day, month and year from outside the try is here converted to the int-representation of the string-input
                    Console.Write(" Input the Day (dd) : ");
                    day = Convert.ToInt32(Console.ReadLine());
                    Console.Write(" Input the Month (mm) : ");
                    month = Convert.ToInt32(Console.ReadLine());
                    Console.Write(" Input the Year (yyyy) : ");
                    year = Convert.ToInt32(Console.ReadLine());

                    // An Date-variable is created as a Date from the int-variables and transformed to a String-object to be used in the Tryparse
                    DateTime dateuserinput = new DateTime(year, month, day);
                    string dateuserinputstring = dateuserinput.ToString();

                    // An empty DateTime-varaible is created for comparison with the user input date-format
                    DateTime correctdateformat;

                    // Tryparse which takes user input and checks if the date-format is the same as with the newly created "correctdateformat"
                    if (DateTime.TryParse(dateuserinputstring, out correctdateformat))
                    {
                        // The correct date is printed out
                        Console.WriteLine(" The formatted Date is : {0}", correctdateformat);

                        // A C# version of Zellers Conguency is used to find out the correct day of the user-chosen date
                        if (month == 1)
                        {
                            month = 13;
                            year--;
                        }
                        if (month == 2)
                        {
                            month = 14;
                            year--;
                        }
                        int k = year % 100;
                        int j = year / 100;
                        int h = day + 13 * (month + 1) / 5 + k + k / 4 + j / 4 + 5 * j;
                        int H = h % 7;
                        switch (H)
                        {
                            // Once the right case is found, the console prints out the correct day, disables the loop and shuts down the program
                            case 0:
                                Console.WriteLine("The day for the date is: Saturday");
                                loop = false;
                                break;


                            case 1:
                                Console.WriteLine("The day for the date is: Sunday");
                                loop = false;
                                break;

                            case 2:
                                Console.WriteLine("The day for the date is: Monday");
                                loop = false;
                                break;

                            case 3:
                                Console.WriteLine("The day for the date is: Tuesday");
                                loop = false;
                                break;

                            case 4:
                                Console.WriteLine("The day for the date is: Wednesday");
                                loop = false;
                                break;

                            case 5:
                                Console.WriteLine("The day for the date is: Thursday");
                                loop = false;
                                break;

                            case 6:
                                Console.WriteLine("The day for the date is: Friday");
                                loop = false;
                                break;
                        }
                    }
                    else
                    {
                        // If the Tryparse fails, a message is printed and the program is rerun
                        Console.Write("Something went wrong with the user input. Please try again with the dateformat-instructions on the consolescreen ");
                        loop = true;
                    }

                }

                // If the try-code fails with an format-error, the console writes out what went wrong and a message prompting the user to find errors with its date-format
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                    Console.WriteLine("Try again with the dateformat-instructions on the consolescreen");
                    loop = true;
                }
                // If instead, the try-code fails with an general error, the console writes out an error and a message to check the error-message being sent for more information
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Something went wrong, please check the error message above");
                    loop = true;
                }
            }
        }
    }
}
