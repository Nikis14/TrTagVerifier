namespace programm
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.insert_original = new System.Windows.Forms.Button();
            this.correct_tags = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openFileDialog_file_mode = new System.Windows.Forms.OpenFileDialog();
            this.openFile_original = new System.Windows.Forms.OpenFileDialog();
            this.folder_original = new System.Windows.Forms.FolderBrowserDialog();
            this.folder_TrTag = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // insert_original
            // 
            this.insert_original.Location = new System.Drawing.Point(31, 64);
            this.insert_original.Name = "insert_original";
            this.insert_original.Size = new System.Drawing.Size(208, 116);
            this.insert_original.TabIndex = 0;
            this.insert_original.Text = "Объединить файлы";
            this.insert_original.UseVisualStyleBackColor = true;
            this.insert_original.Click += new System.EventHandler(this.insert_original_click);
            // 
            // correct_tags
            // 
            this.correct_tags.Location = new System.Drawing.Point(31, 318);
            this.correct_tags.Name = "correct_tags";
            this.correct_tags.Size = new System.Drawing.Size(208, 116);
            this.correct_tags.TabIndex = 1;
            this.correct_tags.Text = "Исправить леммы и грамматические теги (выберите файл)";
            this.correct_tags.UseVisualStyleBackColor = true;
            this.correct_tags.Click += new System.EventHandler(this.correct_tags_click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(269, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(709, 471);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // openFileDialog_file_mode
            // 
            this.openFileDialog_file_mode.Filter = "(*.txt)|*.txt";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(999, 496);
            this.Controls.Add(this.correct_tags);
            this.Controls.Add(this.insert_original);
            this.Controls.Add(this.pictureBox1);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Объединение и редактирование файлов";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button insert_original;
        private System.Windows.Forms.Button correct_tags;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog_file_mode;
        private System.Windows.Forms.OpenFileDialog openFile_original;
        private System.Windows.Forms.FolderBrowserDialog folder_original;
        private System.Windows.Forms.FolderBrowserDialog folder_TrTag;
    }
}

