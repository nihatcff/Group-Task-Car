using System;
using System.Collections.Generic;
using System.Linq;

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

        public void MasinElaveEt()
        {
            Console.Write("Id: "); int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Marka: "); string marka = Console.ReadLine()!;
            Console.Write("Model: "); string model = Console.ReadLine()!;
            Console.Write("İl: "); int il = Convert.ToInt32(Console.ReadLine());
            Console.Write("Qiymət: "); double qiymet = double.Parse(Console.ReadLine()!);

            Masin masin = new Masin(id, marka, model, il, qiymet);
            masinlar.Add(masin);
            bank.PulCixar(qiymet);
            Console.WriteLine($"{marka} {model} sistemə əlavə olundu.");
        }

        public void MasinSil()
        {
            Console.Write("Silinəcək maşının ID-si: ");
            int id = int.Parse(Console.ReadLine()!);

            Masin? masin = masinlar.FirstOrDefault(x => x.Id == id);
            if (masin != null)
            {
                masinlar.Remove(masin);
                Console.WriteLine($"{masin.Marka} {masin.Model} silindi.");
            }
            else Console.WriteLine("Maşın tapılmadı.");
        }

        public void MasinFiltrle()
        {
            Console.Write("Filtrlənəcək il: ");
            if (!int.TryParse(Console.ReadLine(), out int il))
            {
                Console.WriteLine("Yanlış il daxil edildi.");
                return;
            }

            var fff = masinlar.Where(x => x.Il == il).OrderBy(x => x.Il).ToList();
            if (fff.Count == 0)
            {
                Console.WriteLine("Heç bir maşın tapılmadı.");
                return;
            }

            Console.WriteLine($"\n{il}-ci il istehsalı olan maşınlar:");
            foreach (var m in fff)
                m.DisplayInfo();
        }

        public void MasinCesidle()
        {
            var d = masinlar.OrderBy(x => x.Il).ToList();
            Console.WriteLine("\nBütün maşınlar il üzrə sıralandı:");
            foreach (var m in d)
                m.DisplayInfo();
        }

        public void MasinSatVeyaKiraye()
        {
            Console.Write("Maşının markası: ");
            string marka = Console.ReadLine()!;
            Console.Write("Model: ");
            string model = Console.ReadLine()!;

            Masin? masin = masinlar.FirstOrDefault(x => x.Marka == marka && x.Model == model);
            if (masin == null) { Console.WriteLine("Maşın tapılmadı."); return; }

            Console.WriteLine("1. Satmaq  2. Kirayə vermək");
            string secim = Console.ReadLine()!;
            if (secim == "1")
            {
                bank.PulCixar(masin.Qiymet);
                masinlar.Remove(masin);
                Console.WriteLine($"{marka} {model} satıldı.");
            }
            else if (secim == "2")
            {
                Console.Write("Kirayə qiyməti: ");
                double kiraye = double.Parse(Console.ReadLine()!);
                masin.Icarede = true;
                bank.PulYatir(kiraye);
                Console.WriteLine($"{marka} {model} kirayəyə verildi ({kiraye} AZN).");
            }
            else Console.WriteLine("Yanlış seçim.");
        }

        public void Menyu()
        {
            while (true)
            {
                Console.WriteLine("\n----------------------------- RENT A CAR -------------------------------------");
                Console.WriteLine("1. Maşın əlavə et");
                Console.WriteLine("2. Maşın sil");
                Console.WriteLine("3. Maşınları filtr et");
                Console.WriteLine("4. Maşınları sırala");
                Console.WriteLine("5. Maşını sat / kirayə ver");
                Console.WriteLine("0. Çıxış");
                Console.Write("Seçim: ");
                string secim = Console.ReadLine()!;
                switch (secim)
                {
                    case "1": MasinElaveEt(); break;
                    case "2": MasinSil(); break;
                    case "3": MasinFiltrle(); break;
                    case "4": MasinCesidle(); break;
                    case "5": MasinSatVeyaKiraye(); break;
                    case "0": return;
                    default: Console.WriteLine("Yanlış seçim."); break;
                }
            }
        }
    }
}
