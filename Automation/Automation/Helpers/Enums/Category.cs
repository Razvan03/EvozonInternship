﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MsTests.Helpers.Enums
{
    public enum Category
    {
        [System.ComponentModel.Description("WOMEN")]
        WOMEN,
        [System.ComponentModel.Description("MEN")]
        MEN,
        [System.ComponentModel.Description("ACCESSORIES")]
        ACCESSORIES,
        [System.ComponentModel.Description("HOME & DECOR")]
        HOME_AND_DECOR,
        [System.ComponentModel.Description("SALE")]
        SALE,
        [System.ComponentModel.Description("VIP")]
        VIP
    }
}
