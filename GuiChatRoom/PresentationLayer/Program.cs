using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiChatRoom.BussinessLayer;

namespace GuiChatRoom
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("enter url");
			string url = Console.ReadLine();
			ChatRoom c1 = new ChatRoom(url);
			while (Program.Guid(c1))
				Console.WriteLine("hello");
		}

		public static Boolean Guid(ChatRoom c1)
		{
			Console.WriteLine("for logIn click 1");
			Console.WriteLine("for logOut click 2");
			Console.WriteLine("for registeration click 3");
			Console.WriteLine("to Retrieve last 10 messages from server click 4");
			Console.WriteLine("to  Display last 20 retrieved messages  sorted by the message timestamp click 5");
			Console.WriteLine("to  Display all retrieved messages identified by a username and a group id), sorted by the message timestamp click 6");
			Console.WriteLine("to write (and send) a new message click 7");
			Console.WriteLine("to exit click 8");

			string input = Console.ReadLine();
			if (input == "1")
			{
				Console.WriteLine("enter user nickname");
				string nick = Console.ReadLine();
				Console.WriteLine("enter group ID");
				string groupID = Console.ReadLine();
				Boolean log = c1.LogIn(nick, groupID);
				if (log)
					Console.WriteLine(nick + " is now logged in");
				else
					Console.WriteLine("login failed, check your nickname and ID");
				return true;
			}
			if (input == "2")
			{
				c1.LogOut();
				return true;
			}
			if (input == "3")
			{
				Console.WriteLine("enter user nickname");
				string nick = Console.ReadLine();
				Console.WriteLine("enter group ID");
				string groupID = Console.ReadLine();
				Boolean reg = c1.Registeration(nick, groupID);
				if (reg)
					Console.WriteLine("registaration success, " + nick + " is now logged in");
				else
					Console.WriteLine("registaration failed, change your nick, its already used");
				return true;
			}
			if (input == "4")
			{
				c1.Retrive10Messages();
				return true;
			}
			if (input == "5")
			{
				List<BussinessLayer.Message> messages = c1.Getmsg(10);
				if (messages == null)
					Console.WriteLine("there is no 10 messages");
				else
					Console.WriteLine(messages.ToString());
				return true;
			}
			if (input == "6")
			{
				Console.WriteLine("enter user nickname");
				string nick = Console.ReadLine();
				Console.WriteLine("enter group ID");
				string groupID = Console.ReadLine();
				List<BussinessLayer.Message> messages = c1.GetUserMsg(nick, groupID);
				Console.WriteLine(messages.ToString());
				return true;
			}
			if (input == "7")
			{
				Console.WriteLine("enter your message");
				string msg = Console.ReadLine();
				Boolean send = c1.SendMessage(msg);
				if (send)
					Console.WriteLine("your message has been sent");
				else
					Console.WriteLine("wrong message/user is not logged in, try again");
				return true;
			}
			if (input == "8")
			{
				c1.LogOut();
				return false;
			}
			Console.WriteLine("wrong number,try again");
			return true;
		}


	}
}
