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
    class Users
    {
        /* 
            ATTRIBUTE(s)
        */
        private int userID;
        private string userEmail;
        private string userPassword;
        private string userForename;
        private string userSurname;
        private string userHomeTown;
        private string userGender;
        private string userRelationshipStatus;
        private string userCurrentTownOrCity;
        private DateTime userCreatedAtDateAndTime;
        //private List<Friends> userFriendsList;
        private List<Conversations> userConversationsList = new List<Conversations>();
        //private List<BlockedUsers> userBlockedList;

        /* 
            CONSTRUCTOR(s)
        */
        public Users() { }
        public Users(int _userID, string _userEmail, string _userPassword, string _userForename, string _userSurnme, string _userHomeTown,  string _userGender, string _userRelationshipStatus, string _userCurrentTownOrCity, DateTime _userCreatedAtDateAndTime)
        {
            userID = _userID;
            userEmail = _userEmail;
            userPassword = _userPassword;
            userForename = _userForename;
            userSurname = _userSurnme;
            userHomeTown = _userHomeTown;
            userGender = _userGender;
            userRelationshipStatus = _userRelationshipStatus;
            userCurrentTownOrCity = _userCurrentTownOrCity;
            userCreatedAtDateAndTime = _userCreatedAtDateAndTime;
        }

        /* 
         *   @name - getUsersDetails()
         *   @params - selectedUserID: Int
         *   @return - Users object
         *   @description: - takes the input ID for a user and tries to find that specific user in
         *   the users table. If found, it will return a new Users object with all users details.
         */
        public Users getUsersDetails(int selectedUserID)
        {
            // Create a MySQLConnectionObject
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionString))
            {
                // Query: Select the passed in user from the users table
                string getUsersDetailsQuery = "SELECT * FROM isad157_tadams.users WHERE(user_id=" + selectedUserID + ")";

                // Open database connection
                connection.Open();

                // Create a new query command against the connection
                MySqlCommand cmd = new MySqlCommand(getUsersDetailsQuery, connection);

                // Fill datatable based on returned data
                MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                DataTable userTable = new DataTable();
                sqlDA.Fill(userTable);

                // Check to see if any data was returned
                if (userTable.Rows.Count == 0)
                {
                    MessageBox.Show("No user found. Please try again.");
                }
                else
                {
                    // Assign user to users attributes
                    userID = Convert.ToInt32(userTable.Rows[0][0]);
                    userEmail = Convert.ToString(userTable.Rows[0][1]);
                    userPassword = Convert.ToString(userTable.Rows[0][2]);
                    userForename = Convert.ToString(userTable.Rows[0][3]);
                    userSurname = Convert.ToString(userTable.Rows[0][4]);
                    userHomeTown = Convert.ToString(userTable.Rows[0][5]);
                    userGender = Convert.ToString(userTable.Rows[0][6]);
                    userRelationshipStatus = Convert.ToString(userTable.Rows[0][7]);
                    userCurrentTownOrCity = Convert.ToString(userTable.Rows[0][8]);
                    userCreatedAtDateAndTime = Convert.ToDateTime(userTable.Rows[0][9]);

                    // Create and return user object
                    Users userDetails = new Users(userID, userEmail, userPassword, userForename, userSurname, userHomeTown, userGender, userRelationshipStatus, userCurrentTownOrCity, userCreatedAtDateAndTime); ;
                    return userDetails;
                }
            }

            return new Users();
        }

        /* 
        *   @name - getSearchQueryUsers()
        *   @params - forename: string, surname: string
        *   @return - List<Users>
        *   @description: - takes two inputs from the user to create a search query. It will check for any
        *   matches and return them to the respective callers.
        */
        public List<Users> getSearchQueryUsers(string forename, string surname)
        {
            List<Users> currentSearchQueryUsers = new List<Users>();

            // Ensure that the user has input both forename and surname to search with.
            if (forename.Length == 0 || surname.Length == 0)
            {
                MessageBox.Show("Please ensure forename and surname are both filled out!");
            }

            // Search for users connected to search query input
            string searchQuery = "SELECT * FROM isad157_tadams.users WHERE (user_forename=" + "'" + forename + "'" + " AND user_surname=" + "'" + surname + "')";
            using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionString))
            {
                // Open database connection
                connection.Open();

                // Create a new query command against the connection
                MySqlCommand cmd = new MySqlCommand(searchQuery, connection);

                // Fill datatable based on returned data
                MySqlDataAdapter sqlDA = new MySqlDataAdapter(cmd);
                DataTable userTable = new DataTable();
                sqlDA.Fill(userTable);

                // Check to see if any users were returned by the query
                if (userTable.Rows.Count == 0)
                {
                    MessageBox.Show("No users found! Please try again.");
                }
                else
                {
                    // Loops through users and create user objects for each user found
                    for (var u = 0; u < userTable.Rows.Count; u++)
                    {
                        // Assign user to users attributes
                        userID = Convert.ToInt32(userTable.Rows[0][0]);
                        userEmail = Convert.ToString(userTable.Rows[0][1]);
                        userPassword = Convert.ToString(userTable.Rows[0][2]);
                        userForename = Convert.ToString(userTable.Rows[0][3]);
                        userSurname = Convert.ToString(userTable.Rows[0][4]);
                        userHomeTown = Convert.ToString(userTable.Rows[0][5]);
                        userGender = Convert.ToString(userTable.Rows[0][6]);
                        userRelationshipStatus = Convert.ToString(userTable.Rows[0][7]);
                        userCurrentTownOrCity = Convert.ToString(userTable.Rows[0][8]);
                        userCreatedAtDateAndTime = Convert.ToDateTime(userTable.Rows[0][9]);

                        // Create and return user object
                        Users createTempUser = new Users(userID, userEmail, userPassword, userForename, userSurname, userHomeTown, userGender, userRelationshipStatus, userCurrentTownOrCity, userCreatedAtDateAndTime); ;
                        currentSearchQueryUsers.Add(createTempUser);
                    }
                }
            }

            return currentSearchQueryUsers;
        }

        /* 
        *   @name - getAllConversations()
        *   @params - selectedUserID: Int
        *   @return - void
        *   @description: - gets all users conversations in sender and receiver tables,
        *   but does not return any message belowing to those tables. Only the IDs of the users.
        */
        public void getAllConversations(int usersID)
        {
            DataTable senders = Conversations.getConversationSenders(usersID);
            DataTable receivers = Conversations.getConversationReceivers(usersID);

            // Ensure that both or one at least contains some rows
            if (senders.Rows.Count == 0 && receivers.Rows.Count == 0)
            {
                MessageBox.Show("No conversations found.");
            }
            else
            {
                if (senders.Rows.Count != 0) 
                {
                    // Add senders to users conversations list
                    for (var s = 0; s < senders.Rows.Count; s++)
                    {
                        Conversations newConvo = new Conversations(Convert.ToInt32(senders.Rows[s][0]), Convert.ToInt32(senders.Rows[s][1]));
                        userConversationsList.Add(newConvo);
                    }
                }

                if (receivers.Rows.Count != 0) 
                {
                    // Add receivers to users conversations list
                    for (var r = 0; r < receivers.Rows.Count; r++)
                    {
                        Conversations newConvo = new Conversations(Convert.ToInt32(receivers.Rows[r][0]), Convert.ToInt32(receivers.Rows[r][1]));
                        userConversationsList.Add(newConvo);
                    }
                }
            }
        }

        //
        //  GETTER(S)
        //

        public int getUserID()
        {
            return this.userID;
        }
        public string getUserEmail()
        {
            return this.userEmail;
        }
        public string getUserPassword()
        {
            return this.userPassword;
        }
        public string getUserForename()
        {
            return this.userForename;
        }
        public string getUserSurname()
        {
            return this.userSurname;
        }
        public string getUserHomeTown()
        {
            return this.userHomeTown;
        }
        public string getUserGender()
        {
            return this.userGender;
        }
        public string getUserRelationshipStatus()
        {
            return this.userRelationshipStatus;
        }
        public string getUserCurrentTownOrCity()
        {
            return this.userCurrentTownOrCity;
        }
        public DateTime getUserCreatedAtDateAndTime()
        {
            return this.userCreatedAtDateAndTime;
        }
        public List<Conversations> getUserConversationsList()
        {
            return this.userConversationsList;
        }

        // ASSUMPTION: Note there would be SETTERS for all attributes here normally.
    }
}
