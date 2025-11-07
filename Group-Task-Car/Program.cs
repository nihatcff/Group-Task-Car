using System;
using CarSales;

namespace CarManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankApp bankApp = new BankApp(1000, "1234");

            Console.WriteLine("=== Xoş Gəlmisiniz ===");
            Console.Write("Şifrenizi daxil edin: ");
            string pass = Console.ReadLine()!;

            if (!bankApp.SifreDogrula(pass))
            {
                Console.WriteLine("Yanlış şifrə! Proqram bağlanır...");
                return;
            }

        repeat:
            Console.Clear();
            Console.WriteLine("========= CAR MANAGEMENT SYSTEM =========");
            Console.WriteLine("1. Car Sale");
            Console.WriteLine("2. Rent a Car");
            Console.WriteLine("3. Bank App");
            Console.WriteLine("0. Exit");
            Console.Write("\nSeçiminizi edin (0-3): ");
            string secim = Console.ReadLine()!;

            switch (secim)
            {
                case "1":
                    {
                        CarSaleApp sale = new CarSaleApp(bankApp);
                        sale.Menyu();
                        break;
                    }
                case "2":
                    {
                        RentACar rent = new RentACar(bankApp);
                        rent.Menyu();
                        break;
                    }
                case "3":
                    {
                        bankApp.Menyu();
                        break;
                    }
                case "0":
                    Console.WriteLine("Proqramdan çıxılır...");
                    return;
                default:
                    Console.WriteLine("Yanlış seçim etdiniz!");
                    Console.ReadKey();
                    goto repeat;
            }

            Console.Write("\nAna menyuya qayıtmaq istəyirsiniz? (Y/N): ");
            string cavab = Console.ReadLine()!.ToUpper();
            if (cavab == "Y")
                goto repeat;

            Console.WriteLine("Proqram bitdi. Sağ olun!");
        }
    }
}
