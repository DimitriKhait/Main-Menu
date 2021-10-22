using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    // $G$ DSN-999 (-1) All the methods that activate an action should have been implemented in different classes 
    public class ShowVersion : ITask
    {
        public void TaskToDo()
        {
            Console.WriteLine("Version: 21.3.4.8933");
        }
    }
}
