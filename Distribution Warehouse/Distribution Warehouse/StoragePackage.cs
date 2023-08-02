using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution_Warehouse
{
    [Serializable]
    public class StoragePackage
    {
        private Product Product { get; set; }
        private decimal UnitQuantity { get; set; }
        private DateTime EntryDate { get; set; }
        private DateTime ExpirationDate { get; set; }

        public Product GetProduct() => Product;
        public void SetProduct(Product value) => Product = value;

        public decimal GetUnitQuantity() => UnitQuantity;
        public void SetUnitQuantity(decimal value) => UnitQuantity = value;

        public DateTime GetEntryDate() => EntryDate;
        public void SetEntryDate(DateTime value) => EntryDate = value;

        public DateTime GetExpirationDate() => ExpirationDate;
        public void SetExpirationDate(DateTime value) => ExpirationDate = value;

        public StoragePackage(Product product, decimal unitQuantity, DateTime entryDate, DateTime expirationDate)
        {
            Product = product;
            UnitQuantity = unitQuantity;
            EntryDate = entryDate;
            ExpirationDate = expirationDate;
        }

        public decimal CalculatePrice(DateTime date)
        {
            TimeSpan span = ExpirationDate - date;
            if (span.TotalDays < 0)
            {
                return 0;
            }

            decimal discountPercentage = 0;
            if (Product is Fruit && span.TotalDays < 35)
            {
                discountPercentage = (decimal)(35 - span.TotalDays) / 7 * 10 / 100;
            }
            else if (Product is Vegetable && span.TotalDays < 28)
            {
                discountPercentage = (decimal)(28 - span.TotalDays) / 7 * 5 / 100;
            }

            return Product.GetPricePerUnit() * (1 - discountPercentage);
        }

        public decimal CalculateDiscount(DateTime date)
        {
            TimeSpan span = ExpirationDate - date;
            if (span.TotalDays < 0)
            {
                return 100;
            }

            decimal discountPercentage = 0;
            if (Product is Fruit && span.TotalDays < 35)
            {
                discountPercentage = (decimal)(35 - span.TotalDays) / 7 * 10 ;
            }
            else if (Product is Vegetable && span.TotalDays < 28)
            {
                discountPercentage = (decimal)(28 - span.TotalDays) / 7 * 5 ;
            }

            return discountPercentage;
        }
    }
}
