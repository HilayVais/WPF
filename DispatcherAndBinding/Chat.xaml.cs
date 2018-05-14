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
using System.Windows.Shapes;
using System.Timers;

namespace DispatcherAndBinding
{
    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        private static System.Timers.Timer aTimer;
        ObservableObject _main;

        public Chat(ObservableObject _main)
        {
            this._main = _main;
            InitializeComponent();
            aTimer = new Timer(2000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private static void OnTimedEvent(Object source,ElapsedEventArgs e)
        {
         //receive a list from bussiness layer and use listToListbox function 
        }

        private void logOut_Click(object sender, RoutedEventArgs e)
        {
            //log out
            aTimer.Stop();
            aTimer.Dispose();
            this.Close();
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Add(msgText.Text);
            _main.sendMessage(msgText.Text);
            msgText.Text = "";
        }
        public void ListToListbox(List<string> l)
        {
            foreach (string s in l)
                listBox.Items.Add(msgText.Text);
         }
    }
}
