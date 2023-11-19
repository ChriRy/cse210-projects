using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] arguments)
    {
        Menu menu = new Menu();

        menu.TitleScreen();
        menu.ChooseProfile();
        menu.MainMenu();
    }
}