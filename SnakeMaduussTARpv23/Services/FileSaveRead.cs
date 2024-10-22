using System;
using System.IO;

namespace SnakeMaduussTARpv23.Services
{
    public class FileSaveRead
    {
        public void SaveGameData(string playerName, TimeSpan timePlayed)
        {
            string filePath = @"Text.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Player: {playerName}, Time Played: {timePlayed.Minutes:D2}:{timePlayed.Seconds:D2}");
                writer.WriteLine("---------------------------------------------------");
            }
        }
    }
}
