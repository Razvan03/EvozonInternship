using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Distribution_Warehouse
{
    [Serializable]
    public class Warehouse
    {
        private List<StoragePackage> StoragePackages { get; set; }
        private List<Product> fruits = new List<Product>();
        private List<Product> vegetables = new List<Product>();
        static Random random = new Random();

        public Warehouse()
        {
            StoragePackages = new List<StoragePackage>();
        }

        public List<StoragePackage> GetStoragePackages() => StoragePackages;

        public int GetRandomNumber(int min, int max)
        {
            return random.Next(min, max); 
        }

        public string GetRandomNutritionalQuality()
        {
            string[] nutritionalQualities = { "Low", "Medium", "High" };
            return nutritionalQualities[GetRandomNumber(0, nutritionalQualities.Length)];
        }

        public string GetRandomProducer()
        {
            string[] producers = { "Mr. Jones", "Uncle Henry", "Oliver Wendell Douglas", "Philip Walter Archer", "Ray Kinsella", "Arthur Hogget", "Richard Alpert", "Adam Barton", "Paul Martin", "Mulan", "Napoleon" };
            return producers[GetRandomNumber(0, producers.Length)];
        }

        public StoragePackage GenerateRandomStoragePackage(Product product)
        {
            string unitType = product.GetUnit().Item1;
            decimal unitQuantity = 0;

            switch (unitType)
            {
                case "Kg":
                    unitQuantity = GetRandomNumber(50, 250);
                    break;
                case "Bag":
                    unitQuantity = GetRandomNumber(15, 25);
                    break;
                case "Box":
                    unitQuantity = GetRandomNumber(30, 60);
                    break;
                case "Pack":
                    unitQuantity = GetRandomNumber(100, 500);
                    break;
            }

            DateTime entryDate = DateTime.Now.AddDays(-GetRandomNumber(1, 60));

            DateTime expirationDate = entryDate.AddMonths(GetRandomNumber(1, 6));

            return new StoragePackage(product, unitQuantity, entryDate, expirationDate);
        }

        public void Generate()
        {
            // Generate vegetable and fruit names
            string[] vegetableNames = { "Potatoe", "Onion", "Cabbage","Broccoli","Cucumber","Corn","Green Beans","Lettuce","Pumpkin","Tomatoes" };
            string[] fruitNames = { "Apple", "Peach", "Orange","Strawberry","Avocado","Mango","Cherry","Grape","Banana","Raspberry" };

            // Generate unit options and their corresponding ranges
            var unitOptions = new List<Tuple<string, decimal>>()
            {
                new Tuple<string, decimal>("Kg", 1),
                new Tuple<string, decimal>("Bag", GetRandomNumber(1,11)),
                new Tuple<string, decimal>("Box", GetRandomNumber(1,11)),
                new Tuple<string, decimal>("Pack", 1),
            };

            // Generate 100 vegetables
            for (int i = 0; i < 100; i++)
            {
                string name = vegetableNames[GetRandomNumber(0, vegetableNames.Length)];
                Tuple<string, decimal> unit = unitOptions[GetRandomNumber(0, unitOptions.Count)];
                decimal pricePerUnit = GetRandomNumber(5, 30);
                string nutritionalQuality = GetRandomNutritionalQuality();
                string farmer = GetRandomProducer();

                Vegetable vegetable = new Vegetable(name, unit, pricePerUnit, nutritionalQuality,farmer);
                StoragePackages.Add(GenerateRandomStoragePackage(vegetable));
            }

            // Generate 100 fruits
            for (int i = 0; i < 100; i++)
            {
                string name = fruitNames[GetRandomNumber(0, fruitNames.Length)];
                Tuple<string, decimal> unit = unitOptions[GetRandomNumber(0, unitOptions.Count)];
                decimal pricePerUnit = GetRandomNumber(5, 30);
                string nutritionalQuality = GetRandomNutritionalQuality();

                Fruit fruit = new Fruit(name, unit, pricePerUnit, nutritionalQuality);
                StoragePackages.Add(GenerateRandomStoragePackage(fruit));
            }
        }

        public void SaveToDisk(string filePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, this);
                }
                Console.WriteLine("Warehouse data saved to disk successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving warehouse data: {ex.Message}");
            }
        }

        public static Warehouse LoadFromDisk(string filePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    return (Warehouse)binaryFormatter.Deserialize(fileStream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading warehouse data: {ex.Message}");
                return null;
            }
        }
    }
}
