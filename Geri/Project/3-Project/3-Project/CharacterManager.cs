using System;
using System.IO;

namespace _3_Project
{
    class CharacterManager
    {
        private const string directoryPath = "karakterek";

        public static void SaveCharacter(Character character)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, $"{character.Name}.txt");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Name: {character.Name}");
                writer.WriteLine($"Kaszt: {character.Kaszt}");
                writer.WriteLine($"Race: {character.Race}");
                writer.WriteLine($"Strength: {character.Strength}");
                writer.WriteLine($"Luck: {character.Luck}");
                writer.WriteLine($"Agility: {character.Agility}");
            }
        }

        public static Character LoadCharacter(string name)
        {
            string filePath = Path.Combine(directoryPath, $"{name}.txt");

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                string characterName = "", kaszt = "", race = "";
                int strength = 0, luck = 0, agility = 0;
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();
                        switch (key)
                        {
                            case "Name":
                                characterName = value;
                                break;
                            case "Kaszt":
                                kaszt = value;
                                break;
                            case "Race":
                                race = value;
                                break;
                            case "Strength":
                                int.TryParse(value, out strength);
                                break;
                            case "Luck":
                                int.TryParse(value, out luck);
                                break;
                            case "Agility":
                                int.TryParse(value, out agility);
                                break;
                        }
                    }
                }

                return new Character(characterName, kaszt, race, strength, luck, agility);
            }

            return null;
        }
    }
}
