using CarManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagementSystem
{   
    
     public class RentACar
    {
         private List<Masin> masinlar = new List<Masin>();

        private BankApp bank;

        public RentACar(BankApp bankApp)
        {
            bank = bankApp;

        }

        public void MasinElaveEt(Masin masin)
        {
            masinlar.Add(masin);
            Console.WriteLine($"{masin.Marka} {masin.Model} sisteme eelave olundu");

        }

        public void MasinAl(string marka, string model)
        {
             Masin? tapilan = masinlar.FirstOrDefault(x => x.Marka == marka && x.Model == model);
             if (tapilan != null)
            {
               
                if (bank.Balans >= tapilan.Qiymet)
                {
                
                    bank.PulCixar(tapilan.Qiymet);
                    Console.WriteLine($"{tapilan.Marka} {tapilan.Model} alindi!");
                }
             
                 else
                {
                     Console.WriteLine("Balans masin almaq ucun kifayet deyil!");
                }
            }
             else
            {
                  Console.WriteLine("Bu markada masin tapiulmadi!");
            }
        }

        public  void IcareVer(string marka, string model, double icareQiymeti)
        {
             Masin? tapilan = masinlar.FirstOrDefault(x => x.Marka == marka && x.Model == model);
           
            if (tapilan != null && !tapilan.Icarede)
            {
                tapilan.Icarede = true;
                bank.PulYatir(icareQiymeti);
            
                Console.WriteLine($"{tapilan.Marka} {tapilan.Model} icareye verildi ({icareQiymeti} AZN).");
            }
            else
            {
                Console.WriteLine("Bu masin artiq icarededir ve ya movcud deyil.");
            }
        }

     
        public void MasinGeriAl(string marka, string model)
         {
             Masin? tapilan = masinlar.FirstOrDefault(x => x.Marka == marka && x.Model == model);//? null meselesine gore yazmisam  ? siz null ola bilmez  ? ile null ola biler 
            if (tapilan != null && tapilan.Icarede)
            {
                tapilan.Icarede = false;
                Console.WriteLine($"{tapilan.Marka} {tapilan.Model} icareden geri qaytarildi.");
            }
            else
            {
                Console.WriteLine("Bu masin icarede deyil.");
            }
        }

     
        public void MasinlariGoster()
        {
         
            
            Console.WriteLine("Movcud masinlar: ");
            foreach (var f in masinlar)
            {
                Console.WriteLine($"{f.Marka} {f.Model} - Qiymet: {f.Qiymet} AZN - {(f.Icarede ? "İcarede" : "bosdur")}");
            }
        }
    }
}
