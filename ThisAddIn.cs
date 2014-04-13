using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Xml.Linq;
using CalendarEventFromText.Annotations;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.Globalization;

namespace CalendarEventFromText
{
    public partial class ThisAddIn
    {
        public ObservableCollection<Outlook.AppointmentItem> apointments = new ObservableCollection<Outlook.AppointmentItem>();
        private MainUserControl mainWindow;
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            mainWindow = new MainUserControl {Visibility = Visibility.Visible};
            var host = new Window() {Content = mainWindow};
            host.Show();
            mainWindow.PreviewThrowEvent += AnalyseText;
            mainWindow.CommitEvent += CommitApointments;
            mainWindow.MainDataGrid.DataContext = apointments;
            mainWindow.MainDataGrid.ItemsSource = apointments;
        }

        private void AnalyseText(object sender, EventArgs e)
        {
            apointments.Clear();
            SourceTextArgs text = (SourceTextArgs)e;
            LinkedList<LinkedList<string>> lines = new LinkedList<LinkedList<string>>();

            // Tokenize
            using (StringReader reader = new StringReader(text.SourceText))
            {
                IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);

                string line;
                // Get new line each loop
                while ((line = reader.ReadLine()) != null)
                {
                    if (!line.Contains("*"))
                    {
                        LinkedList<string> lineTokens = new LinkedList<string>(line.Split('\t'));
                        lines.AddLast(lineTokens);
                    }
                }
            }
            // Interpret Token
            int number = 0;
            foreach (var line in lines)
            {
                number++;
                var apointment = (Outlook.AppointmentItem)this.Application.CreateItem(Outlook.OlItemType.olAppointmentItem);
                string combinedDateStart = (line.ElementAt(1) + " " + line.ElementAt(2)).Remove(0,4).Replace(".", "");
                string combinedDateEnd = (line.ElementAt(1) + " " + line.ElementAt(3)).Remove(0, 4).Replace(".", "");

                apointment.Start = DateTime.ParseExact(combinedDateStart, "d MMM yyyy HH:mm", new CultureInfo("de-DE"));
                apointment.End = DateTime.ParseExact(combinedDateEnd, "d MMM yyyy HH:mm", new CultureInfo("de-DE"));
                apointment.Location = line.ElementAt(4);
                if (mainWindow.SubjectTextBox.IsEnabled)
                    apointment.Subject = mainWindow.SubjectTextBox.Text;
                if (mainWindow.GruppeTextBox.IsEnabled) 
                    apointment.Categories = mainWindow.GruppeTextBox.Text;
                if (mainWindow.BodyRichTextBox.IsEnabled)
                    apointment.Body = new TextRange(mainWindow.BodyRichTextBox.Document.ContentStart, mainWindow.BodyRichTextBox.Document.ContentEnd).Text.Replace(Environment.NewLine, "  ");
                apointments.Add(apointment);
            }
            mainWindow.PreviewsCreatedTextBlock.Text = number + " event(s).";
            // var apointment = (Outlook.AppointmentItem) this.Application.CreateItem(Outlook.OlItemType.olAppointmentItem);
            // mainWindow.PreviewTextBlock.Text = text.SourceText;
        }

        private void CommitApointments(object sender, EventArgs e)
        {
            int number = 0;
            foreach (var appointmentItem in apointments)
            {
                appointmentItem.Save();
                number++;
            }
            mainWindow.EventsCreatedTextBlock.Text = number + " event(s) created.";
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }

    public class ApointmentRep : INotifyPropertyChanged
    {
        private string _subject;
        private string _body;
        private string _location;
        private string _categories;
        private DateTime _start;
        private DateTime _end;

        public string Subject
        {
            get { return _subject; }
            set { _subject = value;
                OnPropertyChanged();
            }
        }
        public string Body
        {
            get { return _body; }
            set { _body = value;
                OnPropertyChanged();
            }
        }
        public string Location
        {
            get { return _location; }
            set { _location = value;
                OnPropertyChanged();
            }
        }
        public DateTime Start
        {
            get { return _start; }
            set { _start = value;
                OnPropertyChanged();
            }
        }
        public DateTime End
        {
            get { return _end; }
            set { _end = value;
                OnPropertyChanged();
            }
        }
        public string Categories
        {
            get { return _categories; }
            set { _categories = value;
                OnPropertyChanged();
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
