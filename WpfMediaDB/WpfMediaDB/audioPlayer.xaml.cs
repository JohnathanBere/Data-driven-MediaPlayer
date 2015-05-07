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

namespace WpfMediaDB
{
    /// <summary>
    /// Interaction logic for audioPlayer.xaml
    /// </summary>
    public partial class audioPlayer : Window
    {
        string audioFile;
        public audioPlayer(string audioFilename)
        {
            audioFile = audioFilename;
            InitializeComponent();
        }

    }
}
