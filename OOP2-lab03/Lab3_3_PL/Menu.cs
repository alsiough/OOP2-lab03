using System;
using System.Collections.Generic;
using Lab3_3_BLL;
using Lab3_3_DAL.Entities;
using Lab3_3_DAL.DataProvider;

namespace Lab3_3_PL
{
    public static class Menu
    {
        public static void MainMenu()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            // Default provider: JSON (UTF-16)
            var service = new EntityService(new JsonProvider());
            var accounts = new List<Account>();
            var students = new List<Student>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== МЕНЮ ===");
                Console.WriteLine("1. Додати рахунок");
                Console.WriteLine("2. Зберегти рахунки у файл (UTF-16 JSON)");
                Console.WriteLine("3. Завантажити рахунки з файлу");
                Console.WriteLine("4. Порахувати студентів гуртожитку 5 курсу (демо)");
                Console.WriteLine("5. Зберегти студентів у файл");
                Console.WriteLine("6. Завантажити студентів з файлу");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Код власника: ");
                        string code = Console.ReadLine() ?? string.Empty;
                        Console.Write("Сума: ");
                        if (!double.TryParse(Console.ReadLine(), out var sum)) sum = 0;
                        accounts.Add(new Account(code, sum));
                        break;

                    case "2":
                        Console.Write("Ім'я файлу (наприклад accounts.json): ");
                        var fname = Console.ReadLine() ?? "accounts.json";
                        service.SaveAccounts(accounts, fname);
                        Console.WriteLine($"✅ Збережено у {fname}");
                        break;

                    case "3":
                        Console.Write("Ім'я файлу для зчитування: ");
                        var rfile = Console.ReadLine() ?? "accounts.json";
                        try
                        {
                            accounts = service.LoadAccounts(rfile);
                            Console.WriteLine("Завантажені рахунки:");
                            foreach (var acc in accounts) Console.WriteLine(acc);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }
                        break;

                    case "4":
                        // Демонстраційний список студентів (можна замінити завантаженням)
                        students = new List<Student>
                        {
                            new Student { LastName = "Іваненко", FirstName = "Олег", Course = 5, Gender = "ч", Residence = "5-32" },
                            new Student { LastName = "Петренко", FirstName = "Ірина", Course = 5, Gender = "ж", Residence = "Київ" },
                            new Student { LastName = "Сидоренко", FirstName = "Богдан", Course = 5, Gender = "ч", Residence = "5-12" }
                        };
                        int count = service.CountDormStudents(students);
                        Console.WriteLine($"Кількість студентів у гуртожитку 5 курсу: {count}");
                        break;

                    case "5":
                        Console.Write("Ім'я файлу для студентів (наприклад students.json): ");
                        var sf = Console.ReadLine() ?? "students.json";
                        service.SaveStudents(students, sf);
                        Console.WriteLine($"✅ Збережено у {sf}");
                        break;

                    case "6":
                        Console.Write("Ім'я файлу для зчитування студентів: ");
                        var rf = Console.ReadLine() ?? "students.json";
                        try
                        {
                            students = service.LoadStudents(rf);
                            Console.WriteLine("Завантажені дані студентів:");
                            foreach (var s in students) Console.WriteLine(s);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Помилка: {ex.Message}");
                        }
                        break;

                    case "0":
                        return;
                }

                Console.WriteLine("Натисніть Enter для продовження...");
                Console.ReadLine();
            }
        }
    }
}
