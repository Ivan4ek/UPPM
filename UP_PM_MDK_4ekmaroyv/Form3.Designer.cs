namespace UP_PM_MDK_4ekmaroyv
{
    partial class Form3
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
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.btnSearchMenu = new System.Windows.Forms.Button();
            this.tbSearchMenu = new System.Windows.Forms.TextBox();
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox14.SuspendLayout();
            this.groupBox19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.btnLoad);
            this.groupBox14.Controls.Add(this.groupBox19);
            this.groupBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox14.Location = new System.Drawing.Point(497, 376);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(237, 118);
            this.groupBox14.TabIndex = 8;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Поиск";
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLoad.Location = new System.Drawing.Point(6, 71);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(225, 39);
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.btnSearchMenu);
            this.groupBox19.Controls.Add(this.tbSearchMenu);
            this.groupBox19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox19.Location = new System.Drawing.Point(6, 19);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(225, 46);
            this.groupBox19.TabIndex = 1;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "Какую таблицу редактируем?";
            // 
            // btnSearchMenu
            // 
            this.btnSearchMenu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchMenu.Location = new System.Drawing.Point(200, 19);
            this.btnSearchMenu.Name = "btnSearchMenu";
            this.btnSearchMenu.Size = new System.Drawing.Size(20, 20);
            this.btnSearchMenu.TabIndex = 3;
            this.btnSearchMenu.Text = "V";
            this.btnSearchMenu.UseVisualStyleBackColor = true;
            this.btnSearchMenu.Click += new System.EventHandler(this.btnSearchMenu_Click);
            // 
            // tbSearchMenu
            // 
            this.tbSearchMenu.Location = new System.Drawing.Point(6, 19);
            this.tbSearchMenu.Name = "tbSearchMenu";
            this.tbSearchMenu.Size = new System.Drawing.Size(190, 20);
            this.tbSearchMenu.TabIndex = 2;
            // 
            // dgv1
            // 
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Location = new System.Drawing.Point(3, 3);
            this.dgv1.Name = "dgv1";
            this.dgv1.Size = new System.Drawing.Size(731, 323);
            this.dgv1.TabIndex = 9;
            this.dgv1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv1_CellContentClick);
            // 
            // dgv2
            // 
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(3, 329);
            this.dgv2.Name = "dgv2";
            this.dgv2.Size = new System.Drawing.Size(731, 46);
            this.dgv2.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 376);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 118);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавить";
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdd.Location = new System.Drawing.Point(9, 24);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(473, 88);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 497);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox14);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.dgv1);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.groupBox14.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.Button btnSearchMenu;
        private System.Windows.Forms.TextBox tbSearchMenu;
        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdd;
    }
}