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

        public enum HomeAndDecor
        {
            [System.ComponentModel.Description("View All Home & Decor")]
            VIEW_ALL,
            [System.ComponentModel.Description("Books & Music")]
            BOOKS_AND_MUSIC,
            [System.ComponentModel.Description("Bed & Bath")]
            BED_AND_BATH,
            [System.ComponentModel.Description("Electronics")]
            ELECTRONICS,
            [System.ComponentModel.Description("Decorative Accents")]
            DECORATIVE_ACCENTS
        }

        public enum Accessories
        {
            [System.ComponentModel.Description("View All Accessories")]
            VIEW_ALL,
            [System.ComponentModel.Description("Eyewear")]
            EYEWEAR,
            [System.ComponentModel.Description("Jewelry")]
            JEWELRY,
            [System.ComponentModel.Description("Shoes")]
            SHOES,
            [System.ComponentModel.Description("Bags & Luggage")]
            BAGS_AND_LUGGAGE,
        }

        public enum Sale
        {
            [System.ComponentModel.Description("View All Sale")]
            VIEW_ALL,
            [System.ComponentModel.Description("Women")]
            WOMEN,
            [System.ComponentModel.Description("Men")]
            MEN,
            [System.ComponentModel.Description("Accessories")]
            ACCESSORIES,
            [System.ComponentModel.Description("Home & Decor")]
            HOME_AND_DECOR,
        }
    }
}
