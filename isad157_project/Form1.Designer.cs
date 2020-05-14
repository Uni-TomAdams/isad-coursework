namespace isad157_project
{
    partial class facebookFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.facebookLbl = new System.Windows.Forms.Label();
            this.messageTbx = new System.Windows.Forms.TextBox();
            this.addMessageBtn = new System.Windows.Forms.Button();
            this.addFriendBtn = new System.Windows.Forms.Button();
            this.removeFriendBtn = new System.Windows.Forms.Button();
            this.searchSurnameTbx = new System.Windows.Forms.TextBox();
            this.searchUserBtn = new System.Windows.Forms.Button();
            this.currentLoggedInLbl = new System.Windows.Forms.Label();
            this.loggedInAsUsrNameLbl = new System.Windows.Forms.Label();
            this.searchUserLsb = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.conversationsLSB = new System.Windows.Forms.ListBox();
            this.messagesUI = new System.Windows.Forms.ListBox();
            this.searchForenameTbx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // facebookLbl
            // 
            this.facebookLbl.AutoSize = true;
            this.facebookLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.facebookLbl.Location = new System.Drawing.Point(26, 23);
            this.facebookLbl.Name = "facebookLbl";
            this.facebookLbl.Size = new System.Drawing.Size(173, 31);
            this.facebookLbl.TabIndex = 5;
            this.facebookLbl.Text = "FACEBOOK";
            // 
            // messageTbx
            // 
            this.messageTbx.Location = new System.Drawing.Point(313, 434);
            this.messageTbx.Multiline = true;
            this.messageTbx.Name = "messageTbx";
            this.messageTbx.Size = new System.Drawing.Size(672, 43);
            this.messageTbx.TabIndex = 6;
            // 
            // addMessageBtn
            // 
            this.addMessageBtn.Location = new System.Drawing.Point(991, 434);
            this.addMessageBtn.Name = "addMessageBtn";
            this.addMessageBtn.Size = new System.Drawing.Size(90, 45);
            this.addMessageBtn.TabIndex = 7;
            this.addMessageBtn.Text = "Add Message";
            this.addMessageBtn.UseVisualStyleBackColor = true;
            this.addMessageBtn.Click += new System.EventHandler(this.addMessageBtn_Click);
            // 
            // addFriendBtn
            // 
            this.addFriendBtn.BackColor = System.Drawing.Color.LimeGreen;
            this.addFriendBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addFriendBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.addFriendBtn.Location = new System.Drawing.Point(1173, 436);
            this.addFriendBtn.Name = "addFriendBtn";
            this.addFriendBtn.Size = new System.Drawing.Size(118, 43);
            this.addFriendBtn.TabIndex = 8;
            this.addFriendBtn.Text = "Add Friend";
            this.addFriendBtn.UseVisualStyleBackColor = false;
            this.addFriendBtn.Click += new System.EventHandler(this.addFriendBtn_Click);
            // 
            // removeFriendBtn
            // 
            this.removeFriendBtn.BackColor = System.Drawing.Color.IndianRed;
            this.removeFriendBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeFriendBtn.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.removeFriendBtn.Location = new System.Drawing.Point(1299, 436);
            this.removeFriendBtn.Name = "removeFriendBtn";
            this.removeFriendBtn.Size = new System.Drawing.Size(118, 43);
            this.removeFriendBtn.TabIndex = 9;
            this.removeFriendBtn.Text = "Remove Friend";
            this.removeFriendBtn.UseVisualStyleBackColor = false;
            this.removeFriendBtn.Click += new System.EventHandler(this.removeFriendBtn_Click);
            // 
            // searchSurnameTbx
            // 
            this.searchSurnameTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchSurnameTbx.Location = new System.Drawing.Point(1108, 124);
            this.searchSurnameTbx.Multiline = true;
            this.searchSurnameTbx.Name = "searchSurnameTbx";
            this.searchSurnameTbx.Size = new System.Drawing.Size(279, 27);
            this.searchSurnameTbx.TabIndex = 10;
            // 
            // searchUserBtn
            // 
            this.searchUserBtn.Location = new System.Drawing.Point(1393, 78);
            this.searchUserBtn.Name = "searchUserBtn";
            this.searchUserBtn.Size = new System.Drawing.Size(77, 73);
            this.searchUserBtn.TabIndex = 11;
            this.searchUserBtn.Text = "Search User";
            this.searchUserBtn.UseVisualStyleBackColor = true;
            this.searchUserBtn.Click += new System.EventHandler(this.searchUserBtn_Click);
            // 
            // currentLoggedInLbl
            // 
            this.currentLoggedInLbl.AutoSize = true;
            this.currentLoggedInLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentLoggedInLbl.Location = new System.Drawing.Point(29, 491);
            this.currentLoggedInLbl.Name = "currentLoggedInLbl";
            this.currentLoggedInLbl.Size = new System.Drawing.Size(155, 25);
            this.currentLoggedInLbl.TabIndex = 14;
            this.currentLoggedInLbl.Text = "Logged in as:";
            // 
            // loggedInAsUsrNameLbl
            // 
            this.loggedInAsUsrNameLbl.AutoSize = true;
            this.loggedInAsUsrNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loggedInAsUsrNameLbl.Location = new System.Drawing.Point(190, 489);
            this.loggedInAsUsrNameLbl.Name = "loggedInAsUsrNameLbl";
            this.loggedInAsUsrNameLbl.Size = new System.Drawing.Size(0, 25);
            this.loggedInAsUsrNameLbl.TabIndex = 15;
            // 
            // searchUserLsb
            // 
            this.searchUserLsb.FormattingEnabled = true;
            this.searchUserLsb.Location = new System.Drawing.Point(1108, 162);
            this.searchUserLsb.Name = "searchUserLsb";
            this.searchUserLsb.Size = new System.Drawing.Size(362, 251);
            this.searchUserLsb.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Conversations";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(308, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 18;
            this.label2.Text = "Messages";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1103, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "Search Users";
            // 
            // conversationsLSB
            // 
            this.conversationsLSB.FormattingEnabled = true;
            this.conversationsLSB.Location = new System.Drawing.Point(32, 123);
            this.conversationsLSB.Name = "conversationsLSB";
            this.conversationsLSB.Size = new System.Drawing.Size(265, 290);
            this.conversationsLSB.TabIndex = 20;
            this.conversationsLSB.SelectedIndexChanged += new System.EventHandler(this.conversationsLSB_SelectedIndexChanged);
            // 
            // messagesUI
            // 
            this.messagesUI.FormattingEnabled = true;
            this.messagesUI.Location = new System.Drawing.Point(313, 123);
            this.messagesUI.Name = "messagesUI";
            this.messagesUI.Size = new System.Drawing.Size(768, 290);
            this.messagesUI.TabIndex = 21;
            // 
            // searchForenameTbx
            // 
            this.searchForenameTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchForenameTbx.Location = new System.Drawing.Point(1108, 78);
            this.searchForenameTbx.Multiline = true;
            this.searchForenameTbx.Name = "searchForenameTbx";
            this.searchForenameTbx.Size = new System.Drawing.Size(279, 27);
            this.searchForenameTbx.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1105, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Forename";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1105, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Surname";
            // 
            // facebookFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1491, 535);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.searchForenameTbx);
            this.Controls.Add(this.messagesUI);
            this.Controls.Add(this.conversationsLSB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchUserLsb);
            this.Controls.Add(this.loggedInAsUsrNameLbl);
            this.Controls.Add(this.currentLoggedInLbl);
            this.Controls.Add(this.searchUserBtn);
            this.Controls.Add(this.searchSurnameTbx);
            this.Controls.Add(this.removeFriendBtn);
            this.Controls.Add(this.addFriendBtn);
            this.Controls.Add(this.addMessageBtn);
            this.Controls.Add(this.messageTbx);
            this.Controls.Add(this.facebookLbl);
            this.Name = "facebookFrm";
            this.Text = "Facebook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label facebookLbl;
        private System.Windows.Forms.TextBox messageTbx;
        private System.Windows.Forms.Button addMessageBtn;
        private System.Windows.Forms.Button addFriendBtn;
        private System.Windows.Forms.Button removeFriendBtn;
        private System.Windows.Forms.TextBox searchSurnameTbx;
        private System.Windows.Forms.Button searchUserBtn;
        private System.Windows.Forms.Label currentLoggedInLbl;
        private System.Windows.Forms.Label loggedInAsUsrNameLbl;
        private System.Windows.Forms.ListBox searchUserLsb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox conversationsLSB;
        private System.Windows.Forms.ListBox messagesUI;
        private System.Windows.Forms.TextBox searchForenameTbx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

