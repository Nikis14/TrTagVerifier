namespace programm
{
    partial class FormEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEdit));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.CountElemsLabel = new System.Windows.Forms.Label();
            this.comboBoxCount = new System.Windows.Forms.ComboBox();
            this.PrevLabel = new System.Windows.Forms.Label();
            this.NextLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxTo = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FileInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PrevLabel2 = new System.Windows.Forms.Label();
            this.comboBoxCount2 = new System.Windows.Forms.ComboBox();
            this.NextLabel2 = new System.Windows.Forms.Label();
            this.comboBoxTo2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CountElemsLabel2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "(*.txt)|*.txt";
            // 
            // CountElemsLabel
            // 
            this.CountElemsLabel.AutoSize = true;
            this.CountElemsLabel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountElemsLabel.Location = new System.Drawing.Point(40, 36);
            this.CountElemsLabel.Name = "CountElemsLabel";
            this.CountElemsLabel.Size = new System.Drawing.Size(268, 19);
            this.CountElemsLabel.TabIndex = 1;
            this.CountElemsLabel.Text = "Количество показываемых строк:";
            // 
            // comboBoxCount
            // 
            this.comboBoxCount.FormattingEnabled = true;
            this.comboBoxCount.Items.AddRange(new object[] {
            "1",
            "5",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.comboBoxCount.Location = new System.Drawing.Point(347, 35);
            this.comboBoxCount.Name = "comboBoxCount";
            this.comboBoxCount.Size = new System.Drawing.Size(47, 24);
            this.comboBoxCount.TabIndex = 2;
            this.comboBoxCount.Text = "20";
            this.comboBoxCount.SelectedIndexChanged += new System.EventHandler(this.comboBoxCount_SelectedIndexChanged);
            // 
            // PrevLabel
            // 
            this.PrevLabel.AutoSize = true;
            this.PrevLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PrevLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.PrevLabel.Location = new System.Drawing.Point(537, 38);
            this.PrevLabel.Name = "PrevLabel";
            this.PrevLabel.Size = new System.Drawing.Size(49, 17);
            this.PrevLabel.TabIndex = 3;
            this.PrevLabel.Text = "Назад";
            this.PrevLabel.Click += new System.EventHandler(this.PrevLabel_Click);
            // 
            // NextLabel
            // 
            this.NextLabel.AutoSize = true;
            this.NextLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.NextLabel.Location = new System.Drawing.Point(817, 38);
            this.NextLabel.Name = "NextLabel";
            this.NextLabel.Size = new System.Drawing.Size(57, 17);
            this.NextLabel.TabIndex = 6;
            this.NextLabel.Text = "Вперед";
            this.NextLabel.Click += new System.EventHandler(this.NextLabel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label4.Location = new System.Drawing.Point(625, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Перейти";
            // 
            // comboBoxTo
            // 
            this.comboBoxTo.FormattingEnabled = true;
            this.comboBoxTo.Location = new System.Drawing.Point(696, 35);
            this.comboBoxTo.Name = "comboBoxTo";
            this.comboBoxTo.Size = new System.Drawing.Size(84, 24);
            this.comboBoxTo.TabIndex = 8;
            this.comboBoxTo.SelectedIndexChanged += new System.EventHandler(this.comboBoxTo_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.FileInfoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1456, 28);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator,
            this.SaveToolStripMenuItem,
            this.SaveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.FileToolStripMenuItem.Text = "&Файл";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(181, 6);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("SaveToolStripMenuItem.Image")));
            this.SaveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.ShowShortcutKeys = false;
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.SaveToolStripMenuItem.Text = "&Сохранить";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // SaveAsToolStripMenuItem
            // 
            this.SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            this.SaveAsToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.SaveAsToolStripMenuItem.Text = "Сохранить &как";
            this.SaveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.ExitToolStripMenuItem.Text = "Вы&ход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // FileInfoToolStripMenuItem
            // 
            this.FileInfoToolStripMenuItem.Name = "FileInfoToolStripMenuItem";
            this.FileInfoToolStripMenuItem.Size = new System.Drawing.Size(139, 24);
            this.FileInfoToolStripMenuItem.Text = "Справка о файле";
            this.FileInfoToolStripMenuItem.Click += new System.EventHandler(this.FileInfoToolStripMenuItem_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.AutoScroll = true;
            this.MainPanel.Controls.Add(this.panel2);
            this.MainPanel.Controls.Add(this.panel1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 28);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1456, 559);
            this.MainPanel.TabIndex = 10;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.PrevLabel);
            this.panel1.Controls.Add(this.comboBoxCount);
            this.panel1.Controls.Add(this.NextLabel);
            this.panel1.Controls.Add(this.comboBoxTo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.CountElemsLabel);
            this.panel1.Location = new System.Drawing.Point(210, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 66);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.PrevLabel2);
            this.panel2.Controls.Add(this.comboBoxCount2);
            this.panel2.Controls.Add(this.NextLabel2);
            this.panel2.Controls.Add(this.comboBoxTo2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.CountElemsLabel2);
            this.panel2.Location = new System.Drawing.Point(210, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(964, 83);
            this.panel2.TabIndex = 10;
            this.panel2.Visible = false;
            // 
            // PrevLabel2
            // 
            this.PrevLabel2.AutoSize = true;
            this.PrevLabel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PrevLabel2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.PrevLabel2.Location = new System.Drawing.Point(537, 38);
            this.PrevLabel2.Name = "PrevLabel2";
            this.PrevLabel2.Size = new System.Drawing.Size(49, 17);
            this.PrevLabel2.TabIndex = 3;
            this.PrevLabel2.Text = "Назад";
            this.PrevLabel2.Click += new System.EventHandler(this.PrevLabel_Click);
            // 
            // comboBoxCount2
            // 
            this.comboBoxCount2.FormattingEnabled = true;
            this.comboBoxCount2.Items.AddRange(new object[] {
            "1",
            "5",
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.comboBoxCount2.Location = new System.Drawing.Point(347, 35);
            this.comboBoxCount2.Name = "comboBoxCount2";
            this.comboBoxCount2.Size = new System.Drawing.Size(47, 24);
            this.comboBoxCount2.TabIndex = 2;
            this.comboBoxCount2.Text = "20";
            this.comboBoxCount2.SelectedIndexChanged += new System.EventHandler(this.comboBoxCount_SelectedIndexChanged);
            // 
            // NextLabel2
            // 
            this.NextLabel2.AutoSize = true;
            this.NextLabel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NextLabel2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.NextLabel2.Location = new System.Drawing.Point(817, 38);
            this.NextLabel2.Name = "NextLabel2";
            this.NextLabel2.Size = new System.Drawing.Size(57, 17);
            this.NextLabel2.TabIndex = 6;
            this.NextLabel2.Text = "Вперед";
            this.NextLabel2.Click += new System.EventHandler(this.NextLabel_Click);
            // 
            // comboBoxTo2
            // 
            this.comboBoxTo2.FormattingEnabled = true;
            this.comboBoxTo2.Location = new System.Drawing.Point(696, 35);
            this.comboBoxTo2.Name = "comboBoxTo2";
            this.comboBoxTo2.Size = new System.Drawing.Size(84, 24);
            this.comboBoxTo2.TabIndex = 8;
            this.comboBoxTo2.SelectedIndexChanged += new System.EventHandler(this.comboBoxTo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(625, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Перейти";
            // 
            // CountElemsLabel2
            // 
            this.CountElemsLabel2.AutoSize = true;
            this.CountElemsLabel2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CountElemsLabel2.Location = new System.Drawing.Point(40, 36);
            this.CountElemsLabel2.Name = "CountElemsLabel2";
            this.CountElemsLabel2.Size = new System.Drawing.Size(268, 19);
            this.CountElemsLabel2.TabIndex = 1;
            this.CountElemsLabel2.Text = "Количество показываемых строк:";
            // 
            // FormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1456, 587);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEdit";
            this.Text = "Редактирование файла TreeTagger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEdit_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label CountElemsLabel;
        private System.Windows.Forms.ComboBox comboBoxCount;
        private System.Windows.Forms.Label PrevLabel;
        private System.Windows.Forms.Label NextLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxTo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FileInfoToolStripMenuItem;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label PrevLabel2;
        private System.Windows.Forms.ComboBox comboBoxCount2;
        private System.Windows.Forms.Label NextLabel2;
        private System.Windows.Forms.ComboBox comboBoxTo2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label CountElemsLabel2;
    }
}