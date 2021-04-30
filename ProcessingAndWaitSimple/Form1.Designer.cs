
namespace ProcessingAndWait
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.GetIpAddressVersion1Button = new System.Windows.Forms.Button();
            this.GetIpAddressVersion2Button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.GetIpAddressVersion3Button = new System.Windows.Forms.Button();
            this.FamilyListBox = new System.Windows.Forms.ListBox();
            this.AddressFamilyButton = new System.Windows.Forms.Button();
            this.IpAddressTextBox2 = new System.Windows.Forms.TextBox();
            this.IpAddressTextBox1 = new System.Windows.Forms.TextBox();
            this.GetApplicationEventsJsonButton = new System.Windows.Forms.Button();
            this.GetServicesHtmlButton = new System.Windows.Forms.Button();
            this.GetServicesAsJsonButton = new System.Windows.Forms.Button();
            this.ServicesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.ServiceCountLabel = new System.Windows.Forms.Label();
            this.JsonTimeTextBox = new System.Windows.Forms.TextBox();
            this.RunScriptButton = new System.Windows.Forms.Button();
            this.TimeZoneButton = new System.Windows.Forms.Button();
            this.ComputerInformationButton = new System.Windows.Forms.Button();
            this.OpenExecutableFolder = new System.Windows.Forms.Button();
            this.FilesListBox = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UnblockFolderButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // GetIpAddressVersion1Button
            // 
            this.GetIpAddressVersion1Button.Image = ((System.Drawing.Image)(resources.GetObject("GetIpAddressVersion1Button.Image")));
            this.GetIpAddressVersion1Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GetIpAddressVersion1Button.Location = new System.Drawing.Point(12, 26);
            this.GetIpAddressVersion1Button.Name = "GetIpAddressVersion1Button";
            this.GetIpAddressVersion1Button.Size = new System.Drawing.Size(177, 23);
            this.GetIpAddressVersion1Button.TabIndex = 0;
            this.GetIpAddressVersion1Button.Text = "Version 1";
            this.GetIpAddressVersion1Button.UseVisualStyleBackColor = true;
            this.GetIpAddressVersion1Button.Click += new System.EventHandler(this.GetIpAddressVersion1Button_Click);
            // 
            // GetIpAddressVersion2Button
            // 
            this.GetIpAddressVersion2Button.Image = ((System.Drawing.Image)(resources.GetObject("GetIpAddressVersion2Button.Image")));
            this.GetIpAddressVersion2Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GetIpAddressVersion2Button.Location = new System.Drawing.Point(12, 55);
            this.GetIpAddressVersion2Button.Name = "GetIpAddressVersion2Button";
            this.GetIpAddressVersion2Button.Size = new System.Drawing.Size(177, 23);
            this.GetIpAddressVersion2Button.TabIndex = 1;
            this.GetIpAddressVersion2Button.Text = "Version 2";
            this.GetIpAddressVersion2Button.UseVisualStyleBackColor = true;
            this.GetIpAddressVersion2Button.Click += new System.EventHandler(this.GetIpAddressVersion2Button_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.GetIpAddressVersion3Button);
            this.groupBox1.Controls.Add(this.FamilyListBox);
            this.groupBox1.Controls.Add(this.AddressFamilyButton);
            this.groupBox1.Controls.Add(this.IpAddressTextBox2);
            this.groupBox1.Controls.Add(this.IpAddressTextBox1);
            this.groupBox1.Controls.Add(this.GetIpAddressVersion2Button);
            this.groupBox1.Controls.Add(this.GetIpAddressVersion1Button);
            this.groupBox1.Location = new System.Drawing.Point(12, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 226);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Get IP Address";
            // 
            // GetIpAddressVersion3Button
            // 
            this.GetIpAddressVersion3Button.Image = ((System.Drawing.Image)(resources.GetObject("GetIpAddressVersion3Button.Image")));
            this.GetIpAddressVersion3Button.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GetIpAddressVersion3Button.Location = new System.Drawing.Point(12, 84);
            this.GetIpAddressVersion3Button.Name = "GetIpAddressVersion3Button";
            this.GetIpAddressVersion3Button.Size = new System.Drawing.Size(177, 23);
            this.GetIpAddressVersion3Button.TabIndex = 6;
            this.GetIpAddressVersion3Button.Text = "Version 3 *";
            this.GetIpAddressVersion3Button.UseVisualStyleBackColor = true;
            this.GetIpAddressVersion3Button.Click += new System.EventHandler(this.GetIpAddressVersion3Button_Click);
            // 
            // FamilyListBox
            // 
            this.FamilyListBox.FormattingEnabled = true;
            this.FamilyListBox.ItemHeight = 15;
            this.FamilyListBox.Location = new System.Drawing.Point(198, 126);
            this.FamilyListBox.Name = "FamilyListBox";
            this.FamilyListBox.Size = new System.Drawing.Size(152, 94);
            this.FamilyListBox.TabIndex = 5;
            // 
            // AddressFamilyButton
            // 
            this.AddressFamilyButton.Image = ((System.Drawing.Image)(resources.GetObject("AddressFamilyButton.Image")));
            this.AddressFamilyButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddressFamilyButton.Location = new System.Drawing.Point(15, 126);
            this.AddressFamilyButton.Name = "AddressFamilyButton";
            this.AddressFamilyButton.Size = new System.Drawing.Size(177, 23);
            this.AddressFamilyButton.TabIndex = 4;
            this.AddressFamilyButton.Text = "Address family";
            this.AddressFamilyButton.UseVisualStyleBackColor = true;
            this.AddressFamilyButton.Click += new System.EventHandler(this.AddressFamilyButton_Click);
            // 
            // IpAddressTextBox2
            // 
            this.IpAddressTextBox2.Location = new System.Drawing.Point(198, 55);
            this.IpAddressTextBox2.Name = "IpAddressTextBox2";
            this.IpAddressTextBox2.PlaceholderText = "This computers ip";
            this.IpAddressTextBox2.Size = new System.Drawing.Size(152, 23);
            this.IpAddressTextBox2.TabIndex = 3;
            // 
            // IpAddressTextBox1
            // 
            this.IpAddressTextBox1.Location = new System.Drawing.Point(198, 26);
            this.IpAddressTextBox1.Name = "IpAddressTextBox1";
            this.IpAddressTextBox1.PlaceholderText = "This computers ip";
            this.IpAddressTextBox1.Size = new System.Drawing.Size(152, 23);
            this.IpAddressTextBox1.TabIndex = 2;
            // 
            // GetApplicationEventsJsonButton
            // 
            this.GetApplicationEventsJsonButton.Image = ((System.Drawing.Image)(resources.GetObject("GetApplicationEventsJsonButton.Image")));
            this.GetApplicationEventsJsonButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GetApplicationEventsJsonButton.Location = new System.Drawing.Point(408, 49);
            this.GetApplicationEventsJsonButton.Name = "GetApplicationEventsJsonButton";
            this.GetApplicationEventsJsonButton.Size = new System.Drawing.Size(175, 23);
            this.GetApplicationEventsJsonButton.TabIndex = 4;
            this.GetApplicationEventsJsonButton.Text = "Application Events Json";
            this.GetApplicationEventsJsonButton.UseVisualStyleBackColor = true;
            this.GetApplicationEventsJsonButton.Click += new System.EventHandler(this.GetApplicationEventsJsonButton_Click);
            // 
            // GetServicesHtmlButton
            // 
            this.GetServicesHtmlButton.Image = ((System.Drawing.Image)(resources.GetObject("GetServicesHtmlButton.Image")));
            this.GetServicesHtmlButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GetServicesHtmlButton.Location = new System.Drawing.Point(208, 49);
            this.GetServicesHtmlButton.Name = "GetServicesHtmlButton";
            this.GetServicesHtmlButton.Size = new System.Drawing.Size(177, 23);
            this.GetServicesHtmlButton.TabIndex = 4;
            this.GetServicesHtmlButton.Text = "Get services as html";
            this.GetServicesHtmlButton.UseVisualStyleBackColor = true;
            this.GetServicesHtmlButton.Click += new System.EventHandler(this.GetServicesHtmlButton_Click);
            // 
            // GetServicesAsJsonButton
            // 
            this.GetServicesAsJsonButton.Image = ((System.Drawing.Image)(resources.GetObject("GetServicesAsJsonButton.Image")));
            this.GetServicesAsJsonButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GetServicesAsJsonButton.Location = new System.Drawing.Point(408, 20);
            this.GetServicesAsJsonButton.Name = "GetServicesAsJsonButton";
            this.GetServicesAsJsonButton.Size = new System.Drawing.Size(175, 23);
            this.GetServicesAsJsonButton.TabIndex = 3;
            this.GetServicesAsJsonButton.Text = "Get services as json";
            this.GetServicesAsJsonButton.UseVisualStyleBackColor = true;
            this.GetServicesAsJsonButton.Click += new System.EventHandler(this.GetServicesAsJsonButton_Click);
            // 
            // ServicesListView
            // 
            this.ServicesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ServicesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.ServicesListView.FullRowSelect = true;
            this.ServicesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ServicesListView.HideSelection = false;
            this.ServicesListView.Location = new System.Drawing.Point(12, 319);
            this.ServicesListView.MultiSelect = false;
            this.ServicesListView.Name = "ServicesListView";
            this.ServicesListView.Size = new System.Drawing.Size(900, 297);
            this.ServicesListView.TabIndex = 4;
            this.ServicesListView.UseCompatibleStateImageBehavior = false;
            this.ServicesListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Name = "columnHeader1";
            this.columnHeader1.Text = "Name";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Name = "columnHeader2";
            this.columnHeader2.Text = "Display name";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Name = "columnHeader3";
            this.columnHeader3.Text = "Status";
            // 
            // ServiceCountLabel
            // 
            this.ServiceCountLabel.AutoSize = true;
            this.ServiceCountLabel.Location = new System.Drawing.Point(592, 23);
            this.ServiceCountLabel.Name = "ServiceCountLabel";
            this.ServiceCountLabel.Size = new System.Drawing.Size(40, 15);
            this.ServiceCountLabel.TabIndex = 5;
            this.ServiceCountLabel.Text = "Count";
            // 
            // JsonTimeTextBox
            // 
            this.JsonTimeTextBox.Location = new System.Drawing.Point(592, 49);
            this.JsonTimeTextBox.Name = "JsonTimeTextBox";
            this.JsonTimeTextBox.Size = new System.Drawing.Size(92, 23);
            this.JsonTimeTextBox.TabIndex = 4;
            // 
            // RunScriptButton
            // 
            this.RunScriptButton.Image = ((System.Drawing.Image)(resources.GetObject("RunScriptButton.Image")));
            this.RunScriptButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RunScriptButton.Location = new System.Drawing.Point(12, 20);
            this.RunScriptButton.Name = "RunScriptButton";
            this.RunScriptButton.Size = new System.Drawing.Size(177, 23);
            this.RunScriptButton.TabIndex = 4;
            this.RunScriptButton.Text = "Run script example";
            this.RunScriptButton.UseVisualStyleBackColor = true;
            this.RunScriptButton.Click += new System.EventHandler(this.RunScriptButton_Click);
            // 
            // TimeZoneButton
            // 
            this.TimeZoneButton.Image = ((System.Drawing.Image)(resources.GetObject("TimeZoneButton.Image")));
            this.TimeZoneButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TimeZoneButton.Location = new System.Drawing.Point(210, 19);
            this.TimeZoneButton.Name = "TimeZoneButton";
            this.TimeZoneButton.Size = new System.Drawing.Size(177, 23);
            this.TimeZoneButton.TabIndex = 6;
            this.TimeZoneButton.Text = "Time zone example";
            this.TimeZoneButton.UseVisualStyleBackColor = true;
            this.TimeZoneButton.Click += new System.EventHandler(this.TimeZoneButton_Click);
            // 
            // ComputerInformationButton
            // 
            this.ComputerInformationButton.Image = ((System.Drawing.Image)(resources.GetObject("ComputerInformationButton.Image")));
            this.ComputerInformationButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ComputerInformationButton.Location = new System.Drawing.Point(12, 49);
            this.ComputerInformationButton.Name = "ComputerInformationButton";
            this.ComputerInformationButton.Size = new System.Drawing.Size(177, 23);
            this.ComputerInformationButton.TabIndex = 7;
            this.ComputerInformationButton.Text = "Computer info example";
            this.ComputerInformationButton.UseVisualStyleBackColor = true;
            this.ComputerInformationButton.Click += new System.EventHandler(this.ComputerInformationButton_Click);
            // 
            // OpenExecutableFolder
            // 
            this.OpenExecutableFolder.Image = ((System.Drawing.Image)(resources.GetObject("OpenExecutableFolder.Image")));
            this.OpenExecutableFolder.Location = new System.Drawing.Point(690, 254);
            this.OpenExecutableFolder.Name = "OpenExecutableFolder";
            this.OpenExecutableFolder.Size = new System.Drawing.Size(213, 23);
            this.OpenExecutableFolder.TabIndex = 8;
            this.OpenExecutableFolder.UseVisualStyleBackColor = true;
            this.OpenExecutableFolder.Click += new System.EventHandler(this.OpenExecutableFolder_Click);
            // 
            // FilesListBox
            // 
            this.FilesListBox.FormattingEnabled = true;
            this.FilesListBox.ItemHeight = 15;
            this.FilesListBox.Location = new System.Drawing.Point(690, 19);
            this.FilesListBox.Name = "FilesListBox";
            this.FilesListBox.Size = new System.Drawing.Size(213, 229);
            this.FilesListBox.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(668, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // UnblockFolderButton
            // 
            this.UnblockFolderButton.Location = new System.Drawing.Point(408, 78);
            this.UnblockFolderButton.Name = "UnblockFolderButton";
            this.UnblockFolderButton.Size = new System.Drawing.Size(175, 23);
            this.UnblockFolderButton.TabIndex = 11;
            this.UnblockFolderButton.Text = "Unblock folder";
            this.UnblockFolderButton.UseVisualStyleBackColor = true;
            this.UnblockFolderButton.Click += new System.EventHandler(this.UnblockFolderButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 628);
            this.Controls.Add(this.UnblockFolderButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.FilesListBox);
            this.Controls.Add(this.OpenExecutableFolder);
            this.Controls.Add(this.ComputerInformationButton);
            this.Controls.Add(this.TimeZoneButton);
            this.Controls.Add(this.RunScriptButton);
            this.Controls.Add(this.JsonTimeTextBox);
            this.Controls.Add(this.GetApplicationEventsJsonButton);
            this.Controls.Add(this.GetServicesHtmlButton);
            this.Controls.Add(this.ServiceCountLabel);
            this.Controls.Add(this.ServicesListView);
            this.Controls.Add(this.GetServicesAsJsonButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Process run code samples";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GetIpAddressVersion1Button;
        private System.Windows.Forms.Button GetIpAddressVersion2Button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox IpAddressTextBox2;
        private System.Windows.Forms.TextBox IpAddressTextBox1;
        private System.Windows.Forms.Button GetServicesAsJsonButton;
        private System.Windows.Forms.ListView ServicesListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label ServiceCountLabel;
        private System.Windows.Forms.Button GetServicesHtmlButton;
        private System.Windows.Forms.Button GetApplicationEventsJsonButton;
        private System.Windows.Forms.TextBox JsonTimeTextBox;
        private System.Windows.Forms.Button RunScriptButton;
        private System.Windows.Forms.Button TimeZoneButton;
        private System.Windows.Forms.Button ComputerInformationButton;
        private System.Windows.Forms.Button OpenExecutableFolder;
        private System.Windows.Forms.ListBox FilesListBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button AddressFamilyButton;
        private System.Windows.Forms.ListBox FamilyListBox;
        private System.Windows.Forms.Button GetIpAddressVersion3Button;
        private System.Windows.Forms.Button UnblockFolderButton;
    }
}

