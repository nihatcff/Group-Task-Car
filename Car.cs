using System;

namespace CarManagementSystem
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }

        public Car(int id, string brand, string model, int year, string color, double price)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            Color = color;
            Price = price;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}, Brand: {Brand}, Model: {Model}, Year: {Year}, Color: {Color}, Price: ${Price}");
        }
    }
}

