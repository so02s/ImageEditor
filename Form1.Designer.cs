namespace лр1
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
            this.addButton = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.effectsBox = new System.Windows.Forms.ComboBox();
            this.transparencyBar = new System.Windows.Forms.TrackBar();
            this.transparencyLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.layoutGroupPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nameLayoutLabel = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.transparencyLayoutLabel = new System.Windows.Forms.Label();
            this.effectsLayoutLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transparencyBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 12);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(194, 23);
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Файл";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(436, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(684, 755);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // effectsBox
            // 
            this.effectsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.effectsBox.FormattingEnabled = true;
            this.effectsBox.Items.AddRange(new object[] {
            "Нет",
            "Сумма",
            "Умножение",
            "Макс",
            "Мин",
            "Среднее"});
            this.effectsBox.Location = new System.Drawing.Point(12, 41);
            this.effectsBox.Name = "effectsBox";
            this.effectsBox.Size = new System.Drawing.Size(418, 24);
            this.effectsBox.TabIndex = 3;
            this.effectsBox.SelectedIndexChanged += new System.EventHandler(this.EffectsBox_SelectedIndexChanged);
            // 
            // transparencyBar
            // 
            this.transparencyBar.Location = new System.Drawing.Point(12, 112);
            this.transparencyBar.Maximum = 255;
            this.transparencyBar.Name = "transparencyBar";
            this.transparencyBar.Size = new System.Drawing.Size(418, 56);
            this.transparencyBar.TabIndex = 4;
            this.transparencyBar.ValueChanged += new System.EventHandler(this.TransparencyBar_ValueChanged);
            // 
            // transparencyLabel
            // 
            this.transparencyLabel.AutoSize = true;
            this.transparencyLabel.Location = new System.Drawing.Point(12, 79);
            this.transparencyLabel.Name = "transparencyLabel";
            this.transparencyLabel.Size = new System.Drawing.Size(105, 16);
            this.transparencyLabel.TabIndex = 5;
            this.transparencyLabel.Text = "Прозрачность:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(212, 12);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(218, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // layoutGroupPanel
            // 
            this.layoutGroupPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.layoutGroupPanel.Location = new System.Drawing.Point(12, 163);
            this.layoutGroupPanel.Name = "layoutGroupPanel";
            this.layoutGroupPanel.Size = new System.Drawing.Size(418, 604);
            this.layoutGroupPanel.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // nameLayoutLabel
            // 
            this.nameLayoutLabel.Location = new System.Drawing.Point(0, 0);
            this.nameLayoutLabel.Name = "nameLayoutLabel";
            this.nameLayoutLabel.Size = new System.Drawing.Size(100, 23);
            this.nameLayoutLabel.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(0, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 0;
            // 
            // transparencyLayoutLabel
            // 
            this.transparencyLayoutLabel.Location = new System.Drawing.Point(0, 0);
            this.transparencyLayoutLabel.Name = "transparencyLayoutLabel";
            this.transparencyLayoutLabel.Size = new System.Drawing.Size(100, 23);
            this.transparencyLayoutLabel.TabIndex = 0;
            // 
            // effectsLayoutLabel
            // 
            this.effectsLayoutLabel.Location = new System.Drawing.Point(0, 0);
            this.effectsLayoutLabel.Name = "effectsLayoutLabel";
            this.effectsLayoutLabel.Size = new System.Drawing.Size(100, 23);
            this.effectsLayoutLabel.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 779);
            this.Controls.Add(this.layoutGroupPanel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.transparencyLabel);
            this.Controls.Add(this.transparencyBar);
            this.Controls.Add(this.effectsBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.addButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transparencyBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ComboBox effectsBox;
        private System.Windows.Forms.TrackBar transparencyBar;
        private System.Windows.Forms.Label transparencyLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.FlowLayoutPanel layoutGroupPanel;
        private System.Windows.Forms.Label effectsLayoutLabel;
        private System.Windows.Forms.Label transparencyLayoutLabel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label nameLayoutLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

