﻿using System;
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
using System.Windows.Threading;
using GuiChatRoom;

namespace GuiChatRoom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //  private static Random random = new Random();
        //DispatcherTimer dispatcherTimer = new DispatcherTimer();
        ObservableObject1 main1 = new ObservableObject1();
        public MainWindow()
        {
            InitializeComponent();            
            this.DataContext = main1;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (!main1.Login(username.Text, groupID.Text))
                MessageBox.Show(this, "wrong nickname or group  ID, try again");
            else
            {
                MessageBox.Show(this, "Logging in! you will be moved to chatroon window now");
                Chat w = new Chat(this.main1,this);
                w.Show();
                this.Hide();
            }

            }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
                }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (!main1.Register(username.Text, groupID.Text))
                MessageBox.Show(this, "registaration failed, change your nick, its already used");
            else
            {
                MessageBox.Show(this, "registaration success, " + username.Text + " will logg in");
                Chat w = new Chat(this.main1, this);
                w.Show();
                this.Hide();
            }

        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }
    }
}