﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using GradientControls;

namespace FAQ_Net
{
  public partial class AppSettingsForm : Form
  {
    private CustomDesignControl[] _controls;
    //private object[] _controlsBeforeChange;
    private PropertyGridEx.PropertyGridEx _propertyGridEx;
    private const string BACK_COLOR_PROP_NAME = "Цвет фона";
    private const string HEADER_STYLE_BACK_COLOR_PROP_NAME = "Цвет заголовка";
    private const string HEADER_STYLE_FONT_PROP_NAME = "Шрифт заголовка";
    private const string CELL_FONT_PROP_NAME = "Шрифт ячеек";
    private const string CELL_FORE_COLOR = "Цвет шрифта ячеек";
    private const string HEADER_FORE_COLOR = "Цвет шрифта заголовка";
    private const string FONT_PROP_NAME = "Шрифт";
    private const string CATEGORY_DESIGN_VIEW = "Внешний вид";
    private const string FORE_COLOR_PROP_NAME = "Цвет шрифта";
    private const string BACK_COLOR_MODE = "Тип заливки";
    private const string BACK_COLOR2_PROP_NAME = "Цвет фона (градиент)";
    private const string GRADIENT_MODE_PROP_NAME = "Тип градиента";
    private const string MENU_COLOR1 = "Цвет1. Фон при наведении корневого пункта";
    private const string MENU_COLOR2 = "Цвет2. Фон выбранного пункта";
    private const string MENU_COLOR3 = "Цвет3. Разделитель пунктов";
    private const string MENU_COLOR4 = "Цвет4. Чекбокс при наведении";
    private const string MENU_COLOR5 = "Цвет5. Оконтовка выбранного пункта";
    private const string MENU_COLOR6 = "Цвет6. Цвет шрифта";
    private const string MENU_COLOR7 = "Цвет7. Чекбокс";

    public AppSettingsForm(CustomDesignControl[] customDesignControls)
    {
      InitializeComponent();

      MainForm._settingsXml.LoadFormPosition(this);

      // Создать компонент с расширенными свойствами
      _propertyGridEx = new PropertyGridEx.PropertyGridEx();
      _propertyGridEx.ShowCustomProperties = true;
      _propertyGridEx.Dock = DockStyle.Fill;
      _propertyGridEx.Parent = this;
      _propertyGridEx.BringToFront();
      _propertyGridEx.PropertyValueChanged += _propertyGridEx_PropertyValueChanged;

      _controls = customDesignControls;

      foreach (CustomDesignControl cntrl in customDesignControls)
      {
        if (cntrl == null)
          continue;
        TreeNode addedTreeNode = null;
        if (cntrl.Description != null)
          addedTreeNode = tvSettings.Nodes.Add(cntrl.Description);
        else
          addedTreeNode = tvSettings.Nodes.Add(cntrl.SettingId);

        // Загрузить пользовательские настройки
        tvSettings.SelectedNode = addedTreeNode;
        ParseProperty(ParseType.LoadFromFile);
      }
    }

