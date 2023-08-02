using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution_Warehouse
{
    [Serializable]
    internal class Fruit : Product
    {
        private string NutritionalQuality { get; set; }

        public string GetNutritionalQuality() => NutritionalQuality;
        public void SetNutritionalQuality(string value) => NutritionalQuality = value;

        public Fruit(string name, Tuple<string, decimal> unit, decimal pricePerUnit, string nutritionalQuality)
        : base(name, unit, pricePerUnit)
        {
            NutritionalQuality = nutritionalQuality;
        }
    }
}
