using System;
using System.Collections.Generic;

namespace AdvancedPersonnelAccounting
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddDossier = "1";
            const string CommandOutputAllDossiers = "2";
            const string CommandDeleteDossier = "3";
            const string CommandSearchSurnames = "4";
            const string CommandExit = "5";

            bool isWork = true;

            string userInput;

            List<string> fullNames = new List<string> { "Иванов Иван Иванович", "Петров Петр Петрович", "Карлов Карл Карлович" };
            List<string> positions = new List<string> { "Актер", "Художник", "Музыкант" };


            while (isWork)
            {
                Console.WriteLine("Выберите пункт меню");
                Console.WriteLine($"{CommandAddDossier} Добавить досье");
                Console.WriteLine($"{CommandOutputAllDossiers} Вывести все досье");
                Console.WriteLine($"{CommandDeleteDossier} Удалить досье");
                Console.WriteLine($"{CommandSearchSurnames} Поиск по фамилии");
                Console.WriteLine($"{CommandExit} Выход");

                userInput = Console.ReadLine();

                Console.Clear();

                switch (userInput)
                {
                    case CommandAddDossier:
                        AddDossier(fullNames, positions);
                        break;

                    case CommandOutputAllDossiers:
                        OutputAllDossiers(fullNames, positions);
                        break;

                    case CommandDeleteDossier:
                        DeleteDossier(fullNames, positions);
                        break;

                    case CommandSearchSurnames:
                        SearchSurnames(fullNames, positions);
                        break;

                    case CommandExit:
                        isWork = false;
                        break;
                }

                Console.WriteLine("\n");
            }
        }

        private static void AddDossier(List<string> fullNamesArray, List<string> positionsArray)
        {
            Console.WriteLine("Введите ФИО");
            string inputName = Console.ReadLine();
            fullNamesArray.Add(inputName);

            Console.WriteLine("Должность");
            string post = Console.ReadLine();
            positionsArray.Add(post);
        }

        private static void OutputAllDossiers(List<string> fullNamesArray, List<string> positionsArray)
        {
            for (int i = 0; i < fullNamesArray.Count; i++)
            {
                int number = 1;
                int dossierNumber = i + number;

                Console.WriteLine($"{dossierNumber} {fullNamesArray[i]} {positionsArray[i]}");
            }
        }

        private static void DeleteDossier(List<string> fullNamesArray, List<string> positionsArray)
        {
            Console.WriteLine("Введите номер досье которое хотите удалить");
            int.TryParse(Console.ReadLine(), out int element);

            if (element <= 0 || element > fullNamesArray.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Данные не верны");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                fullNamesArray.RemoveAt(element - 1);
                positionsArray.RemoveAt(element - 1);
            }
        }

        private static void SearchSurnames(List<string> fullNamesArray, List<string> positionsArray)
        {
            char whitespace = ' ';

            bool isSurnameFound = false;

            Console.WriteLine("Введите фамилию");
            string surname = Console.ReadLine();

            for (int i = 0; i < fullNamesArray.Count; i++)
            {
                string[] splitArray = fullNamesArray[i].Split(whitespace);

                for (int j = 0; j < splitArray.Length; j++)
                {
                    if (splitArray[0].ToLower() == surname.ToLower())
                    {
                        int number = 1;
                        int dossierNumber = i + number;

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"[{dossierNumber}] Full name: [{fullNamesArray[i]}] Post: [{positionsArray[i]}]");
                        Console.ForegroundColor = ConsoleColor.White;

                        isSurnameFound = true;
                        break;
                    }
                }
            }

            if (isSurnameFound == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Фамилия не найдена");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
