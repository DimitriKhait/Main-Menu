using Ex04.Menus.Delegates;

namespace Ex04.Menus.Test
{
    public delegate MenuTask Action(string str, Menu menu);

    public class HandleDelegates
    {
        internal event Action action;

        private Menu m_Menu;

        public HandleDelegates()
        {
            m_Menu = new Menu("Main Menu" + " Delegates", Menu.eMenuType.MainMenu, 2);
        }

        public void Handle()
        {
            buildMenu();
            m_Menu.DisplayMenu();
        }

        private void buildMenu()
        {
            action += createAction;
            Menu subMenuVersionAndSpaces = createSubMenu("Version and Spaces", 2, m_Menu);
            Menu subMenuDateTime = createSubMenu("Show Date/Time", 2, m_Menu);

            action("Count Spaces", subMenuVersionAndSpaces).ActionDone += new CountSpaces().TaskToDo;
            action("Show Version", subMenuVersionAndSpaces).ActionDone += new ShowVersion().TaskToDo;
            action("Show Time", subMenuDateTime).ActionDone += new ShowTime().TaskToDo;
            action("Show Date", subMenuDateTime).ActionDone += new ShowDate().TaskToDo;
        }

        public MenuTask createAction(string i_Title, Menu i_ParentMenu)
        {
            MenuTask action = new MenuTask(i_Title);
            i_ParentMenu.AddMenuPage(action);

            return action;
        }

        private Menu createSubMenu(string i_Title, int i_SubMenusAmount, Menu i_PreviousMenu)
        {
            Menu nextMenu = new Menu(i_Title, Menu.eMenuType.SubMenu, i_SubMenusAmount);
            i_PreviousMenu.AddMenuPage(nextMenu);

            return nextMenu;
        }
    }
}
