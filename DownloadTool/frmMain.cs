using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;
using System.Diagnostics;
using FFMpegCore;
using Xabe.FFmpeg.Downloader;
using System.Text.RegularExpressions;
using System.Net.Http;
using Xabe.FFmpeg;
using System.Threading;

namespace DownloadTool
{
    public partial class frmMain : Form
    {
        List<IVideoStreamInfo> videoStreams = new List<IVideoStreamInfo>();
        List<AudioOnlyStreamInfo> audioStreams = new List<AudioOnlyStreamInfo>();
        Dictionary<string, AudioOnlyStreamInfo> dicAudio = new Dictionary<string, AudioOnlyStreamInfo>();
        Dictionary<string, IVideoStreamInfo> dicVideo = new Dictionary<string, IVideoStreamInfo>();
        YoutubeClient YTClient = new YoutubeClient();
        StreamManifest streamManifest;
        YoutubeExplode.Videos.Video video;
        bool IsUrlOK = false;
        string author;
        string title;
        public frmMain()
        {
            InitializeComponent();

            this.Width = pbxYoutube.Location.X;
            toolTip.SetToolTip(pbxYoutube, "點一下來開啟連結");
        }

        private void SetEnable(bool pEnable)
        {
            rbtnAudio.Enabled = cmbAudioQuality.Enabled = cmbVideoQuality.Enabled = rbtnVideo.Enabled = btnDownload.Enabled = pEnable;
        }

        private async void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                SetEnable(false);

                await Download(txtVideoUrl.Text);

