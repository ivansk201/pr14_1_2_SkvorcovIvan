using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace prakt14
{
    class Program
    {
        static void zad1()
        {
            Stack<int> stack = new Stack<int>();
            Console.Write("Введите n =  ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"Размерность стека {n}");        
            for (int i = 1; i <= n; i++)
            {
                stack.Push(i);
            }
            Console.WriteLine($"Верхний элемент стека = {n}");
            Console.WriteLine($"Размерность стека {n}");
            Console.Write($"Содиржимое стека = ");
            while (stack.Count > 0)             
            {
                Console.Write($" {stack.Pop()}");
            }
            stack.Clear();       
            Console.WriteLine($"\nНовая размерность {stack.Count}");
        }
        static void zad2()
        {
            Console.WriteLine("Введите вашу формулу:");
            string formula = Console.ReadLine();
            File.WriteAllText("t.txt", formula);
            string expression = File.ReadAllText("t.txt");

            Stack<int> stack = new Stack<int>();
            bool inString = false;

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                if (c == '"')
                {
                    inString = !inString;
                }
                else if (!inString)
                {
                    if (c == '(')
                    {
                        stack.Push(i);
                    }
                    else if (c == ')')
                    {
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        else
                        {
                            Console.WriteLine("Возможно лишняя ) скобка в позиции: {0}", i + 1);
                            return;
                        }
                    }
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("Скобки сбалансированы");
            }
            else
            {
                Console.WriteLine("Возможно лишняя ( скобка в позиции: {0}", stack.Pop() + 1);
                Console.ReadKey();
            }

            Console.ReadKey();


        }



        static void zad3()
        {
            Console.WriteLine("Введите вашу формулу:");
            string formula = Console.ReadLine();
            File.WriteAllText("t.txt", formula);
            string expression = File.ReadAllText("t.txt");
            Stack<int> stack2 = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    stack2.Push(i);
                }
                else if (expression[i] == ')')
                {
                    if (stack2.Count > 0) 
                    {
                       
                        stack2.Pop();
                    }
                    else 
                    {
                        expression = expression.Remove(i, 1);
                        expression = expression.Insert(i, " ");
                    }
                }
            }
            while (stack2.Count > 0)
            {
                int index = stack2.Pop();
                expression = expression.Remove(index, 1);
                expression = expression.Insert(index, " ");
            }
            using (StreamWriter writer = new StreamWriter("t1.txt"))
            {
                writer.Write(expression);
            }

            Console.WriteLine("Новое выражение успешно записано в файл t1.txt.");
            Console.ReadLine();
        }




            static void Main(string[] args)
            {
            try {

                Console.WriteLine("Выбирите какое задание хотите выполнить? 1,2,3");
                int vibor = int.Parse(Console.ReadLine());
                switch (vibor)
                {
                    case 1:
                        zad1();
                        break;
                    case 2:
                        zad2();
                        break;
                    case 3:
                        zad3();
                        break;

                    default:
                        Console.WriteLine("Ошибка, Вы ввели недопустимое число.");
                        Console.ReadKey();
                        break;
                }

            }
            catch { Console.WriteLine("Ошибка, Вы ввели недопустимое число."); }
            Console.ReadKey();
        }
            

            
        }
    }

