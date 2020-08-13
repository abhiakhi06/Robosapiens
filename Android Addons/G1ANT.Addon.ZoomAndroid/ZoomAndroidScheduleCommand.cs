﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using G1ANT.Language;


namespace G1ANT.Addon.ZoomAndroid
{
    [Command(Name = "zoomandroid.schedule", Tooltip = "This command opens the schedule Tab on the user's zoom account.")]
    public class ZoomAndroidScheduleCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {

        }

        public ZoomAndroidScheduleCommand(AbstractScripter scripter) :
            base(scripter)
        {
        }

        // Implement this method
        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "//android.widget.LinearLayout[@content-desc=]/android.widget.RelativeLayout/android.widget.ImageView";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();
        }
    }
}