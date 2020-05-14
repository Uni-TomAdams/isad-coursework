using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isad157_project.entities
{
    class Messages
    {
        /* 
            ATTRIBUTE(s)
        */

        private int messageID;
        private string messageText;
        private DateTime messageDateTime;

        /* 
            CONSTRUCTOR(s)
        */

        public Messages() { }

        public Messages(string _messageText, DateTime _messageDateTime) 
        {
            messageText = _messageText;
            messageDateTime = _messageDateTime;
        }
        public Messages(int _messageID, string _messageText, DateTime _messageDateTime)
        {
            messageID = _messageID;
            messageText = _messageText;
            messageDateTime = _messageDateTime;
        }

        /* 
            GETTER(s)
        */

        public int getMessageID()
        {
            return this.messageID;
        }
        public string getMessageText()
        {
            return this.messageText;
        }
        public DateTime getMessageDateTime()
        {
            return this.messageDateTime;
        }
    }
}
