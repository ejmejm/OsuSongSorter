namespace Osu__Song_Sorter
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.songPath = new System.Windows.Forms.TextBox();
            this.newSongPath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.skipButton = new System.Windows.Forms.Button();
            this.songCountLabel = new System.Windows.Forms.Label();
            this.editSongIndex = new System.Windows.Forms.TextBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.unfocus = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.artistLabel = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Below list the path of your Osu! songs folder";
            this.label1.Visible = false;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // songPath
            // 
            this.songPath.Location = new System.Drawing.Point(15, 51);
            this.songPath.Name = "songPath";
            this.songPath.Size = new System.Drawing.Size(268, 20);
            this.songPath.TabIndex = 1;
            this.songPath.Text = "C:\\Program Files (x86)\\osu!\\Songs";
            this.songPath.Visible = false;
            // 
            // newSongPath
            // 
            this.newSongPath.Location = new System.Drawing.Point(15, 111);
            this.newSongPath.Name = "newSongPath";
            this.newSongPath.Size = new System.Drawing.Size(268, 20);
            this.newSongPath.TabIndex = 3;
            this.newSongPath.Text = "C:\\Users\\Meyer Family\\Desktop\\OsuSongsTest";
            this.newSongPath.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Below list the path for the mp3s";
            this.label2.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(113, 137);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Begin";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(113, 99);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 5;
            this.playButton.Text = "Pause";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Visible = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(32, 128);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(111, 34);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Visible = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // skipButton
            // 
            this.skipButton.Location = new System.Drawing.Point(160, 129);
            this.skipButton.Name = "skipButton";
            this.skipButton.Size = new System.Drawing.Size(113, 34);
            this.skipButton.TabIndex = 7;
            this.skipButton.Text = "Skip";
            this.skipButton.UseVisualStyleBackColor = true;
            this.skipButton.Visible = false;
            this.skipButton.Click += new System.EventHandler(this.skipButton_Click);
            // 
            // songCountLabel
            // 
            this.songCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.songCountLabel.AutoSize = true;
            this.songCountLabel.Location = new System.Drawing.Point(95, 166);
            this.songCountLabel.Name = "songCountLabel";
            this.songCountLabel.Size = new System.Drawing.Size(93, 13);
            this.songCountLabel.TabIndex = 8;
            this.songCountLabel.Text = "Song x out of xxxx";
            this.songCountLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.songCountLabel.Visible = false;
            this.songCountLabel.Click += new System.EventHandler(this.songCountLabel_Click);
            // 
            // editSongIndex
            // 
            this.editSongIndex.AcceptsReturn = true;
            this.editSongIndex.Location = new System.Drawing.Point(124, 162);
            this.editSongIndex.Name = "editSongIndex";
            this.editSongIndex.Size = new System.Drawing.Size(28, 20);
            this.editSongIndex.TabIndex = 10;
            this.editSongIndex.Text = "x";
            this.editSongIndex.Visible = false;
            this.editSongIndex.Enter += new System.EventHandler(this.editSongIndex_Enter);
            this.editSongIndex.KeyDown += new System.Windows.Forms.KeyEventHandler(this.editSongIndex_KeyDown);
            this.editSongIndex.Leave += new System.EventHandler(this.editSongIndex_Leave);
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.SystemColors.Control;
            this.trackBar1.Location = new System.Drawing.Point(17, 48);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(268, 45);
            this.trackBar1.TabIndex = 11;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Visible = false;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseDown);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // unfocus
            // 
            this.unfocus.AutoSize = true;
            this.unfocus.Location = new System.Drawing.Point(-1, 7);
            this.unfocus.Name = "unfocus";
            this.unfocus.Size = new System.Drawing.Size(0, 13);
            this.unfocus.TabIndex = 12;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(95, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(95, 13);
            this.titleLabel.TabIndex = 13;
            this.titleLabel.Text = "Now Playing - Title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.titleLabel.Visible = false;
            this.titleLabel.SizeChanged += new System.EventHandler(this.titleLabel_SizeChanged);
            // 
            // artistLabel
            // 
            this.artistLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.artistLabel.AutoSize = true;
            this.artistLabel.Location = new System.Drawing.Point(121, 26);
            this.artistLabel.Name = "artistLabel";
            this.artistLabel.Size = new System.Drawing.Size(44, 13);
            this.artistLabel.TabIndex = 14;
            this.artistLabel.Text = "by Artist";
            this.artistLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.artistLabel.Visible = false;
            this.artistLabel.SizeChanged += new System.EventHandler(this.artistLabel_SizeChanged);
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(32, 99);
            this.trackBar2.Maximum = 100;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(65, 45);
            this.trackBar2.TabIndex = 15;
            this.trackBar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar2.Value = 50;
            this.trackBar2.Visible = false;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 183);
            this.Controls.Add(this.artistLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.unfocus);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.editSongIndex);
            this.Controls.Add(this.songCountLabel);
            this.Controls.Add(this.skipButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.newSongPath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.songPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar2);
            this.Name = "Form1";
            this.Text = "Osu! Song Sorter Alpha V 0.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox songPath;
        private System.Windows.Forms.TextBox newSongPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button skipButton;
        private System.Windows.Forms.Label songCountLabel;
        private System.Windows.Forms.TextBox editSongIndex;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label unfocus;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label artistLabel;
        private System.Windows.Forms.TrackBar trackBar2;
    }
}

