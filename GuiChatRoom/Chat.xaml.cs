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
        public List <Message> msgList;
     private   User loogedIn;
        private string sort = null;
        private string filter = null;
        private GroupComparator groupCompare = new GroupComparator();
        private NicknameComparator nickCompare = new NicknameComparator();
        private TimestampComparator timeCompare = new TimestampComparator();




        public Chat(ObservableObject1 _main, MainWindow mainWin)
        {
          //  this.loogedIn = _main.GetUser();
            this.mainWin = mainWin;
            this._main = _main;
            InitializeComponent();
           this.DataContext = _main;
            _main.retrieve10Messages();
            this.msgList = new List<Message>();
            Refresh();
           ListToListbox();
           // chatBox.ItemsSource = msgList;
            aTimer = new Timer();
            aTimer.Interval=2000;
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Start();
           // aTimer.AutoReset = true;
            //aTimer.Enabled = true;
            filterBox.Items.Add("none");
            filterBox.Items.Add("group");
            filterBox.Items.Add("user");
            sortBox.Items.Add("none");
            sortBox.Items.Add("nickname");
            sortBox.Items.Add("Message timestamp");
            sortBox.Items.Add("gID,nickname,timestamp");
            
        }
        private  void OnTimedEvent(Object source,ElapsedEventArgs e)
        {
            _main.retrieve10Messages();
            Refresh();
            //ListToListbox();
        }

        private void logOut_Click(object sender, RoutedEventArgs e)
        {
            this._main.logOut();
            aTimer.Stop();
            aTimer.Dispose();
            mainWin.Show();
            this.Close();
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
              if( !_main.sendMessage(msgText.Text))
                  MessageBox.Show(this, "wrong message (over 150 chars) ,try again");
             msgText.Text = "";
           this.Refresh();

        }

         public void ListToListbox()
         {
             foreach (Message m in msgList)
                if (!chatBox.Items.Contains(m))
                    chatBox.Items.Add(m);
        }
        private void Refresh()
        {
            List<Message> TempMsgList = _main.GetAllMessages();
            
            foreach (Message m in TempMsgList)
              if (m != null && !msgList.Contains(m))
              msgList.Add(m);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.filter=filterBox.Text;
            this.sort = sortBox.Text;
            this.filterAndSort();
        }
        private void SortByNickname(){this.msgList.Sort(this.nickCompare); }
        private void SortByMessageTimestamp() { this.msgList.Sort(this.timeCompare); }
        private void SortByCombo() {
            this.msgList.Sort(this.groupCompare);
            SortByNickname();
            SortByMessageTimestamp();
        }
        private void FilterByGroup() {
            foreach (Message msg in msgList)
                          if (!msg.GetUser().GetGroupID().Equals( loogedIn.GetGroupID()))
                                 msgList.Remove(msg);
        }
        private void FilterByUser() {
            this.FilterByGroup();
            foreach (Message msg in msgList)
                    msgList.Remove(msg);
        }
        public void filterAndSort()
        {
            this.msgList = _main.GetAllMessages();
            if (filter == "group")
                this.FilterByGroup();
            if (filter == "user")
                this.FilterByUser();
            if (sort == "nickname")
                this.SortByNickname();
            if (sort == "Message timestamp")
                this.SortByMessageTimestamp();
            if (sort == "gID,nickname,timestamp")
                this.SortByCombo();
            this.ListToListbox();
        }
    }
}
