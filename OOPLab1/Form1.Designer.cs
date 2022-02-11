namespace OOPLab1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.formSkin = new OOPLab1.FormSkin();
            this.audioCombobox = new System.Windows.Forms.ComboBox();
            this.timeSlider = new System.Windows.Forms.TrackBar();
            this.flatButton1 = new OOPLab1.FlatButton();
            this.addAlarmBtn = new OOPLab1.FlatButton();
            this.alarmOLV = new BrightIdeasSoftware.ObjectListView();
            this.stateColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.TimeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.SoundColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.alarmTimePicker = new System.Windows.Forms.DateTimePicker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dismissBtn = new OOPLab1.FlatButton();
            this.activateAlarmBtn = new OOPLab1.FlatButton();
            this.deleteAlarmBtn = new OOPLab1.FlatButton();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.clockBtn = new OOPLab1.FlatButton();
            this.closeBtn = new OOPLab1.FlatClose();
            this.miniBtn = new OOPLab1.FlatMini();
            this.formSkin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alarmOLV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // formSkin
            // 
            this.formSkin.BackColor = System.Drawing.Color.Gray;
            this.formSkin.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(73)))), ((int)(((byte)(76)))));
            this.formSkin.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(58)))), ((int)(((byte)(60)))));
            this.formSkin.Controls.Add(this.audioCombobox);
            this.formSkin.Controls.Add(this.timeSlider);
            this.formSkin.Controls.Add(this.flatButton1);
            this.formSkin.Controls.Add(this.addAlarmBtn);
            this.formSkin.Controls.Add(this.alarmOLV);
            this.formSkin.Controls.Add(this.alarmTimePicker);
            this.formSkin.Controls.Add(this.pictureBox1);
            this.formSkin.Controls.Add(this.dismissBtn);
            this.formSkin.Controls.Add(this.activateAlarmBtn);
            this.formSkin.Controls.Add(this.deleteAlarmBtn);
            this.formSkin.Controls.Add(this.timePicker);
            this.formSkin.Controls.Add(this.clockBtn);
            this.formSkin.Controls.Add(this.closeBtn);
            this.formSkin.Controls.Add(this.miniBtn);
            this.formSkin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formSkin.FlatColor = System.Drawing.Color.Transparent;
            this.formSkin.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formSkin.HeaderColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.formSkin.HeaderMaximize = false;
            this.formSkin.Location = new System.Drawing.Point(0, 0);
            this.formSkin.Name = "formSkin";
            this.formSkin.Size = new System.Drawing.Size(415, 460);
            this.formSkin.TabIndex = 0;
            this.formSkin.Text = "GUI Clock: 00:00";
            // 
            // audioCombobox
            // 
            this.audioCombobox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(73)))));
            this.audioCombobox.DisplayMember = "1";
            this.audioCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioCombobox.FormattingEnabled = true;
            this.audioCombobox.Items.AddRange(new object[] {
            "Silent",
            "Alien",
            "Uboat"});
            this.audioCombobox.Location = new System.Drawing.Point(10, 416);
            this.audioCombobox.Name = "audioCombobox";
            this.audioCombobox.Size = new System.Drawing.Size(242, 34);
            this.audioCombobox.TabIndex = 28;
            this.audioCombobox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.audioCombobox_MouseMove);
            // 
            // timeSlider
            // 
            this.timeSlider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(73)))), ((int)(((byte)(76)))));
            this.timeSlider.Location = new System.Drawing.Point(10, 325);
            this.timeSlider.Maximum = 1439;
            this.timeSlider.Name = "timeSlider";
            this.timeSlider.Size = new System.Drawing.Size(244, 45);
            this.timeSlider.TabIndex = 27;
            this.timeSlider.TickFrequency = 60;
            this.timeSlider.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.timeSlider.Value = 720;
            this.timeSlider.Scroll += new System.EventHandler(this.timeSlider_Scroll);
            this.timeSlider.MouseMove += new System.Windows.Forms.MouseEventHandler(this.timeSlider_MouseMove);
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.Color.Transparent;
            this.flatButton1.BaseColor = System.Drawing.Color.YellowGreen;
            this.flatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.flatButton1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flatButton1.Location = new System.Drawing.Point(341, 24);
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.Rounded = true;
            this.flatButton1.Size = new System.Drawing.Size(55, 57);
            this.flatButton1.TabIndex = 12;
            this.flatButton1.Text = "debug add";
            this.flatButton1.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.flatButton1.Click += new System.EventHandler(this.flatButton1_Click);
            // 
            // addAlarmBtn
            // 
            this.addAlarmBtn.BackColor = System.Drawing.Color.Transparent;
            this.addAlarmBtn.BaseColor = System.Drawing.Color.ForestGreen;
            this.addAlarmBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addAlarmBtn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAlarmBtn.Location = new System.Drawing.Point(134, 376);
            this.addAlarmBtn.Name = "addAlarmBtn";
            this.addAlarmBtn.Rounded = true;
            this.addAlarmBtn.Size = new System.Drawing.Size(118, 37);
            this.addAlarmBtn.TabIndex = 22;
            this.addAlarmBtn.Text = "Add";
            this.addAlarmBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.addAlarmBtn.Click += new System.EventHandler(this.addAlarmBtn_Click);
            // 
            // alarmOLV
            // 
            this.alarmOLV.AllColumns.Add(this.stateColumn);
            this.alarmOLV.AllColumns.Add(this.TimeColumn);
            this.alarmOLV.AllColumns.Add(this.SoundColumn);
            this.alarmOLV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(144)))), ((int)(((byte)(150)))));
            this.alarmOLV.CellEditUseWholeCell = false;
            this.alarmOLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.stateColumn,
            this.TimeColumn,
            this.SoundColumn});
            this.alarmOLV.Cursor = System.Windows.Forms.Cursors.Default;
            this.alarmOLV.FullRowSelect = true;
            this.alarmOLV.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.alarmOLV.HideSelection = false;
            this.alarmOLV.Location = new System.Drawing.Point(3, 54);
            this.alarmOLV.MultiSelect = false;
            this.alarmOLV.Name = "alarmOLV";
            this.alarmOLV.ShowGroups = false;
            this.alarmOLV.Size = new System.Drawing.Size(407, 256);
            this.alarmOLV.TabIndex = 18;
            this.alarmOLV.UseCompatibleStateImageBehavior = false;
            this.alarmOLV.View = System.Windows.Forms.View.Details;
            this.alarmOLV.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.objectListView1_FormatRow);
            this.alarmOLV.SelectedIndexChanged += new System.EventHandler(this.alarmOLV_SelectedIndexChanged);
            // 
            // stateColumn
            // 
            this.stateColumn.AspectName = "State";
            this.stateColumn.Text = "State";
            this.stateColumn.Width = 114;
            // 
            // TimeColumn
            // 
            this.TimeColumn.AspectName = "Time";
            this.TimeColumn.Text = "Time";
            this.TimeColumn.Width = 104;
            // 
            // SoundColumn
            // 
            this.SoundColumn.AspectName = "Sound";
            this.SoundColumn.FillsFreeSpace = true;
            this.SoundColumn.Text = "Sound";
            this.SoundColumn.Width = 120;
            // 
            // alarmTimePicker
            // 
            this.alarmTimePicker.CustomFormat = "HH:mm";
            this.alarmTimePicker.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alarmTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.alarmTimePicker.Location = new System.Drawing.Point(10, 375);
            this.alarmTimePicker.Name = "alarmTimePicker";
            this.alarmTimePicker.ShowUpDown = true;
            this.alarmTimePicker.Size = new System.Drawing.Size(118, 37);
            this.alarmTimePicker.TabIndex = 21;
            this.alarmTimePicker.Value = new System.DateTime(2021, 11, 9, 12, 0, 0, 0);
            this.alarmTimePicker.ValueChanged += new System.EventHandler(this.alarmTimePicker_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.pictureBox1.Location = new System.Drawing.Point(3, 316);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(258, 141);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // dismissBtn
            // 
            this.dismissBtn.BackColor = System.Drawing.Color.Transparent;
            this.dismissBtn.BaseColor = System.Drawing.Color.Red;
            this.dismissBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dismissBtn.Font = new System.Drawing.Font("Comic Sans MS", 11F);
            this.dismissBtn.Location = new System.Drawing.Point(291, 410);
            this.dismissBtn.Name = "dismissBtn";
            this.dismissBtn.Rounded = true;
            this.dismissBtn.Size = new System.Drawing.Size(119, 41);
            this.dismissBtn.TabIndex = 19;
            this.dismissBtn.Text = "Dismiss Alarms";
            this.dismissBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.dismissBtn.Visible = false;
            this.dismissBtn.Click += new System.EventHandler(this.dismissBtn_Click);
            // 
            // activateAlarmBtn
            // 
            this.activateAlarmBtn.BackColor = System.Drawing.Color.Transparent;
            this.activateAlarmBtn.BaseColor = System.Drawing.Color.ForestGreen;
            this.activateAlarmBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.activateAlarmBtn.Enabled = false;
            this.activateAlarmBtn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activateAlarmBtn.Location = new System.Drawing.Point(291, 318);
            this.activateAlarmBtn.Name = "activateAlarmBtn";
            this.activateAlarmBtn.Rounded = true;
            this.activateAlarmBtn.Size = new System.Drawing.Size(119, 41);
            this.activateAlarmBtn.TabIndex = 17;
            this.activateAlarmBtn.Text = "Activate";
            this.activateAlarmBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.activateAlarmBtn.Click += new System.EventHandler(this.activateAlarmBtn_Click);
            // 
            // deleteAlarmBtn
            // 
            this.deleteAlarmBtn.BackColor = System.Drawing.Color.Transparent;
            this.deleteAlarmBtn.BaseColor = System.Drawing.Color.Red;
            this.deleteAlarmBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteAlarmBtn.Enabled = false;
            this.deleteAlarmBtn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteAlarmBtn.Location = new System.Drawing.Point(291, 365);
            this.deleteAlarmBtn.Name = "deleteAlarmBtn";
            this.deleteAlarmBtn.Rounded = true;
            this.deleteAlarmBtn.Size = new System.Drawing.Size(119, 41);
            this.deleteAlarmBtn.TabIndex = 14;
            this.deleteAlarmBtn.Text = "Delete";
            this.deleteAlarmBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.deleteAlarmBtn.Click += new System.EventHandler(this.deleteAlarmBtn_Click);
            // 
            // timePicker
            // 
            this.timePicker.CustomFormat = "HH:mm";
            this.timePicker.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePicker.Location = new System.Drawing.Point(189, 12);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(72, 30);
            this.timePicker.TabIndex = 10;
            this.timePicker.Value = new System.DateTime(2021, 11, 4, 0, 0, 0, 0);
            // 
            // clockBtn
            // 
            this.clockBtn.BackColor = System.Drawing.Color.Transparent;
            this.clockBtn.BaseColor = System.Drawing.Color.ForestGreen;
            this.clockBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clockBtn.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clockBtn.Location = new System.Drawing.Point(267, 12);
            this.clockBtn.Name = "clockBtn";
            this.clockBtn.Rounded = true;
            this.clockBtn.Size = new System.Drawing.Size(80, 30);
            this.clockBtn.TabIndex = 7;
            this.clockBtn.Text = "Start";
            this.clockBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.clockBtn.Click += new System.EventHandler(this.clockBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Black;
            this.closeBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.closeBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeBtn.Font = new System.Drawing.Font("Marlett", 10F);
            this.closeBtn.Location = new System.Drawing.Point(397, 0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(18, 18);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "flatClose1";
            this.closeBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // miniBtn
            // 
            this.miniBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.miniBtn.BackColor = System.Drawing.Color.White;
            this.miniBtn.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(47)))), ((int)(((byte)(49)))));
            this.miniBtn.Font = new System.Drawing.Font("Marlett", 12F);
            this.miniBtn.Location = new System.Drawing.Point(378, 0);
            this.miniBtn.Name = "miniBtn";
            this.miniBtn.Size = new System.Drawing.Size(18, 18);
            this.miniBtn.TabIndex = 0;
            this.miniBtn.Text = "flatMini1";
            this.miniBtn.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.miniBtn.Click += new System.EventHandler(this.miniBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 460);
            this.Controls.Add(this.formSkin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.formSkin.ResumeLayout(false);
            this.formSkin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.timeSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alarmOLV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FormSkin formSkin;
        private FlatClose closeBtn;
        private FlatMini miniBtn;
        private FlatButton clockBtn;
        private System.Windows.Forms.DateTimePicker timePicker;
        private FlatButton flatButton1;
        private FlatButton deleteAlarmBtn;
        private FlatButton activateAlarmBtn;
        private BrightIdeasSoftware.ObjectListView alarmOLV;
        private BrightIdeasSoftware.OLVColumn stateColumn;
        private BrightIdeasSoftware.OLVColumn TimeColumn;
        private FlatButton dismissBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DateTimePicker alarmTimePicker;
        private FlatButton addAlarmBtn;
        private BrightIdeasSoftware.OLVColumn SoundColumn;
        private System.Windows.Forms.TrackBar timeSlider;
        private System.Windows.Forms.ComboBox audioCombobox;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

