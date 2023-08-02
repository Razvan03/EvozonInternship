using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution_Warehouse
{
    [Serializable]
    public abstract class Product
    {
        private string Name { get; set; }
        private Tuple<string, decimal> Unit { get; set; }
        private decimal PricePerUnit { get; set; }

        public string GetName() => Name;
        public void SetName(string value) => Name = value;

        public Tuple<string, decimal> GetUnit() => Unit;
        

        public decimal GetPricePerUnit() => PricePerUnit;
        public void SetPricePerUnit(decimal value) => PricePerUnit = value;

        protected Product(string name, Tuple<string, decimal> unit, decimal pricePerUnit)
        {
            Name = name;
            Unit = unit;
            PricePerUnit = pricePerUnit;
        }
    }
}
