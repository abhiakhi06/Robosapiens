﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using G1ANT.Language;
using OpenQA.Selenium;

namespace G1ANT.Addon.Facebook
{
    [Command(Name = "facebook.open", Tooltip = "This command opens Facebook")]
    public class FacebookOpenCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Name of a web browser")]
            public TextStructure Type { get; set; }

            [Argument(DefaultVariable = "Facebook Webpage", Tooltip = "URL address of a webpage to be loaded")]
            public TextStructure Url { get; set; } = new TextStructure("www.Facebook.com");

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Tooltip = "By default, waits until the webpage fully loads")]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(false);

            [Argument(Tooltip = "Name of a variable where the command's result will be stored")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }

        public FacebookOpenCommand(AbstractScripter scripter) :
            base(scripter)
        {
        }

        // Implement this method
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumWrapper wrapper = SeleniumManager.CreateWrapper(
                    arguments.Type.Value,
                    arguments.Url?.Value,
                    arguments.Timeout.Value,
                    arguments.NoWait.Value,
                    Scripter.Log,
                    Scripter.Settings.UserDocsAddonFolder.FullName);
                int wrapperId = wrapper.Id;
                OnScriptEnd = () =>
                {
                    SeleniumManager.DisposeAllOpenedDrivers();
                    SeleniumManager.RemoveWrapper(wrapperId);
                    SeleniumManager.CleanUp();
                };
                Scripter.Variables.SetVariableValue(arguments.Result.Value, new IntegerStructure(wrapper.Id));
            }
            catch (DriverServiceNotFoundException ex)
            {
                throw new ApplicationException("Driver not found", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Url '{arguments.Url.Value}'. Message: {ex.Message}", ex);
            }
        }
    }
}