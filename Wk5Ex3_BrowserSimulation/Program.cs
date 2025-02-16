using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk5Ex3_BrowserSimulation
{
    internal class Program
    {
        // Method to handle integer input
        static int HandleIntInput(string aPrompt, string anErrorMessage = "Your input is invalid. Please enter a whole number.\n")
        {
            // initialize return value
            int returnValue = Int32.MaxValue;


            // processing


            // start of a do while loop
            do
            {
                // A try catch to ensure the user input is valid
                try
                {
                    // Ask user to input a number
                    Console.Write(aPrompt);
                    // Convert user input to a double, collect input from user and store it in the returnValue
                    returnValue = Convert.ToInt32(Console.ReadLine());
                }
                // if that doesn't work, output an error message
                catch (Exception e)
                {
                    // output an error message
                    Console.WriteLine("\n" + anErrorMessage);
                }
            }
            // loop until returnValue has a different value


            while (returnValue == Int32.MaxValue);


            // return returnValue
            return returnValue;
        }


        // Method to validate string input
        static string HandleStringInput(string aPrompt = "Write your sentence/string: ", string anErrorMessage = "Something went wrong on our end. Please enter a valid string input.\n")
        {
            // initialize return value
            string returnValue = "";


            // processing


            // start of a do while loop
            do
            {
                // A try catch to ensure the user input is valid
                try
                {
                    // Ask user to input a string
                    Console.Write(aPrompt);
                    // Collect input from user and store it in the returnValue
                    returnValue = (Console.ReadLine());
                }
                // if that doesn't work, output an error message
                catch (Exception e)
                {
                    // output an error message
                    Console.WriteLine(anErrorMessage);
                }
            }
            // loop until returnValue has a different value
            while (returnValue == "");


            // return returnValue
            return returnValue;
        }


        // a method to check if an integer input is between two numbers
        static int CheckIntRange(int input, int min, int max, int evaluationValue = Int32.MinValue, string errorMessage = "Your input was out of range. Input again.\n")
        {
            // initialize return value to the input
            int returnValue = input;

            // processing


            // check if the input is grater than a max value OR less than a min value
            if (input > max || input < min)
            {
                // return an error message
                Console.WriteLine(errorMessage);
                // make evaluation variable reset
                returnValue = evaluationValue;
            }


            // return returnValue
            return returnValue;
        }


        // Method to visit a new page
        static void VisitNewPage(Stack<string> browsingLocation, List<string> browsingHistory)
        {
            // variable declarations
            string newPage = ""; // string variable containing new page a user inputs, initialized to blank

            // validate string input from user and store it in the newPage variable
            newPage = HandleStringInput("Enter webpage URL: ");
            // linebreak for readability
            Console.Write("\n");


            // add/push the new page to the end of the browsing location stack
            browsingLocation.Push(newPage);
            // add the new page to the end of the browsing history
            UpdateBrowsingHistory(browsingHistory, newPage);
            // Tell user they have visited the page!
            Console.WriteLine("Page visited successfully!\n");
        }


        // Method to go to the previous page
        static void ReturnToPreviousPage(Stack<string> browserLocation, List<string> browsingHistory)
        {
            // Declarations
            string previousPage = ""; // declare a string variable to hold the name of the page they have been moved back to

            // check if browser history is less than or equal to 0
            if (browserLocation.Count <= 1)
            {
                // Tell the user they have no history yet
                Console.WriteLine("There are no pages to move back to, so no action was performed.\n");
            }
            // if the browsing history is greater than 1
            else
            {
                // remove the current page in the browserLocation stack
                browserLocation.Pop();

                // set the previous page variable to the page we just moved back to
                previousPage = browserLocation.Peek();

                // tell user what page thee have successfully been moved back to the previous page
                Console.WriteLine($"Current Page: {previousPage}\n");

                // add the new page to the end of the browsing history
                UpdateBrowsingHistory(browsingHistory, previousPage);
            }
        }
        

        // Method to view browsing history
        static void ViewBrowsingHistory(List<string> browsingHistory)
        {
            // Display title of history page
            Console.WriteLine("Browsing History");


            // check if there is no browsing history
            if (browsingHistory.Count == 0)
            {
                // output 'empty' status
                Console.WriteLine("[Empty]\n");
            }
            // check if the browsing history is negative
            else if (browsingHistory.Count < 0)
            {
                // output error warning
                Console.WriteLine("WARNING\nYour browsing history is somehow in the negatives.\nLook at previous actions to see how this happened, or close the application and start over.\n");
            }
            // if the browsing history is positive
            else
            {
                // for every page's index in the browsing history list, going in reverse order
                foreach (string webpage in browsingHistory)
                {
                    // output webpage in list
                    Console.WriteLine(webpage);
                }
                // linebreak after all pages have been output
                Console.Write("\n");
            }
        }


        // Method to add a new web page to the browsing history
        static void UpdateBrowsingHistory(List<string> browsingHistory, string newPage)
        {
            // processing


            // if the page they are on now is already in the browser history, remove it and add it to the end/top

            // check if there is no browsing history
            if (browsingHistory.Count == 0)
            {
                // add the new page to the browsing history list
                browsingHistory.Add(newPage);
            }
            else
            {
                
                // for every index in browser history, loop
                foreach (string page in browsingHistory)
                {
                    // check if browser history at this index has the same name as the new page
                    if (page == newPage)
                    {
                        // remove the new page from the list at it's current location
                        browsingHistory.Remove(newPage);
                        // add the new page back to the list at the very beginning
                        browsingHistory.Insert(0, newPage);

                        // exit the foreach loop
                        break;
                    }
                }
            }


            // if the new page is not already in the browsing history list
            if (!(browsingHistory.Contains(newPage)))
            {
                // add the new page to the browsing history list at the beginning
                browsingHistory.Insert(0, newPage);
            }
        }


        static void Main(string[] args)
        {
            // Objective: Simulate Browser Navigation
            /* Have a menu of 4 Options. Visit new page, Go back, 
             * view browsing hisory, and exit.
             * Let the user choose an option. They enter urls for each new page visited.
             * Track browsing history in a list where nothing gets removed. */


            // processing


            // Declarations
            // inputs
            int menuSelection = Int32.MinValue; // int variable containing the user's option selection from the menu, initialized to min int value
            Stack<string> browsingLocation = new Stack<string> ();// declaration of an empty stack to hold the current previous web pages
            List<string> browsingHistory = new List<string> ();     // declaration of an empty list to hold the browsing history. This way, it will include ALL history, not just what is left in the stack

            // Display Application name
            Console.WriteLine("Welcome to the Web Browser Back Button application\n");



            // output the options to the user with their number



            // Output to tell the user they can type 1 to Visit a New Page
            Console.WriteLine("1. Visit New Page\n");

            // Output to tell the user they can type 2 to Go Back to the previous page
            Console.WriteLine("2. Go Back\n");

            // Output to tell the user they can type 3 to view their browsing history
            Console.WriteLine("3. View Browsing History\n");

            // Output to tell the user they can type 4 to exit the application
            Console.WriteLine("4. Exit\n");



            // A do while loop to run the program and allow continuous choice.
            do
            {
                // do while loop to make sure the user selection is within range
                do
                {
                    // ask for and recieve user choice as an integer number
                    menuSelection = HandleIntInput("Enter your choice: ");
                    // line break for readability
                    Console.Write("\n");

                    // make sure the integer input is between 1 and 4. If interger is not, reset user selection to Int32 min value
                    menuSelection = CheckIntRange(menuSelection, 1, 4, Int32.MinValue, "Your input was out of range. Make sure your number is between 1 and 4.\n");
                }
                while (menuSelection == Int32.MinValue);


                // check if the user selection is 4, leave the while loop
                if (menuSelection == 4)
                {
                    // leave the while loop
                    break;
                }


                // use a switch case to perform an operation based on the selection
                switch (menuSelection)
                {
                    // Run this case if selection = 1
                    case 1:
                        // Visit new web page
                        VisitNewPage(browsingLocation, browsingHistory);

                        // Jump out of switch here.
                        break;


                    // Run this case if selection = 2
                    case 2:
                        // return to previous page
                        ReturnToPreviousPage(browsingLocation, browsingHistory);


                        // Jump out of switch here.
                        break;


                    // Run this case if selection = 3
                    case 3:
                        // View browsing history list
                        ViewBrowsingHistory(browsingHistory);


                        // Jump out of switch here.
                        break;


                    default:
                        // Output a polite message in case of unforseen error.
                        Console.WriteLine("It seems something went wrong on our end. Please try again./n");

                        // Jump out of switch here.
                        break;
                }

                // prompt user to continue the loop
                Console.WriteLine("Select what you would like to do next or press 4 to exit.");


                // reset the evaluation variable
                menuSelection = Int32.MinValue;
            }
            while (menuSelection == Int32.MinValue);


            // Thank user for using the program
            Console.WriteLine("Thank you for using this program! Come again!");


            // Pause at the end of program for user to read
            Console.Read();
        }
    }
}