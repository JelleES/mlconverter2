﻿namespace mlconverter2
{
    partial class RomViewer
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
            this.songListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // songListBox
            // 
            this.songListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.songListBox.FormattingEnabled = true;
            this.songListBox.Location = new System.Drawing.Point(13, 13);
            this.songListBox.Name = "songListBox";
            this.songListBox.Size = new System.Drawing.Size(259, 238);
            this.songListBox.TabIndex = 0;
            this.songListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.songListBox_MouseDoubleClick);
            // 
            // RomViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.songListBox);
            this.Name = "RomViewer";
            this.Text = "RomViewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox songListBox;
    }
}