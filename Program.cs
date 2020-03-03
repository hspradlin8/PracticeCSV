using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PracticeCSV
{
    class Program
    {
        static List<Monster> Monsters = new List<Monster>();

        public static string searchKey { get; private set; }

        [STAThread]
        static void Main()
        {
            Console.WriteLine("Welcome To Sprad's Monsters...");
            Console.WriteLine("1. View Monsters");
            Console.WriteLine("2. Add Monster");
            Console.WriteLine("3. View One Monster");
            Console.WriteLine("Please Make a Selection:");
            var selection = Console.ReadLine();

            if (selection == "1")
            {
                ReadMonstersFromFile();
                WriteMonstersToConsole(Monsters);
                Console.WriteLine("Type Home to go back or quit to exit.");
                var answer = Console.ReadLine();
                if (answer == "Home")
                {
                    Main();
                }

            }

            if (selection == "2")
            {
                //shows list of parameters for the user to type in the info
                Monsters.Add(AddMonster());
                //then add the infor to the console and the file
                WriteMonstersToFile(@"/Users/Heidi/Downloads/two copy.csv");
                Main();

            }

            if (selection == "3")
            {
                // shows one monster with infor 
                MonsterDetail();
                //ReadMonstersFromFile();
                Main();
            }

        }


        private static void ReadMonstersFromFile()
        {
            string filePath = @"/Users/Heidi/Downloads/two copy.csv";
            string filePath2 = @"/Users/Heidi/Downloads/monster_map.csv";


            List<string> lines = File.ReadAllLines(filePath).ToList();
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');

                Monster newMonster = new Monster();

                newMonster.TimeStamp = entries[0];
                newMonster.Researcher = entries[1];
                newMonster.MonsterName = entries[2];
                newMonster.Latitude = entries[3];
                newMonster.Longitude = entries[4];

                Monsters.Add(newMonster);
            }

        }

        private static void MonsterDetail()
        {
            string filePath = @"/Users/Heidi/Downloads/two copy.csv";
            string filePath2 = @"/Users/Heidi/Downloads/monster_map.csv";

            Console.WriteLine("Please type in monster name");
            var userString = Console.ReadLine();
            // pull files from filePath 
            List<string> lines = File.ReadAllLines(filePath).ToList();
            List<string> codeLines = File.ReadAllLines(filePath2).ToList();
            // search for the monster name from the file

            foreach (var line in lines)
            {
                string[] entries = line.Split(',');

                Monster newMonster = new Monster();

                newMonster.TimeStamp = entries[0];
                newMonster.Researcher = entries[1];
                newMonster.MonsterName = entries[2];
                newMonster.Latitude = entries[3];
                newMonster.Longitude = entries[4];

                Monsters.Add(newMonster);
            }

            foreach (Monster monster in Monsters)
            {
                Console.WriteLine(userString, monster.MonsterName);
                if (monster.MonsterName == userString)
                {
                    Console.WriteLine();
                }
            }

        }


        private static void WriteMonstersToConsole(List<Monster> monsters)
        {

            foreach (var monster in monsters)
            {
                Console.WriteLine($"{monster.TimeStamp} {monster.Researcher} {monster.MonsterName} {monster.Latitude} {monster.Longitude}");
            }

        }

        private static Monster AddMonster()
        {
            //Need to create a new monster
            Monster newMonster = new Monster();
            //Need to give it a name
            Console.WriteLine("What is the name of the researcher?");
            newMonster.Researcher = Console.ReadLine();
            Console.WriteLine("What is the name of the new Monster?");
            newMonster.MonsterName = Console.ReadLine();
            // Console.WriteLine("What is the code name of the new Monster?");
            // newMonster.MonsterCodeName = Console.ReadLine();            
            Console.WriteLine("What is the latitude of the monster's location?");
            newMonster.Latitude = Console.ReadLine();
            Console.WriteLine("What is the longitude of the monster's location?");
            newMonster.Longitude = Console.ReadLine();
            return newMonster;
        }

        public static bool recordMatches(string monster, string[] record, int positionOfSearchTerm)
        {
            if (record[positionOfSearchTerm].Equals(monster))
            {
                return true;
            }
            return false;
        }

        public static void WriteMonstersToFile(string filePath)
        {
            List<string> output = new List<string>();

            foreach (var monster in Monsters)
            {
                output.Add($"{ monster.TimeStamp },{ monster.Researcher },{ monster.MonsterName },{ monster.Latitude },{ monster.Longitude }");
            }

            Console.WriteLine("writing to text file");
            File.WriteAllLines(filePath, output);
            Console.WriteLine("all entries written");
            Console.ReadLine();
        }

        //convert csv file into objects

        //write objects back to csv

        //add a monster 

        // get one monster then pull all info from that monster

        // get monster code name then pull all info from that code name 



    }

}

