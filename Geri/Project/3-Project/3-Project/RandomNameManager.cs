using System;
using System.Collections.Generic;
using System.IO;

namespace _3_Project
{
    class RandomNameManager
    {
        List<string> names = new List<string>();

        public RandomNameManager()
        {
            LoadNamesFromFile("nevek.txt");
        }

        private void LoadNamesFromFile(string fileName)
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines)
                {
                    names.Add(line.Trim()); 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading names from file: {ex.Message}");
            }
        }

        public string GetRandomName()
        {
            Random rand = new Random();
            int randomIndex = rand.Next(0, names.Count);
            return names[randomIndex].Replace(" ", "");
        }
    }
}
