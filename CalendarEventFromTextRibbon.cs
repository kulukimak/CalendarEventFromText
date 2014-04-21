using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Microsoft.Office.Tools.Ribbon;

namespace CalendarEventFromText
{
    public partial class CalendarEventFromTextRibbon
    {
        private void CalendarEventFromTextRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void openEventerButton_Click(object sender, RibbonControlEventArgs e)
        {
            //Globals.ThisAddIn.mainWindow = new MainUserControl { Visibility = Visibility.Visible };
            Globals.ThisAddIn.host = new Window() { Content = Globals.ThisAddIn.mainWindow };
            Globals.ThisAddIn.host.Show();
        }
    }
}
