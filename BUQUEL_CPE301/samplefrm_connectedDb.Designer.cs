namespace BUQUEL_CPE301
{
    partial class samplefrm_connectedDb
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.student_numTxtbox = new System.Windows.Forms.TextBox();
            this.student_nameTxtbox = new System.Windows.Forms.TextBox();
            this.student_departmentTxtbox = new System.Windows.Forms.TextBox();
            this.datagrid_display = new System.Windows.Forms.DataGridView();
            this.saveBtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.updateBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.newBtn = new System.Windows.Forms.Button();
            this.picturpathTxtbox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_display)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(27, 25);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(244, 255);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(290, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student no.:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(290, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Student name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(290, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Department:";
            // 
            // student_numTxtbox
            // 
            this.student_numTxtbox.Location = new System.Drawing.Point(379, 27);
            this.student_numTxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.student_numTxtbox.Name = "student_numTxtbox";
            this.student_numTxtbox.Size = new System.Drawing.Size(167, 20);
            this.student_numTxtbox.TabIndex = 4;
            this.student_numTxtbox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // student_nameTxtbox
            // 
            this.student_nameTxtbox.Location = new System.Drawing.Point(379, 50);
            this.student_nameTxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.student_nameTxtbox.Name = "student_nameTxtbox";
            this.student_nameTxtbox.Size = new System.Drawing.Size(167, 20);
            this.student_nameTxtbox.TabIndex = 5;
            this.student_nameTxtbox.TextChanged += new System.EventHandler(this.student_nameTxtbox_TextChanged);
            // 
            // student_departmentTxtbox
            // 
            this.student_departmentTxtbox.Location = new System.Drawing.Point(379, 72);
            this.student_departmentTxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.student_departmentTxtbox.Name = "student_departmentTxtbox";
            this.student_departmentTxtbox.Size = new System.Drawing.Size(167, 20);
            this.student_departmentTxtbox.TabIndex = 6;
            // 
            // datagrid_display
            // 
            this.datagrid_display.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagrid_display.Location = new System.Drawing.Point(292, 102);
            this.datagrid_display.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.datagrid_display.Name = "datagrid_display";
            this.datagrid_display.RowHeadersWidth = 51;
            this.datagrid_display.RowTemplate.Height = 24;
            this.datagrid_display.Size = new System.Drawing.Size(253, 128);
            this.datagrid_display.TabIndex = 7;
            this.datagrid_display.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagrid_display_CellContentClick);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(292, 240);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(81, 37);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "SAVE";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(377, 240);
            this.searchBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(80, 37);
            this.searchBtn.TabIndex = 9;
            this.searchBtn.Text = "SEARCH";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(464, 240);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(81, 37);
            this.deleteBtn.TabIndex = 10;
            this.deleteBtn.Text = "DELETE";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(292, 282);
            this.updateBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(81, 37);
            this.updateBtn.TabIndex = 11;
            this.updateBtn.Text = "UPDATE / EDIT";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(379, 282);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(80, 37);
            this.cancelBtn.TabIndex = 12;
            this.cancelBtn.Text = "CANCEL";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // newBtn
            // 
            this.newBtn.Location = new System.Drawing.Point(461, 282);
            this.newBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.newBtn.Name = "newBtn";
            this.newBtn.Size = new System.Drawing.Size(81, 37);
            this.newBtn.TabIndex = 13;
            this.newBtn.Text = "NEW";
            this.newBtn.UseVisualStyleBackColor = true;
            this.newBtn.Click += new System.EventHandler(this.button6_Click);
            // 
            // picturpathTxtbox
            // 
            this.picturpathTxtbox.Location = new System.Drawing.Point(60, 203);
            this.picturpathTxtbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picturpathTxtbox.Name = "picturpathTxtbox";
            this.picturpathTxtbox.Size = new System.Drawing.Size(180, 20);
            this.picturpathTxtbox.TabIndex = 14;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // samplefrm_connectedDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 565);
            this.Controls.Add(this.picturpathTxtbox);
            this.Controls.Add(this.newBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.datagrid_display);
            this.Controls.Add(this.student_departmentTxtbox);
            this.Controls.Add(this.student_nameTxtbox);
            this.Controls.Add(this.student_numTxtbox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "samplefrm_connectedDb";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.samplefrm_connectedDb_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagrid_display)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox student_numTxtbox;
        private System.Windows.Forms.TextBox student_nameTxtbox;
        private System.Windows.Forms.TextBox student_departmentTxtbox;
        private System.Windows.Forms.DataGridView datagrid_display;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button newBtn;
        private System.Windows.Forms.TextBox picturpathTxtbox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

