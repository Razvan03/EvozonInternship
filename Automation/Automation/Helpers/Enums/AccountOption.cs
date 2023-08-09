using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Helpers.Enums
{
    public enum AccountOption
    {
        [System.ComponentModel.Description("My Account")]
        MY_ACCOUNT,
        [System.ComponentModel.Description("My Wishlist")]
        MY_WISHLIST,
        [System.ComponentModel.Description("My Cart")]
        MY_CART,
        [System.ComponentModel.Description("Checkout")]
        CHECKOUT,
        [System.ComponentModel.Description("Register")]
        REGISTER,
        [System.ComponentModel.Description("Log In")]
        LOG_IN,
        [System.ComponentModel.Description("Log Out")]
        LOG_OUT
    }
}
