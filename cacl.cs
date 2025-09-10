using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pervoeChislo, vtoroeChislo, resultat;
            double pamyat = 0; // Память калькулятора
            char znak;
            const double MAX_CHISLO = 999999;
            
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            
            Console.WriteLine("Добро пожаловать в калькулятор. Вам необходимо ввести первое число, затем знак действия(+, -, *, /, %, i, s, r, m+, m-, mr), которое хотите совершить и второе число (если требуется).");
            Console.WriteLine("Для выхода введите 'x' вместо числа.");
            Console.WriteLine("Для использования памяти введите 'p' вместо числа.");

            while (true)
            {
                Console.WriteLine("\n--- Новый расчет ---");
                Console.WriteLine("Текущее значение памяти: " + (float)pamyat);
                
                // Ввод первого числа
                Console.Write("Введите первое число (или 'x' для выхода, 'p' для использования памяти): ");
                string vvodPervogo = Console.ReadLine();
                
                if (vvodPervogo.ToLower() == "x")
                {
                    Console.WriteLine("Выход из калькулятора...");
                    break;
                }
                
                if (vvodPervogo.ToLower() == "p")
                {
                    pervoeChislo = pamyat;
                    Console.WriteLine("Использовано значение из памяти: " + (float)pervoeChislo);
                }
                else
                {
                    if (!double.TryParse(vvodPervogo, out pervoeChislo))
                    {
                        Console.WriteLine("Ошибка. Введите корректное число.");
                        continue;
                    }
                    
                    // Проверка максимального числа
                    if (Math.Abs(pervoeChislo) > MAX_CHISLO)
                    {
                        Console.WriteLine("Ошибка. Число не может превышать 999999 по модулю.");
                        continue;
                    }
                }
                
                // Ввод знака операции
                Console.Write("Введите знак действия (+, -, *, /, %, i, s, r, m+, m-, mr): ");
                string vvodZnaka = Console.ReadLine();
                
                if (vvodZnaka.ToLower() == "x")
                {
                    Console.WriteLine("Выход из калькулятора...");
                    break;
                }
                
                if (string.IsNullOrEmpty(vvodZnaka))
                {
                    Console.WriteLine("Ошибка. Знак не может быть пустым.");
                    continue;
                }
                
                znak = vvodZnaka[0];
                
                // Операции, не требующие второго числа
                if (znak == 'i' || znak == 's' || znak == 'r' || znak == 'm' || znak == 'M' || znak == 'p' || znak == 'P' || znak == 'n' || znak == 'N')
                {
                    vtoroeChislo = 0;
                }
                else
                {
                    // Ввод второго числа
                    Console.Write("Введите второе число (или 'x' для выхода, 'p' для использования памяти): ");
                    string vvodVtorogo = Console.ReadLine();
                    
                    if (vvodVtorogo.ToLower() == "x")
                    {
                        Console.WriteLine("Выход из калькулятора...");
                        break;
                    }
                    
                    if (vvodVtorogo.ToLower() == "p")
                    {
                        vtoroeChislo = pamyat;
                        Console.WriteLine("Использовано значение из памяти: " + (float)vtoroeChislo);
                    }
                    else
                    {
                        if (!double.TryParse(vvodVtorogo, out vtoroeChislo))
                        {
                            Console.WriteLine("Ошибка. Введите корректное число.");
                            continue;
                        }
                        
                        // Проверка максимального числа
                        if (Math.Abs(vtoroeChislo) > MAX_CHISLO)
                        {
                            Console.WriteLine("Ошибка. Число не может превышать 999999 по модулю.");
                            continue;
                        }
                    }
                }
                
                // Выполнение операций
                if (znak == '+')
                {
                    resultat = pervoeChislo + vtoroeChislo;
                    if (Math.Abs(resultat) > MAX_CHISLO)
                    {
                        Console.WriteLine("Ошибка. Результат превышает максимальное допустимое значение 999999.");
                    }
                    else
                    {
                        Console.WriteLine("Сумма ваших чисел равна " + (float)resultat);
                    }
                }
                else if (znak == '-')
                {
                    resultat = pervoeChislo - vtoroeChislo;
                    if (Math.Abs(resultat) > MAX_CHISLO)
                    {
                        Console.WriteLine("Ошибка. Результат превышает максимальное допустимое значение 999999.");
                    }
                    else
                    {
                        Console.WriteLine("Разность ваших чисел равна " + (float)resultat);
                    }
                }
                else if (znak == '*')
                {
                    resultat = pervoeChislo * vtoroeChislo;
                    if (Math.Abs(resultat) > MAX_CHISLO)
                    {
                        Console.WriteLine("Ошибка. Результат превышает максимальное допустимое значение 999999.");
                    }
                    else
                    {
                        Console.WriteLine("Произведение ваших чисел равно " + (float)resultat);
                    }
                }
                else if (znak == '/')
                {
                    if (vtoroeChislo == 0)
                    {
                        Console.WriteLine("Ошибка. Делитель не может быть равным нулю.");
                    }
                    else
                    {
                        resultat = pervoeChislo / vtoroeChislo;
                        if (Math.Abs(resultat) > MAX_CHISLO)
                        {
                            Console.WriteLine("Ошибка. Результат превышает максимальное допустимое значение 999999.");
                        }
                        else
                        {
                            Console.WriteLine("Частное ваших чисел равно " + (float)resultat);
                        }
                    }
                }
                else if (znak == '%')
                {
                    if (vtoroeChislo == 0)
                    {
                        Console.WriteLine("Ошибка. Делитель не может быть равным нулю.");
                    }
                    else
                    {
                        resultat = pervoeChislo % vtoroeChislo;
                        if (Math.Abs(resultat) > MAX_CHISLO)
                        {
                            Console.WriteLine("Ошибка. Результат превышает максимальное допустимое значение 999999.");
                        }
                        else
                        {
                            Console.WriteLine("Остаток от деления равен " + (float)resultat);
                        }
                    }
                }
                else if (znak == 'i') // 1/x - обратное число
                {
                    if (pervoeChislo == 0)
                    {
                        Console.WriteLine("Ошибка. Нельзя вычислить обратное значение для нуля.");
                    }
                    else
                    {
                        resultat = 1 / pervoeChislo;
                        if (Math.Abs(resultat) > MAX_CHISLO)
                        {
                            Console.WriteLine("Ошибка. Результат превышает максимальное допустимое значение 999999.");
                        }
                        else
                        {
                            Console.WriteLine("Обратное значение числа равно " + (float)resultat);
                        }
                    }
                }
                else if (znak == 's') // x^2 - квадрат числа
                {
                    resultat = pervoeChislo * pervoeChislo;
                    if (Math.Abs(resultat) > MAX_CHISLO)
                    {
                        Console.WriteLine("Ошибка. Результат превышает максимальное допустимое значение 999999.");
                    }
                    else
                    {
                        Console.WriteLine("Квадрат числа равен " + (float)resultat);
                    }
                }
                else if (znak == 'r') // √x - квадратный корень
                {
                    if (pervoeChislo < 0)
                    {
                        Console.WriteLine("Ошибка. Нельзя извлечь квадратный корень из отрицательного числа.");
                    }
                    else
                    {
                        resultat = Math.Sqrt(pervoeChislo);
                        if (Math.Abs(resultat) > MAX_CHISLO)
                        {
                            Console.WriteLine("Ошибка. Результат превышает максимальное допустимое значение 999999.");
                        }
                        else
                        {
                            Console.WriteLine("Квадратный корень равен " + (float)resultat);
                        }
                    }
                }
                else if (znak == 'm' || znak == 'M') // M+ - добавление в память
                {
                    if (Math.Abs(pamyat + pervoeChislo) > MAX_CHISLO)
                    {
                        Console.WriteLine("Ошибка. Значение памяти не может превышать 999999.");
                    }
                    else
                    {
                        pamyat += pervoeChislo;
                        Console.WriteLine("Число добавлено в память. Текущее значение памяти: " + (float)pamyat);
                    }
                }
                else if (znak == 'n' || znak == 'N') // M- - вычитание из памяти
                {
                    if (Math.Abs(pamyat - pervoeChislo) > MAX_CHISLO)
                    {
                        Console.WriteLine("Ошибка. Значение памяти не может превышать 999999.");
                    }
                    else
                    {
                        pamyat -= pervoeChislo;
                        Console.WriteLine("Число вычтено из памяти. Текущее значение памяти: " + (float)pamyat);
                    }
                }
                else if (znak == 'p' || znak == 'P') // MR - чтение из памяти
                {
                    Console.WriteLine("Текущее значение памяти: " + (float)pamyat);
                }
                else if (znak == 'c' || znak == 'C') // MC - очистка памяти
                {
                    pamyat = 0;
                    Console.WriteLine("Память очищена. Текущее значение памяти: 0");
                }
                else
                {
                    Console.WriteLine("Ошибка. Вы ввели неверный знак.");
                }
            }
            
            Console.WriteLine("Для выхода нажмите любую клавишу...");
            Console.ReadKey();
        }
    }
}