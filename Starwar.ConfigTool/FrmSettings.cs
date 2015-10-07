using System;
using System.Linq;
using System.Windows.Forms;
using Starwar.Common;

namespace Starwar.ConfigTool
{
    public partial class FrmSettings : Form
    {
        public FrmSettings()
        {
            InitializeComponent();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            var settings = Settings.ReadSettings();
            this.ChkLiveForever.Checked = settings.LiveForever;
            this.ChkShowDebugInfo.Checked = settings.ShowDebugInfo;
            this.TbEnemyGenFreq.Value = settings.NumOfEnemiesPerSecond;
            this.ChkFullScreen.Checked = settings.FullScreen;
            this.TbLaserGenFreq.Value = settings.NumOfLasersPerSecond;

            this.CbBackgroundMusic.DataSource = BackgroundMusicItem.All;
            if (!string.IsNullOrEmpty(settings.BgmSoundEffect))
            {
                this.CbBackgroundMusic.SelectedItem =
                    BackgroundMusicItem.All.First(i => i.SoundEffect == settings.BgmSoundEffect);
            }
            else
            {
                this.CbBackgroundMusic.SelectedIndex = 0;
            }

            this.TbEnemyGenFreq_ValueChanged(this, EventArgs.Empty);
            this.TbLaserGenFreq_ValueChanged(this, EventArgs.Empty);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            var settings = new Settings
            {
                LiveForever = ChkLiveForever.Checked,
                ShowDebugInfo = ChkShowDebugInfo.Checked,
                NumOfEnemiesPerSecond = TbEnemyGenFreq.Value,
                FullScreen = ChkFullScreen.Checked,
                NumOfLasersPerSecond = TbLaserGenFreq.Value,
                BgmSoundEffect = ((BackgroundMusicItem)CbBackgroundMusic.SelectedItem).SoundEffect
            };
            Settings.SaveSettings(settings);
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TbEnemyGenFreq_ValueChanged(object sender, EventArgs e)
        {
            LblEnemyGenFreq.Text = string.Format("{0} 架/秒", TbEnemyGenFreq.Value);
        }

        private void TbLaserGenFreq_ValueChanged(object sender, EventArgs e)
        {
            LblLaserGenFreq.Text = string.Format("{0} 发/秒", TbLaserGenFreq.Value);
        }
    }
}
