namespace Gameproject
{
    partial class SelectedCharacter
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
            buttonGreen = new System.Windows.Forms.Button();
            buttonRed = new System.Windows.Forms.Button();
            buttonYellow = new System.Windows.Forms.Button();
            buttonBlue = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // buttonGreen
            // 
            buttonGreen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            buttonGreen.BackColor = System.Drawing.Color.FromArgb(182, 255, 0);
            buttonGreen.Image = DinoRun.Properties.Resources.Dino_Grenn;
            buttonGreen.Location = new System.Drawing.Point(-8, -58);
            buttonGreen.Name = "buttonGreen";
            buttonGreen.Size = new System.Drawing.Size(380, 940);
            buttonGreen.TabIndex = 0;
            buttonGreen.UseVisualStyleBackColor = false;
            buttonGreen.Click += buttonGreen_Click;
            // 
            // buttonRed
            // 
            buttonRed.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonRed.BackColor = System.Drawing.Color.Red;
            buttonRed.Image = DinoRun.Properties.Resources.Dino_Red;
            buttonRed.Location = new System.Drawing.Point(362, -58);
            buttonRed.Name = "buttonRed";
            buttonRed.Size = new System.Drawing.Size(380, 940);
            buttonRed.TabIndex = 1;
            buttonRed.UseVisualStyleBackColor = false;
            buttonRed.Click += buttonRed_Click;
            // 
            // buttonYellow
            // 
            buttonYellow.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonYellow.BackColor = System.Drawing.Color.FromArgb(255, 174, 0);
            buttonYellow.Image = DinoRun.Properties.Resources.Dino_Yelleow;
            buttonYellow.Location = new System.Drawing.Point(732, -58);
            buttonYellow.Name = "buttonYellow";
            buttonYellow.Size = new System.Drawing.Size(380, 940);
            buttonYellow.TabIndex = 2;
            buttonYellow.UseVisualStyleBackColor = false;
            buttonYellow.Click += buttonYellow_Click;
            // 
            // buttonBlue
            // 
            buttonBlue.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonBlue.BackColor = System.Drawing.Color.FromArgb(0, 148, 255);
            buttonBlue.Image = DinoRun.Properties.Resources.Dino_Blue;
            buttonBlue.Location = new System.Drawing.Point(1103, -58);
            buttonBlue.Name = "buttonBlue";
            buttonBlue.Size = new System.Drawing.Size(380, 940);
            buttonBlue.TabIndex = 3;
            buttonBlue.UseVisualStyleBackColor = false;
            buttonBlue.Click += buttonBlue_Click;
            // 
            // SelectedCharacter
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1474, 869);
            ControlBox = false;
            Controls.Add(buttonBlue);
            Controls.Add(buttonYellow);
            Controls.Add(buttonRed);
            Controls.Add(buttonGreen);
            Name = "SelectedCharacter";
            Text = "Selected Character";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button buttonGreen;
        private System.Windows.Forms.Button buttonRed;
        private System.Windows.Forms.Button buttonYellow;
        private System.Windows.Forms.Button buttonBlue;
    }
}