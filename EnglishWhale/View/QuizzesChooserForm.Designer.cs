namespace EnglishWhale.View
{
    partial class QuizzesChooserForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuizzesChooserForm));
            this.diretionComboBox = new System.Windows.Forms.ComboBox();
            this.learningButton = new EnglishWhale.View.CustomButton();
            this.chooseAnswerTimeButton = new EnglishWhale.View.CustomButton();
            this.writeAnswerButton = new EnglishWhale.View.CustomButton();
            this.chooseAnswerButton = new EnglishWhale.View.CustomButton();
            this.SuspendLayout();
            // 
            // diretionComboBox
            // 
            this.diretionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.diretionComboBox.Location = new System.Drawing.Point(61, 20);
            this.diretionComboBox.Name = "diretionComboBox";
            this.diretionComboBox.Size = new System.Drawing.Size(171, 21);
            this.diretionComboBox.TabIndex = 0;
            // 
            // learningButton
            // 
            this.learningButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.learningButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.learningButton.ForeColor = System.Drawing.Color.White;
            this.learningButton.Image = ((System.Drawing.Image)(resources.GetObject("learningButton.Image")));
            this.learningButton.Location = new System.Drawing.Point(20, 80);
            this.learningButton.Margin = new System.Windows.Forms.Padding(0);
            this.learningButton.Name = "learningButton";
            this.learningButton.Size = new System.Drawing.Size(115, 55);
            this.learningButton.TabIndex = 4;
            this.learningButton.Text = "Learning";
            this.learningButton.UseVisualStyleBackColor = true;
            this.learningButton.Click += new System.EventHandler(this.learningButton_Click);
            // 
            // chooseAnswerTimeButton
            // 
            this.chooseAnswerTimeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseAnswerTimeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chooseAnswerTimeButton.ForeColor = System.Drawing.Color.White;
            this.chooseAnswerTimeButton.Image = ((System.Drawing.Image)(resources.GetObject("chooseAnswerTimeButton.Image")));
            this.chooseAnswerTimeButton.Location = new System.Drawing.Point(170, 170);
            this.chooseAnswerTimeButton.Name = "chooseAnswerTimeButton";
            this.chooseAnswerTimeButton.Size = new System.Drawing.Size(115, 55);
            this.chooseAnswerTimeButton.TabIndex = 3;
            this.chooseAnswerTimeButton.Text = "Choose an answer (Time)";
            this.chooseAnswerTimeButton.UseVisualStyleBackColor = true;
            this.chooseAnswerTimeButton.Click += new System.EventHandler(this.chooseAnswerWithTimerButton_Click);
            // 
            // writeAnswerButton
            // 
            this.writeAnswerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.writeAnswerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.writeAnswerButton.ForeColor = System.Drawing.Color.White;
            this.writeAnswerButton.Image = ((System.Drawing.Image)(resources.GetObject("writeAnswerButton.Image")));
            this.writeAnswerButton.Location = new System.Drawing.Point(170, 80);
            this.writeAnswerButton.Name = "writeAnswerButton";
            this.writeAnswerButton.Size = new System.Drawing.Size(115, 55);
            this.writeAnswerButton.TabIndex = 2;
            this.writeAnswerButton.Text = "Write an answer";
            this.writeAnswerButton.UseVisualStyleBackColor = true;
            this.writeAnswerButton.Click += new System.EventHandler(this.writeAnswerButton_Click);
            // 
            // chooseAnswerButton
            // 
            this.chooseAnswerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseAnswerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chooseAnswerButton.ForeColor = System.Drawing.Color.White;
            this.chooseAnswerButton.Image = ((System.Drawing.Image)(resources.GetObject("chooseAnswerButton.Image")));
            this.chooseAnswerButton.Location = new System.Drawing.Point(20, 170);
            this.chooseAnswerButton.Name = "chooseAnswerButton";
            this.chooseAnswerButton.Size = new System.Drawing.Size(115, 55);
            this.chooseAnswerButton.TabIndex = 1;
            this.chooseAnswerButton.Text = "Choose an answer";
            this.chooseAnswerButton.UseVisualStyleBackColor = true;
            this.chooseAnswerButton.Click += new System.EventHandler(this.chooseAnswerButton_Click);
            // 
            // QuizzesChooserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EnglishWhale.Properties.Resources.background_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(304, 262);
            this.Controls.Add(this.learningButton);
            this.Controls.Add(this.chooseAnswerTimeButton);
            this.Controls.Add(this.writeAnswerButton);
            this.Controls.Add(this.chooseAnswerButton);
            this.Controls.Add(this.diretionComboBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuizzesChooserForm";
            this.Text = "English Whale";
            this.MaximizeBox = false;
            this.CenterToScreen();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox diretionComboBox;
        private CustomButton chooseAnswerButton;
        private CustomButton writeAnswerButton;
        private CustomButton chooseAnswerTimeButton;
        private CustomButton learningButton;
    }
}