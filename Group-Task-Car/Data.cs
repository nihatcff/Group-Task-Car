namespace CarManagementSystem
{
    public class Data
    {
        public List<Car> Cars { get; set; }

        public Data()
        {
            Cars = new List<Car>
            {
                new Car(1, "Toyota", "Corolla", 2023, "Red", 22000),
                new Car(2, "Honda", "Civic", 2022, "Blue", 21000),
                new Car(3, "Ford", "Mustang", 2021, "Black", 35000),
                new Car(4, "Chevrolet", "Camaro", 2023, "Yellow", 37000),
                new Car(5, "BMW", "X5", 2022, "White", 60000),
                new Car(6, "Audi", "A4", 2023, "Gray", 45000),
                new Car(7, "Mercedes", "C-Class", 2021, "Silver", 50000),
                new Car(8, "Tesla", "Model 3", 2023, "White", 42000),
                new Car(9, "Hyundai", "Elantra", 2022, "Blue", 20000),
                new Car(10, "Kia", "Sportage", 2021, "Red", 25000)
            };
        }

        public void DisplayAllCars()
        {
            foreach (var car in Cars)
            {
                car.DisplayInfo();
            }
        }
    }
}


