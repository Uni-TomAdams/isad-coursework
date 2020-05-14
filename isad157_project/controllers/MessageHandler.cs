using isad157_project.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isad157_project.controllers
{
    class MessageHandler
    {
        /* 
            METHOD(s)
        */

        public static void getSelectedConversationMessages(Conversations selectedConversation)
        {
            selectedConversation.getConversationMessages(selectedConversation);  
        }

        public static void addMessageToConversation(Messages newMessage, Conversations currentConversation)
        {
            Conversations.addMessage(newMessage, currentConversation);
        }
    }
}
