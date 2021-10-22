using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    public class MenuTask : MenuPage
    {
        private readonly List<IHandleTask> m_TaskList = new List<IHandleTask>();

        private readonly ITask r_Task;

        public MenuTask(ITask i_Task, string i_Headline) : base(i_Headline)
        {
            r_Task = i_Task;
        }

        public void AttachReporter(IHandleTask i_TaskReporter)
        {
            m_TaskList.Add(i_TaskReporter);
        }

        public void DetachReporter(IHandleTask i_TaskReporter)
        {
            m_TaskList.Remove(i_TaskReporter);
        }

        public override void DisplayMenu()
        {
            Console.Clear();
            r_Task.TaskToDo();
        }
    }
}
