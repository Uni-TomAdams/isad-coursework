using isad157_project.controllers;
using isad157_project.entities;
using isad157_project.utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace isad157_project
{
    public partial class facebookFrm : Form
    {
        /* 
            ATTRIBUTE(s)
        */
        private static Users currentLoggedInUser;
        private List<Users> possibleFriendsToAdd = new List<Users>();


        /* 
            CONSTRUCTOR(s)
        */
        public facebookFrm()
        {
            InitializeComponent();
            // WARNING: This is a temp instance of Users, in order to show the applications functionality as there is no login system. Change int for differnt user between 1-5000.
            currentLoggedInUser = new Users().getUsersDetails(1);
            loggedInAsUsrNameLbl.Text = (currentLoggedInUser.getUserForename() + " " + currentLoggedInUser.getUserSurname());

            // Get all users conversations
            currentLoggedInUser.getAllConversations(currentLoggedInUser.getUserID());

            // Put conversations into the conversationsUI
            foreach (Conversations convo in currentLoggedInUser.getUserConversationsList())
            {
                Users getCurrentConvosDetails = new Users().getUsersDetails(convo.getReceiverID());
                conversationsLSB.Items.Add(getCurrentConvosDetails.getUserForename() + " " + getCurrentConvosDetails.getUserSurname());
            }
        }

        /* 
         METHOD(s)
        */

        private void searchUserBtn_Click(object sender, EventArgs e)
        {
            // Pass users forename and surname into the search query method
            List<Users> searchedUsers = currentLoggedInUser.getSearchQueryUsers(searchForenameTbx.Text, searchSurnameTbx.Text);
            possibleFriendsToAdd = searchedUsers;

            // Add items to the search listbox
            for(var i = 0; i < searchedUsers.Count; i++)
            {
                searchUserLsb.Items.Add("ID: " + searchedUsers[i].getUserID() + " Forename: " + searchedUsers[i].getUserForename() + " Surname: " + searchedUsers[i].getUserSurname() +  " Created at: " + searchedUsers[i].getUserCreatedAtDateAndTime());
            }
        }

        private void conversationsLSB_SelectedIndexChanged(object sender, EventArgs e)
        {
            int getSelectedConversation = conversationsLSB.SelectedIndex;

            // Present the conversations messages when listbox item clicked
            // TODO: Needs better implementation to prevent duplication on the list...
            MessageHandler.getSelectedConversationMessages(currentLoggedInUser.getUserConversationsList()[getSelectedConversation]);

            // Loop through the selected conversations messages and display in listbox
            messagesUI.Items.Clear();
            List<Messages> conversationMessageList = currentLoggedInUser.getUserConversationsList()[getSelectedConversation].getMessages();
            for (var i = 0; i < conversationMessageList.Count(); i++)
            {
                messagesUI.Items.Add(conversationMessageList[i].getMessageID() + "         " + conversationMessageList[i].getMessageText() + "             " + conversationMessageList[i].getMessageDateTime());
            }
        }

        private void addMessageBtn_Click(object sender, EventArgs e)
        {
            // Ensure user has selected a conversation to write into.
            if (conversationsLSB.SelectedIndex != -1)
            {
                // Check to make sure the user has entered an actual message.
                if (messageTbx.TextLength != 0)
                {
                    // Pass new message along to control
                    Messages newMessage = new Messages(messageTbx.Text, new DateTime());
                    MessageHandler.addMessageToConversation(newMessage, currentLoggedInUser.getUserConversationsList()[conversationsLSB.SelectedIndex]);
                    messageTbx.Clear();
                }
            }
        }

        private void addFriendBtn_Click(object sender, EventArgs e)
        {
            // Check to see if a user is selected.
            if (searchUserLsb.SelectedIndex != -1)
            {
                int currentlySelectedItem = searchUserLsb.SelectedIndex;

                // Check to see if the user already has said user as a friend
                string checkForFriendQuery = "SELECT * FROM isad157_tadams.friends WHERE (requestor_id_fk=" + "'" + currentLoggedInUser.getUserID() + "')";
                using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionString))
                {
                    // Open database connection
                    connection.Open();

                    // Create a new query command against the connection
                    MySqlCommand cmd = new MySqlCommand(checkForFriendQuery, connection);

                    // Fill datatable based on returned data
                    MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                    DataTable friendsTable = new DataTable();
                    sqlDA.Fill(friendsTable);

                    // Check to see if any data was returned
                    if (friendsTable.Rows.Count == 0)
                    {
                        MessageBox.Show("Oops. You're already friends with this user!");
                    }
                    else
                    {
                        int requestorID = currentLoggedInUser.getUserID();
                        int requestedID = possibleFriendsToAdd[searchUserLsb.SelectedIndex].getUserID();

                        string addFriendQuery = "INSERT INTO isad157_tadams.friends (requestor_id_fk, requested_id_fk) VALUES ('" + requestorID + "'" + ", '" + requestedID + "')";
                        using (MySqlConnection connections = new MySqlConnection(DBConnection.connectionString))
                        {
                            // Open database connection
                            connections.Open();

                            // Create a new query command against the connection
                            MySqlCommand cmmd = new MySqlCommand(addFriendQuery, connections);

                            // Fill datatable based on returned data
                            MySqlDataAdapter sqlDAa = new MySqlDataAdapter(cmd);
                            DataTable friendTable = new DataTable();
                            sqlDA.Fill(friendTable);

                            MessageBox.Show("Friend added!");
                        }
                    }
                }
            }
        }

        private void removeFriendBtn_Click(object sender, EventArgs e)
        {
            // ASSUMPTION: Here would be the code for removing a friend. Basically the same kind of code used for adding a friend...
        }
    }
}
