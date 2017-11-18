namespace WindowsFormsApplication1
{
    partial class MainForm
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
            this.lblMsg = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdSearch = new System.Windows.Forms.Button();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.cmdDel = new System.Windows.Forms.Button();
            this.cmdInster = new System.Windows.Forms.Button();
            this.cmdInit = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdMD5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.LightCyan;
            this.lblMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblMsg.Font = new System.Drawing.Font("SimHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMsg.ForeColor = System.Drawing.Color.Blue;
            this.lblMsg.Location = new System.Drawing.Point(4, 98);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lblMsg.Size = new System.Drawing.Size(320, 19);
            this.lblMsg.TabIndex = 57;
            this.lblMsg.UseWaitCursor = true;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(123, 18);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(140, 20);
            this.txtName.TabIndex = 56;
            this.txtName.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 11);
            this.label1.TabIndex = 55;
            this.label1.Text = "Document";
            // 
            // cmdSearch
            // 
            this.cmdSearch.Location = new System.Drawing.Point(166, 218);
            this.cmdSearch.Name = "cmdSearch";
            this.cmdSearch.Size = new System.Drawing.Size(60, 23);
            this.cmdSearch.TabIndex = 54;
            this.cmdSearch.Text = "Search";
            this.cmdSearch.UseVisualStyleBackColor = true;
            this.cmdSearch.Click += new System.EventHandler(this.cmdSearch_Click);
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Location = new System.Drawing.Point(88, 218);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(60, 21);
            this.cmdUpdate.TabIndex = 53;
            this.cmdUpdate.Text = "Update";
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // cmdDel
            // 
            this.cmdDel.Location = new System.Drawing.Point(166, 177);
            this.cmdDel.Name = "cmdDel";
            this.cmdDel.Size = new System.Drawing.Size(62, 26);
            this.cmdDel.TabIndex = 52;
            this.cmdDel.Text = "Delete";
            this.cmdDel.UseVisualStyleBackColor = true;
            this.cmdDel.Click += new System.EventHandler(this.cmdDel_Click);
            // 
            // cmdInster
            // 
            this.cmdInster.Location = new System.Drawing.Point(88, 177);
            this.cmdInster.Name = "cmdInster";
            this.cmdInster.Size = new System.Drawing.Size(60, 27);
            this.cmdInster.TabIndex = 51;
            this.cmdInster.Text = "Insert";
            this.cmdInster.UseVisualStyleBackColor = true;
            this.cmdInster.Click += new System.EventHandler(this.cmdInster_Click);
            // 
            // cmdInit
            // 
            this.cmdInit.Location = new System.Drawing.Point(88, 126);
            this.cmdInit.Name = "cmdInit";
            this.cmdInit.Size = new System.Drawing.Size(143, 35);
            this.cmdInit.TabIndex = 50;
            this.cmdInit.Text = "初始化 Mongo DB 设定";
            this.cmdInit.UseVisualStyleBackColor = true;
            this.cmdInit.Click += new System.EventHandler(this.cmdInit_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(123, 46);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(140, 20);
            this.txtValue.TabIndex = 59;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 11);
            this.label2.TabIndex = 58;
            this.label2.Text = "Field Value";
            // 
            // txtNewV
            // 
            this.txtNewV.Location = new System.Drawing.Point(123, 72);
            this.txtNewV.Name = "txtNewV";
            this.txtNewV.Size = new System.Drawing.Size(140, 20);
            this.txtNewV.TabIndex = 61;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 11);
            this.label3.TabIndex = 60;
            this.label3.Text = "New F Value";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(2, 247);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(320, 230);
            this.dataGridView1.TabIndex = 62;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ID";
            this.Column2.Name = "Column2";
            this.Column2.Width = 175;
            // 
            // cmdMD5
            // 
            this.cmdMD5.Location = new System.Drawing.Point(239, 126);
            this.cmdMD5.Name = "cmdMD5";
            this.cmdMD5.Size = new System.Drawing.Size(75, 35);
            this.cmdMD5.TabIndex = 63;
            this.cmdMD5.Text = "C MD5 Info";
            this.cmdMD5.UseVisualStyleBackColor = true;
            this.cmdMD5.Click += new System.EventHandler(this.cmdMD5_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(326, 487);
            this.Controls.Add(this.cmdMD5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtNewV);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdSearch);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.cmdDel);
            this.Controls.Add(this.cmdInster);
            this.Controls.Add(this.cmdInit);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("SimHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HelpButton = true;
            this.HelpButtonText = "Helper";
            this.Name = "MainForm";
            this.Tag = "";
            this.TitleText = "MongoDB数据库訪問";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox lblMsg;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdSearch;
        private System.Windows.Forms.Button cmdUpdate;
        private System.Windows.Forms.Button cmdDel;
        private System.Windows.Forms.Button cmdInster;
        private System.Windows.Forms.Button cmdInit;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Button cmdMD5;
    }
}