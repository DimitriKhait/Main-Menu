using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    // $G$ DSN-999 (-1) All the methods that activate an action should have been implemented in different classes 
    public class CountSpaces : ITask
    {
        public void TaskToDo()
        {
            int count = 0;
            string userInput;
            bool validInput = false;

            Console.WriteLine("Please enter a sentence:");
            while (!validInput)
            {
                try
                {
                    validInput = checkInput(out userInput);
                    foreach (char c in userInput)
                    {
                        if (c == ' ')
                        {
                            count++;
                        }
                    }
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Input can't be empty, please try again.");
                }
            }

            Console.WriteLine($"In your sentence there are {count} spaces.");
        }

        private bool checkInput(out string i_UserInput)
        {
            i_UserInput = Console.ReadLine();
            if (i_UserInput.Length == 0)
            {
                throw new ArgumentNullException();
            }

            return true;
        }
    }
}
