using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuiChatRoom.BussinessLayer;
using GuiChatRoom.BussinessLayer;
using GuiChatRoom.CommunicationLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace GuiChatRoom
{
    public class ObservableObject1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private LinkedList<String> messages;
        public LinkedList<String> Messages
        {
            get { return messages; }
            set {
                messages = value;
                OnPropertyChanged("Messages");
            }
        }

        private string text = "";
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        public ObservableObject1()
        {

        }        
            }
        }
    
