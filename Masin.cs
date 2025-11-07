using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManagementSystem
{
    public class Masin
    {
        public int Id;
        public string Marka { get; set; }
        public string Model { get; set; }
        public int Il {  get; set; }
        public double Qiymet { get; set; }
        public bool Icarede { get; set; }=false;

        public Masin(int id ,string marka, string model,int il, double qiymet)
        {
            Id = id;
            Marka = marka;
            Model = model;
            Il = il;
            Qiymet = qiymet;
            Icarede = false;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"{Marka} {Model} - Qiymet: {Qiymet} AZN - {(Icarede ? "Kirayede" : "Bos")}");
        }
    }

}
