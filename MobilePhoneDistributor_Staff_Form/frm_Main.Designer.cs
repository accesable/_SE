namespace MobilePhoneDistributor_Staff_Form
{
    partial class frm_Main
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
            this.groupBoxFind = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFind = new System.Windows.Forms.TextBox();
            this.dateTimePickerFind = new System.Windows.Forms.DateTimePicker();
            this.groupBoxFunction = new System.Windows.Forms.GroupBox();
            this.buttonDetail = new System.Windows.Forms.Button();
            this.buttonReload = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.groupBoxDisplay = new System.Windows.Forms.GroupBox();
            this.dataGridViewReceipt = new System.Windows.Forms.DataGridView();
            this.groupBoxinfor = new System.Windows.Forms.GroupBox();
            this.textBoxStaff = new System.Windows.Forms.TextBox();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.deliveryNotesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.groupBoxFind.SuspendLayout();
            this.groupBoxFunction.SuspendLayout();
            this.groupBoxDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceipt)).BeginInit();
            this.groupBoxinfor.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFind
            // 
            this.groupBoxFind.Controls.Add(this.label5);
            this.groupBoxFind.Controls.Add(this.label1);
            this.groupBoxFind.Controls.Add(this.textBoxFind);
            this.groupBoxFind.Controls.Add(this.dateTimePickerFind);
            this.groupBoxFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFind.Location = new System.Drawing.Point(3, 367);
            this.groupBoxFind.Name = "groupBoxFind";
            this.groupBoxFind.Size = new System.Drawing.Size(376, 193);
            this.groupBoxFind.TabIndex = 7;
            this.groupBoxFind.TabStop = false;
            this.groupBoxFind.Text = "Find Receipt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 22);
            this.label5.TabIndex = 3;
            this.label5.Text = "On Staff ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "On Date";
            // 
            // textBoxFind
            // 
            this.textBoxFind.Location = new System.Drawing.Point(6, 123);
            this.textBoxFind.Name = "textBoxFind";
            this.textBoxFind.Size = new System.Drawing.Size(364, 28);
            this.textBoxFind.TabIndex = 1;
            this.textBoxFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxFind_KeyUp);
            // 
            // dateTimePickerFind
            // 
            this.dateTimePickerFind.Location = new System.Drawing.Point(6, 60);
            this.dateTimePickerFind.Name = "dateTimePickerFind";
            this.dateTimePickerFind.Size = new System.Drawing.Size(364, 28);
            this.dateTimePickerFind.TabIndex = 0;
            this.dateTimePickerFind.ValueChanged += new System.EventHandler(this.dateTimePickerFind_ValueChanged);
            // 
            // groupBoxFunction
            // 
            this.groupBoxFunction.Controls.Add(this.buttonDetail);
            this.groupBoxFunction.Controls.Add(this.buttonReload);
            this.groupBoxFunction.Controls.Add(this.buttonSave);
            this.groupBoxFunction.Controls.Add(this.buttonDelete);
            this.groupBoxFunction.Controls.Add(this.buttonAdd);
            this.groupBoxFunction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxFunction.Location = new System.Drawing.Point(3, 224);
            this.groupBoxFunction.Name = "groupBoxFunction";
            this.groupBoxFunction.Size = new System.Drawing.Size(382, 137);
            this.groupBoxFunction.TabIndex = 6;
            this.groupBoxFunction.TabStop = false;
            this.groupBoxFunction.Text = "Functions";
            // 
            // buttonDetail
            // 
            this.buttonDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDetail.Location = new System.Drawing.Point(204, 59);
            this.buttonDetail.Name = "buttonDetail";
            this.buttonDetail.Size = new System.Drawing.Size(91, 41);
            this.buttonDetail.TabIndex = 5;
            this.buttonDetail.Text = "Details";
            this.buttonDetail.UseVisualStyleBackColor = true;
            this.buttonDetail.Click += new System.EventHandler(this.buttonDetail_Click);
            // 
            // buttonReload
            // 
            this.buttonReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReload.Location = new System.Drawing.Point(107, 85);
            this.buttonReload.Name = "buttonReload";
            this.buttonReload.Size = new System.Drawing.Size(91, 41);
            this.buttonReload.TabIndex = 4;
            this.buttonReload.Text = "Reload";
            this.buttonReload.UseVisualStyleBackColor = true;
            this.buttonReload.Click += new System.EventHandler(this.buttonReload_Click_1);
            // 
            // buttonSave
            // 
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(10, 85);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(91, 41);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(107, 25);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(91, 54);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "Delete Receipt";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click_1);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(10, 25);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(91, 54);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Add Receipt";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click_1);
            // 
            // groupBoxDisplay
            // 
            this.groupBoxDisplay.Controls.Add(this.dataGridViewReceipt);
            this.groupBoxDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDisplay.Location = new System.Drawing.Point(391, 43);
            this.groupBoxDisplay.Name = "groupBoxDisplay";
            this.groupBoxDisplay.Size = new System.Drawing.Size(584, 523);
            this.groupBoxDisplay.TabIndex = 5;
            this.groupBoxDisplay.TabStop = false;
            this.groupBoxDisplay.Text = "Receipt Display";
            // 
            // dataGridViewReceipt
            // 
            this.dataGridViewReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReceipt.Location = new System.Drawing.Point(6, 25);
            this.dataGridViewReceipt.Name = "dataGridViewReceipt";
            this.dataGridViewReceipt.RowHeadersWidth = 62;
            this.dataGridViewReceipt.RowTemplate.Height = 28;
            this.dataGridViewReceipt.Size = new System.Drawing.Size(572, 492);
            this.dataGridViewReceipt.TabIndex = 0;
            this.dataGridViewReceipt.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewReceipt_CellClick);
            // 
            // groupBoxinfor
            // 
            this.groupBoxinfor.Controls.Add(this.textBoxStaff);
            this.groupBoxinfor.Controls.Add(this.dateTimePickerDate);
            this.groupBoxinfor.Controls.Add(this.textBoxID);
            this.groupBoxinfor.Controls.Add(this.label4);
            this.groupBoxinfor.Controls.Add(this.label3);
            this.groupBoxinfor.Controls.Add(this.label2);
            this.groupBoxinfor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxinfor.Location = new System.Drawing.Point(3, 43);
            this.groupBoxinfor.Name = "groupBoxinfor";
            this.groupBoxinfor.Size = new System.Drawing.Size(382, 175);
            this.groupBoxinfor.TabIndex = 4;
            this.groupBoxinfor.TabStop = false;
            this.groupBoxinfor.Text = "Phone Product Good Imported Receipt";
            // 
            // textBoxStaff
            // 
            this.textBoxStaff.Location = new System.Drawing.Point(126, 105);
            this.textBoxStaff.Name = "textBoxStaff";
            this.textBoxStaff.Size = new System.Drawing.Size(250, 28);
            this.textBoxStaff.TabIndex = 7;
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerDate.Location = new System.Drawing.Point(126, 68);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(250, 28);
            this.dateTimePickerDate.TabIndex = 6;
            // 
            // textBoxID
            // 
            this.textBoxID.Location = new System.Drawing.Point(126, 35);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(250, 28);
            this.textBoxID.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Staff ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Receipt Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Receipt ID";
            // 
            // deliveryNotesToolStripMenuItem
            // 
            this.deliveryNotesToolStripMenuItem.Name = "deliveryNotesToolStripMenuItem";
            this.deliveryNotesToolStripMenuItem.Size = new System.Drawing.Size(143, 29);
            this.deliveryNotesToolStripMenuItem.Text = "Delivery Notes";
            this.deliveryNotesToolStripMenuItem.Click += new System.EventHandler(this.deliveryNotesToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deliveryNotesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(996, 33);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 574);
            this.Controls.Add(this.groupBoxFind);
            this.Controls.Add(this.groupBoxFunction);
            this.Controls.Add(this.groupBoxDisplay);
            this.Controls.Add(this.groupBoxinfor);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frm_Main";
            this.Text = "Good Import Receipt ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBoxFind.ResumeLayout(false);
            this.groupBoxFind.PerformLayout();
            this.groupBoxFunction.ResumeLayout(false);
            this.groupBoxDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceipt)).EndInit();
            this.groupBoxinfor.ResumeLayout(false);
            this.groupBoxinfor.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFind;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFind;
        private System.Windows.Forms.DateTimePicker dateTimePickerFind;
        private System.Windows.Forms.GroupBox groupBoxFunction;
        private System.Windows.Forms.Button buttonDetail;
        private System.Windows.Forms.Button buttonReload;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.GroupBox groupBoxDisplay;
        private System.Windows.Forms.DataGridView dataGridViewReceipt;
        private System.Windows.Forms.GroupBox groupBoxinfor;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxStaff;
        private System.Windows.Forms.ToolStripMenuItem deliveryNotesToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

