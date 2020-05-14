using isad157_project.utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace isad157_project.entities
{
    class Conversations
    {
        /* 
            ATTRIBUTE(s)
        */
        private int senderID;
        private int receiverID;
        private List<Messages> conversationMessages = new List<Messages>();

        /* 
            CONSTRUCTOR(s)
        */

        public Conversations() { }
        public Conversations(int _senderID, int _receiverID)
        {
            senderID = _senderID;
            receiverID = _receiverID;
        }

        /* 
            METHOD(s)
        */

        /* 
         *   @name - getConversationReceivers()
         *   @params - usersID: Int
         *   @return - DataTable of user rows
         *   @description: - attempts to select all records from the receiver table, where the same message ID exists inside the
         *   senders table.
         */
        public static DataTable getConversationReceivers(int usersID)
        {
            // Query: Select all conversations senders.
            string receiversQuery = "SELECT sender_id_fk, receiver_id_fk FROM isad157_tadams.message_senders, isad157_tadams.message_receivers WHERE (receiver_id_fk = " + usersID + " AND message_senders.message_id_fk=message_receivers.message_id_fk)";

            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionString))
            {
                // Open database connection
                connection.Open();

                // Create a new query command against the connection
                MySqlCommand cmd = new MySqlCommand(receiversQuery, connection);

                // Fill datatable based on returned data
                MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                DataTable receiverTable = new DataTable();
                sqlDA.Fill(receiverTable);

                return receiverTable;
            }
        }

        /* 
         *   @name - getConversationSenders()
         *   @params - usersID: Int
         *   @return - DataTable of user rows
         *   @description: - attempts to select all records from the senders table, where the same message ID exists inside the
         *   receivers table.
         */
        public static DataTable getConversationSenders(int usersID)
        {
            // Query: Select all conversations senders.
            string receiversQuery = "SELECT sender_id_fk, receiver_id_fk FROM isad157_tadams.message_senders, isad157_tadams.message_receivers WHERE (sender_id_fk = " + usersID + " AND message_receivers.message_id_fk=message_senders.message_id_fk)";

            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionString))
            {
                // Open database connection
                connection.Open();

                // Create a new query command against the connection
                MySqlCommand cmd = new MySqlCommand(receiversQuery, connection);

                // Fill datatable based on returned data
                MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                DataTable senderTable = new DataTable();
                sqlDA.Fill(senderTable);

                return senderTable;
            }
        }

        /* 
        *   @name - getConversationMessages()
        *   @params - selectedConversation: Conversations
        *   @return - void
        *   @description: - attempts to collect all receiver and sender messages for the given conversation and
        *   stores messages per instance, to keep a unique storage per object.
        */
        public void getConversationMessages(Conversations selectedConversation)
        {
            List<int> listOfMessageIDs = new List<int>();

            // Used to get the senders messages
            string getSendersMessageIDs = "SELECT message_senders.message_id_fk FROM isad157_tadams.message_senders, isad157_tadams.message_receivers WHERE(sender_id_fk = " + selectedConversation.getSenderID() + " AND message_receivers.message_id_fk= message_senders.message_id_fk)";
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionString))
            {
                // Open database connection
                connection.Open();

                // Create a new query command against the connection
                MySqlCommand cmd = new MySqlCommand(getSendersMessageIDs, connection);

                // Fill datatable based on returned data
                MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                DataTable senderTable = new DataTable();
                sqlDA.Fill(senderTable);

                // Check to see if sender has any messages in the current conversation
                if (senderTable.Rows.Count == 0) return;
                else
                {
                    // Loop across all sender message IDs and store.
                    for (var s = 0; s < senderTable.Rows.Count; s++)
                    {
                        listOfMessageIDs.Add(Convert.ToInt32(senderTable.Rows[s][0]));
                    }
                }
            }

            // Used to get the receivers messages
            string getReceiversMessageIDs = "SELECT message_receivers.message_id_fk FROM isad157_tadams.message_senders, isad157_tadams.message_receivers WHERE(receiver_id_fk = " + selectedConversation.getReceiverID() + " AND message_senders.message_id_fk= message_receivers.message_id_fk)";
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionString))
            {
                // Open database connection
                connection.Open();

                // Create a new query command against the connection
                MySqlCommand cmd = new MySqlCommand(getReceiversMessageIDs, connection);

                // Fill datatable based on returned data
                MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                DataTable receiverTable = new DataTable();
                sqlDA.Fill(receiverTable);

                // Check to see if receiver has any messages in the current conversation
                if (receiverTable.Rows.Count == 0) return;
                else
                {
                    // Loop across all received message IDs and store.
                    for (var s = 0; s < receiverTable.Rows.Count; s++)
                    {
                        listOfMessageIDs.Add(Convert.ToInt32(receiverTable.Rows[s][0]));
                    }
                }
            }

            for(var q = 0; q < listOfMessageIDs.Count; q++)
            {
                // Used to get the receivers messages
                string getAllConversationMessages = "SELECT * FROM isad157_tadams.messages WHERE message_id = " + listOfMessageIDs[q];
                using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionString))
                {
                    // Open database connection
                    connection.Open();

                    // Create a new query command against the connection
                    MySqlCommand cmd = new MySqlCommand(getAllConversationMessages, connection);

                    // Fill datatable based on returned data
                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable messagesTable = new DataTable();
                    sqlDA.Fill(messagesTable);

                    // Check to see if receiver has any messages in the current conversation
                    if (messagesTable.Rows.Count == 0) return;
                    else
                    {
                        // Loop across all messages and add to global List of messages for this conversation
                        for (var s = 0; s < messagesTable.Rows.Count; s++)
                        {
                            Messages currentMessage = new Messages(Convert.ToInt32(messagesTable.Rows[s][0]), Convert.ToString(messagesTable.Rows[s][1]), Convert.ToDateTime(messagesTable.Rows[s][2]));
                            conversationMessages.Add(currentMessage);
                        }
                    }
                }
            }
        }

        /* 
        *   @name - addMessage()
        *   @params - newMessage: Messages, currentConversation: Conversations
        *   @return - void
        *   @description: - used to open up a basic insert query into the messages tabling consiting of
        *   the users input message of a given conversation.
        */
        public static void addMessage(Messages newMessage, Conversations currentConversation)
        {
            // QUERY: Used to insert a new message into the Messages table
            string insertMessageQuery = "INSERT INTO isad157_tadams.messages (message_text, message_date_time) VALUES ('" + newMessage.getMessageText() + "', '" + newMessage.getMessageDateTime() + "')";
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionString))
            {
                // Open database connection
                connection.Open();

                // Create a new query command against the connection
                MySqlCommand cmd = new MySqlCommand(insertMessageQuery, connection);

                // Fill datatable based on returned data
                MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                DataTable messagesTable = new DataTable();
                sqlDA.Fill(messagesTable);
            }

            // Assumption: Insertion into the join tables here also...
        }

        //
        //  GETTER(S)
        //

        public int getSenderID()
        {
            return this.senderID;
        }
        public int getReceiverID()
        {
            return this.receiverID;
        }
        public List<Messages> getMessages()
        {
            return this.conversationMessages;
        }
    }
}
