
namespace LanChat
{
    partial class LanChat
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
            this.buttonServer = new System.Windows.Forms.Button();
            this.buttonClient = new System.Windows.Forms.Button();
            this.richTextServer = new System.Windows.Forms.RichTextBox();
            this.richTextClient = new System.Windows.Forms.RichTextBox();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.buttonServerSend = new System.Windows.Forms.Button();
            this.buttonClientSend = new System.Windows.Forms.Button();
            this.textBoxClient = new System.Windows.Forms.TextBox();
            this.comboListIP = new System.Windows.Forms.ComboBox();
            this.buttonDisconect = new System.Windows.Forms.Button();
            this.buttonListen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonServer
            // 
            this.buttonServer.Location = new System.Drawing.Point(13, 70);
            this.buttonServer.Margin = new System.Windows.Forms.Padding(4);
            this.buttonServer.Name = "buttonServer";
            this.buttonServer.Size = new System.Drawing.Size(184, 186);
            this.buttonServer.TabIndex = 1;
            this.buttonServer.Text = "Server Start";
            this.buttonServer.UseVisualStyleBackColor = true;
            this.buttonServer.Click += new System.EventHandler(this.buttonServer_Click);
            // 
            // buttonClient
            // 
            this.buttonClient.Location = new System.Drawing.Point(13, 305);
            this.buttonClient.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClient.Name = "buttonClient";
            this.buttonClient.Size = new System.Drawing.Size(184, 215);
            this.buttonClient.TabIndex = 2;
            this.buttonClient.Text = "Client Start";
            this.buttonClient.UseVisualStyleBackColor = true;
            this.buttonClient.Click += new System.EventHandler(this.buttonClient_Click);
            // 
            // richTextServer
            // 
            this.richTextServer.Location = new System.Drawing.Point(204, 70);
            this.richTextServer.Name = "richTextServer";
            this.richTextServer.Size = new System.Drawing.Size(296, 186);
            this.richTextServer.TabIndex = 3;
            this.richTextServer.Text = "";
            // 
            // richTextClient
            // 
            this.richTextClient.Location = new System.Drawing.Point(204, 305);
            this.richTextClient.Name = "richTextClient";
            this.richTextClient.Size = new System.Drawing.Size(296, 186);
            this.richTextClient.TabIndex = 4;
            this.richTextClient.Text = "";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(204, 262);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(215, 23);
            this.textBoxServer.TabIndex = 5;
            this.textBoxServer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxServer_KeyUp);
            // 
            // buttonServerSend
            // 
            this.buttonServerSend.Location = new System.Drawing.Point(425, 262);
            this.buttonServerSend.Name = "buttonServerSend";
            this.buttonServerSend.Size = new System.Drawing.Size(75, 23);
            this.buttonServerSend.TabIndex = 6;
            this.buttonServerSend.Text = "Send";
            this.buttonServerSend.UseVisualStyleBackColor = true;
            this.buttonServerSend.Click += new System.EventHandler(this.buttonServerSend_Click);
            // 
            // buttonClientSend
            // 
            this.buttonClientSend.Location = new System.Drawing.Point(425, 497);
            this.buttonClientSend.Name = "buttonClientSend";
            this.buttonClientSend.Size = new System.Drawing.Size(75, 23);
            this.buttonClientSend.TabIndex = 8;
            this.buttonClientSend.Text = "Send";
            this.buttonClientSend.UseVisualStyleBackColor = true;
            this.buttonClientSend.Click += new System.EventHandler(this.buttonClientSend_Click);
            // 
            // textBoxClient
            // 
            this.textBoxClient.Location = new System.Drawing.Point(204, 497);
            this.textBoxClient.Name = "textBoxClient";
            this.textBoxClient.Size = new System.Drawing.Size(215, 23);
            this.textBoxClient.TabIndex = 7;
            this.textBoxClient.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxClient_KeyUp);
            // 
            // comboListIP
            // 
            this.comboListIP.FormattingEnabled = true;
            this.comboListIP.Location = new System.Drawing.Point(13, 13);
            this.comboListIP.Name = "comboListIP";
            this.comboListIP.Size = new System.Drawing.Size(184, 24);
            this.comboListIP.TabIndex = 9;
            // 
            // buttonDisconect
            // 
            this.buttonDisconect.Location = new System.Drawing.Point(366, 13);
            this.buttonDisconect.Name = "buttonDisconect";
            this.buttonDisconect.Size = new System.Drawing.Size(134, 35);
            this.buttonDisconect.TabIndex = 10;
            this.buttonDisconect.Text = "Disconnect";
            this.buttonDisconect.UseVisualStyleBackColor = true;
            this.buttonDisconect.Click += new System.EventHandler(this.buttonDisconect_Click);
            // 
            // buttonListen
            // 
            this.buttonListen.Location = new System.Drawing.Point(204, 12);
            this.buttonListen.Name = "buttonListen";
            this.buttonListen.Size = new System.Drawing.Size(156, 35);
            this.buttonListen.TabIndex = 11;
            this.buttonListen.Text = "Server Listen again";
            this.buttonListen.UseVisualStyleBackColor = true;
            this.buttonListen.Click += new System.EventHandler(this.buttonListen_Click);
            // 
            // LanChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 554);
            this.Controls.Add(this.buttonListen);
            this.Controls.Add(this.buttonDisconect);
            this.Controls.Add(this.comboListIP);
            this.Controls.Add(this.buttonClientSend);
            this.Controls.Add(this.textBoxClient);
            this.Controls.Add(this.buttonServerSend);
            this.Controls.Add(this.textBoxServer);
            this.Controls.Add(this.richTextClient);
            this.Controls.Add(this.richTextServer);
            this.Controls.Add(this.buttonClient);
            this.Controls.Add(this.buttonServer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LanChat";
            this.Text = "Chat On Lan";
            this.Load += new System.EventHandler(this.LanChat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonServer;
        private System.Windows.Forms.Button buttonClient;
        private System.Windows.Forms.RichTextBox richTextServer;
        private System.Windows.Forms.RichTextBox richTextClient;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Button buttonServerSend;
        private System.Windows.Forms.Button buttonClientSend;
        private System.Windows.Forms.TextBox textBoxClient;
        private System.Windows.Forms.ComboBox comboListIP;
        private System.Windows.Forms.Button buttonDisconect;
        private System.Windows.Forms.Button buttonListen;
    }
}

