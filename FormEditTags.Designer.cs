namespace programm
{
    partial class FormEditTags
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
            this.listBoxCategories = new System.Windows.Forms.ListBox();
            this.label_category = new System.Windows.Forms.Label();
            this.listBoxFeatures = new System.Windows.Forms.ListBox();
            this.label_feature = new System.Windows.Forms.Label();
            this.panelValues = new System.Windows.Forms.Panel();
            this.label_value = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label_lemma = new System.Windows.Forms.Label();
            this.textBoxLemma = new System.Windows.Forms.TextBox();
            this.label_word = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxCategories
            // 
            this.listBoxCategories.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listBoxCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)), true);
            this.listBoxCategories.FormattingEnabled = true;
            this.listBoxCategories.IntegralHeight = false;
            this.listBoxCategories.ItemHeight = 25;
            this.listBoxCategories.Items.AddRange(new object[] {
            "Существительное",
            "Глагол",
            "Прилагательное",
            "Наречие",
            "Местоимение",
            "Предлог",
            "Союз",
            "Частица",
            "Числительное",
            "Междометие",
            "Сокращение/Аббрев-ра",
            "Другое"});
            this.listBoxCategories.Location = new System.Drawing.Point(28, 123);
            this.listBoxCategories.Name = "listBoxCategories";
            this.listBoxCategories.Size = new System.Drawing.Size(215, 288);
            this.listBoxCategories.TabIndex = 1;
            this.listBoxCategories.SelectedIndexChanged += new System.EventHandler(this.CategorySelectedIndexChanged);
            // 
            // label_category
            // 
            this.label_category.AutoSize = true;
            this.label_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_category.Location = new System.Drawing.Point(70, 85);
            this.label_category.Name = "label_category";
            this.label_category.Size = new System.Drawing.Size(106, 24);
            this.label_category.TabIndex = 2;
            this.label_category.Text = "Категории";
            // 
            // listBoxFeatures
            // 
            this.listBoxFeatures.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listBoxFeatures.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxFeatures.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)), true);
            this.listBoxFeatures.FormattingEnabled = true;
            this.listBoxFeatures.IntegralHeight = false;
            this.listBoxFeatures.ItemHeight = 25;
            this.listBoxFeatures.Location = new System.Drawing.Point(308, 123);
            this.listBoxFeatures.Name = "listBoxFeatures";
            this.listBoxFeatures.Size = new System.Drawing.Size(226, 288);
            this.listBoxFeatures.TabIndex = 3;
            this.listBoxFeatures.SelectedIndexChanged += new System.EventHandler(this.FeatureSelectedIndexChanged);
            // 
            // label_feature
            // 
            this.label_feature.AutoSize = true;
            this.label_feature.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_feature.Location = new System.Drawing.Point(369, 85);
            this.label_feature.Name = "label_feature";
            this.label_feature.Size = new System.Drawing.Size(96, 24);
            this.label_feature.TabIndex = 4;
            this.label_feature.Text = "Признаки";
            // 
            // panelValues
            // 
            this.panelValues.AutoScroll = true;
            this.panelValues.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelValues.Location = new System.Drawing.Point(598, 123);
            this.panelValues.Name = "panelValues";
            this.panelValues.Size = new System.Drawing.Size(256, 288);
            this.panelValues.TabIndex = 5;
            // 
            // label_value
            // 
            this.label_value.AutoSize = true;
            this.label_value.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_value.Location = new System.Drawing.Point(619, 85);
            this.label_value.Name = "label_value";
            this.label_value.Size = new System.Drawing.Size(197, 24);
            this.label_value.TabIndex = 6;
            this.label_value.Text = "Значения признаков";
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonCancel.Location = new System.Drawing.Point(772, 485);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(82, 33);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonOK.Location = new System.Drawing.Point(675, 485);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(82, 33);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label_lemma
            // 
            this.label_lemma.AutoSize = true;
            this.label_lemma.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_lemma.Location = new System.Drawing.Point(503, 23);
            this.label_lemma.Name = "label_lemma";
            this.label_lemma.Size = new System.Drawing.Size(69, 24);
            this.label_lemma.TabIndex = 9;
            this.label_lemma.Text = "Лемма";
            // 
            // textBoxLemma
            // 
            this.textBoxLemma.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLemma.Location = new System.Drawing.Point(586, 23);
            this.textBoxLemma.Name = "textBoxLemma";
            this.textBoxLemma.Size = new System.Drawing.Size(246, 27);
            this.textBoxLemma.TabIndex = 10;
            // 
            // label_word
            // 
            this.label_word.AutoSize = true;
            this.label_word.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_word.Location = new System.Drawing.Point(50, 23);
            this.label_word.Name = "label_word";
            this.label_word.Size = new System.Drawing.Size(71, 24);
            this.label_word.TabIndex = 11;
            this.label_word.Text = "Слово:";
            this.label_word.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormEditTags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 530);
            this.Controls.Add(this.label_word);
            this.Controls.Add(this.textBoxLemma);
            this.Controls.Add(this.label_lemma);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label_value);
            this.Controls.Add(this.panelValues);
            this.Controls.Add(this.label_feature);
            this.Controls.Add(this.listBoxFeatures);
            this.Controls.Add(this.label_category);
            this.Controls.Add(this.listBoxCategories);
            this.Name = "FormEditTags";
            this.Text = "Редактирование слова";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxCategories;
        private System.Windows.Forms.Label label_category;
        private System.Windows.Forms.ListBox listBoxFeatures;
        private System.Windows.Forms.Label label_feature;
        private System.Windows.Forms.Panel panelValues;
        private System.Windows.Forms.Label label_value;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label_lemma;
        private System.Windows.Forms.TextBox textBoxLemma;
        private System.Windows.Forms.Label label_word;
    }
}