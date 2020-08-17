﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using G1ANT.Language;


namespace G1ANT.Addon.MicrosoftTeams
{
    [Command(Name = "microsoft.search", Tooltip = "Search a keyword in microsoft teams")]
    public class MicrosoftTeamsSearchCommand : Language.Command
    {
        public class Arguments : SeleniumCommandArguments
        {
            // Enter all arguments you need
            [Argument(Name = "keyword", Required = true, Tooltip = "Enter the search keyword.")]
            public TextStructure keyword { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Tooltip = "By default, waits until the webpage fully loads")]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(true);

            [Argument(Tooltip = "Result variable")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }

        public MicrosoftTeamsSearchCommand(AbstractScripter scripter) :
            base(scripter)
        {
        }

        // Implement this method
        public void Execute(Arguments arguments)
        {
            arguments.Search.Value = "/html/body/div[1]/div[1]/app-header-bar/div/power-bar/div/div/form/search-box/div/input";
            arguments.By.Value = "xpath";
            SeleniumManager.CurrentWrapper.TypeText(arguments.keyword.Value, arguments, arguments.Timeout.Value);
            SeleniumManager.CurrentWrapper.PressKey("enter", arguments, arguments.Timeout.Value);
        }
    }
}