﻿namespace Ex04.Menus.Interfaces
{
    // $G$ CSS-999 (-1) You were required to call this class MenuItem
    // $G$ DSN-999 (-3) Should have been abstract class
    public abstract class MenuPage
    {
        private MenuPage m_PreviousMenuPage;
        private string m_Headline;

        internal MenuPage(string i_Headline)
        {
            m_Headline = i_Headline;
        }

        public MenuPage PreviousMenuPage
        {
            get
            {
                return m_PreviousMenuPage;
            }

            set
            {
                m_PreviousMenuPage = value;
            }
        }

        public string Headline
        {
            get
            {
                return m_Headline;
            }

            set
            {
                m_Headline = value;
            }
        }

        public abstract void DisplayMenu();
    }
}
