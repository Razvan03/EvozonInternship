using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsTests.Helpers.Enums
{
    public class Subcategory
    {
        public enum Women
        {
            [System.ComponentModel.Description("View All Women")]
            VIEW_ALL,
            [System.ComponentModel.Description("New Arrivals")]
            NEW_ARRIVALS,
            [System.ComponentModel.Description("Tops & Blouses")]
            TOPS_AND_BLOUSES,
            [System.ComponentModel.Description("Pants & Denim")]
            PANTS_AND_DENIM,
            [System.ComponentModel.Description("Dresses & Skirts")]
            DRESSES_AND_SKIRTS
        }

        public enum Men
        {
            [System.ComponentModel.Description("View All Men")]
            VIEW_ALL,
            [System.ComponentModel.Description("New Arrivals")]
            NEW_ARRIVALS,
            [System.ComponentModel.Description("Shirts")]
            SHIRTS,
            [System.ComponentModel.Description("Tees, Knits and Polos")]
            TEES_KNITS_AND_POLOS,
            [System.ComponentModel.Description("Pants & Denim")]
            PANTS_AND_DENIM,
            [System.ComponentModel.Description("Blazers")]
            BLAZERS
        }
    }
}
