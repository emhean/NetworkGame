namespace NetworkGame
{
    partial class ServerForm
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
            this.connectClientBtn = new System.Windows.Forms.Button();
            this.ipTbx = new System.Windows.Forms.TextBox();
            this.startServerBtn = new System.Windows.Forms.Button();
            this.nameTbx = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.portTbx = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectClientBtn
            // 
            this.connectClientBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectClientBtn.Location = new System.Drawing.Point(240, 130);
            this.connectClientBtn.Name = "connectClientBtn";
            this.connectClientBtn.Size = new System.Drawing.Size(119, 31);
            this.connectClientBtn.TabIndex = 0;
            this.connectClientBtn.Text = "Connect";
            this.connectClientBtn.UseVisualStyleBackColor = true;
            this.connectClientBtn.Click += new System.EventHandler(this.connectClientBtn_Click);
            // 
            // ipTbx
            // 
            this.ipTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipTbx.Location = new System.Drawing.Point(15, 39);
            this.ipTbx.Name = "ipTbx";
            this.ipTbx.Size = new System.Drawing.Size(117, 26);
            this.ipTbx.TabIndex = 1;
            this.ipTbx.Text = "127.0.0.1";
            // 
            // startServerBtn
            // 
            this.startServerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startServerBtn.Location = new System.Drawing.Point(130, 91);
            this.startServerBtn.Name = "startServerBtn";
            this.startServerBtn.Size = new System.Drawing.Size(131, 31);
            this.startServerBtn.TabIndex = 2;
            this.startServerBtn.Text = "Start Server";
            this.startServerBtn.UseVisualStyleBackColor = true;
            this.startServerBtn.Click += new System.EventHandler(this.startServerBtn_Click);
            // 
            // nameTbx
            // 
            this.nameTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTbx.Location = new System.Drawing.Point(15, 85);
            this.nameTbx.Name = "nameTbx";
            this.nameTbx.Size = new System.Drawing.Size(117, 26);
            this.nameTbx.TabIndex = 3;
            this.nameTbx.Text = "anonymous";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.portTbx);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.connectClientBtn);
            this.groupBox1.Controls.Add(this.ipTbx);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nameTbx);
            this.groupBox1.Location = new System.Drawing.Point(26, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 178);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client Stuff";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.startServerBtn);
            this.groupBox2.Location = new System.Drawing.Point(26, 218);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 128);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Server Host Stuff";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Port:";
            // 
            // portTbx
            // 
            this.portTbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portTbx.Location = new System.Drawing.Point(15, 135);
            this.portTbx.Name = "portTbx";
            this.portTbx.Size = new System.Drawing.Size(117, 26);
            this.portTbx.TabIndex = 6;
            this.portTbx.Text = "12345";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 367);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ServerForm";
            this.Text = "ServerForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox ipTbx;
        public System.Windows.Forms.Button connectClientBtn;
        public System.Windows.Forms.Button startServerBtn;
        private System.Windows.Forms.TextBox nameTbx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox portTbx;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}