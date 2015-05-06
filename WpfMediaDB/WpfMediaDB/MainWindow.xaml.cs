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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.OleDb;

namespace WpfMediaDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // As database has extension .accdb
        private const String access7ConnectionString =
            @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\entries.accdb";
        // Data components
        private OleDbConnection myConnection;
        private DataTable myDataTable;
        private OleDbDataAdapter myAdapter;
        private OleDbCommandBuilder myCommandBuilder;

        // Index of the current record
        private int currentRecord = 0;

        private void UpdateDB()
        {
            try
            {
                myConnection.Open();
                myAdapter.Update(myDataTable);
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in methods of updating : \r\n" + ex.Message);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            String command = "SELECT * FROM Music";
            try 
            {
                myConnection = new OleDbConnection(access7ConnectionString);
                myAdapter = new OleDbDataAdapter(access7ConnectionString, myConnection);
                myCommandBuilder = new OleDbCommandBuilder(myAdapter);
                myDataTable = new DataTable();
                FillDataTable(command);

                DisplayRow(currentRecord);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillDataTable(string selectCommand)
        {
            try
            {
                myConnection.Open();
                myAdapter.SelectCommand.CommandText = selectCommand;
                // Get schema for entries table to fully configure datatable
                myAdapter.FillSchema(myDataTable, SchemaType.Source);
                // Fill the datatable with the rows returned by the select command
                myAdapter.Fill(myDataTable);
                myConnection.Close();
            }

            catch(Exception ex)
            {
                MessageBox.Show("Error in FillDataTable: \r\n" + ex.Message);
                // close the myConnection class
                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Close();
                }
            }

        }

        private void DisplayRow(int rowIndex)
        { 
            // Check if given row can be retrieved
            if (myDataTable.Rows.Count == 0)
            return; // nowt to display
            if (rowIndex >= myDataTable.Rows.Count)
                return; // the index is out of range

            try
            {
                DataRow row = myDataTable.Rows[rowIndex];
                trackNumberTextBox.Text = row["TrackNo"].ToString();
                trackNameTextbox.Text = row["TrackName"].ToString();
                artistTextbox.Text = row["Artist"].ToString();
                albumTextbox.Text = row["Album"].ToString();
                genreTextbox.Text = row["Genre"].ToString();
                yearReleasedTextbox.Text = row["YearReleased"].ToString();
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Error in DisplayRow : \r\n" + ex.Message);
            }

            statusLbl.Content = (currentRecord + 1).ToString() + " of " + myDataTable.Rows.Count.ToString();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            // check if we are the at the end of the table before trying to
            // display the next record

            if (currentRecord < myDataTable.Rows.Count - 1)
            {
                currentRecord++;
                DisplayRow(currentRecord);
            }
        }

        private void prevButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentRecord <= myDataTable.Rows.Count)
            {
                currentRecord--;
                DisplayRow(currentRecord);
            }
        }

        private void firstButton_Click(object sender, RoutedEventArgs e)
        {
            currentRecord = 0;
            DisplayRow(currentRecord);
        }

        private void lastButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void modify_Click(object sender, RoutedEventArgs e)
        {
            EditWindow editDialog = new EditWindow(myDataTable.Rows[currentRecord]);
            // edit window as Dialog type prevents users from using main window whilst editing
            if (editDialog.ShowDialog() == true)
            {
                // Display the edited row
                DisplayRow(currentRecord);
                // Commit changes to database
                UpdateDB();
            }
        }

    }
}
