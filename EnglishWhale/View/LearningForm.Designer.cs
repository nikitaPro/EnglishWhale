namespace EnglishWhale.View
{
    partial class LearningForm
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

            this.SuspendLayout();
            // 
            // LearningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "LearningForm";
            this.Text = "Learning";
            this.makeSentencePanel.ResumeLayout(false);
            this.makeSentencePanel.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel GetMakeSentencePanel()
        {
            if (this.makeSentencePanel == null)
            {
                this.makeSentencePanel = new System.Windows.Forms.Panel();
                this.makeSentencePanel.SuspendLayout();
                this.makeSentencePanel.Controls.Add(GetNextButton());
                this.makeSentencePanel.Controls.Add(GetSecondPhraseLabel());
                this.makeSentencePanel.Controls.Add(GetFirstPhraseLabel());
                this.makeSentencePanel.Controls.Add(GetTitleLable());
                this.makeSentencePanel.Location = new System.Drawing.Point(0, 0);
                this.makeSentencePanel.Name = "makeSentencePanel";
                this.makeSentencePanel.Size = new System.Drawing.Size(585, 365);
                this.makeSentencePanel.TabIndex = 0;
            }
            return this.makeSentencePanel;
        }

        private System.Windows.Forms.Label GetTitleLable()
        {
            if (this.titleLabel == null)
            {
                this.titleLabel = new System.Windows.Forms.Label();
                this.titleLabel.AutoSize = true;
                this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.titleLabel.Location = new System.Drawing.Point(99, 47);
                this.titleLabel.Name = "label1";
                this.titleLabel.Size = new System.Drawing.Size(400, 31);
                this.titleLabel.TabIndex = 1;
                this.titleLabel.Text = "Try use both in one sentence.";
            }
            return this.titleLabel;
        }

        private System.Windows.Forms.Label GetFirstPhraseLabel()
        {
            if (this.firstPhraseLabel == null)
            {
                this.firstPhraseLabel = new System.Windows.Forms.Label();
                this.firstPhraseLabel.AutoSize = true;
                this.firstPhraseLabel.Location = new System.Drawing.Point(43, 119);
                this.firstPhraseLabel.Name = "firstPhraseLabel";
                this.firstPhraseLabel.Size = new System.Drawing.Size(35, 13);
                this.firstPhraseLabel.TabIndex = 2;
                this.firstPhraseLabel.Text = "label2";
            }
            return this.firstPhraseLabel;
        }

        private System.Windows.Forms.Label GetSecondPhraseLabel()
        {
            if(this.secondPhraseLabel == null)
            {
                this.secondPhraseLabel = new System.Windows.Forms.Label();
                this.secondPhraseLabel.AutoSize = true;
                this.secondPhraseLabel.Location = new System.Drawing.Point(43, 176);
                this.secondPhraseLabel.Name = "secondPhraseLabel";
                this.secondPhraseLabel.Size = new System.Drawing.Size(35, 13);
                this.secondPhraseLabel.TabIndex = 3;
                this.secondPhraseLabel.Text = "label3";
            }
            return this.secondPhraseLabel;
        }

        private System.Windows.Forms.Panel GetShowWordPanel()
        {
            if (this.showWordPanel == null)
            {
                this.showWordPanel = new System.Windows.Forms.Panel();
                this.showWordPanel.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();

                this.showWordPanel.Controls.Add(GetVoicePicture());
                this.showWordPanel.Controls.Add(GetAnswerLabel());
                this.showWordPanel.Controls.Add(GetQuestioLabel());
                this.showWordPanel.Controls.Add(GetNextButton());
                this.showWordPanel.Location = new System.Drawing.Point(0, 0);
                this.showWordPanel.Name = "showWordPanel";
                this.showWordPanel.Size = new System.Drawing.Size(585, 365);
                this.showWordPanel.TabIndex = 0;

                this.showWordPanel.ResumeLayout(false);
                this.showWordPanel.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)GetShowWordPanel()).EndInit();
            }
            return this.showWordPanel;
        }

        private System.Windows.Forms.Button GetNextButton()
        {
            if(this.nextButton == null)
            {
                this.nextButton = new System.Windows.Forms.Button();
                this.nextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.nextButton.Location = new System.Drawing.Point(244, 308);
                this.nextButton.Name = "nextButton";
                this.nextButton.Size = new System.Drawing.Size(109, 42);
                this.nextButton.TabIndex = 3;
                this.nextButton.Text = "Next";
                this.nextButton.UseVisualStyleBackColor = true;
            }
            return this.nextButton;
        }

        private System.Windows.Forms.Label GetQuestioLabel()
        {
            if (this.questionLabel == null)
            {
                this.questionLabel = new System.Windows.Forms.Label();
                this.questionLabel.AutoSize = true;
                this.questionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.questionLabel.Location = new System.Drawing.Point(50, 75);
                this.questionLabel.Name = "questionLabel";
                this.questionLabel.Size = new System.Drawing.Size(92, 31);
                this.questionLabel.TabIndex = 0;
                this.questionLabel.Text = "label1";
            }
            return this.questionLabel;
        }

        private System.Windows.Forms.Label GetAnswerLabel()
        {
            if (this.answerLabel == null)
            {
                this.answerLabel = new System.Windows.Forms.Label();
                this.answerLabel.AutoSize = true;
                this.answerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.answerLabel.Location = new System.Drawing.Point(52, 177);
                this.answerLabel.Name = "answerLabel";
                this.answerLabel.Size = new System.Drawing.Size(66, 24);
                this.answerLabel.TabIndex = 1;
                this.answerLabel.Text = "label2";
            }
            return this.answerLabel;
        }

        private System.Windows.Forms.PictureBox GetVoicePicture()
        {
            if (this.pictureBox1 == null)
            {
                this.pictureBox1 = new System.Windows.Forms.PictureBox();
                this.pictureBox1.Image = global::EnglishWhale.Properties.Resources.volume;
                this.pictureBox1.Location = new System.Drawing.Point(56, 12);
                this.pictureBox1.Name = "pictureBox1";
                this.pictureBox1.Size = new System.Drawing.Size(37, 35);
                this.pictureBox1.TabIndex = 2;
                this.pictureBox1.TabStop = false;
            }
            return this.pictureBox1;
        }

        #endregion

        private System.Windows.Forms.Panel showWordPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label answerLabel;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Panel makeSentencePanel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label secondPhraseLabel;
        private System.Windows.Forms.Label firstPhraseLabel;
    }
}