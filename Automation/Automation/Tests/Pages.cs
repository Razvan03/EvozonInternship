﻿using Automation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Pages;
using Automation.Helpers;
using SeleniumExtras.PageObjects;

namespace Automation.Tests
{
    public static class Pages
    {
        public static Homepage HomePage => InitPage(new Homepage());

        public static LoginPage LoginPage => InitPage(new LoginPage());
        public static T InitPage<T>(T page)
        {
            PageFactory.InitElements(Browser.GetDriver(), page);
            return page;
        }
    }
}