                SetEnable(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"下载出错：{ex.Message}", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task Download(string url)
        {
            try
            {
                var progress = new Progress<double>(p =>
                {
                    progressBar1.Value = Convert.ToInt32(p * 100);
                    labPercent.Text = Convert.ToString(Math.Round(p * 100, 1, MidpointRounding.AwayFromZero)) + "%";
                });

                if (rbtnAudio.Checked)
                {
                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.FileName = $"{title}.mp3";
                    dialog.Filter = "音訊檔 (*.mp3)|*.mp3";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string path = new FileInfo(dialog.FileName).Directory.FullName;

                        await YTClient.Videos.Streams.DownloadAsync(dicAudio[cmbAudioQuality.Text], Path.Combine(path, $"{title}.mp3"), progress);
                    }
                }
                else
                {
                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.FileName = $"{title}.mp4";
                    dialog.Filter = "影片檔 (*.mp4)|*.mp4";
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        string OutputPath = new FileInfo(dialog.FileName).Directory.FullName;
                        string AudioPath = Path.Combine(Directory.GetCurrentDirectory(), $"{title}-audio.mp3");
                        string VideoPath = Path.Combine(Directory.GetCurrentDirectory(), $"{title}-video.mp4");

                        labStatus.Text = "正在擷取影片資料";
                        await YTClient.Videos.Streams.DownloadAsync(dicVideo[cmbVideoQuality.Text], VideoPath, progress);
                        
                        labStatus.Text = "正在擷取音訊資料";
                        await YTClient.Videos.Streams.DownloadAsync(dicAudio.First().Value, AudioPath, progress);

                        labStatus.Text = "檔案格式轉換中";
                        Task.Run(() => CheckVideoDuration(AudioPath, VideoPath, Path.Combine(OutputPath, $"{title}.mp4")));
                        await FFmpegDownloader.GetLatestVersion(FFmpegVersion.Full);
                        FFMpeg.ReplaceAudio(VideoPath, AudioPath, Path.Combine(OutputPath, $"{title}.mp4"));

                        File.Delete(VideoPath);
                        File.Delete(AudioPath);

                        labStatus.Text = "下載完成";
                        MessageBox.Show("下載完成！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        string argument = "/select, \"" + dialog.FileName + "\"";

                        System.Diagnostics.Process.Start("explorer.exe", argument);
                    }
                }

                #region
                //string savePath = Path.Combine(Directory.GetCurrentDirectory(), "YouTubeDownloads");
                //var ext = VideoStreamInfo.Container.Name;
                //var fileName = $"{video.Title}.{ext}";

                //if (!Directory.Exists(savePath))
                //{
                //    Directory.CreateDirectory(savePath);
                //}

                //var filePath = Path.Combine(savePath, fileName);

                //var progress = new Progress<double>(p =>
                //{
                //    progressBar1.Value = Convert.ToInt32(p * 100);
                //    label1.Text = Convert.ToString(Math.Round(p * 100, 1, MidpointRounding.AwayFromZero)) + "%";
                //});


                //using (var videoStream = await _youtube.Videos.Streams.GetAsync(VideoStreamInfo))
                //using (var audioStream = await _youtube.Videos.Streams.GetAsync(AudioStreamInfo))
                //using (var outputFile = File.Create(filePath))
                //{
                //    await videoStream.CopyToAsync(outputFile);
                //    await audioStream.CopyToAsync(outputFile);
                //}
                #endregion


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CheckVideoDuration(string pAudioPath, string pVideoPath, string pOutputPath)
        {
            try
            {
                if (progressBar1.InvokeRequired)
                {
                    progressBar1.BeginInvoke(new Action(() => { }));
                }
                else
                {
                    bool IsConvertOK = false;
                    while (!IsConvertOK)
                    {
                        double AudioSize = Convert.ToDouble(new FileInfo(pAudioPath).Length);
                        double VideoSize = Convert.ToDouble(new FileInfo(pVideoPath).Length);
                        if (File.Exists(pOutputPath))
                        {
                            double OutputSize = Convert.ToDouble(new FileInfo(pOutputPath).Length);
                            if (AudioSize + VideoSize > OutputSize)
                            {
                                progressBar1.Value = Convert.ToInt32(OutputSize / (AudioSize + VideoSize) * 100);
                                labPercent.Text = Convert.ToString(Math.Round(OutputSize / (AudioSize + VideoSize) * 100, 1, MidpointRounding.AwayFromZero)) + "%";

                                if (!File.Exists(pAudioPath) && !File.Exists(pVideoPath))
                                    IsConvertOK = true;
                            }
                        }
                    }

                    progressBar1.Value = 100;
                    labPercent.Text = "100%";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private async void txtVideoUrl_TextChanged(object sender, EventArgs e)
        {
            SetEnable(false);

            cmbAudioQuality.Items.Clear();
            cmbVideoQuality.Items.Clear();
            txtTitle.Text = labDuration.Text = string.Empty;
            pbxYoutube.Image = null;
            this.Width = pbxYoutube.Location.X;
            labCheckUrl.ForeColor = Color.Black;
            labCheckUrl.Text = "網址檢查中";
            await CheckUrl();
        }

        private async Task CheckUrl()
        {
            try
            {
                txtVideoUrl.Text = txtVideoUrl.Text.Trim();
                if (IsYouTubeUrl(txtVideoUrl.Text))
                {
                    video = await YTClient.Videos.GetAsync(txtVideoUrl.Text);
                    author = video.Author.ChannelTitle;
                    streamManifest = await YTClient.Videos.Streams.GetManifestAsync(video.Id);

                    title = video.Title
                    .Replace("\\", " ")
                    .Replace("/", " ")
                    .Replace(":", " ")
                    .Replace("*", " ")
                    .Replace("?", " ")
                    .Replace("\"", " ")
                    .Replace("<", " ")
                    .Replace(">", " ")
                    .Replace("|", " ");

                    txtTitle.Text = video.Title;

                    labDuration.Text = video.Duration.ToString();

                    this.Width = pbxYoutube.Location.X + pbxYoutube.Width + 20;
                    string ImageUrl = video.Thumbnails.Where(t => t.Resolution.ToString() == "480x360").FirstOrDefault().Url;
                    await GetYoutubeImage(ImageUrl);

                    GetQuality();

                    SetEnable(true);
                    IsUrlOK = true;
                    labCheckUrl.ForeColor = Color.DarkGreen;
                    labCheckUrl.Text = "網址可以使用";
                }
                else
                {
                    IsUrlOK = false;
                    labCheckUrl.ForeColor = Color.Red;
                    labCheckUrl.Text = "不支援的網址";
                }
            }
            catch (Exception ex)
            {
                IsUrlOK = false;
                labCheckUrl.ForeColor = Color.Red;
                labCheckUrl.Text = "網址擷取失敗";
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

        private async Task GetYoutubeImage(string pImageUrl)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync(pImageUrl))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            using (var stream = await response.Content.ReadAsStreamAsync())
                            {
                                var image = Image.FromStream(stream);

                                pbxYoutube.Image = image;
                            }
                        }
                        else
                        {
                            MessageBox.Show("無法下載封面圖片", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

        private bool IsYouTubeUrl(string url)
        {
            string pattern = @"^(https?://)?(www\.)?(youtube\.com/watch\?v=|youtu\.be/)([\w-]{11})";
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return IsUrlOK = regex.IsMatch(url);
        }

        private void GetQuality()
        {
            try
            {
                if (IsUrlOK)
                {
                    string quality = "";
                    cmbAudioQuality.Items.Clear();
                    cmbVideoQuality.Items.Clear();
                    dicAudio = new Dictionary<string, AudioOnlyStreamInfo>();
                    dicVideo = new Dictionary<string, IVideoStreamInfo>();
                    if (rbtnAudio.Checked)
                    {
                        audioStreams = streamManifest.GetAudioOnlyStreams().ToList();
                        foreach (AudioOnlyStreamInfo audio in audioStreams)
                        {
                            quality = audio.Bitrate.ToString();
                            if (!dicAudio.ContainsKey(quality))
                                dicAudio.Add(quality, audio);
                        }
                        dicAudio = dicAudio.OrderByDescending(t => t.Value.Bitrate).ToDictionary(t => t.Key, t => t.Value);

                        foreach (string key in dicAudio.Keys)
                        {
                            cmbAudioQuality.Items.Add(key);
                        }

                        cmbAudioQuality.SelectedIndex = 0;
                    }
                    else
                    {
                        videoStreams = streamManifest.GetVideoOnlyStreams().ToList<IVideoStreamInfo>();
                        foreach (IVideoStreamInfo video in videoStreams)
                        {
                            quality = video.VideoQuality.ToString();
                            if (!dicVideo.ContainsKey(quality))
                                dicVideo.Add(quality, video);
                            else if (video.VideoCodec.StartsWith("av01"))
                                dicVideo[quality] = video;
                        }

                        dicVideo = dicVideo.OrderByDescending(t => t.Value.VideoQuality).ToDictionary(t => t.Key, t => t.Value);

                        AudioOnlyStreamInfo audio = streamManifest.GetAudioOnlyStreams().OrderByDescending(t => t.Bitrate).ToList().First();

                        if (!dicAudio.ContainsKey(audio.Bitrate.ToString()))
                            dicAudio.Add(audio.Bitrate.ToString(), audio);

                        foreach (string key in dicVideo.Keys)
                        {
                            cmbVideoQuality.Items.Add(key);
                        }

                        cmbVideoQuality.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            GetQuality();
        }

        private void pbxYoutube_Click(object sender, EventArgs e)
        {
            Process.Start(txtVideoUrl.Text);
        }
    }
}
