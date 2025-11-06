using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace CarManagementSystem
{
    public class BankApp
    {
        private string sifre = "1234";
        private double balans = 1000;

        public void Start()
        {
            Console.WriteLine("=== Xosh gelmisiniz (Bank sistemi) ===");
            Console.Write("Sifrenizi daxil edin: ");
            string pass = ReadPassword();
            Console.WriteLine();

            if (pass != sifre)
            {
                Console.WriteLine("Yanlis sifre. Cixilir...");
                return;
            }

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n1. Balans \n2. Medaxil  \n3. Mexaric  \n4. Kocurme  \n5. Cixish \n Secim: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Console.WriteLine($"Balansiniz: {balans}");
                        break;
                    case "2":
                        Console.Write("Medaxil meblegi: ");
                        if (double.TryParse(Console.ReadLine(), out double depozit) && depozit > 0)
                        {
                            balans += depozit;
                            Console.WriteLine($"{depozit} elave olundu. Yeni balans: {balans}");
                        }
                        else Console.WriteLine("Yanlis mebleg.");
                        break;
                    case "3":
                        Console.Write("Mexaric meblegi: ");
                        if (double.TryParse(Console.ReadLine(), out double mexaric) && mexaric > 0)
                        {
                            if (mexaric <= balans)
                            {
                                balans -= mexaric;
                                Console.WriteLine($"{mexaric} cekildi. Balans: {balans}");
                            }
                            else Console.WriteLine("Kifayet qeder vesait yoxdur.");
                        }
                        else Console.WriteLine("Yanlis mebleg.");
                        break;
                    case "4":
                        Console.Write("Kocurulecek hesab: ");
                        string hesab = Console.ReadLine();
                        Console.Write("Mebleg: ");
                        if (double.TryParse(Console.ReadLine(), out double kocurme) && kocurme > 0)
                        {
                            if (kocurme <= balans)
                            {
                                balans -= kocurme;
                                Console.WriteLine($"{kocurme} {hesab} hesabina kocuruldu. Yeni balans: {balans}");
                            }
                            else Console.WriteLine("Kifayet qeder vesait yoxdur.");
                        }
                        else Console.WriteLine("Yanlis mebleg.");
                        break;
                    case "5":
                        Console.WriteLine("Sag olun! Cixis edildi.");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Yanlis secim. 1-5 araliginda secin.");
                        break;
                }
            }
        }

        private string ReadPassword()
        {
            return Console.ReadLine();
        }
    }
}
