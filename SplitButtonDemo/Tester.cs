using AhDung.WinForm.Controls;
using System;
using System.Windows.Forms;

namespace SplitButtonDemo
{
    public partial class Tester : Form
    {
        public Tester()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            ActiveControl = null;

            foreach (var control in Controls)
            {
                if (control is Button button)
                {
                    //register all button Click events, SplitButton is derived from Button
                    button.Click += buttons_Click;

                    //set drop down menu to all SplitButton
                    if (control is SplitButton splitButton)
                        splitButton.SplitDropDownMenuStrip = contextMenuStrip1;
                }
            }

            //customize split area width
            sb3.SplitWidth = 40;

            //set context menu
            //note that there are two context menus in .net: ContextMenu and ContextMenuStrip,
            //ContextMenu is encapsulated from the system native menu, but ContextMenuStrip is
            //implemented by pure .net. SplitButton allows you use one of them, if both setted,
            //ContextMenu first.
            sb5.SplitDropDownMenu = contextMenu1;

            //customize split click event action. register this event will cause SplitDropDownMenuStrip
            //and SplitDropDownMenu to be ignored.
            //So, the precedence is ClickSplit > SplitDropDownMenu > SplitDropDownMenuStrip
            sb6.ClickSplit += (_, _) => WriteMessage("split clicked");
        }

        private void buttons_Click(object sender, EventArgs e)
        {
            WriteMessage($"\"{(sender as Control)?.Text}\" clicked.");
        }

        void WriteMessage(string message)
        {
            txbMessage.AppendText($"{message}{Environment.NewLine}");
        }

        private void ToolStripMenuItems_Click(object sender, EventArgs e)
        {
            WriteMessage($"\"{(sender as ToolStripItem)?.Text}\" clicked.");
        }

        private void menuItems_Click(object sender, EventArgs e)
        {
            WriteMessage($"\"{(sender as MenuItem)?.Text}\" clicked.");
        }
    }
}
