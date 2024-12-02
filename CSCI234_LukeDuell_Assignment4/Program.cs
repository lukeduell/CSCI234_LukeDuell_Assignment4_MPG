/* Luke Duell
 * Instructor: Professor Hanoudi
 * CSCI 234: Object Oriented Programming w/C#
 * Assignment 4
 * Description: This program takes in the user input
 *              for gallons and miles and outputs
 *              the mpg. This program also uses active
 *              error checking to ensure the information
 *              sent by the user is correct and not a string
 *              or something other than an int.
 */

using System;

class InputErrorChecking
{
    public int result { get; set; }
    public int output_int { get; set; }

    public InputErrorChecking(int result_priv)
    {
        //takes in input from user
        int input_int_priv;
        string input_string_priv = Console.ReadLine();
        //tries input to see if input is a string
        try
        {
            input_int_priv = int.Parse(input_string_priv);
            output_int = input_int_priv;
        }
        //if input is a string error is caught
        catch (FormatException)
        {
            Console.WriteLine("Input entered is incorrect format");
            result_priv = 1;
        }
        //if there is an unexpected character it is caught here
        catch (Exception exception)
        {
            Console.WriteLine($"Unexpected Error: {exception.Message}");
            result_priv = 1;
        }
        //result is stored in a public int
        result = result_priv;
    }
}


class WritetoConsole
{
    static void Main()
    {
        int ResultCheck = 0;

    //goto function restart for Miles Reset. Part of error checking
    MilesReset:

        //prompts user to enter miles
        Console.WriteLine("Enter Miles Driven");

        InputErrorChecking errorcheckMiles = new InputErrorChecking(ResultCheck);

        int Miles = errorcheckMiles.output_int;

        //error checking
        if (errorcheckMiles.result == 1)
        {
            Console.WriteLine("Incorrect Input");
            errorcheckMiles.result = 0;
            goto MilesReset;
        }
    GallonsReset:

        //prompts user to enter miles
        Console.WriteLine("Enter Gallons");

        InputErrorChecking errorcheckGallons = new InputErrorChecking(ResultCheck);

        int Gallons = errorcheckGallons.output_int;

        //error checking
        if (errorcheckGallons.result == 1)
        {
            Console.WriteLine("Incorrect Input");
            errorcheckGallons.result = 0;
            goto GallonsReset;
        }
        if (errorcheckGallons.result == 0 && errorcheckMiles.result == 0)
        {
            Console.WriteLine($"MPG: {Miles / Gallons}");
        }
    }

    
}

