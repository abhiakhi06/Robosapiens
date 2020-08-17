﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using G1ANT.Language;


namespace G1ANT.Addon.IRCTCAndroid
{
    [Command(Name = "irctcandroid.refundhistory", Tooltip = "This navigates to the 'Refund History' tab")]
    public class IRCTCAndroidRefundhistoryCommand : Language.Command
    {
        public class Arguments : AppiumCommandArguments
        {
            
        }

        public IRCTCAndroidRefundhistoryCommand(AbstractScripter scripter) :
            base(scripter)
        {
        }

        // Implement this method
        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/androidx.drawerlayout.widget.DrawerLayout/android.widget.RelativeLayout/android.widget.LinearLayout[1]/android.widget.FrameLayout/android.widget.RelativeLayout/android.widget.ScrollView/android.widget.LinearLayout/android.widget.LinearLayout[2]/android.widget.LinearLayout/android.widget.LinearLayout[2]";
            //arguments.Search.Value = "cris.org.in.prs.ima:id/refund_history_ll";
            arguments.By.Value = "xpath";
            //arguments.By.Value = "id";
            ElementHelper.GetElement(arguments.By.Value, arguments.Search.Value).Click();

        }
    }
}