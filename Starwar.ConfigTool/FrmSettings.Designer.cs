namespace Starwar.ConfigTool
{
    partial class FrmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.TabControl = new System.Windows.Forms.TabControl();
            this.TpGeneral = new System.Windows.Forms.TabPage();
            this.GrpEnemyGenerationFreq = new System.Windows.Forms.GroupBox();
            this.LblEnemyGenFreq = new System.Windows.Forms.Label();
            this.TbEnemyGenFreq = new System.Windows.Forms.TrackBar();
            this.ChkLiveForever = new System.Windows.Forms.CheckBox();
            this.TpDevelopment = new System.Windows.Forms.TabPage();
            this.ChkShowDebugInfo = new System.Windows.Forms.CheckBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.TabControl.SuspendLayout();
            this.TpGeneral.SuspendLayout();
            this.GrpEnemyGenerationFreq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbEnemyGenFreq)).BeginInit();
            this.TpDevelopment.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.TpGeneral);
            this.TabControl.Controls.Add(this.TpDevelopment);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(307, 329);
            this.TabControl.TabIndex = 0;
            // 
            // TpGeneral
            // 
            this.TpGeneral.Controls.Add(this.GrpEnemyGenerationFreq);
            this.TpGeneral.Controls.Add(this.ChkLiveForever);
            this.TpGeneral.Location = new System.Drawing.Point(4, 22);
            this.TpGeneral.Name = "TpGeneral";
            this.TpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.TpGeneral.Size = new System.Drawing.Size(299, 303);
            this.TpGeneral.TabIndex = 0;
            this.TpGeneral.Text = "通用";
            this.TpGeneral.UseVisualStyleBackColor = true;
            // 
            // GrpEnemyGenerationFreq
            // 
            this.GrpEnemyGenerationFreq.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpEnemyGenerationFreq.Controls.Add(this.LblEnemyGenFreq);
            this.GrpEnemyGenerationFreq.Controls.Add(this.TbEnemyGenFreq);
            this.GrpEnemyGenerationFreq.Location = new System.Drawing.Point(6, 28);
            this.GrpEnemyGenerationFreq.Name = "GrpEnemyGenerationFreq";
            this.GrpEnemyGenerationFreq.Size = new System.Drawing.Size(287, 92);
            this.GrpEnemyGenerationFreq.TabIndex = 2;
            this.GrpEnemyGenerationFreq.TabStop = false;
            this.GrpEnemyGenerationFreq.Text = "敌机产生频率";
            // 
            // LblEnemyGenFreq
            // 
            this.LblEnemyGenFreq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblEnemyGenFreq.AutoSize = true;
            this.LblEnemyGenFreq.Location = new System.Drawing.Point(234, 68);
            this.LblEnemyGenFreq.Name = "LblEnemyGenFreq";
            this.LblEnemyGenFreq.Size = new System.Drawing.Size(47, 12);
            this.LblEnemyGenFreq.TabIndex = 1;
            this.LblEnemyGenFreq.Text = "0 架/秒";
            // 
            // TbEnemyGenFreq
            // 
            this.TbEnemyGenFreq.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TbEnemyGenFreq.Location = new System.Drawing.Point(6, 20);
            this.TbEnemyGenFreq.Maximum = 15;
            this.TbEnemyGenFreq.Minimum = 1;
            this.TbEnemyGenFreq.Name = "TbEnemyGenFreq";
            this.TbEnemyGenFreq.Size = new System.Drawing.Size(275, 45);
            this.TbEnemyGenFreq.TabIndex = 0;
            this.TbEnemyGenFreq.Value = 1;
            this.TbEnemyGenFreq.ValueChanged += new System.EventHandler(this.TbEnemyGenFreq_ValueChanged);
            // 
            // ChkLiveForever
            // 
            this.ChkLiveForever.AutoSize = true;
            this.ChkLiveForever.Location = new System.Drawing.Point(6, 6);
            this.ChkLiveForever.Name = "ChkLiveForever";
            this.ChkLiveForever.Size = new System.Drawing.Size(72, 16);
            this.ChkLiveForever.TabIndex = 1;
            this.ChkLiveForever.Text = "无敌模式";
            this.ChkLiveForever.UseVisualStyleBackColor = true;
            // 
            // TpDevelopment
            // 
            this.TpDevelopment.Controls.Add(this.ChkShowDebugInfo);
            this.TpDevelopment.Location = new System.Drawing.Point(4, 22);
            this.TpDevelopment.Name = "TpDevelopment";
            this.TpDevelopment.Padding = new System.Windows.Forms.Padding(3);
            this.TpDevelopment.Size = new System.Drawing.Size(299, 303);
            this.TpDevelopment.TabIndex = 1;
            this.TpDevelopment.Text = "开发";
            this.TpDevelopment.UseVisualStyleBackColor = true;
            // 
            // ChkShowDebugInfo
            // 
            this.ChkShowDebugInfo.AutoSize = true;
            this.ChkShowDebugInfo.Location = new System.Drawing.Point(6, 6);
            this.ChkShowDebugInfo.Name = "ChkShowDebugInfo";
            this.ChkShowDebugInfo.Size = new System.Drawing.Size(96, 16);
            this.ChkShowDebugInfo.TabIndex = 3;
            this.ChkShowDebugInfo.Text = "显示调试信息";
            this.ChkShowDebugInfo.UseVisualStyleBackColor = true;
            // 
            // BtnOK
            // 
            this.BtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BtnOK.Location = new System.Drawing.Point(163, 347);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(75, 23);
            this.BtnOK.TabIndex = 1;
            this.BtnOK.Text = "确定(&O)";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(244, 347);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "取消(&C)";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmSettings
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(331, 382);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.TabControl);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "太空大战游戏配置系统";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.TabControl.ResumeLayout(false);
            this.TpGeneral.ResumeLayout(false);
            this.TpGeneral.PerformLayout();
            this.GrpEnemyGenerationFreq.ResumeLayout(false);
            this.GrpEnemyGenerationFreq.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TbEnemyGenFreq)).EndInit();
            this.TpDevelopment.ResumeLayout(false);
            this.TpDevelopment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage TpGeneral;
        private System.Windows.Forms.CheckBox ChkLiveForever;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TabPage TpDevelopment;
        private System.Windows.Forms.CheckBox ChkShowDebugInfo;
        private System.Windows.Forms.GroupBox GrpEnemyGenerationFreq;
        private System.Windows.Forms.Label LblEnemyGenFreq;
        private System.Windows.Forms.TrackBar TbEnemyGenFreq;

    }
}

