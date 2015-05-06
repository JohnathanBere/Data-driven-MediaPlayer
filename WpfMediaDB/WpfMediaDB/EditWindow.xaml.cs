using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using Microsoft.Win32;

namespace WpfMediaDB
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private DataRow editRow; // reference to the row to edit
        public EditWindow(DataRow row)
        {
            InitializeComponent();
            editRow = row; // references the row that's been passed to a local object
            PopulateForm();
        }

        private void PopulateForm()
        {
            // these lines extract each field from the DataRow and places
            // them in the corresponding Textboxes on the UI
            this.trackNumberTextBox.Text = editRow["TrackNo"].ToString();
            this.trackNameTextbox.Text = editRow["TrackName"].ToString();
            this.artistTextbox.Text = editRow["Artist"].ToString();
            this.albumTextbox.Text = editRow["Album"].ToString();
            this.genreTextbox.Text = editRow["Genre"].ToString();
            this.yearReleasedTextbox.Text = editRow["YearReleased"].ToString();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            // user cancels edit
            this.DialogResult = false;
            this.Close();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            // user pressed ok to confirm the edits
            // copy edited text here and append to data row object
            editRow["TrackNo"] = trackNumberTextBox.Text; 
            editRow["TrackName"] = trackNameTextbox.Text;
            editRow["Artist"] = artistTextbox.Text;
            editRow["Album"] = albumTextbox.Text;
            editRow["Genre"] = genreTextbox.Text;
            editRow["YearReleased"] = yearReleasedTextbox.Text;

            // let calling window know OK was pressed
            this.DialogResult = true;
            this.Close();
        }
    }
}
