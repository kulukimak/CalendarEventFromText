using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalendarEventFromText
{
    /// <summary>
    /// Interaction logic for MainUserControl.xaml
    /// </summary>
    public partial class MainUserControl : UserControl
    {
        public MainUserControl()
        {
            InitializeComponent();
        }

        public delegate void PassingTextEventHandler(object sender, SourceTextArgs sourceText);
        public event PassingTextEventHandler PreviewThrowEvent;
        public event EventHandler CommitEvent;

        private void EnableGruppeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            GruppeTextBox.IsEnabled = true;
        }

        private void EnableGruppeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            GruppeTextBox.IsEnabled = false;
        }

        private void CreateEventsButton_Click(object sender, RoutedEventArgs e)
        {
            CommitEvent(this, null);
        }

        private void EnableSubjectCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SubjectTextBox.IsEnabled = true;
        }

        private void EnableSubjectCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            SubjectTextBox.IsEnabled = false;
        }

        private void EnableBodyRichTextBoxCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            BodyRichTextBox.IsEnabled = true;
        }

        private void EnableBodyRichTextBoxCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            BodyRichTextBox.IsEnabled = false;
        }

        private void PreviewButton_Click(object sender, RoutedEventArgs e)
        {
            PreviewThrowEvent(this, new SourceTextArgs(SourceTextBox.Text));
            EventsCreatedTextBlock.Text = "";
        }

        private void RevertItem_Click(object sender, RoutedEventArgs e)
        {
            //ToDo: Implement Revertion of connected items: http://stackoverflow.com/questions/16822956/getting-wpf-data-grid-context-menu-click-row
            // http://blog.gisspan.com/2012/11/contextmenu-for-wpf-datagrid-on-row.html

            //Get the clicked MenuItem
            var menuItem = (MenuItem)sender;

            //Get the ContextMenu to which the menuItem belongs
            var contextMenu = (ContextMenu)menuItem.Parent;

            //Find the placementTarget
            var item = (DataGrid)contextMenu.PlacementTarget;

            //Get the underlying item, that you cast to your object that is bound
            //to the DataGrid (and has subject and state as property)
            var toDeleteFromBindedList = (revertableAppointmentList)item.SelectedCells[0].Item;
            foreach (var appointmentItem in toDeleteFromBindedList.AppointmentList)
            {
                try
                {
                    appointmentItem.Delete();
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    Debug.WriteLine(ex.Message);
                }
                
            }
        }
        
    }

    public class SourceTextArgs : EventArgs
    {
        public string SourceText { get; private set; }

        public SourceTextArgs(string sourceText)
        {
            this.SourceText = sourceText;
        }
    }
}
