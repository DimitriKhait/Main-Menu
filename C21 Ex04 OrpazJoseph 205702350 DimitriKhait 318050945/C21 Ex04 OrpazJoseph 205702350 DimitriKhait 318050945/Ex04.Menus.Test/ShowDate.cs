using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    // $G$ DSN-999 (-1) All the methods that activate an action should have been implemented in different classes 
    public class ShowDate : ITask
    {
        public void TaskToDo()
        {
            Console.WriteLine($"Today's date: {DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year}");
        }
    }
}
