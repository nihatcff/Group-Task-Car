using System;

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
        Console.WriteLine($"{mebleg} AZN elave olundu. Yeni balans: {balans}");
    }

    public void PulCixar(double mebleg)
    {
        if (mebleg <= balans)
        {
            balans -= mebleg;
            Console.WriteLine($"{mebleg} AZN cixarildi. Yeni balans: {balans}");
        }
        else
        {
            Console.WriteLine("Kifayet qeder balans yoxdur.");
        }
    }

    public void BalansGoster()
    {
        Console.WriteLine($"Balansiniz: {balans} AZN");
    }

    public bool SifreDogrula(string pass)
    {
        return pass == sifre;
    }
}

class Program1
{
    static void Main()
    {
        BankApp bank = new BankApp(1000, "1234");

        Console.WriteLine("=== Xosh gelmisiniz ===");
        Console.Write("Sifrenizi daxil edin: ");
        string pass = Console.ReadLine()!;
        if (!bank.SifreDogrula(pass))
        {
            Console.WriteLine("Yanlis sifre. Cixilir...");
            return;
        }

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n1. Balans");
            Console.WriteLine("2. Medaxil");
            Console.WriteLine("3. Mexaric");
            Console.WriteLine("4. Kocurme");
            Console.WriteLine("5. Cixish");
            Console.Write("Secim: ");
            string secim = Console.ReadLine()!;

            switch (secim)
            {
                case "1": bank.BalansGoster(); break;
                case "2":
                    Console.Write("Medaxil meblegi: ");
                    if (double.TryParse(Console.ReadLine(), out double depozit) && depozit > 0)
                        bank.PulYatir(depozit);
                    else
                        Console.WriteLine("Yanlis mebleg.");
                    break;
                case "3":
                    Console.Write("Mexaric meblegi: ");
                    if (double.TryParse(Console.ReadLine(), out double mexaric) && mexaric > 0)
                        bank.PulCixar(mexaric);
                    else
                        Console.WriteLine("Yanlis mebleg.");
                    break;
                case "4":
                    Console.Write("Kocurulecek hesab: ");
                    string hesab = Console.ReadLine()!;
                    Console.Write("Mebleg: ");
                    if (double.TryParse(Console.ReadLine(), out double kocurme) && kocurme > 0)
                    {
                        if (kocurme <= bank.Balans)
                        {
                            bank.PulCixar(kocurme);
                            Console.WriteLine($"{kocurme} AZN {hesab} hesabina kocuruldu. Yeni balans: {bank.Balans}");
                        }
                        else Console.WriteLine("Kifayet qeder vesait yoxdur.");
                    }
                    else Console.WriteLine("Yanlis mebleg.");
                    break;
                case "5": exit = true; Console.WriteLine("Sag olun!"); break;
                default: Console.WriteLine("Yanlis secim."); break;
            }
        }
    }
}
