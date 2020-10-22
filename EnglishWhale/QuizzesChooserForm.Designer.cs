namespace EnglishWhale
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
            this.chooseAnswerButton = new System.Windows.Forms.Button();
            this.writeAnswerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // diretionComboBox
            // 
            this.diretionComboBox.FormattingEnabled = true;
            this.diretionComboBox.Location = new System.Drawing.Point(62, 12);
            this.diretionComboBox.Name = "diretionComboBox";
            this.diretionComboBox.Size = new System.Drawing.Size(171, 21);
            this.diretionComboBox.TabIndex = 0;
            this.diretionComboBox.Text = "Select direction";
            // 
            // chooseAnswerButton
            // 
            this.chooseAnswerButton.Location = new System.Drawing.Point(12, 53);
            this.chooseAnswerButton.Name = "chooseAnswerButton";
            this.chooseAnswerButton.Size = new System.Drawing.Size(117, 55);
            this.chooseAnswerButton.TabIndex = 1;
            this.chooseAnswerButton.Text = "Choose an answer";
            this.chooseAnswerButton.UseVisualStyleBackColor = true;
            this.chooseAnswerButton.Click += new System.EventHandler(this.chooseAnswerButton_Click);
            // 
            // writeAnswerButton
            // 
            this.writeAnswerButton.Location = new System.Drawing.Point(169, 53);
            this.writeAnswerButton.Name = "writeAnswerButton";
            this.writeAnswerButton.Size = new System.Drawing.Size(116, 55);
            this.writeAnswerButton.TabIndex = 2;
            this.writeAnswerButton.Text = "Write an answer";
            this.writeAnswerButton.UseVisualStyleBackColor = true;
            // 
            // QuizzesChooserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 450);
            this.Controls.Add(this.writeAnswerButton);
            this.Controls.Add(this.chooseAnswerButton);
            this.Controls.Add(this.diretionComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuizzesChooserForm";
            this.Text = "English Whale";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox diretionComboBox;
        private System.Windows.Forms.Button chooseAnswerButton;
        private System.Windows.Forms.Button writeAnswerButton;
    }
}