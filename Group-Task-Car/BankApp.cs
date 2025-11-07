using System;

namespace CarManagementSystem
{
    public class BankApp
    {
        private double balans;
        private string sifre;

        public BankApp(double ilkinBalans, string parol)
        {
            balans = ilkinBalans;
            sifre = parol;
        }

        public double Balans => balans;

        public void PulYatir(double mebleg)
        {
            balans += mebleg;
            Console.WriteLine($"{mebleg} AZN əlavə olundu. Yeni balans: {balans}");
        }

        public void PulCixar(double mebleg)
        {
            if (mebleg <= balans)
            {
                balans -= mebleg;
                Console.WriteLine($"{mebleg} AZN çıxarıldı. Yeni balans: {balans}");
            }
            else
            {
                Console.WriteLine("Kifayət qədər balans yoxdur.");
            }
        }

        public void BalansGoster()
        {
            Console.WriteLine($"Balansınız: {balans} AZN");
        }

        public bool SifreDogrula(string pass)
        {
            return pass == sifre;
        }

        public void Menyu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n========== BANK APP ==========");
                Console.WriteLine("1. Balansa bax");
                Console.WriteLine("2. Pul yatir");
                Console.WriteLine("3. Pul cixar");
                Console.WriteLine("4. Köçürmə et");
                Console.WriteLine("0. Geri qayıt");
                Console.Write("Seçim: ");
                string secim = Console.ReadLine()!;

                switch (secim)
                {
                    case "1": BalansGoster(); break;
                    case "2":
                        Console.Write("Məbləğ: ");
                        if (double.TryParse(Console.ReadLine(), out double depozit) && depozit > 0)
                            PulYatir(depozit);
                        else
                            Console.WriteLine("Yanlış məbləğ.");
                        break;
                    case "3":
                        Console.Write("Məbləğ: ");
                        if (double.TryParse(Console.ReadLine(), out double mexaric) && mexaric > 0)
                            PulCixar(mexaric);
                        else
                            Console.WriteLine("Yanlış məbləğ.");
                        break;
                    case "4":
                        Console.Write("Köçürüləcək hesab: ");
                        string hesab = Console.ReadLine()!;
                        Console.Write("Məbləğ: ");
                        if (double.TryParse(Console.ReadLine(), out double kocurme) && kocurme > 0)
                        {
                            if (kocurme <= balans)
                            {
                                PulCixar(kocurme);
                                Console.WriteLine($"{kocurme} AZN {hesab} hesabına köçürüldü. Yeni balans: {balans}");
                            }
                            else Console.WriteLine("Kifayət qədər vəsait yoxdur.");
                        }
                        else Console.WriteLine("Yanlış məbləğ.");
                        break;
                    case "0": exit = true; break;
                    default: Console.WriteLine("Yanlış seçim."); break;
                }
            }
        }
    }
}