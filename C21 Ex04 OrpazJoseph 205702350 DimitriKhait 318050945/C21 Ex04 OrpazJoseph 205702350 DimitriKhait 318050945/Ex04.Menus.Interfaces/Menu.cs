using System;
using System.Collections.Generic;
using System.Text;

namespace Ex04.Menus.Interfaces
{
    // $G$ CSS-999 (-1) You were required to call this class MainMenu
    public class Menu : MenuPage, IMenu
    {
        private readonly List<MenuPage> m_MenuPages;
        private readonly eMenuType r_MenuType;
        private string m_QuitString;

        public Menu(string i_Headline, eMenuType i_MenuType, int i_InternalMenus)
            : base(i_Headline)
        {
            m_MenuPages = new List<MenuPage>(i_InternalMenus);

            r_MenuType = i_MenuType;
            setMenu();
        }

        private static bool validateUserIntInput(out int o_UserInput, int i_MinValue, int i_MaxValue)
        {
            if (!int.TryParse(Console.ReadLine(), out o_UserInput))
            {
                throw new FormatException();
            }

            if (o_UserInput < i_MinValue || o_UserInput > i_MaxValue)
            {
                throw new ValueOutOfRangeException(new Exception(), i_MinValue, i_MaxValue);
            }

            return true;
        }

        private void setMenu()
        {
            m_QuitString = r_MenuType == eMenuType.MainMenu ? "Exit" : "Back";
        }

        public enum eMenuType
        {
            MainMenu = 1,
            SubMenu
        }

        private enum eMenuSession
        {
            Continue = 1,
            Exit
        }

        public void AddMenuPage(MenuPage i_MenuPage)
        {
            i_MenuPage.PreviousMenuPage = this;
            m_MenuPages.Add(i_MenuPage);
        }

        public string MenuBuilder()
        {
            int index = 1;
            StringBuilder layout = new StringBuilder();

            foreach (MenuPage item in m_MenuPages)
            {
                layout.AppendLine($"{index}) {item.Headline}");
                ++index;
            }

            layout.AppendLine($"0. {m_QuitString}");
            return layout.ToString();
        }

        public override void DisplayMenu()
        {
            int userChoice;
            eMenuSession menuSession = eMenuSession.Continue;

            while (menuSession != eMenuSession.Exit)
            {
                Console.Clear();
                string show = string.Format($"{Headline}{Environment.NewLine}{MenuBuilder()}{Environment.NewLine}" +
                                $"Please choose one of the options:");
                Console.WriteLine(show);
                userChoice = getValidUserInput();

                if (userChoice == 0)
                {
                    menuSession = eMenuSession.Exit;
                }
                else
                {
                    handleMenuPage(userChoice);
                }
            }
        }

        private int getValidUserInput()
        {
            int userInput = 0;
            bool validInput = false;

            while (!validInput)
            {
                try
                {
                    validInput = validateUserIntInput(out userInput, 0, m_MenuPages.Count);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input must be a number.");
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine($"Input should be between {ex.MinValue} - {ex.MaxValue}");
                }
                catch (Exception)
                {
                    Console.WriteLine("Unknown error.");
                }
            }

            return userInput;
        }

        private void handleMenuPage(int i_Index)
        {
            m_MenuPages[i_Index - 1].DisplayMenu();
            if (m_MenuPages[i_Index - 1] is MenuTask)
            {
                Console.WriteLine("Press any key to return...");
                Console.ReadKey();
            }
        }
    }
}