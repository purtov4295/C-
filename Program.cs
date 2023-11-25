using System;
using System.Text;
using System.IO;

internal class Program
{
    // static bool IsPalindrome(string word)
    // {
    //     char[] charArray = word.ToCharArray();
    //     Array.Reverse(charArray);
    //     string reversedWord = new string(charArray);

    //     if (reversedWord.ToLower() == word.ToLower())
    //     {   
    //         return true;
    //     }
    //     else
    //     {
    //         return false;
    //     }
    // }

    static int CalculateRabbitPairs(int months)
    {
    if (months <= 0)
    {
        return 0;
    }
    else if (months == 1 || months == 2)
    {
        return 1;
    }
    else
    {
        int zeroMonthPairs = 0;
        int oneMonthPairs = 0;
        int twoMonthPairs = 1;
        int totalPairs = 2;

        for (int i = 3; i <= months; i++)
        {
            totalPairs = twoMonthPairs * 2 + zeroMonthPairs + oneMonthPairs;
            oneMonthPairs = zeroMonthPairs;
            zeroMonthPairs = twoMonthPairs;
            twoMonthPairs += oneMonthPairs;
        }

        return totalPairs;
    }
    }
    private static void Main(string[] args)
    {
        double numberLab = double.Parse(Console.ReadLine());
        
        if (numberLab == 1)
        {
            Console.WriteLine("Введите значение градусов:");
            double degrees = double.Parse(Console.ReadLine());

            Console.WriteLine("Выберите исходную шкалу (C - Цельсий, K - Кельвин, F - Фаренгейт):");
            string sourceScale = Console.ReadLine().ToUpper();

            Console.WriteLine("Выберите шкалу для перевода (C - Цельсий, K - Кельвин, F - Фаренгейт):");
            string targetScale = Console.ReadLine().ToUpper();

            double result;

            // Цельсий в Кельвин
            if (sourceScale == "C" && targetScale == "K")
            {
                result = degrees + 273.15;
            }
            // Кельвин в Цельсий
            else if (sourceScale == "K" && targetScale == "C")
            {
                result = degrees - 273.15;
            }
            // Цельсий в Фаренгейт
            else if (sourceScale == "C" && targetScale == "F")
            {
                result = degrees * 9 / 5 + 32;
            }
            // Фаренгейт в Цельсий
            else if (sourceScale == "F" && targetScale == "C")
            {
                result = (degrees - 32) * 5 / 9;
            }
            // Кельвин в Фаренгейт
            else if (sourceScale == "K" && targetScale == "F")
            {
                result = degrees * 9 / 5 - 459.67;
            }
            // Фаренгейт в Кельвин
            else if (sourceScale == "F" && targetScale == "K")
            {
                result = (degrees + 459.67) * 5 / 9;
            }
            else
            {
                Console.WriteLine("Неверный выбор шкалы!");
                return;
            }

            Console.WriteLine($"Результат: {result} {targetScale}");
        }
        if (numberLab == 2)
        {
            Console.WriteLine("Введите слово: ");
            string word = Console.ReadLine();

            bool check = true;
            for (int i = 0; i < word.Length / 2; i++) {
                if(word[i] == word[word.Length - i - 1]) {
                    check = true;
                } else {
                    check = false;
                }
            }

            Console.WriteLine(check ? "Палиндром" : "Not палиндром");
        }
        if (numberLab == 3){
            Console.WriteLine("Введите количество месяцев:");
            int months = Convert.ToInt32(Console.ReadLine());

            int pairs = CalculateRabbitPairs(months);
            Console.WriteLine("Количество пар кроликов будет: " + pairs);

            Console.ReadLine();
        }
        if (numberLab == 4){
        int j = 0;
        
        long[,] matrix = new long[10,10];

        Console.WriteLine("\n");

        //читаем файл построчно
        foreach (string line in System.IO.File.ReadLines("File.csv")) {
            //выводим то что считали
            Console.WriteLine(line);
            
            //в переменную кладем часть строки до ,
            string[] word = line.Split(',');
            //int[] word_convert;
            int i = 0;

            foreach (string value in word) {
                long number = Int64.Parse(value);
                matrix[i, j] = number;
                i++;
            }
        }
        j++;
        Console.WriteLine("\nInput operation (max, min, aver, disp): ");
        string into = Console.ReadLine();

        switch (into) {
            case "max":
                long max = matrix[0, 0];
                for (int a = 9; a >= 0; a--) {
                    for (int b = 9; b >= 0; b--) {
                        if (matrix[a, b] > max) {
                            max = matrix[a, b];
                            
                        }
                    }
                }
                Console.WriteLine($"{max}");
                break;

            case "min":
            long min = matrix[0, 0];
                for (int a = 0; a < 10; a++) {
                    for (int b = 0; b < 10; b++) {
                        if (matrix[a, b] < min) {
                            min = matrix[a, b];
                        }
                    }
                }
                Console.WriteLine($"Minimum: {min}");
                break;

            case "aver":
            long aver = 0;
                for (int a = 0; a < 10; a++) {
                    for (int b = 0; b < 10; b++) {
                        aver += matrix[a, b];
                        }
                    }
                    aver /= 100;
                Console.WriteLine($"Average: {aver}");
                break;


            case "disp":
            double S = 0, S1 = 0, S2 = 0;
            double aver1 = 0;

                for (int a = 0; a < 10; a++) {
                    for (int b = 0; b < 10; b++) {
                        aver1 += matrix[a, b];
                        }
                    }
                    aver1 /= 100;
                for (int a = 0; a < 10; a++) {
                    for (int b = 0; b < 10; b++) {
                        S = Math.Pow((matrix[a, b] - aver1), 2);
                    }
                }
                S1 = 1.0 / 99.0;
                S2 = Math.Sqrt(S * S1); 
                Console.WriteLine($"Dispersion: {S2:f3}");
                break;
            default:
                Console.WriteLine("Error of input");
                break;
        }
        }
    }
}
