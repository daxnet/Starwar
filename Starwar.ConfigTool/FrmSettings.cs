using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starwar.ConfigTool
{
    using Common;

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
                NumOfLasersPerSecond = TbLaserGenFreq.Value
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
