using System;

namespace AgeCalculator
{
    public class InvalidYearException : Exception
    {
        public InvalidYearException() : base() { }

        public InvalidYearException(string message) : base(message) { }

        public InvalidYearException(string message, Exception innerException)
            : base(message, innerException) { }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Калькулятор возраста");
            try
            {
                // Ввод года рождения
                Console.Write("Введите год вашего рождения: ");
                string input = Console.ReadLine()!;
                // Проверка ввода
                if (!int.TryParse(input, out int birthYear))
                {
                    throw new FormatException("Вы ввели не число. Пожалуйста, введите год в числовом формате.");
                }
                // Проверка года рождения
                ValidateBirthYear(birthYear);
                // Вычисление возраста
                int currentYear = DateTime.Now.Year;
                // Вычисление возраста
                int age = currentYear - birthYear;

                // Вывод результата
                Console.WriteLine($"Ваш возраст: {age} лет");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Ошибка ввода: {ex.Message}");
            }
            catch (InvalidYearException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла непредвиденная ошибка: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nНажмите любую клавишу для завершения...");
                Console.ReadKey();
            }
        }
        static void ValidateBirthYear(int birthYear)
        {
            int currentYear = DateTime.Now.Year;
            if (birthYear < 1900)
            {
                throw new InvalidYearException("Недопустимый год рождения. Год должен быть не ранее 1900.");
            }
            if (birthYear > currentYear)
            {
                throw new InvalidYearException("Недопустимый год рождения. Год не может быть из будущего.");
            }
        }
    }
}