using System;
using System.Threading;

namespace Khlyzova_Valeria_PRI_117_lab_03
{
    class Program
    {
        // определяем входные параметры для потоков
        const double a = -5;
        const double b = 5;
        const double n = 40;

        // 15 вариант
        // 7 * x / (3 * x ^ 2 + 2 * x + 1) - ln(5 * tg(x)) - exp(7 * sqrt(x))
        private static void MainThread(object obj)
        {
            // конвертируем в число с точкой
            double x = Convert.ToDouble(obj);
            Console.WriteLine("поток со значением " + x + " запущен");

            // считаем
            double xOne = 7 * x / (3 * Math.Pow(x, 2) + Math.Pow(2, x) + 1);
            double xTwo = Math.Log(Math.Abs(5 * Math.Tan(x)));
            double xThree = Math.Sqrt(Math.Abs(x));
            double result = xOne - xTwo - xThree;

            // выводим результат
            Console.WriteLine("поток со значением " + x + " завершен, результат: " + result);
        }

        static void Main(string[] args)
        {
            // создаем три потока
            Thread th_1 = new Thread(MainThread);
            Thread th_2 = new Thread(MainThread);
            Thread th_3 = new Thread(MainThread);

            // назначаем потокам приоритет
            th_1.Priority = ThreadPriority.Highest; // самый высокий
            th_2.Priority = ThreadPriority.Normal; // средний
            th_3.Priority = ThreadPriority.Lowest; // низкий

            // запускаем потоки
            th_1.Start(a);
            th_2.Start(b);
            th_3.Start(n);

            Console.WriteLine("все потоки запущены\n\n");

            // ждем выполнения всех потоков
            th_1.Join();
            th_2.Join();
            th_3.Join();

            Console.WriteLine("\n\nвсе потоки завершены");

            Console.ReadKey();
        }
    }
}
