using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class HandleInterface : IHandleTask
    {
        private Menu m_Menu;

        public HandleInterface()
        {
            m_Menu = new Menu("Main Menu" + " Interfaces", Menu.eMenuType.MainMenu, 2);
        }

        public void ReportExecutingAction(ITask i_Task)
        {
            i_Task.TaskToDo();
        }

        public void Handle()
        {
            buildMenu();
            m_Menu.DisplayMenu();
        }

        private void buildMenu()
        {
            Menu subMenuVersionAndSpaces, subMenuDateTime;

            subMenuVersionAndSpaces = createSubMenu("Version and Spaces", m_Menu);
            subMenuDateTime = createSubMenu("Show Date/Time", m_Menu);
            createAction(new CountSpaces(), "Count Spaces", subMenuVersionAndSpaces);
            createAction(new ShowVersion(), "Show Version", subMenuVersionAndSpaces);
            createAction(new ShowTime(), "Show Time", subMenuDateTime);
            createAction(new ShowDate(), "Show Date", subMenuDateTime);
        }

        private void createAction(ITask i_Task, string i_Headline, Menu i_PreviousMenu)
        {
            MenuTask action = new MenuTask(i_Task, i_Headline);
            i_PreviousMenu.AddMenuPage(action);
            action.AttachReporter(this);
        }

        private Menu createSubMenu(string i_Headline, Menu i_PreviousMenu)
        {
            Menu nextMenu = new Menu(i_Headline, Menu.eMenuType.SubMenu, 2);
            i_PreviousMenu.AddMenuPage(nextMenu);

            return nextMenu;
        }

        public void HandleTask(ITask i_Task)
        {
            i_Task.TaskToDo();
        }
    }
}
