namespace EnglishWhale.View
{
    partial class WrittenQuizPanel
    {
        /// <summary> 
        /// Required constructor variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Free up all used resources.
        /// </summary>
        /// <param name="disposing">true if the managed resource should be deleted; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            components = new System.ComponentModel.Container();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;

            this.SuspendLayout();
            
            this.Controls.Add(GetAnswerTextBox());
            this.Controls.Add(GetQuestionTextBox());
            this.Controls.Add(GetTimeBar());
            this.Controls.Add(GetTimerLabel());
            this.Controls.Add(GetNextButton());
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "showWordPanel";
            this.Size = new System.Drawing.Size(585, 365);
            this.BackgroundImage = global::EnglishWhale.Properties.Resources.background_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TabIndex = 0;

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button GetNextButton()
        {
            if(this.nextButton == null)
            {
                this.nextButton = new System.Windows.Forms.Button();
                this.nextButton.Location = new System.Drawing.Point(217, 249);
                this.nextButton.Name = "nextButton";
                this.nextButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
                this.nextButton.Size = new System.Drawing.Size(50, 40);
                this.nextButton.TabIndex = 4;
                this.nextButton.UseVisualStyleBackColor = true;
                this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
                this.nextButton.Paint += new System.Windows.Forms.PaintEventHandler(this.NextButton_Paint);
            }
            return this.nextButton;
        }

        private System.Windows.Forms.Label GetTimerLabel()
        {
            if (this.timerLabel == null)
            {
                this.timerLabel = new System.Windows.Forms.Label();
                this.timerLabel.AutoSize = true;
                this.timerLabel.Font = font;
                this.timerLabel.ForeColor = System.Drawing.Color.White;
                this.timerLabel.Location = new System.Drawing.Point(213, 108);
                this.timerLabel.Name = "timerLabel";
                this.timerLabel.Size = new System.Drawing.Size(53, 20);
                this.timerLabel.TabIndex = 3;
                this.timerLabel.Text = "Timer";
                this.timerLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            }
            return this.timerLabel;
        }

        private System.Windows.Forms.ProgressBar GetTimeBar()
        {
            if (this.timerBar == null)
            {
                this.timerBar = new System.Windows.Forms.ProgressBar();
                this.timerBar.Location = new System.Drawing.Point(65, 131);
                this.timerBar.Name = "timerBar";
                this.timerBar.Size = new System.Drawing.Size(349, 25);
                this.timerBar.TabIndex = 2;
            }
            return this.timerBar;
        }

        private System.Windows.Forms.RichTextBox GetQuestionTextBox()
        {
            if (this.questionTextBox == null)
            {
                this.questionTextBox = new System.Windows.Forms.RichTextBox();
                this.questionTextBox.BackColor = System.Drawing.Color.Goldenrod;
                this.questionTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.questionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.questionTextBox.Location = new System.Drawing.Point(65, 29);
                this.questionTextBox.Name = "questionTextBox";
                this.questionTextBox.ReadOnly = true;
                this.questionTextBox.Size = new System.Drawing.Size(350, 61);
                this.questionTextBox.TabIndex = 1;
                this.questionTextBox.Text = "";
            }
            return this.questionTextBox;
        }

        private System.Windows.Forms.TextBox GetAnswerTextBox()
        {
            if (this.answerTextBox == null)
            {
                this.answerTextBox = new System.Windows.Forms.TextBox();
                this.answerTextBox.BackColor = System.Drawing.Color.Goldenrod;
                this.answerTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.answerTextBox.Font = font;
                this.answerTextBox.ForeColor = System.Drawing.SystemColors.WindowText;
                this.answerTextBox.Location = new System.Drawing.Point(65, 189);
                this.answerTextBox.Name = "answerTextBox";
                this.answerTextBox.Size = new System.Drawing.Size(350, 26);
                this.answerTextBox.TabIndex = 0;
                this.answerTextBox.TextChanged += new System.EventHandler(this.AnswerTextBox_TextChanged);
            }
            return this.answerTextBox;
        }

        private System.Drawing.Font font;
        private System.Windows.Forms.TextBox answerTextBox;
        private System.Windows.Forms.RichTextBox questionTextBox;
        private System.Windows.Forms.ProgressBar timerBar;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Button nextButton;
    }
}
