using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

public class BankApp
{
    private double balans = 16000;
    private string sifre = "1234";

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
            Console.WriteLine($"{mebleg} AZN cixarildsi Yeni balans: {balans}");
        }
        else
        {
            Console.WriteLine("Kifayet qeder balans yoxdur");
        }
    }

    public void BalansGoster()
    {
        Console.WriteLine($"Balansiniz {balans} AZN");
    }

    public bool SifreDogrula(string pass)
    {
        return pass == sifre;
    }
}
