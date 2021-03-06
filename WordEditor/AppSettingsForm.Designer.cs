﻿namespace FAQ_Net
{
  partial class AppSettingsForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppSettingsForm));
      this.tvSettings = new System.Windows.Forms.TreeView();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.tsbSave = new System.Windows.Forms.ToolStripButton();
      this.tsbCancel = new System.Windows.Forms.ToolStripButton();
      this.tssbStyleIcons = new System.Windows.Forms.ToolStripSplitButton();
      this.tssbStyleThemes = new System.Windows.Forms.ToolStripSplitButton();
      this.tsbLoadSettingsFromFile = new System.Windows.Forms.ToolStripButton();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tvSettings
      // 
      this.tvSettings.Dock = System.Windows.Forms.DockStyle.Left;
      this.tvSettings.FullRowSelect = true;
      this.tvSettings.HideSelection = false;
      this.tvSettings.Location = new System.Drawing.Point(0, 25);
      this.tvSettings.Name = "tvSettings";
      this.tvSettings.ShowLines = false;
      this.tvSettings.ShowRootLines = false;
      this.tvSettings.Size = new System.Drawing.Size(276, 286);
      this.tvSettings.TabIndex = 0;
      this.tvSettings.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSettings_AfterSelect);
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbCancel,
            this.tssbStyleIcons,
            this.tssbStyleThemes,
            this.tsbLoadSettingsFromFile});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(530, 25);
      this.toolStrip1.TabIndex = 2;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // tsbSave
      // 
      this.tsbSave.Enabled = false;
      this.tsbSave.Image = global::FAQ_Net.Properties.Resources.SaveSml;
      this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbSave.Name = "tsbSave";
      this.tsbSave.Size = new System.Drawing.Size(85, 22);
      this.tsbSave.Text = "Сохранить";
      this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
      // 
      // tsbCancel
      // 
      this.tsbCancel.Enabled = false;
      this.tsbCancel.Image = global::FAQ_Net.Properties.Resources.No;
      this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbCancel.Name = "tsbCancel";
      this.tsbCancel.Size = new System.Drawing.Size(69, 22);
      this.tsbCancel.Text = "Отмена";
      this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
      // 
      // tssbStyleIcons
      // 
      this.tssbStyleIcons.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.tssbStyleIcons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.tssbStyleIcons.Image = ((System.Drawing.Image)(resources.GetObject("tssbStyleIcons.Image")));
      this.tssbStyleIcons.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tssbStyleIcons.Name = "tssbStyleIcons";
      this.tssbStyleIcons.Size = new System.Drawing.Size(65, 22);
      this.tssbStyleIcons.Text = "Иконки";
      this.tssbStyleIcons.ButtonClick += new System.EventHandler(this.tssbStyleIcons_ButtonClick);
      this.tssbStyleIcons.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tssbStyleIcons_DropDownItemClicked);
      // 
      // tssbStyleThemes
      // 
      this.tssbStyleThemes.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.tssbStyleThemes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.tssbStyleThemes.Image = ((System.Drawing.Image)(resources.GetObject("tssbStyleThemes.Image")));
      this.tssbStyleThemes.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tssbStyleThemes.Name = "tssbStyleThemes";
      this.tssbStyleThemes.Size = new System.Drawing.Size(54, 22);
      this.tssbStyleThemes.Text = "Темы";
      this.tssbStyleThemes.ButtonClick += new System.EventHandler(this.tssbStyleThemes_ButtonClick);
      this.tssbStyleThemes.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tssbStyleThemes_DropDownItemClicked);
      // 
      // tsbLoadSettingsFromFile
      // 
      this.tsbLoadSettingsFromFile.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.tsbLoadSettingsFromFile.Image = global::FAQ_Net.Properties.Resources.OpenSml;
      this.tsbLoadSettingsFromFile.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbLoadSettingsFromFile.Name = "tsbLoadSettingsFromFile";
      this.tsbLoadSettingsFromFile.Size = new System.Drawing.Size(195, 22);
      this.tsbLoadSettingsFromFile.Text = "Загрузить настройки из файла";
      this.tsbLoadSettingsFromFile.Click += new System.EventHandler(this.tsbLoadSettingsFromFile_Click);
      // 
      // AppSettingsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(530, 311);
      this.Controls.Add(this.tvSettings);
      this.Controls.Add(this.toolStrip1);
      this.MinimumSize = new System.Drawing.Size(420, 350);
      this.Name = "AppSettingsForm";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Настройки внешнего вида";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppSettingsForm_FormClosing);
      this.Shown += new System.EventHandler(this.AppSettingsForm_Shown);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TreeView tvSettings;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton tsbSave;
    private System.Windows.Forms.ToolStripButton tsbCancel;
    private System.Windows.Forms.ToolStripSplitButton tssbStyleThemes;
    private System.Windows.Forms.ToolStripButton tsbLoadSettingsFromFile;
    private System.Windows.Forms.ToolStripSplitButton tssbStyleIcons;
  }
}