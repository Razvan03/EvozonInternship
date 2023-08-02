using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribution_Warehouse
{
    [Serializable]
    internal class Vegetable : Product
    {
        private string NutritionalQuality { get; set; }
        private string Producer { get; set; }

        public string GetNutritionalQuality() => NutritionalQuality;
        public void SetNutritionalQuality(string value) => NutritionalQuality = value;

        public string GetProducer() => Producer;
        public void SetProducer(string value) => Producer = value;

        public Vegetable(string name, Tuple<string, decimal> unit, decimal pricePerUnit, string nutritionalQuality, string producer)
        : base(name, unit, pricePerUnit)
        {
            NutritionalQuality = nutritionalQuality;
            Producer = producer;
        }
    }
}
