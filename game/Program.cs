
using System;
using System.Diagnostics.Metrics;

class Program
{
    void Logic()
    {
        string[] coordinates = ["1", "2", "3", "4", "5", "6", "7", "8", "9"];
        Console.WriteLine("Выберите чем играть (X или O):");
        string element = Console.ReadLine();
        Program solution = new Program();
        solution.DrawDesk(coordinates);
        switch (element) 
        {
            case "X":
                while (true)
                {
                    Console.WriteLine("Ходит игрок: ");
                    string move = Convert.ToString(solution.Player(coordinates));
                    coordinates[Array.IndexOf(coordinates, move)] = element;
                    solution.DrawDesk(coordinates);
                    Console.ReadKey();
                    if (solution.CheckWin(coordinates, element))
                    { 
                        Console.WriteLine("Выиграл игрок");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("Ходит бот: ");
                    string bot = Convert.ToString(solution.Ai(coordinates));
                    coordinates[Array.IndexOf(coordinates, bot)] = "O";
                    solution.DrawDesk(coordinates);                   
                    if (solution.CheckWin(coordinates, "O"))
                    {
                        Console.WriteLine("Выиграл бот");
                        Console.ReadKey();
                        break;
                    }
                }     
                break;
            case "O":
                while (true)
                {
                    Console.WriteLine("Ходит игрок: ");
                    string move = Convert.ToString(solution.Player(coordinates));
                    coordinates[Array.IndexOf(coordinates, move)] = element;
                    solution.DrawDesk(coordinates);
                    Console.ReadKey();
                    if (solution.CheckWin(coordinates, element))
                    {
                        Console.WriteLine("Выиграл игрок");
                        Console.ReadKey();
                        break;
                    }
                    Console.WriteLine("Ходит бот: ");
                    string bot = Convert.ToString(solution.Ai(coordinates));
                    coordinates[Array.IndexOf(coordinates, bot)] = "X";
                    solution.DrawDesk(coordinates);
                    if (solution.CheckWin(coordinates, "X"))
                    {
                        Console.WriteLine("Выиграл бот");
                        Console.ReadKey();
                        break;
                    }
                }
                break;
        }
    }
    int Player(string[] coordinate)
    {
        Console.WriteLine("Введите свободную координату: ");
        int movement = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < coordinate.Length; i++)
        {
            bool isnumeric = int.TryParse(coordinate[i], out int n);
            if (isnumeric && movement == Convert.ToInt32(coordinate[i]))
            {
                break;
            }
        }
        return movement;
    }
    int Ai(string[] coordinate)
    {
        int[] newarray = new int[0];
        int counter = 0;
        for (int i = 0; i < coordinate.Length; i++)
        {
            bool isnumeric = int.TryParse(coordinate[i], out int n);
            if (isnumeric)
            {
                newarray[counter] = Convert.ToInt32(coordinate[i]);
            }
        }
        Random random = new Random();
        int result = random.Next(0, coordinate.Length);
        return newarray[result];
    }
    bool CheckWin(string[] coordinate, string string_value)
    {
        int[,] win_combination = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, { 2, 4, 6 }, { 0, 4, 8 }, { 0, 3, 6 }, { 1, 4, 7 }, { 2, 5, 8 } };
        bool winner = false;
        int count = 0;
        for (int i = 0; i < win_combination.Length; i++)
        {
            for (int d = 0; d < 3; d++)
            {
                int index_element = win_combination[i, d];
                Program indexes_list = new Program();
                if (indexes_list.FindIndexes(string_value, coordinate).Contains(index_element)) 
                {
                    count++;
                }
            }
            if (count == 3)
            {
                winner = true;
                break;
            }
            else
            {
                count = 0;
            }
        }
        return winner;
    }
    int[] FindIndexes(string string_value, string[] coordinate)
    {
        int[] result = new int[0];
        int count = 0;
        for (int i = 0; i < coordinate.Length; i++) 
        {
            if (string_value == coordinate[i])
            {
                result[count] = i;
                count++;
            }
        }
        return result;
    }
    void DrawDesk(string[] coordinate) 
    {
        string string_line = "| ";
        int count = 1;
        Console.WriteLine("---------");
        for (int i = 0; i < coordinate.Length; i++) 
        {
            string_line += coordinate[i] + " | ";
            count++;
            if (count % 3 == 0) 
            {
                Console.WriteLine(string_line);
                Console.WriteLine("---------");
                string_line = "";
            }
        }
        Console.WriteLine("---------");
    }
}