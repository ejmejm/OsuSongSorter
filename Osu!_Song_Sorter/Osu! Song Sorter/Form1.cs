using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Osu__Song_Sorter
{
    public partial class Form1 : Form
    {
        int totalSongs = 0;
        int songIndex = 1;
        String currentMp3;
        DirectoryInfo[] songFolders;
        WMPLib.WindowsMediaPlayer wplayer;

        public Form1()
        {
            wplayer = new WMPLib.WindowsMediaPlayer();
            wplayer.settings.setMode("loop", true);
            InitializeComponent();
            newSongPath.ReadOnly = false;
            songPath.ReadOnly = false;
            label1.Visible = true;
            label2.Visible = true;
            songPath.Visible = true;
            newSongPath.Visible = true;
            button1.Enabled = true;
            button1.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            CustomTrackBar TrackBar1 = new CustomTrackBar(19,
                new Size(300, 50));
            this.Controls.Add(TrackBar1);
            TrackBar1.BringToFront();
             */
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(@songPath.Text))
            {
                label1.Text = "This path does not exist, please check it again.";
                if (!Directory.Exists(@newSongPath.Text))
                {
                    label2.Text = "This path does not exist, please check it again.";
                }
            }
            else if(!Directory.Exists(@newSongPath.Text))
            {
                label2.Text = "This path does not exist, please check it again.";
            }
            else
            {
                DirectoryInfo info = new DirectoryInfo(@songPath.Text);
                DirectoryInfo[] tempFolders = info.GetDirectories();

                //Check how many folders are a actually Osu! beatmaps
                int fullCount = 0;
                foreach(DirectoryInfo d in tempFolders)
                {
                    bool osuFile = false;
                    foreach(FileInfo f in d.GetFiles())
                    {
                        if(f.Name.IndexOf(".osu") != -1)
                        {
                            osuFile = true;
                        }
                    }
                    if(osuFile)
                    {
                        fullCount++;
                    }
                }

                songFolders = new DirectoryInfo[fullCount];

                for (int i = 0; i < fullCount; i++)
                {
                    songFolders[i] = tempFolders[i];
                }

                totalSongs = songFolders.Count();
                newSongPath.ReadOnly = true;
                songPath.ReadOnly = true;
                label1.Visible = false;
                label2.Visible = false;
                songPath.Visible = false;
                newSongPath.Visible = false;
                button1.Enabled = false;
                button1.Visible = false;
                playButton.Visible = true;
                addButton.Visible = true;
                skipButton.Visible = true;
                songCountLabel.Visible = true;
                trackBar1.Visible = true;
                artistLabel.Visible = true;
                titleLabel.Visible = true;
                trackBar2.Visible = true;

                wplayer.settings.volume = trackBar2.Value;
                playSong(songIndex);
                timer1.Enabled = true;
            }
        }

        private String findMp3Path(String folderPath)
        {
            FileInfo[] fileInfos = new DirectoryInfo(@folderPath).GetFiles();
            String mp3Path = "";
            long mp3Size = 0;
            foreach(FileInfo f in fileInfos)
            {
                if(f.Name.IndexOf(".mp3") != -1 && f.Length > mp3Size)
                {
                    mp3Path = f.FullName;
                    mp3Size = f.Length;
                }
            }
            return mp3Path;
        }
        
        private String findOsuPath(String folderPath)
        {
            FileInfo[] fileInfos = new DirectoryInfo(@folderPath).GetFiles();
            foreach(FileInfo f in fileInfos)
            {
                if(f.Name.IndexOf(".osu") != -1)
                {
                    return f.FullName;
                }
            }
            return null;
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            playPause();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            addSong();
            unfocus.Focus();
        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            skipSong();
            unfocus.Focus();
        }

        private void songCountLabel_Click(object sender, EventArgs e)
        {
            editSongIndex.Visible = true;
            editSongIndex.Focus();
        }

        private void editSongIndex_Leave(object sender, EventArgs e)
        {
            editSongIndex.Visible = false;
            int n;
            if (int.TryParse(editSongIndex.Text, out n) && songIndex <= totalSongs)
            {
                songIndex = n - 1;
                skipSong();
            }
        }

        private void editSongIndex_Enter(object sender, EventArgs e)
        {
            editSongIndex.Text = songIndex.ToString();
            editSongIndex.BringToFront();
        }

        private void addSong()
        {
            timer1.Enabled = false;
            trackBar1.Value = 0;
            String newMp3Path = newSongPath.Text + "\\" + Path.GetFileName(@currentMp3);
            File.Copy(@currentMp3, @newMp3Path, true);
            TagLib.File newMp3 = TagLib.File.Create(@newMp3Path);
            string osuInfo;
            var fileStream = new FileStream(@findOsuPath(songFolders[songIndex - 1].FullName), FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                osuInfo = streamReader.ReadToEnd();
            }
            if (newMp3.Tag.Title == null)
            {
                newMp3.Tag.Title = osuInfo.Substring(osuInfo.IndexOf("Title:") + 6,
                    osuInfo.IndexOf(System.Environment.NewLine, osuInfo.IndexOf("Title:") + 6) - osuInfo.IndexOf("Title:") - 6);
            }
            if (newMp3.Tag.AlbumArtists == null)
            {
                newMp3.Tag.AlbumArtists = new string[] { osuInfo.Substring(osuInfo.IndexOf("Artist:") + 7, 
                    osuInfo.IndexOf(System.Environment.NewLine, osuInfo.IndexOf("Artist:") + 7) - osuInfo.IndexOf("Artist:") - 7) };
            }
            newMp3.Save();
            songIndex++;
            playSong(songIndex);
        }

        private void skipSong()
        {
            songIndex++;
            playSong(songIndex);
        }

        private void editSongIndex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                unfocus.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            unfocus.Focus();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if((int)((double) 1000 * wplayer.controls.currentPosition / wplayer.controls.currentItem.duration) >= 0
                && (int)((double)1000 * wplayer.controls.currentPosition / wplayer.controls.currentItem.duration) <= 1000)
            {
                trackBar1.Value = (int)((double) 1000 * wplayer.controls.currentPosition / wplayer.controls.currentItem.duration);
            }
            else
            {
                trackBar1.Value = 0;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            wplayer.controls.currentPosition = wplayer.controls.currentItem.duration * 
                (double) trackBar1.Value / (double) trackBar1.Maximum;
        }

        private void playPause()
        {
            if (playButton.Text == "Play")
            {
                wplayer.controls.play();
                playButton.Text = "Pause";
            }
            else
            {
                wplayer.controls.pause();
                playButton.Text = "Play";
            }
        }

        private void playSong(int songNumber)
        {
            timer1.Enabled = false;
            trackBar1.Value = 0;
            if(songIndex < 1 || songIndex > totalSongs)
            {
                songIndex = 1;
            }
            currentMp3 = findMp3Path(songFolders[songIndex - 1].FullName);
            string osuInfo;
            String osuPath = findOsuPath(songFolders[songIndex - 1].FullName);
            if (osuPath != null)
            {
                var fileStream = new FileStream(@osuPath, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    osuInfo = streamReader.ReadToEnd();
                }
            }
            else
            {
                songIndex = 1;
                var fileStream = new FileStream(@findOsuPath(songFolders[songIndex - 1].FullName), FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    osuInfo = streamReader.ReadToEnd();
                }
            }
            int previewTime = 0;
            int.TryParse(osuInfo.Substring(osuInfo.IndexOf("PreviewTime:") + 12,
                osuInfo.IndexOf(System.Environment.NewLine, osuInfo.IndexOf("PreviewTime:") + 12) - osuInfo.IndexOf("PreviewTime:") - 12), out previewTime);
            wplayer.URL = currentMp3;
            wplayer.controls.currentPosition = (double)previewTime / 1000.0;
            playButton.Text = "Pause";
            songCountLabel.Text = "Song " + songIndex + " out of " + totalSongs;
            titleLabel.Text = getSongInfo("Title");
            artistLabel.Text = "by " + getSongInfo("Artist");
            timer1.Enabled = true;
        }

        private String getSongInfo(String key)
        {
            string osuInfo;
            var fileStream = new FileStream(@findOsuPath(songFolders[songIndex - 1].FullName), FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                osuInfo = streamReader.ReadToEnd();
            }
            string info = osuInfo.Substring(osuInfo.IndexOf(key + ":") + (key.Length + 1),
                osuInfo.IndexOf(System.Environment.NewLine, osuInfo.IndexOf(key + ":") + (key.Length + 1)) - osuInfo.IndexOf(key + ":") - (key.Length + 1));
            return info;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Space && titleLabel.Visible)
            {
                playPause();
                return true;
            }
            else if (keyData == Keys.Right)
            {
                songIndex++;
                playSong(songIndex);
                return true;
            }
            else if (keyData == Keys.Left)
            {
                songIndex--;
                playSong(songIndex);
                return true;
            }
            else if (keyData == Keys.Z)
            {
                addSong();
                return true;
            }
            else if (keyData == Keys.X)
            {
                skipSong();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void titleLabel_SizeChanged(object sender, EventArgs e)
        {
            titleLabel.Left = (this.ClientSize.Width - titleLabel.Size.Width) / 2;
        }

        private void artistLabel_SizeChanged(object sender, EventArgs e)
        {
            artistLabel.Left = (this.ClientSize.Width - artistLabel.Size.Width) / 2;
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            unfocus.Focus();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            wplayer.settings.volume = trackBar2.Value;
        }
    }
}