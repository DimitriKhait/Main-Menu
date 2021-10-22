namespace Ex04.Menus.Delegates
{
    // $G$ CSS-999 (-1) You were required to call this class MenuItem
    public abstract class MenuPage
    {
        private MenuPage m_PreviousMenuPage;
        private string m_Headline;

        protected MenuPage(string i_Title)
        {
            m_Headline = i_Title;
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
