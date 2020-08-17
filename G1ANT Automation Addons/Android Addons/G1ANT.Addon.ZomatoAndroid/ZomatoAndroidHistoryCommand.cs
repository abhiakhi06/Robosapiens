﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using G1ANT.Language;
using OpenQA.Selenium.Appium.MultiTouch;

namespace G1ANT.Addon.ZomatoAndroid
{
    [Command(Name = "zomatoandroid.history", Tooltip = "This enters into 'History' tab")]
    public class ZomatoAndroidHistoryCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            
        }

        public ZomatoAndroidHistoryCommand(AbstractScripter scripter) :
            base(scripter)
        {
        }

        // Implement this method
        public void Execute(Arguments arguments)
        {
            ///arguments.Search.Value = "";
            //arguments.Search.Value = "";
            //arguments.By.Value = "xpath";
            //arguments.By.Value = "id";
            //ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();

            TouchAction clickAction = new TouchAction(ZomatoAndroidOpenCommand.GetDriver());
            var coordinates = arguments.Search.Value.Split(',');
            clickAction.Tap(int.Parse(coordinates[275]), int.Parse(coordinates[1283])).Perform();

        }
    }
}