﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispatcherAndBinding
{
    public class Paths
    {


        static string Path = @"C:/Users/mohamad/Desktop/chatroom/MilestoneClient1/BussinessLayer/DataBase";

        public static string UsersDBPath()
        {
            return Path + @"/Registration.txt";
        }
        public static string msgDBPath()
        {
            return Path + @"/messages.txt";
        }
        public static string lastmsgDBPath()
        {
            return Path + @"/last20msg.txt";
        }
        public static string logDBPath()
        {
            return Path + @"/log_file.txt";
        }
    }
}