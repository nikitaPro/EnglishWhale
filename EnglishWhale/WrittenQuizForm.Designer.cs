namespace EnglishWhale
{
    partial class WrittenQuizForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WrittenQuizForm));
            this.answerTextBox = new System.Windows.Forms.TextBox();
            this.questionTextBox = new System.Windows.Forms.RichTextBox();
            this.timerBar = new System.Windows.Forms.ProgressBar();
            this.timerLabel = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // answerTextBox
            // 
            this.answerTextBox.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.answerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.answerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.answerTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.answerTextBox.Location = new System.Drawing.Point(65, 189);
            this.answerTextBox.Name = "answerTextBox";
            this.answerTextBox.Size = new System.Drawing.Size(350, 26);
            this.answerTextBox.TabIndex = 0;
            this.answerTextBox.TextChanged += new System.EventHandler(this.AnswerTextBox_TextChanged);
            // 
            // questionTextBox
            // 
            this.questionTextBox.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.questionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.questionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.questionTextBox.Location = new System.Drawing.Point(65, 29);
            this.questionTextBox.Name = "questionTextBox";
            this.questionTextBox.ReadOnly = true;
            this.questionTextBox.Size = new System.Drawing.Size(350, 61);
            this.questionTextBox.TabIndex = 1;
            this.questionTextBox.Text = "";
            // 
            // timerBar
            // 
            this.timerBar.Location = new System.Drawing.Point(65, 131);
            this.timerBar.Name = "timerBar";
            this.timerBar.Size = new System.Drawing.Size(349, 25);
            this.timerBar.TabIndex = 2;
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timerLabel.ForeColor = System.Drawing.Color.White;
            this.timerLabel.Location = new System.Drawing.Point(213, 108);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(53, 20);
            this.timerLabel.TabIndex = 3;
            this.timerLabel.Text = "Timer";
            this.timerLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(217, 249);
            this.nextButton.Name = "nextButton";
            this.nextButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nextButton.Size = new System.Drawing.Size(50, 40);
            this.nextButton.TabIndex = 4;
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Paint += new System.Windows.Forms.PaintEventHandler(this.NextButton_Paint);
            // 
            // WrittenQuizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(484, 312);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.timerBar);
            this.Controls.Add(this.questionTextBox);
            this.Controls.Add(this.answerTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WrittenQuizForm";
            this.Text = "Written Quiz";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox answerTextBox;
        private System.Windows.Forms.RichTextBox questionTextBox;
        private System.Windows.Forms.ProgressBar timerBar;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Button nextButton;
    }
}