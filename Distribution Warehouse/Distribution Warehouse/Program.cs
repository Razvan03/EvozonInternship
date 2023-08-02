using System;

namespace Distribution_Warehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();
            warehouse.Generate();

            string filePath = "D:\\Evozon\\Distribution Warehouse\\warehouse_data.bin";

            warehouse.SaveToDisk(filePath);

            Warehouse loadedWarehouse = Warehouse.LoadFromDisk(filePath);

            if (loadedWarehouse != null)
            {
                Console.WriteLine("Warehouse Summary:\n");

                // Calculate and print Fruits summary
                Console.WriteLine("Fruits:");
                var fruits = loadedWarehouse.GetStoragePackages().Where(p => p.GetProduct() is Fruit);
                decimal totalFruitsWeight = fruits.Sum(f => f.GetUnitQuantity() * f.GetProduct().GetUnit().Item2);
                decimal totalFruitsPrice = fruits.Sum(f => f.CalculatePrice(DateTime.Now) * f.GetUnitQuantity());
                Console.WriteLine($"Total: {totalFruitsWeight} kg, Total Price: {totalFruitsPrice}\n");

                // Print individual fruit details
                foreach (var fruitPackage in fruits)
                {
                    Product product = fruitPackage.GetProduct();
                    string productName = product.GetName();
                    string unitDescription = product.GetUnit().Item1;
                    decimal unitDescription2 = product.GetUnit().Item2;
                    decimal unitQuantity = fruitPackage.GetUnitQuantity();
                    decimal unitPrice = product.GetPricePerUnit();
                    decimal totalPrice = fruitPackage.CalculatePrice(DateTime.Now) * unitQuantity;
                    decimal discount = fruitPackage.CalculateDiscount(DateTime.Now);

                    Console.WriteLine($"Fruit {productName}: {unitQuantity} {unitDescription} ( {unitDescription2} kg ), Unit Price: {unitPrice}, Total Price: {totalPrice}, Discount: {discount} %");
                }

                // Calculate and print Vegetables summary
                Console.WriteLine("\nVegetables:");
                var vegetables = loadedWarehouse.GetStoragePackages().Where(p => p.GetProduct() is Vegetable);
                decimal totalVegetablesWeight = vegetables.Sum(v => v.GetUnitQuantity() * v.GetProduct().GetUnit().Item2);
                decimal totalVegetablesPrice = vegetables.Sum(v => v.CalculatePrice(DateTime.Now) * v.GetUnitQuantity());
                Console.WriteLine($"Total: {totalVegetablesWeight} kg, Total Price: {totalVegetablesPrice}\n");

                // Print individual vegetable details
                foreach (var vegetablePackage in vegetables)
                {
                    Product product = vegetablePackage.GetProduct();
                    string productName = product.GetName();
                    string unitDescription = product.GetUnit().Item1;
                    decimal unitDescription2 = product.GetUnit().Item2;
                    decimal unitQuantity = vegetablePackage.GetUnitQuantity();
                    decimal unitPrice = product.GetPricePerUnit();
                    decimal totalPrice = vegetablePackage.CalculatePrice(DateTime.Now) * unitQuantity;
                    decimal discount = vegetablePackage.CalculateDiscount(DateTime.Now);

                    Console.WriteLine($"Vegetable {productName}: {unitQuantity} {unitDescription} ( {unitDescription2} kg ), Unit Price: {unitPrice}, Total Price: {totalPrice}, Discount: {discount} %");
                }
            }
        }
    }
}