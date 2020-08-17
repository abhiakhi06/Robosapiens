﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using G1ANT.Language;


namespace G1ANT.Addon.OlaAndroid
{
    [Command(Name = "olaandroid.bookcab", Tooltip = "This searches for can in an android app and book the cab")]
    public class OlaAndroidBookcabCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            // Enter all arguments you need
            [Argument(DefaultVariable = "Pickup Location", Required = true, Tooltip = "Enter Pickup location")]
            public TextStructure Pickup { get; set; } = new TextStructure("");

            [Argument(DefaultVariable = "Drop Location", Required = true, Tooltip = "Enter Drop location")]
            public TextStructure Drop { get; set; } = new TextStructure("");
        }

        public OlaAndroidBookcabCommand(AbstractScripter scripter) :
            base(scripter)
        {
        }

        // Implement this method
        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "com.olacabs.customer:id/tv_pickup";
            //arguments.Search.Value = "";
            arguments.By.Value = "id";
            //arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();

            arguments.Search.Value = "com.olacabs.customer:id/et_pickup";
            //arguments.Search.Value = "";
            arguments.By.Value = "id";
            //arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.Pickup.Value);

            arguments.Search.Value = "com.olacabs.customer:id/tv_drop";
            //arguments.Search.Value = "";
            arguments.By.Value = "id";
            //arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();

            arguments.Search.Value = "com.olacabs.customer:id/et_drop";
            //arguments.Search.Value = "";
            arguments.By.Value = "id";
            //arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).SendKeys(arguments.Drop.Value);

            arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/androidx.drawerlayout.widget.DrawerLayout/android.widget.FrameLayout[1]/android.widget.FrameLayout/android.view.ViewGroup/android.view.ViewGroup[2]/android.view.ViewGroup/android.view.ViewGroup[2]/androidx.recyclerview.widget.RecyclerView/android.widget.LinearLayout[2]/android.view.ViewGroup/android.widget.TextView[1]";
            arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();

            arguments.Search.Value = "com.olacabs.customer:id/btn_done";
            //arguments.Search.Value = "";
            arguments.By.Value = "id";
            //arguments.By.Value = "xpath";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();

        }
    }
}