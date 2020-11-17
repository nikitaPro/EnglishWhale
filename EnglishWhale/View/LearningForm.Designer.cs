using System;
using System.Drawing;
using System.Windows.Forms;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LearningForm));
            this.SuspendLayout();
            // 
            // LearningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 362);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LearningForm";
            this.Text = "Learning";
            this.MaximizeBox = false;
            this.CenterToScreen();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        #endregion

        private Panel GetMakeSentencePanel()
        {
            if (this.makeSentencePanel == null)
            {
                this.makeSentencePanel = new Panel();
                this.makeSentencePanel.SuspendLayout();
                this.makeSentencePanel.Controls.Add(GetNextButton());
                this.makeSentencePanel.Controls.Add(GetSecondPhraseLabel());
                this.makeSentencePanel.Controls.Add(GetFirstPhraseLabel());
                this.makeSentencePanel.Controls.Add(GetTitleLable());
                this.makeSentencePanel.Controls.Add(GetFirstVoicePic());
                this.makeSentencePanel.Controls.Add(GetSecondVoicePic());
                this.makeSentencePanel.Location = new System.Drawing.Point(0, 0);
                this.makeSentencePanel.Name = "makeSentencePanel";
                this.makeSentencePanel.Size = new System.Drawing.Size(585, 365);
                this.makeSentencePanel.BackgroundImage = global::EnglishWhale.Properties.Resources.background_1;
                this.makeSentencePanel.BackgroundImageLayout = ImageLayout.Stretch;
                this.makeSentencePanel.TabIndex = 0;

                this.makeSentencePanel.ResumeLayout(false);
                this.makeSentencePanel.PerformLayout();
            }
            return this.makeSentencePanel;
        }

        private Label GetTitleLable()
        {
            if (this.titleLabel == null)
            {
                this.titleLabel = new Label();
                this.titleLabel.BackColor = Color.Goldenrod;
                this.titleLabel.Padding = new Padding(0, 4, 0, 6);
                this.titleLabel.MinimumSize = new Size(385, 30);
                this.titleLabel.AutoSize = true;
                this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                this.titleLabel.Location = new System.Drawing.Point(90, 50);
                this.titleLabel.Name = "label1";
                this.titleLabel.TabIndex = 1;
                this.titleLabel.Text = "Try use both in one sentence.";
            }
            return this.titleLabel;
        }

        private RichTextBox GetFirstPhraseLabel()
        {
            if (this.firstPhraseLabel == null)
            {
                this.firstPhraseLabel = new RichTextBox();
                this.firstPhraseLabel.BackColor = Color.Goldenrod;
                this.firstPhraseLabel.Padding = new Padding(0, 4, 0, 6);
                this.firstPhraseLabel.MinimumSize = new Size(485, 30);
                this.firstPhraseLabel.MaximumSize = new Size(485, 80);
                this.firstPhraseLabel.Font = font14;
                this.firstPhraseLabel.AutoSize = true;
                this.firstPhraseLabel.Location = new System.Drawing.Point(43, 130);
                this.firstPhraseLabel.Name = "firstPhraseLabel";
                this.firstPhraseLabel.TabIndex = 2;
                this.firstPhraseLabel.Text = "label2";
                this.firstPhraseLabel.BorderStyle = BorderStyle.None;
                this.firstPhraseLabel.ReadOnly = true;
            }
            return this.firstPhraseLabel;
        }


        private RichTextBox GetSecondPhraseLabel()
        {
            if(this.secondPhraseLabel == null)
            {
                this.secondPhraseLabel = new RichTextBox(); 
                this.secondPhraseLabel.BackColor = Color.Goldenrod;
                this.secondPhraseLabel.Padding = new Padding(0, 4, 0, 6);
                this.secondPhraseLabel.MinimumSize = new Size(485, 30);
                this.secondPhraseLabel.MaximumSize = new Size(485, 80);
                this.secondPhraseLabel.Font = font14;
                this.secondPhraseLabel.AutoSize = true;
                this.secondPhraseLabel.Location = new System.Drawing.Point(43, 220);
                this.secondPhraseLabel.Name = "secondPhraseLabel";
                this.secondPhraseLabel.TabIndex = 3;
                this.secondPhraseLabel.Text = "label3";
                this.secondPhraseLabel.BorderStyle = BorderStyle.None;
                this.secondPhraseLabel.ReadOnly = true;
            }
            return this.secondPhraseLabel;
        }

        private PictureBox GetFirstVoicePic()
        {
            if (this.firstVoicePic == null)
            {
                this.firstVoicePic = new PictureBox();
                this.firstVoicePic.BackColor = Color.FromArgb(0);
                this.firstVoicePic.Image = global::EnglishWhale.Properties.Resources.volume;
                this.firstVoicePic.Location = new System.Drawing.Point(8, 130);
                this.firstVoicePic.Name = "firstVoicePic";
                this.firstVoicePic.Size = new System.Drawing.Size(32, 32);
                this.firstVoicePic.TabIndex = 2;
                this.firstVoicePic.TabStop = false;
                this.firstVoicePic.MouseEnter += FirstVoicePic_MouseEnter;
            }
            return this.firstVoicePic;
        }

        private PictureBox GetSecondVoicePic()
        {
            if (this.secondVoicePic == null)
            {
                this.secondVoicePic = new PictureBox();
                this.secondVoicePic.BackColor = Color.FromArgb(0);
                this.secondVoicePic.Image = global::EnglishWhale.Properties.Resources.volume;
                this.secondVoicePic.Location = new System.Drawing.Point(8, 220);
                this.secondVoicePic.Name = "secondVoicePic";
                this.secondVoicePic.Size = new System.Drawing.Size(32, 32);
                this.secondVoicePic.TabIndex = 2;
                this.secondVoicePic.TabStop = false;
                this.secondVoicePic.MouseEnter += SecondVoicePic_MouseEnter;
            }
            return this.secondVoicePic;
        }

        private Panel GetShowWordPanel()
        {
            if (this.showWordPanel == null)
            {
                this.showWordPanel = new Panel();
                this.showWordPanel.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(GetVoicePicture())).BeginInit();

                this.showWordPanel.Controls.Add(GetVoicePicture());
                this.showWordPanel.Controls.Add(GetAnswerLabel());
                this.showWordPanel.Controls.Add(GetQuestioLabel());
                this.showWordPanel.Controls.Add(GetNextButton());
                this.showWordPanel.Location = new System.Drawing.Point(0, 0);
                this.showWordPanel.Name = "showWordPanel";
                this.showWordPanel.Size = new System.Drawing.Size(585, 365);
                this.showWordPanel.BackgroundImage = global::EnglishWhale.Properties.Resources.background_1;
                this.showWordPanel.BackgroundImageLayout = ImageLayout.Stretch;
                this.showWordPanel.TabIndex = 0;

                this.showWordPanel.ResumeLayout(false);
                this.showWordPanel.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)GetVoicePicture()).EndInit();
            }
            return this.showWordPanel;
        }

        private Button GetNextButton()
        {
            if(this.nextButton == null)
            {
                this.nextButton = new CustomButton();
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

        private RichTextBox GetQuestioLabel()
        {
            if (this.questionLabel == null)
            {
                this.questionLabel = new RichTextBox();
                this.questionLabel.BackColor = Color.Goldenrod;
                this.questionLabel.Padding = new Padding(0, 4, 0, 6);
                this.questionLabel.MinimumSize = new Size(485, 30);
                this.questionLabel.AutoSize = true;
                this.questionLabel.Font = font20;
                this.questionLabel.Location = new System.Drawing.Point(50, 75);
                this.questionLabel.Name = "questionLabel";
                this.questionLabel.TabIndex = 0;
                this.questionLabel.Text = "label1";
                this.questionLabel.BorderStyle = BorderStyle.None;
                this.questionLabel.ReadOnly = true;
            }
            return this.questionLabel;
        }

        private RichTextBox GetAnswerLabel()
        {
            if (this.answerLabel == null)
            {
                this.answerLabel = new RichTextBox();
                this.answerLabel.BackColor = Color.Goldenrod;
                this.answerLabel.Padding = new Padding(0, 4, 0, 6);
                this.answerLabel.MinimumSize = new Size(485, 30);
                this.answerLabel.AutoSize = true;
                this.answerLabel.Font = font20;
                this.answerLabel.Location = new System.Drawing.Point(50, 175);
                this.answerLabel.Name = "answerLabel";
                this.answerLabel.TabIndex = 1;
                this.answerLabel.Text = "label2";
                this.answerLabel.BorderStyle = BorderStyle.None;
                this.answerLabel.ReadOnly = true;
            }
            return this.answerLabel;
        }

        private PictureBox GetVoicePicture()
        {
            if (this.voicePicture == null)
            {
                this.voicePicture = new PictureBox();
                this.voicePicture.BackColor = Color.FromArgb(0);
                this.voicePicture.Image = global::EnglishWhale.Properties.Resources.volume;
                this.voicePicture.Location = new System.Drawing.Point(56, 12);
                this.voicePicture.Name = "voicePicture";
                this.voicePicture.Size = new System.Drawing.Size(37, 35);
                this.voicePicture.TabIndex = 2;
                this.voicePicture.TabStop = false;
                this.voicePicture.MouseEnter += VoicePicture_MouseEnter;
            }
            return this.voicePicture;
        }

        private ToolTip GetToolTip()
        {
            if (toolTip == null)
            {
                toolTip = new ToolTip();
                toolTip.UseAnimation = true;
                toolTip.UseAnimation = true;
            }
            return toolTip;
        }
        private System.Drawing.Font font14 = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        private System.Drawing.Font font20 = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        private Panel showWordPanel;
        private PictureBox voicePicture;
        private PictureBox firstVoicePic;
        private PictureBox secondVoicePic;
        private RichTextBox answerLabel;
        private RichTextBox questionLabel;
        private Button nextButton;
        private Panel makeSentencePanel;
        private Label titleLabel;
        private RichTextBox secondPhraseLabel;
        private RichTextBox firstPhraseLabel;
        private ToolTip toolTip;
    }
}