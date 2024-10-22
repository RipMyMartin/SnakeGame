using System;
using System.Threading;
using NAudio.Wave;
using SnakeMaduussTARpv23.Game;

namespace SnakeMaduussTARpv23
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();
            menu.Display();
        }
    }
}
