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
using GuiChatRoom.BussinessLayer;
using System.ComponentModel;
using System.IO;

namespace GuiChatRoom
{
    /// <summary>
    /// Interaction logic for Chat.xaml
    /// </summary>
    public partial class Chat : Window
    {
        private static System.Timers.Timer aTimer;
       public  ObservableObject1 _main;
        MainWindow mainWin;
        private string sort = null;
        private string filter = null;
        ChatRoom c1;
        private GroupComparator groupCompare = new GroupComparator();
        private NicknameComparator nickCompare = new NicknameComparator();
        private TimestampComparator timeCompare = new TimestampComparator();
        List<Message> msgList;

        public Chat(ObservableObject1 _main, MainWindow mainWin, ChatRoom c1)
        {
            this.c1 = c1;
            this.mainWin = mainWin;
            this._main = _main;
            InitializeComponent();
            this.DataContext = _main;
            retrieve10Messages();
            aTimer = new Timer();
            aTimer.Interval=2000;
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Start();                 
        }
        private  void OnTimedEvent(Object source,ElapsedEventArgs e)
        {
            retrieve10Messages();
        }

        private void logOut_Click(object sender, RoutedEventArgs e)
        {
            c1.LogOut();
            aTimer.Stop();
            aTimer.Dispose();
            mainWin.Show();
            this.Close();
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            if (!c1.SendMessage(_main.Text))
                MessageBox.Show(this, "wrong message (over 150 chars) ,try again");
            else
            {
                msgText.Text = "";
                retrieve10Messages();
            }
        }

               public void retrieve10Messages()
        {
            msgList = c1.Retrive10Messages();
            LinkedList<String> s = new LinkedList<String>();
            foreach (Message m in msgList)
                s.AddLast(m.ToString());
            _main.Messages = s;
        }

        private void msgText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }            
}
