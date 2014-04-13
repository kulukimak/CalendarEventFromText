using System;
using System.Collections.Generic;
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
