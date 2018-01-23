using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Homework1;

namespace GUITest
{
    /// <summary>
    /// ViewTest 的摘要描述
    /// </summary>
    [CodedUITest]
    public class ViewTest
    {
        //const string FILE_PATH = @"../../../Homework1.exe";
        const string FILE_PATH = @"Homework1.exe";
        private const string CALCULATOR_TITLE = "View";

        [TestInitialize()]
        public void Initialize()
        {
            Robot.Initialize(FILE_PATH, CALCULATOR_TITLE);
        }

        /// <summary>
        /// Closes the launched program
        /// </summary>
        [TestCleanup()]
        public void Cleanup()
        {
            Robot.CleanUp();
        }

        //TestNextButton
        [TestMethod]
        public void TestNextButton()
        {
            Robot.ClickButton("Start");

            for (int i = 0; i < 10; i++)
                Robot.ClickButton("Next");

            Robot.SendKeyEnterToMessageBox(" ");
        }

        //TestStopButton
        [TestMethod]
        public void TestStopButton()
        {
            Robot.ClickButton("Start");
            Robot.ClickButton("Stop");
            Robot.AssertWindow(" ");
            Robot.SendKeyEnterToMessageBox(" ");
        }

        //TestNumeric
        [TestMethod]
        public void TestNumeric()
        {
            Robot.SetNumericUpDown("Numeric", "87");
            Robot.AssertNumericUpDown("Numeric", "87");
        }

        //TestCombo
        [TestMethod]
        public void TestCombo()
        {
            Robot.SetComboBox("Combobox", "All fill in the blank questions");
            Robot.AssertComboBox("Combobox", "All fill in the blank questions");
            Robot.SetComboBox("Combobox", "All multiple-choice questions");
            Robot.AssertComboBox("Combobox", "All multiple-choice questions");
            Robot.SetComboBox("Combobox", "Pick up question randomly");
            Robot.AssertComboBox("Combobox", "Pick up question randomly");
        }

        //測試選擇題題型-radioButton
        [TestMethod]
        public void TestRadioButton()
        {
            string[] button = new string[4] { "ButtonOne", "ButtonTwo", "ButtonThree", "ButtonFour" };
            Robot.SetComboBox("Combobox", "All multiple-choice questions");
            Robot.SetNumericUpDown("Numeric", "4");
            Robot.ClickButton("Start");

            for (int i = 0; i < 4; i++)
            {
                Robot.ClickRadioButton(button[i]);
                Robot.ClickButton("Next");
            }

            Robot.SendKeyEnterToMessageBox(" ");
        }

        //測試填充題題型-TextBox
        [TestMethod]
        public void TestTextBox()
        {
            string[] checkBoxText = new string[2] { "TestTextBox", "ForGUITest" };
            Robot.SetComboBox("Combobox", "All fill in the blank questions");
            Robot.SetNumericUpDown("Numeric", "2");
            Robot.ClickButton("Start");

            for (int i = 0; i < 2; i++)
            {
                Robot.SetEdit("TextBox", checkBoxText[i]);
                Robot.AssertEdit("TextBox", checkBoxText[i]);
                Robot.ClickButton("Next");
            }

            Robot.SendKeyEnterToMessageBox(" ");
        }
    }
}
