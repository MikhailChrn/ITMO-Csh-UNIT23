using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Задание_01
{
    //1.Разработать асинхронный метод для вычисления факториала числа. В методе Main выполнить проверку работы метода.
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1;
            Console.WriteLine("Здравствуйте!");
        ReadFactorialCount:
            Console.WriteLine("Введите для вычисление факториала (целое положительное число):");
            try { n = Convert.ToInt16(Console.ReadLine()); }
            catch { Console.WriteLine("Введено некорректное значение!"); goto ReadFactorialCount; }
            if (n > 99 || n < 2) { Console.WriteLine("Введено некорректное значение!"); goto ReadFactorialCount; }

            long q = GetFactorialAsync(n).Result; //Вызываем асинхронный метод

            Console.WriteLine("факториал числа {0}! составляет: {1}", n, q);
            Console.ReadKey();
        }
        static async Task<long> GetFactorialAsync(int n)
        //Асинхронный метод позволяет запускать вычисление факториала в режиме AWAIT
        {
            Console.WriteLine("GetFactorialAsync начал работу.");
            long result = await Task.Run(() => GetFactorial(n));
            Console.WriteLine("GetFactorialAsync закончил работу.");
            return result;
        }
        static long GetFactorial(int n)
        //Метод, вычисляющий факториал
        {
            long fact = 1;
            for (int i = 1; i < n; i++) { fact = fact * (i + 1); }
            return fact;
        }
    }
}
