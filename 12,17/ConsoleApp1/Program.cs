using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract12_17
{
    internal class Program
    {
        static void Pract12()
        {
            Console.Write("Введите номер задачи: ");
            short numb = short.Parse(Console.ReadLine());
            switch (numb)
            {
                case 1:
                    int[,] matr = new int[10, 6];
                    Random random = new Random();

                    Console.WriteLine("Матрица:");
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            matr[i, j] = random.Next(1, 100); // Случайные числа от 1 до 99
                            Console.Write(matr[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }

                    // Подсчет количества четных элементов
                    int evenCount = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            if (matr[i, j] % 2 == 0)
                            {
                                evenCount++;
                            }
                        }
                    }

                    Console.WriteLine($"\nЧисло четных элементов в матрице: {evenCount}");
                    break;

                    case 2:                                                                                         //200000000
                    int[,] matrix = {
                    {1, 2, 0},
                    {4, 0, 6},
                    {0, 8, 9}
                     };

                    int count = 0;

                    // Проходим по строкам матрицы
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            // Проверяем наличие нулевого элемента в строке
                            if (matrix[i, j] == 0)
                            {
                                count++;
                                break; // Переходим к следующей строке
                            }
                        }
                    }
                    Console.WriteLine($"Количество строк с нулевым элементом: {count}");
                    break;


                    case 3:
                    int courses = 5;  // Количество курсов
                    int groupsPerCourse = 8;  // Количество групп на курсе
                    int totalGroups = courses * groupsPerCourse;  // Общее количество групп

                    int[,] students = new int[courses, groupsPerCourse];  // Массив студентов на курсе
                    double totalStudents = 0;  // Общее количество студентов

                    Random rand = new Random();

                    // Заполняем массив случайными числами студентов в каждой группе
                    for (int i = 0; i < courses; i++)
                    {
                        for (int j = 0; j < groupsPerCourse; j++)
                        {
                            students[i, j] = rand.Next(10, 31);  // От 10 до 30 студентов
                            totalStudents += students[i, j];  // Суммируем студентов
                        }
                    }

                    // Среднее количество студентов в группе
                    double avg = totalStudents / totalGroups;

                    Console.WriteLine($"Общее количество студентов: {totalStudents}");
                    Console.WriteLine($"Среднее количество студентов в группе: {avg:F2}");
                    break;
            }
        }









        static void Pract17()
        {
            Console.Write("Введите номер задачи: ");
            short numb = short.Parse(Console.ReadLine());
            switch (numb)
            {
                case 1:
                    string str1 = "яблоко банан апельсин груша";
                    string str2 = "груша персик яблоко киви";

                    // Разделяем строки на слова
                    string[] words1 = str1.Split(' ');
                    string[] words2 = str2.Split(' ');

                    // а) Слова, которые встречаются хотя бы в одной строке
                    string[] wordsInEither = words1.Union(words2).ToArray();
                    Console.WriteLine("Слова, встречающиеся хотя бы в одной строке: " + string.Join(" ", wordsInEither));

                    // б) Слова, которые встречаются только в первой строке
                    string[] wordsOnlyInFirst = words1.Except(words2).ToArray();
                    Console.WriteLine("Слова, встречающиеся только в первой строке: " + string.Join(" ", wordsOnlyInFirst));

                    // в) Слова, которые встречаются только в одной из строк
                    string[] wordsInOneString = words1.Where(word => !words2.Contains(word)).Union(words2.Where(word => !words1.Contains(word))) .ToArray();
                    Console.WriteLine("Слова, встречающиеся только в одной из строк: " + string.Join(" ", wordsInOneString));
                    break;



                case 2:
                    string sentence = "книга котик крик крот кабель кокок";
                    string[] words = sentence.Split(' ');

                    Console.WriteLine("Слова, начинающиеся и заканчивающиеся одной и той же буквой:");
                    foreach (string word in words)
                    {
                        if (word.Length > 1 && word[0] == word[word.Length - 1])
                        {
                            Console.WriteLine(word);
                        }
                    }

                    Console.WriteLine("\nСлова, содержащие ровно три буквы 'k':");
                    foreach (string word in words)
                    {
                        int kCount = 0;
                        foreach (char c in word)
                        {
                            if (c == 'к')
                            {
                                kCount++;
                            }
                        }
                        if (kCount == 3)
                        {
                            Console.WriteLine(word);
                        }
                    }
                    break;


                case 3:
                    Console.WriteLine("Введите строки (каждая строка должна начинаться с числа):");
                    string[] lines = new string[]
                    {
            "25 apple",
            "10 banana",
            "25 orange",
            "10 apple",
            "30 pear"
                    };

                    // Сортировка строк
                    Array.Sort(lines, (line1, line2) =>
                    {
                        // Разделяем строку на число и слово
                        string[] parts1 = line1.Split(' ');
                        string[] parts2 = line2.Split(' ');

                        // Преобразуем первую часть каждой строки в число для сравнения
                        int num1 = int.Parse(parts1[0]);
                        int num2 = int.Parse(parts2[0]);

                        // Сначала сортируем по числам
                        if (num1 != num2)
                        {
                            return num1.CompareTo(num2);
                        }
                        else
                        {
                            // Если числа одинаковые, сортируем по слову
                            return parts1[1].CompareTo(parts2[1]);
                        }
                    });

                    // Вывод отсортированных строк
                    Console.WriteLine("Результат сортировки:");
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                    break;

            }
        }






        static void Main(string[] args)
        {
            Console.Write("Введите номер практической работы(12,17):");
            short numb = short.Parse(Console.ReadLine());
            switch (numb)
            {
                case 12: Pract12(); break;

                case 17:
                    Pract17();
                    break;
            }
            Console.ReadKey();
        }
    }
}
