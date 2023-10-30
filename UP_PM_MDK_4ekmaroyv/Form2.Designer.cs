namespace UP_PM_MDK_4ekmaroyv
{
    partial class Form2
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
            this.pReg = new System.Windows.Forms.Panel();
            this.btnReg = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.pLog = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnLog = new System.Windows.Forms.Button();
            this.pReg.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // pReg
            // 
            this.pReg.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pReg.Controls.Add(this.btnReg);
            this.pReg.Controls.Add(this.label4);
            this.pReg.Location = new System.Drawing.Point(120, 187);
            this.pReg.Name = "pReg";
            this.pReg.Size = new System.Drawing.Size(210, 79);
            this.pReg.TabIndex = 10;
            // 
            // btnReg
            // 
            this.btnReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReg.Location = new System.Drawing.Point(14, 3);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(183, 53);
            this.btnReg.TabIndex = 0;
            this.btnReg.Text = "Register";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(56, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Уже есть аккаунт?";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbPass);
            this.groupBox2.Location = new System.Drawing.Point(120, 90);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 61);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Пароль";
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(10, 25);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(190, 20);
            this.tbPass.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbUser);
            this.groupBox1.Location = new System.Drawing.Point(120, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 61);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Логин";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(10, 25);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(190, 20);
            this.tbUser.TabIndex = 2;
            // 
            // pLog
            // 
            this.pLog.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pLog.Controls.Add(this.label3);
            this.pLog.Controls.Add(this.btnLog);
            this.pLog.Location = new System.Drawing.Point(120, 187);
            this.pLog.Name = "pLog";
            this.pLog.Size = new System.Drawing.Size(210, 79);
            this.pLog.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(57, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Еще не аккаунта?";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // btnLog
            // 
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLog.Location = new System.Drawing.Point(14, 3);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(183, 53);
            this.btnLog.TabIndex = 1;
            this.btnLog.Text = "Login";
            this.btnLog.UseVisualStyleBackColor = true;
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(450, 289);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pLog);
            this.Controls.Add(this.pReg);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.pReg.ResumeLayout(false);
            this.pReg.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pLog.ResumeLayout(false);
            this.pLog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pReg;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Panel pLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLog;
    }
}