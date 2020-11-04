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
            this.button1 = new System.Windows.Forms.Button();
            this.learningButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // diretionComboBox
            // 
            this.diretionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.diretionComboBox.Location = new System.Drawing.Point(62, 12);
            this.diretionComboBox.Name = "diretionComboBox";
            this.diretionComboBox.Size = new System.Drawing.Size(171, 21);
            this.diretionComboBox.TabIndex = 0;
            // 
            // chooseAnswerButton
            // 
            this.chooseAnswerButton.Location = new System.Drawing.Point(12, 113);
            this.chooseAnswerButton.Name = "chooseAnswerButton";
            this.chooseAnswerButton.Size = new System.Drawing.Size(117, 55);
            this.chooseAnswerButton.TabIndex = 1;
            this.chooseAnswerButton.Text = "Choose an answer";
            this.chooseAnswerButton.UseVisualStyleBackColor = true;
            this.chooseAnswerButton.Click += new System.EventHandler(this.chooseAnswerButton_Click);
            // 
            // writeAnswerButton
            // 
            this.writeAnswerButton.Location = new System.Drawing.Point(168, 113);
            this.writeAnswerButton.Name = "writeAnswerButton";
            this.writeAnswerButton.Size = new System.Drawing.Size(116, 55);
            this.writeAnswerButton.TabIndex = 2;
            this.writeAnswerButton.Text = "Write an answer";
            this.writeAnswerButton.UseVisualStyleBackColor = true;
            this.writeAnswerButton.Click += new System.EventHandler(this.writeAnswerButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(91, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 55);
            this.button1.TabIndex = 3;
            this.button1.Text = "Choose an answer (Time)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.chooseAnswerWithTimerButton_Click);
            // 
            // learningButton
            // 
            this.learningButton.Location = new System.Drawing.Point(93, 53);
            this.learningButton.Name = "learningButton";
            this.learningButton.Size = new System.Drawing.Size(115, 54);
            this.learningButton.TabIndex = 4;
            this.learningButton.Text = "Learning";
            this.learningButton.UseVisualStyleBackColor = true;
            this.learningButton.Click += new System.EventHandler(this.learningButton_Click);
            // 
            // QuizzesChooserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 255);
            this.Controls.Add(this.learningButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.writeAnswerButton);
            this.Controls.Add(this.chooseAnswerButton);
            this.Controls.Add(this.diretionComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "QuizzesChooserForm";
            this.Text = "English Whale";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox diretionComboBox;
        private System.Windows.Forms.Button chooseAnswerButton;
        private System.Windows.Forms.Button writeAnswerButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button learningButton;
    }
}