    private void _propertyGridEx_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
    {
      if (tvSettings.SelectedNode != null)
      {
        try
        {
          Control control = (Control)_controls[tvSettings.SelectedNode.Index].ObjectControl;
          PropertyGridEx.CustomProperty backColorProperty = null;
          foreach (PropertyGridEx.CustomProperty prop in _propertyGridEx.Item)
          {
            switch (prop.Name)
            {
              case BACK_COLOR_PROP_NAME:
                backColorProperty = prop;
                //if (control is DataGridView)
                //{
                //  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                //    (control as DataGridView).BackgroundColor = (Color)prop.Value;
                //}
                //else
                //if (control is TabControl)
                //{
                //  TabControl tc = control as TabControl;
                //  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                //  {
                //    foreach(TabPage tp in tc.TabPages)
                //      tp.BackColor = (Color)prop.Value;
                //  }
                //}
                //else
                //{
                //  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                //    control.BackColor = (Color)prop.Value;
                //}
                break;
              case HEADER_STYLE_BACK_COLOR_PROP_NAME:
                if (control is DataGridView)
                {
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                    (control as DataGridView).ColumnHeadersDefaultCellStyle.BackColor = (Color)prop.Value;
                }
                break;
              case HEADER_STYLE_FONT_PROP_NAME:
                if (control is DataGridView)
                {
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                    (control as DataGridView).ColumnHeadersDefaultCellStyle.Font = (Font)prop.Value;
                }
                break;
              case CELL_FONT_PROP_NAME:
                if (control is DataGridView)
                {
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                    (control as DataGridView).DefaultCellStyle.Font = (Font)prop.Value;
                }
                break;
              case FONT_PROP_NAME:
                if (prop.Value != null && prop.Value.ToString() != string.Empty)
                  control.Font = (Font)prop.Value;
                break;
              case FORE_COLOR_PROP_NAME:
                if (control is DataGridView)
                {
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                    (control as DataGridView).DefaultCellStyle.ForeColor = (Color)prop.Value;
                }
                else
                if (control is TabControl)
                {
                  TabControl tc = control as TabControl;
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                  {
                    foreach (TabPage tp in tc.TabPages)
                      tp.ForeColor = (Color)prop.Value;
                  }
                }
                else
                {
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                    control.ForeColor = (Color)prop.Value;
                }
                break;
              case CELL_FORE_COLOR:
                if (control is DataGridView)
                {
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                    (control as DataGridView).DefaultCellStyle.ForeColor = (Color)prop.Value;
                }
                break;
              case HEADER_FORE_COLOR:
                if (control is DataGridView)
                {
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                    (control as DataGridView).ColumnHeadersDefaultCellStyle.ForeColor = (Color)prop.Value;
                }
                break;
              case BACK_COLOR_MODE:
                if (prop.Value != null && prop.Value.ToString() != string.Empty)
                {
                  (control as IGradientControl).FillColorType = (GradientControls.GradientEnums.FillColorMode)prop.Value;
                  //(control as IGradientControl).GradientFillControl_Paint(null, null);
                }
                if (control is GradientControls.TabControlGradient)
                {
                  GradientControls.TabControlGradient tc = control as GradientControls.TabControlGradient;
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                  {
                    foreach (TabPage tp in tc.TabPages)
                    {
                      (tp as GradientControls.TabPageGradient).FillColorType = tc.FillColorType;
                    }
                  }
                }
                if (control is GradientControls.StatusStripGradient)
                {
                  (control as GradientControls.StatusStripGradient).BackColor = Color.Transparent;
                  foreach (ToolStripItem statusItem in (control as GradientControls.StatusStripGradient).Items)
                    statusItem.BackColor = Color.Transparent;
                }
                if (control is GradientControls.PanelGradient)
                {
                  GradientControls.PanelGradient panel = control as GradientControls.PanelGradient;
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                  {
                    foreach (Control cntrl in panel.Controls)
                    {
                      if (cntrl is Label || cntrl is CheckBox || cntrl is RadioButton)
                        cntrl.BackColor = Color.Transparent;
                    }
                  }
                }
                break;
              case BACK_COLOR2_PROP_NAME:
                if (prop.Value != null && prop.Value.ToString() != string.Empty)
                  (control as IGradientControl).BackColorBottom = (Color)prop.Value;
                if (control is GradientControls.TabControlGradient)
                {
                  GradientControls.TabControlGradient tc = control as GradientControls.TabControlGradient;
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                  {
                    foreach (TabPage tp in tc.TabPages)
                    {
                      GradientControls.TabPageGradient tpg = tp as GradientControls.TabPageGradient;
                      tpg.BackColorBottom = (Color)prop.Value;
                    }
                  }
                }
                if (control is GradientControls.StatusStripGradient)
                {
                  (control as GradientControls.StatusStripGradient).BackColor = Color.Transparent;
                  foreach (ToolStripItem statusItem in (control as GradientControls.StatusStripGradient).Items)
                    statusItem.BackColor = Color.Transparent;
                }
                if (control is GradientControls.PanelGradient)
                {
                  GradientControls.PanelGradient panel = control as GradientControls.PanelGradient;
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                  {
                    foreach (Control cntrl in panel.Controls)
                    {
                      if (cntrl is Label || cntrl is CheckBox || cntrl is RadioButton)
                        cntrl.BackColor = Color.Transparent;
                    }
                  }
                }
                break;
              case GRADIENT_MODE_PROP_NAME:
                if (prop.Value != null && prop.Value.ToString() != string.Empty)
                  (control as IGradientControl).GradientMode = (System.Drawing.Drawing2D.LinearGradientMode)prop.Value;
                if (control is GradientControls.TabControlGradient)
                {
                  GradientControls.TabControlGradient tc = control as GradientControls.TabControlGradient;
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                  {
                    foreach (TabPage tp in tc.TabPages)
                    {
                      GradientControls.TabPageGradient tpg = tp as GradientControls.TabPageGradient;
                      tpg.GradientMode = (System.Drawing.Drawing2D.LinearGradientMode)prop.Value;
                    }
                  }
                }
                if (control is GradientControls.StatusStripGradient)
                {
                  (control as GradientControls.StatusStripGradient).BackColor = Color.Transparent;
                  foreach (ToolStripItem statusItem in (control as GradientControls.StatusStripGradient).Items)
                    statusItem.BackColor = Color.Transparent;
                }
                if (control is GradientControls.PanelGradient)
                {
                  GradientControls.PanelGradient panel = control as GradientControls.PanelGradient;
                  if (prop.Value != null && prop.Value.ToString() != string.Empty)
                  {
                    foreach (Control cntrl in panel.Controls)
                    {
                      if (cntrl is Label || cntrl is CheckBox || cntrl is RadioButton)
                        cntrl.BackColor = Color.Transparent;
                    }
                  }
                }
                break;
              case MENU_COLOR1:
                if (prop.Value != null && prop.Value.ToString() != string.Empty)
                  (control as GradientControls.MenuStripZ).MenuColor1 = (Color)prop.Value;
                break;
              case MENU_COLOR2:
                if (prop.Value != null && prop.Value.ToString() != string.Empty)
                  (control as GradientControls.MenuStripZ).MenuColor2 = (Color)prop.Value;
                break;
              case MENU_COLOR3:
                if (prop.Value != null && prop.Value.ToString() != string.Empty)
                  (control as GradientControls.MenuStripZ).MenuColor3 = (Color)prop.Value;
                break;
              case MENU_COLOR4:
                if (prop.Value != null && prop.Value.ToString() != string.Empty)
                  (control as GradientControls.MenuStripZ).MenuColor4 = (Color)prop.Value;
                break;
              case MENU_COLOR5:
                if (prop.Value != null && prop.Value.ToString() != string.Empty)
                  (control as GradientControls.MenuStripZ).MenuColor5 = (Color)prop.Value;
                break;
              case MENU_COLOR6:
                if (prop.Value != null && prop.Value.ToString() != string.Empty)
                  (control as GradientControls.MenuStripZ).MenuColor6 = (Color)prop.Value;
                break;
              case MENU_COLOR7:
                if (prop.Value != null && prop.Value.ToString() != string.Empty)
                  (control as GradientControls.MenuStripZ).MenuColor7 = (Color)prop.Value;
                break;
                //case HEADER_BACK_COLOR_PROP_NAME:
                //  if (control is DataGridView)
                //  {
                //    if (prop.Value != null && prop.Value.ToString() != string.Empty)
                //      (control as DataGridView).ColumnHeadersDefaultCellStyle.BackColor = (Color)prop.Value;
                //  }
                //  break;
            }
          }
          if (backColorProperty != null)
          {
            if (control is DataGridView)
            {
              if (backColorProperty.Value != null && backColorProperty.Value.ToString() != string.Empty)
                (control as DataGridView).BackgroundColor = (Color)backColorProperty.Value;
            }
            else
            if (control is TabControl)
            {
              TabControl tc = control as TabControl;
              if (backColorProperty.Value != null && backColorProperty.Value.ToString() != string.Empty)
              {
                foreach (TabPage tp in tc.TabPages)
                  tp.BackColor = (Color)backColorProperty.Value;
              }
            }
            else
            if (control is GradientControls.PanelGradient)
            {
              GradientControls.PanelGradient panel = control as GradientControls.PanelGradient;
              if (backColorProperty.Value != null && backColorProperty.Value.ToString() != string.Empty)
              {
                control.BackColor = (Color)backColorProperty.Value;
                foreach (Control cntrl in panel.Controls)
                {
                  if (cntrl is Label || cntrl is CheckBox || cntrl is RadioButton)
                    cntrl.BackColor = Color.Transparent;
                }
              }
            }
            else
            {
              if (backColorProperty.Value != null && backColorProperty.Value.ToString() != string.Empty)
                control.BackColor = (Color)backColorProperty.Value;
            }
          }
          tsbSave.Enabled = true;
          tsbCancel.Enabled = true;
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }

    private void SaveDesignSettings()
    {
      MainForm mf = Application.OpenForms[0] as MainForm;
      MainApp.WaitForm.Show(this);
      mf.SetStatusLabel("Сохранение настроек внешнего вида");
      this.Invoke((MethodInvoker)delegate
      {
        RefreshPropertiesForControlsBeforeChange(true);
        tsbSave.Enabled = false;
        tsbCancel.Enabled = false;
      });
      mf.SetStatusLabel("Настройки внешнего вида успешно сохранены");
      MainApp.WaitForm.Close();
    }

    private void tsbSave_Click(object sender, EventArgs e)
    {
      System.Threading.Thread th = new System.Threading.Thread(SaveDesignSettings);
      th.Start();
    }

    enum ParseType
    {
      SaveToFile,
      LoadFromFile,
      LoadFromControl
    }

    private void ParseProperty(ParseType parseType)
    {
      //_propertyGridEx.SelectedObject = _controls[0]
      CustomDesignControl customDesignControl = (CustomDesignControl)_controls[tvSettings.SelectedNode.Index];
      Control cntrl = (Control)_controls[tvSettings.SelectedNode.Index].ObjectControl;
      if (cntrl == null)
        return;
      PropertyInfo[] properties = cntrl.GetType().GetProperties();
      if (parseType == ParseType.LoadFromControl)
        _propertyGridEx.Item.Clear();
      foreach (PropertyInfo pi in properties)
      {
        switch (pi.Name)
        {
          case "Font":
            if (cntrl is DataGridView)
              continue;
            if (cntrl is ToolStrip)
              continue;
            if (cntrl is RichTextBox)
              continue;
            cntrl.Font = ParseFontDesignSetting(parseType, cntrl, FONT_PROP_NAME, cntrl.Font, customDesignControl.SettingId);
            break;
          case "BackColor":
            if (cntrl is DataGridView)
              continue;
            if (cntrl is GradientControls.TabControlGradient)
            {
              GradientControls.TabControlGradient tcg = cntrl as GradientControls.TabControlGradient;
              foreach (GradientControls.TabPageGradient tp in (((GradientControls.TabControlGradient)cntrl).TabPages))
              {
                //tp.BackColor = ParseColorDesignSetting(parseType, (TabControl)cntrl, BACK_COLOR_PROP_NAME, cntrl.BackColor);
                string fillColorType = ParseEnumDesignSetting(parseType, (GradientControls.TabControlGradient)cntrl, BACK_COLOR_MODE, tp.FillColorType.ToString(), customDesignControl.SettingId, typeof(GradientEnums.FillColorMode));
                tp.FillColorType = (GradientEnums.FillColorMode)EnumString.GetValue(fillColorType, typeof(GradientEnums.FillColorMode));
                tp.BackColor = ParseColorDesignSetting(parseType, (GradientControls.TabControlGradient)cntrl, BACK_COLOR_PROP_NAME, tp.BackColor, customDesignControl.SettingId);
                //tp.BackColorTop = ParseColorDesignSetting(parseType, (GradientControls.TabControlGradient)cntrl, BACK_COLOR_MODE, tp.BackColorTop, customDesignControl.SettingId);
                tp.BackColorBottom = ParseColorDesignSetting(parseType, (GradientControls.TabControlGradient)cntrl, BACK_COLOR2_PROP_NAME, tp.BackColorBottom, customDesignControl.SettingId);
                string gradientMode = ParseEnumDesignSetting(parseType, (GradientControls.TabControlGradient)cntrl, GRADIENT_MODE_PROP_NAME, tp.GradientMode.ToString(), customDesignControl.SettingId, typeof(System.Drawing.Drawing2D.LinearGradientMode));
                tp.GradientMode = (System.Drawing.Drawing2D.LinearGradientMode)EnumString.GetValue(gradientMode, typeof(System.Drawing.Drawing2D.LinearGradientMode));
                foreach (Control ctrl in tp.Controls)
                {
                  try
                  {
                    if (ctrl is Label || ctrl is Panel)
                      ctrl.BackColor = Color.Transparent;
                  }
                  catch (Exception) { }
                }
              }
              continue;
            }
            else
            if (cntrl is IGradientControl)
            {
              IGradientControl gradientControl = cntrl as IGradientControl;
              string fillColorType = ParseEnumDesignSetting(parseType, gradientControl, BACK_COLOR_MODE, gradientControl.FillColorType.ToString(), customDesignControl.SettingId, typeof(GradientEnums.FillColorMode));
              (cntrl as IGradientControl).FillColorType = (GradientEnums.FillColorMode)EnumString.GetValue(fillColorType, typeof(GradientEnums.FillColorMode));
              //tp.BackColorTop = ParseColorDesignSetting(parseType, (GradientControls.TabControlGradient)cntrl, BACK_COLOR_MODE, tp.BackColorTop, customDesignControl.SettingId);
              (cntrl as IGradientControl).BackColorBottom = ParseColorDesignSetting(parseType, cntrl, BACK_COLOR2_PROP_NAME, gradientControl.BackColorBottom, customDesignControl.SettingId);
              string gradientMode = ParseEnumDesignSetting(parseType, gradientControl, GRADIENT_MODE_PROP_NAME, gradientControl.GradientMode.ToString(), customDesignControl.SettingId, typeof(System.Drawing.Drawing2D.LinearGradientMode));
              (cntrl as IGradientControl).GradientMode = (System.Drawing.Drawing2D.LinearGradientMode)EnumString.GetValue(gradientMode, typeof(System.Drawing.Drawing2D.LinearGradientMode));
              if (cntrl is GradientControls.PanelGradient)
              {
                foreach (Control ctrl in (cntrl as PanelGradient).Controls)
                {
                  try
                  {
                    if (ctrl is Label)
                      ctrl.BackColor = Color.Transparent;
                  }
                  catch (Exception) { }
                }
              }
              if (cntrl is StatusStripGradient)
              {
                foreach (ToolStripItem statusItem in (cntrl as GradientControls.StatusStripGradient).Items)
                {
                  statusItem.BackColor = Color.Transparent;
                  statusItem.ForeColor = cntrl.ForeColor;
                }
              }
            }
            if (cntrl is GradientControls.MenuStripZ)
            {
              GradientControls.MenuStripZ msz = cntrl as GradientControls.MenuStripZ;
              msz.MenuColor1 = ParseColorDesignSetting(parseType, cntrl, MENU_COLOR1, msz.MenuColor1, customDesignControl.SettingId);
              msz.MenuColor2 = ParseColorDesignSetting(parseType, cntrl, MENU_COLOR2, msz.MenuColor2, customDesignControl.SettingId);
              msz.MenuColor3 = ParseColorDesignSetting(parseType, cntrl, MENU_COLOR3, msz.MenuColor3, customDesignControl.SettingId);
              msz.MenuColor4 = ParseColorDesignSetting(parseType, cntrl, MENU_COLOR4, msz.MenuColor4, customDesignControl.SettingId);
              msz.MenuColor5 = ParseColorDesignSetting(parseType, cntrl, MENU_COLOR5, msz.MenuColor5, customDesignControl.SettingId);
              msz.MenuColor6 = ParseColorDesignSetting(parseType, cntrl, MENU_COLOR6, msz.MenuColor6, customDesignControl.SettingId);
              msz.MenuColor7 = ParseColorDesignSetting(parseType, cntrl, MENU_COLOR7, msz.MenuColor7, customDesignControl.SettingId);
            }
            cntrl.BackColor = ParseColorDesignSetting(parseType, cntrl, BACK_COLOR_PROP_NAME, cntrl.BackColor, customDesignControl.SettingId);
            break;
          case "BackgroundColor":
            if (cntrl is DataGridView)
            {
              ((DataGridView)cntrl).BackgroundColor = ParseColorDesignSetting(parseType, cntrl, BACK_COLOR_PROP_NAME, ((DataGridView)cntrl).BackgroundColor, customDesignControl.SettingId);
            }
            break;
          case "ColumnHeadersDefaultCellStyle":
            if (cntrl is DataGridView)
            {
              ((DataGridView)cntrl).ColumnHeadersDefaultCellStyle.BackColor = ParseColorDesignSetting(parseType, cntrl, HEADER_STYLE_BACK_COLOR_PROP_NAME, ((DataGridView)cntrl).ColumnHeadersDefaultCellStyle.BackColor, customDesignControl.SettingId);
              ((DataGridView)cntrl).ColumnHeadersDefaultCellStyle.Font = ParseFontDesignSetting(parseType, cntrl, HEADER_STYLE_FONT_PROP_NAME, ((DataGridView)cntrl).ColumnHeadersDefaultCellStyle.Font, customDesignControl.SettingId);
              ((DataGridView)cntrl).DefaultCellStyle.Font = ParseFontDesignSetting(parseType, cntrl, CELL_FONT_PROP_NAME, ((DataGridView)cntrl).DefaultCellStyle.Font, customDesignControl.SettingId);
              ((DataGridView)cntrl).DefaultCellStyle.ForeColor = ParseColorDesignSetting(parseType, cntrl, CELL_FORE_COLOR, ((DataGridView)cntrl).DefaultCellStyle.ForeColor, customDesignControl.SettingId);
              ((DataGridView)cntrl).ColumnHeadersDefaultCellStyle.ForeColor = ParseColorDesignSetting(parseType, cntrl, HEADER_FORE_COLOR, ((DataGridView)cntrl).ColumnHeadersDefaultCellStyle.ForeColor, customDesignControl.SettingId);
            }
            break;
          case "ForeColor":
            if (cntrl is DataGridView)
              continue;
            if (cntrl is ToolStrip)
              continue;
            if (cntrl is RichTextBox)
              continue;
            cntrl.ForeColor = ParseColorDesignSetting(parseType, cntrl, FORE_COLOR_PROP_NAME, cntrl.ForeColor, customDesignControl.SettingId);
            break;
            //default:
            //  _propertyGridEx.Item.Add(pi.Name, string.Empty, false, pi.PropertyType.Name, string.Empty, true);
            //  break;
        }
      }
      if (parseType == ParseType.LoadFromControl)
        _propertyGridEx.Refresh();
    }

    private string ParseEnumDesignSetting(ParseType parseType, IGradientControl cntrl, string customPropertyName, string valueStr, string settingId, Type tyEnum)
    {
      string result = string.Empty;
      if (tyEnum.Equals(typeof(GradientEnums.FillColorMode)))
        result = Enum.Parse(typeof(GradientEnums.FillColorMode), valueStr).ToString();
      if (tyEnum.Equals(typeof(System.Drawing.Drawing2D.LinearGradientMode)))
        result = Enum.Parse(typeof(System.Drawing.Drawing2D.LinearGradientMode), valueStr).ToString();
      if (parseType == ParseType.SaveToFile)
        MainForm._settingsXml.SetSetting(string.Format("{0}_{1}", settingId, customPropertyName), valueStr);
      else
      if (parseType == ParseType.LoadFromFile)
      {
        string str = MainForm._settingsXml.GetSetting(string.Format("{0}_{1}", settingId, customPropertyName));
        if (!string.IsNullOrEmpty(str))
        {
          result = str;
        }
      }
      else
      if (parseType == ParseType.LoadFromControl)
      {
        if (cntrl is GradientControls.TabControlGradient)
        {
          GradientControls.TabControlGradient tabControlGradient = cntrl as GradientControls.TabControlGradient;
          switch (customPropertyName)
          {
            case BACK_COLOR_MODE:
              AddPropertyIfNotExists(tabControlGradient, customPropertyName, (tabControlGradient.TabPages[0] as GradientControls.TabPageGradient).FillColorType, CATEGORY_DESIGN_VIEW);
              break;
            case GRADIENT_MODE_PROP_NAME:
              AddPropertyIfNotExists(tabControlGradient, customPropertyName, (tabControlGradient.TabPages[0] as GradientControls.TabPageGradient).GradientMode, CATEGORY_DESIGN_VIEW);
              break;
            case BACK_COLOR2_PROP_NAME:
              AddPropertyIfNotExists(tabControlGradient, customPropertyName, (tabControlGradient.TabPages[0] as GradientControls.TabPageGradient).BackColorBottom, CATEGORY_DESIGN_VIEW);
              break;
            case BACK_COLOR_PROP_NAME:
              AddPropertyIfNotExists(tabControlGradient, customPropertyName, tabControlGradient.TabPages[0].BackColor, CATEGORY_DESIGN_VIEW);
              break;
            case FORE_COLOR_PROP_NAME:
              AddPropertyIfNotExists(tabControlGradient, customPropertyName, tabControlGradient.TabPages[0].ForeColor, CATEGORY_DESIGN_VIEW);
              break;
          }
        }
        else
        //  if (cntrl is DataGridView)
        //  {
        //    switch (customPropertyName)
        //    {
        //      case BACK_COLOR_PROP_NAME:
        //        AddPropertyIfNotExists(cntrl, customPropertyName, ((DataGridView)cntrl).BackgroundColor, CATEGORY_DESIGN_VIEW);
        //        break;
        //      case HEADER_STYLE_BACK_COLOR_PROP_NAME:
        //        AddPropertyIfNotExists(cntrl, customPropertyName, ((DataGridView)cntrl).ColumnHeadersDefaultCellStyle.BackColor, CATEGORY_DESIGN_VIEW);
        //        break;
        //      case CELL_FORE_COLOR:
        //        AddPropertyIfNotExists(cntrl, customPropertyName, ((DataGridView)cntrl).DefaultCellStyle.ForeColor, CATEGORY_DESIGN_VIEW);
        //        break;
        //      case HEADER_FORE_COLOR:
        //        AddPropertyIfNotExists(cntrl, customPropertyName, ((DataGridView)cntrl).ColumnHeadersDefaultCellStyle.ForeColor, CATEGORY_DESIGN_VIEW);
        //        break;
        //      default:
        //        AddPropertyIfNotExists(cntrl, customPropertyName, null, CATEGORY_DESIGN_VIEW);
        //        break;
        //    }
        //  }
        //  else
        {
          switch (customPropertyName)
          {
            case BACK_COLOR_PROP_NAME:
              //_propertyGridEx.Item.Add("Имя свойства", "Значение по-умолчанию", readOnly, "Категория", "Описание", visible);
              AddPropertyIfNotExists(cntrl as Control, customPropertyName, cntrl.BackColor, CATEGORY_DESIGN_VIEW);
              break;
            case FORE_COLOR_PROP_NAME:
              AddPropertyIfNotExists(cntrl as Control, customPropertyName, cntrl.ForeColor, CATEGORY_DESIGN_VIEW);
              break;
            case BACK_COLOR_MODE:
              AddPropertyIfNotExists(cntrl as Control, customPropertyName, ((GradientControls.IGradientControl)cntrl).FillColorType, CATEGORY_DESIGN_VIEW);
              break;
            case GRADIENT_MODE_PROP_NAME:
              AddPropertyIfNotExists(cntrl as Control, customPropertyName, ((GradientControls.IGradientControl)cntrl).GradientMode, CATEGORY_DESIGN_VIEW);
              break;
            case BACK_COLOR2_PROP_NAME:
              AddPropertyIfNotExists(cntrl as Control, customPropertyName, ((GradientControls.IGradientControl)cntrl).BackColorBottom, CATEGORY_DESIGN_VIEW);
              break;
            case MENU_COLOR1:
              AddPropertyIfNotExists(cntrl as Control, customPropertyName, ((GradientControls.MenuStripZ)cntrl).MenuColor1, CATEGORY_DESIGN_VIEW);
              break;
            case MENU_COLOR2:
              AddPropertyIfNotExists(cntrl as Control, customPropertyName, ((GradientControls.MenuStripZ)cntrl).MenuColor2, CATEGORY_DESIGN_VIEW);
              break;
            case MENU_COLOR3:
              AddPropertyIfNotExists(cntrl as Control, customPropertyName, ((GradientControls.MenuStripZ)cntrl).MenuColor3, CATEGORY_DESIGN_VIEW);
              break;
            case MENU_COLOR4:
              AddPropertyIfNotExists(cntrl as Control, customPropertyName, ((GradientControls.MenuStripZ)cntrl).MenuColor4, CATEGORY_DESIGN_VIEW);
              break;
            case MENU_COLOR5:
              AddPropertyIfNotExists(cntrl as Control, customPropertyName, ((GradientControls.MenuStripZ)cntrl).MenuColor5, CATEGORY_DESIGN_VIEW);
              break;
            case MENU_COLOR6:
              AddPropertyIfNotExists(cntrl as Control, customPropertyName, ((GradientControls.MenuStripZ)cntrl).MenuColor6, CATEGORY_DESIGN_VIEW);
              break;
            case MENU_COLOR7:
              AddPropertyIfNotExists(cntrl as Control, customPropertyName, ((GradientControls.MenuStripZ)cntrl).MenuColor7, CATEGORY_DESIGN_VIEW);
              break;
          }
        }
      }
      return result;
    }
    
    private void SaveDesignSetting(Control cntrl, string value)
    {
      MainForm._settingsXml.SetSetting(string.Format("{0}_{1}", cntrl.Tag.ToString(), BACK_COLOR_PROP_NAME), value);
    }

    private Font ParseFontDesignSetting(ParseType parseType, Control cntrl, string customPropertyName, Font fontValue, string settingId)
    {
      var cvt = new FontConverter();
      Font resultFont = fontValue;
      if (parseType == ParseType.SaveToFile)
      {
        string fontString = cvt.ConvertToString(fontValue);
        MainForm._settingsXml.SetSetting(string.Format("{0}_{1}", settingId, customPropertyName), fontString);
      }
      else
      if (parseType == ParseType.LoadFromFile)
      {
        //string s = cvt.ConvertToString(this.Font);
        string str = MainForm._settingsXml.GetSetting(string.Format("{0}_{1}", settingId, customPropertyName));
        if (!string.IsNullOrEmpty(str))
          resultFont = cvt.ConvertFromString(str) as Font;
      }
      else
      if (parseType == ParseType.LoadFromControl)
      {

        if (cntrl is DataGridView)
        {
          switch (customPropertyName)
          {
            case HEADER_STYLE_FONT_PROP_NAME:
              _propertyGridEx.Item.Add(customPropertyName, ((DataGridView)cntrl).ColumnHeadersDefaultCellStyle.Font, false, CATEGORY_DESIGN_VIEW, customPropertyName, true);
              break;
            case CELL_FONT_PROP_NAME:
              _propertyGridEx.Item.Add(customPropertyName, ((DataGridView)cntrl).DefaultCellStyle.Font, false, CATEGORY_DESIGN_VIEW, customPropertyName, true);
              break;
            case CELL_FORE_COLOR:
              _propertyGridEx.Item.Add(customPropertyName, ((DataGridView)cntrl).DefaultCellStyle.ForeColor, false, CATEGORY_DESIGN_VIEW, customPropertyName, true);
              break;
            default:
              _propertyGridEx.Item.Add(customPropertyName, null, false, CATEGORY_DESIGN_VIEW, customPropertyName, true);
              break;
          }
        }
        else
          //_propertyGridEx.Item.Add("Имя свойства", "Значение по-умолчанию", readOnly, "Категория", "Описание", visible);
          _propertyGridEx.Item.Add(customPropertyName, cntrl.Font, false, CATEGORY_DESIGN_VIEW, customPropertyName, true);
      }
      return resultFont;
    }

    private Color ParseColorDesignSetting(ParseType parseType, Control cntrl, string customPropertyName, Color colorValue, string settingId)
    {
      Color resultColor = colorValue;
      if (parseType == ParseType.SaveToFile)
        MainForm._settingsXml.SetSetting(string.Format("{0}_{1}", settingId, customPropertyName), colorValue.ToArgb().ToString());
      else
      if (parseType == ParseType.LoadFromFile)
      {
        string str = MainForm._settingsXml.GetSetting(string.Format("{0}_{1}", settingId, customPropertyName));
        if (!string.IsNullOrEmpty(str))
          resultColor = (Color.FromArgb(Convert.ToInt32(str)));
      }
      else
      if (parseType == ParseType.LoadFromControl)
      {
        if (cntrl is TabControl)
        {
          switch (customPropertyName)
          {
            case BACK_COLOR_PROP_NAME:
              AddPropertyIfNotExists(cntrl, customPropertyName, ((TabControl)cntrl).TabPages[0].BackColor, CATEGORY_DESIGN_VIEW);
              break;
            case BACK_COLOR2_PROP_NAME:
              AddPropertyIfNotExists(cntrl, customPropertyName, (((TabControlGradient)cntrl).TabPages[0] as GradientControls.TabPageGradient).BackColorBottom, CATEGORY_DESIGN_VIEW);
              break;
            case GRADIENT_MODE_PROP_NAME:
              AddPropertyIfNotExists(cntrl, customPropertyName, (((TabControlGradient)cntrl).TabPages[0] as GradientControls.TabPageGradient).GradientMode, CATEGORY_DESIGN_VIEW);
              break;
            case BACK_COLOR_MODE:
              AddPropertyIfNotExists(cntrl, customPropertyName, (((TabControlGradient)cntrl).TabPages[0] as GradientControls.TabPageGradient).FillColorType, CATEGORY_DESIGN_VIEW);
              break;
            case FORE_COLOR_PROP_NAME:
              AddPropertyIfNotExists(cntrl, customPropertyName, ((TabControl)cntrl).TabPages[0].ForeColor, CATEGORY_DESIGN_VIEW);
              break;
          }
        }
        else
        if (cntrl is DataGridView)
        {
          switch (customPropertyName)
          {
            case BACK_COLOR_PROP_NAME:
              AddPropertyIfNotExists(cntrl, customPropertyName, ((DataGridView)cntrl).BackgroundColor, CATEGORY_DESIGN_VIEW);
              break;
            case HEADER_STYLE_BACK_COLOR_PROP_NAME:
              AddPropertyIfNotExists(cntrl, customPropertyName, ((DataGridView)cntrl).ColumnHeadersDefaultCellStyle.BackColor, CATEGORY_DESIGN_VIEW);
              break;
            case CELL_FORE_COLOR:
              AddPropertyIfNotExists(cntrl, customPropertyName, ((DataGridView)cntrl).DefaultCellStyle.ForeColor, CATEGORY_DESIGN_VIEW);
              break;
            case HEADER_FORE_COLOR:
              AddPropertyIfNotExists(cntrl, customPropertyName, ((DataGridView)cntrl).ColumnHeadersDefaultCellStyle.ForeColor, CATEGORY_DESIGN_VIEW);
              break;
            default:
              AddPropertyIfNotExists(cntrl, customPropertyName, null, CATEGORY_DESIGN_VIEW);
              break;
          }
        }
        else
        {
          switch (customPropertyName)
          {
            case BACK_COLOR_PROP_NAME:
              //_propertyGridEx.Item.Add("Имя свойства", "Значение по-умолчанию", readOnly, "Категория", "Описание", visible);
              AddPropertyIfNotExists(cntrl, customPropertyName, cntrl.BackColor, CATEGORY_DESIGN_VIEW);
              break;
            case FORE_COLOR_PROP_NAME:
              AddPropertyIfNotExists(cntrl, customPropertyName, cntrl.ForeColor, CATEGORY_DESIGN_VIEW);
              break;
            case BACK_COLOR_MODE:
              AddPropertyIfNotExists(cntrl, customPropertyName, ((GradientControls.IGradientControl)cntrl).FillColorType, CATEGORY_DESIGN_VIEW);
              break;
            case GRADIENT_MODE_PROP_NAME:
              AddPropertyIfNotExists(cntrl, customPropertyName, ((GradientControls.IGradientControl)cntrl).GradientMode, CATEGORY_DESIGN_VIEW);
              break;
            case BACK_COLOR2_PROP_NAME:
              AddPropertyIfNotExists(cntrl, customPropertyName, ((GradientControls.IGradientControl)cntrl).BackColorBottom, CATEGORY_DESIGN_VIEW);
              break;
            case MENU_COLOR1:
              AddPropertyIfNotExists(cntrl, customPropertyName, ((GradientControls.MenuStripZ)cntrl).MenuColor1, CATEGORY_DESIGN_VIEW);
              break;
            case MENU_COLOR2:
              AddPropertyIfNotExists(cntrl, customPropertyName, ((GradientControls.MenuStripZ)cntrl).MenuColor2, CATEGORY_DESIGN_VIEW);
              break;
            case MENU_COLOR3:
              AddPropertyIfNotExists(cntrl, customPropertyName, ((GradientControls.MenuStripZ)cntrl).MenuColor3, CATEGORY_DESIGN_VIEW);
              break;
            case MENU_COLOR4:
              AddPropertyIfNotExists(cntrl, customPropertyName, ((GradientControls.MenuStripZ)cntrl).MenuColor4, CATEGORY_DESIGN_VIEW);
              break;
            case MENU_COLOR5:
              AddPropertyIfNotExists(cntrl, customPropertyName, ((GradientControls.MenuStripZ)cntrl).MenuColor5, CATEGORY_DESIGN_VIEW);
              break;
            case MENU_COLOR6:
              AddPropertyIfNotExists(cntrl, customPropertyName, ((GradientControls.MenuStripZ)cntrl).MenuColor6, CATEGORY_DESIGN_VIEW);
              break;
            case MENU_COLOR7:
              AddPropertyIfNotExists(cntrl, customPropertyName, ((GradientControls.MenuStripZ)cntrl).MenuColor7, CATEGORY_DESIGN_VIEW);
              break;
          }
        }
      }
      return resultColor;
    }

    private void AddPropertyIfNotExists(Control cntrl, string customPropertyName, object value, string categoryName)
    {
      bool find = false;
      foreach (PropertyGridEx.CustomProperty prop in _propertyGridEx.Item)
      {
        if (prop.Name == customPropertyName)
        {
          find = true;
          break;
        }
      }
      if (!find)
        _propertyGridEx.Item.Add(customPropertyName, value, false, categoryName, customPropertyName, true);
    }

    private void tvSettings_AfterSelect(object sender, TreeViewEventArgs e)
    {
      ParseProperty(ParseType.LoadFromControl);
    }

    private void tsbCancel_Click(object sender, EventArgs e)
    {
      // Вернуть свойства компонента из его старой копии не получается (см.комментарии ниже),
      // поэтому используется перезагрузка приложения
      if (MessageBox.Show("Для отмены изменений требуется перезагрузка приложения. Перезапустить приложение?"
        , "Перезапустить приложение?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        Application.Restart();
        if (!MainForm.RestartApplicationCanceled)
          Application.ExitThread();
      }

      // Некоторые свойства компонентов по непонятным причинам не копируются в отдельный объект, а лишь ссылаются на это свойство
      // соответственно, при смене значения свойства изменения происходят не только в объекте-источнике, но и в объекте-назначения
      // например: у компонента DataGridView не копируется свойство DefaultCellStyle.Font
      // В связи с этим код закомментирован и неиспользуется, пока не найдется решение.
      //for (int i = 0; i < _controlsBeforeChange.Length; i++)
      //{
      //  PropertyInfo[] properties = null;
      //  properties = _controlsBeforeChange[i].GetType().GetProperties();
      //  if (_controlsBeforeChange[i] is DataGridView)
      //    properties = ((DataGridView)_controlsBeforeChange[i]).GetType().GetProperties();

      //  foreach (var propInfo in properties)
      //  {
      //    bool canSetValue = true;
      //    if (propInfo.CanWrite)
      //    {
      //      if (propInfo.Name == "Parent")
      //        continue;
      //      if (propInfo.Name == "Visible")
      //        continue;
      //      if (propInfo.Name == "WindowTarget")
      //        continue;
      //      if (propInfo.DeclaringType.FullName == "System.Windows.Forms.DataGridView")
      //      {
      //        if (propInfo.Name != "BackgroundColor"
      //         || propInfo.Name != "BackColor"
      //         || propInfo.Name != "DefaultCellStyle"
      //         || propInfo.Name != "Font")
      //          canSetValue = false;
      //      }
      //      if (canSetValue)
      //        propInfo.SetValue(_controls[i], propInfo.GetValue(_controlsBeforeChange[i], null), null);
      //    }
      //  }
      //}
      //tvSettings_AfterSelect(sender, null);
    }

    private void AppSettingsForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      MainForm._settingsXml.SaveFormPosition(this);
      e.Cancel = true;
      this.Hide();
    }

    private void AppSettingsForm_Shown(object sender, EventArgs e)
    {
      RefreshPropertiesForControlsBeforeChange(false);
    }

    private void RefreshPropertiesForControlsBeforeChange(bool saveChangesToFile)
    {
      //_controlsBeforeChange = new object[_controls.Length];

      for (int i = 0; i < _controls.Length; i++)
      {
        //if (_controls[i] is DataGridView)
        //{
        //  _controlsBeforeChange[i] = new DataGridView();
        //  _controlsBeforeChange[i] = ControlExtensions.CloneDataGridView((DataGridView)_controls[i]);
        //}
        //else
        //{
        //  _controlsBeforeChange[i] = new Control();
        //  _controlsBeforeChange[i] = ControlExtensions.Clone((Control)_controls[i]);
        //}
        if (saveChangesToFile)
        {
          this.Invoke((MethodInvoker)delegate
          {
            tvSettings.SelectedNode = tvSettings.Nodes[i];
            ParseProperty(ParseType.SaveToFile);
          });
        }
      }
    }
  }
}

