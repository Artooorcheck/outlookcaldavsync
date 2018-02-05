﻿using CalDavSynchronizer.Globalization;

namespace CalDavSynchronizer
{
  partial class CalDavSynchronizerRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public CalDavSynchronizerRibbon ()
      : base (Globals.Factory.GetRibbonFactory ())
    {
      InitializeComponent ();
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose (bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose ();
      }
      base.Dispose (disposing);
    }

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent ()
    {
      this.tab1 = this.Factory.CreateRibbonTab();
      this.group1 = this.Factory.CreateRibbonGroup();
      this.SynchronizeNowButton = this.Factory.CreateRibbonButton();
      this.OptionsButton = this.Factory.CreateRibbonButton();
      this.GeneralOptionsButton = this.Factory.CreateRibbonButton();
      this.AboutButton = this.Factory.CreateRibbonButton();
      this.ReportsButton = this.Factory.CreateRibbonButton();
      this.StatusesButton = this.Factory.CreateRibbonButton();
      this.tab1.SuspendLayout();
      this.group1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tab1
      // 
      this.tab1.Groups.Add(this.group1);
      this.tab1.Label = "CalDav Synchronizer";
      this.tab1.Name = "tab1";
      // 
      // group1
      // 
      this.group1.Items.Add(this.SynchronizeNowButton);
      this.group1.Items.Add(this.OptionsButton);
      this.group1.Items.Add(this.GeneralOptionsButton);
      this.group1.Items.Add(this.AboutButton);
      this.group1.Items.Add(this.ReportsButton);
      this.group1.Items.Add(this.StatusesButton);
      this.group1.Label = "CalDav Synchronizer";
      this.group1.Name = "group1";
      // 
      // SynchronizeNowButton
      // 
      this.SynchronizeNowButton.Image = global::CalDavSynchronizer.Properties.Resources.Sync;
      this.SynchronizeNowButton.Label = Strings.Get($"Synchronize now");
      this.SynchronizeNowButton.Name = "SynchronizeNowButton";
      this.SynchronizeNowButton.ScreenTip = Strings.Get($"Synchronize now");
      this.SynchronizeNowButton.ShowImage = true;
      this.SynchronizeNowButton.SuperTip = Strings.Get($"Start a manual synchronization of all active profiles.");
      this.SynchronizeNowButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.SynchronizeNowButton_Click);
      // 
      // OptionsButton
      // 
      this.OptionsButton.Image = global::CalDavSynchronizer.Properties.Resources.Options;
      this.OptionsButton.Label = Strings.Get($"Synchronization Profiles");
      this.OptionsButton.Name = "OptionsButton";
      this.OptionsButton.ScreenTip = Strings.Get($"Synchronization Profiles");
      this.OptionsButton.ShowImage = true;
      this.OptionsButton.SuperTip = Strings.Get($"Configure your synchronization profiles.");
      this.OptionsButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.OptionsButton_Click);
      // 
      // GeneralOptionsButton
      // 
      this.GeneralOptionsButton.Image = global::CalDavSynchronizer.Properties.Resources.GeneralOptions;
      this.GeneralOptionsButton.Label = Strings.Get($"General Options");
      this.GeneralOptionsButton.Name = "GeneralOptionsButton";
      this.GeneralOptionsButton.ScreenTip = Strings.Get($"General Options");
      this.GeneralOptionsButton.ShowImage = true;
      this.GeneralOptionsButton.SuperTip = Strings.Get($"Set global options for all profiles like SSL/TLS settings.");
      this.GeneralOptionsButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.GeneralOptionsButton_Click);
      // 
      // AboutButton
      // 
      this.AboutButton.Image = global::CalDavSynchronizer.Properties.Resources.About;
      this.AboutButton.Label = Strings.Get($"About");
      this.AboutButton.Name = "AboutButton";
      this.AboutButton.ScreenTip = Strings.Get($"About");
      this.AboutButton.ShowImage = true;
      this.AboutButton.SuperTip = Strings.Get($"Information about the project and version.");
      this.AboutButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AboutButton_Click);
      // 
      // ReportsButton
      // 
      this.ReportsButton.Image = global::CalDavSynchronizer.Properties.Resources.SyncReport;
      this.ReportsButton.Label = Strings.Get($"Reports");
      this.ReportsButton.Name = "ReportsButton";
      this.ReportsButton.ScreenTip = Strings.Get($"Reports");
      this.ReportsButton.ShowImage = true;
      this.ReportsButton.SuperTip = Strings.Get($"Show reports of last sync runs.");
      this.ReportsButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ReportsButton_Click);
      // 
      // StatusesButton
      // 
      this.StatusesButton.Image = global::CalDavSynchronizer.Properties.Resources.report;
      this.StatusesButton.Label = Strings.Get($"Status");
      this.StatusesButton.Name = "StatusesButton";
      this.StatusesButton.ScreenTip = Strings.Get($"Status");
      this.StatusesButton.ShowImage = true;
      this.StatusesButton.SuperTip = Strings.Get($"Show status of sync runs.");
      this.StatusesButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.StatusesButton_Click);
      // 
      // CalDavSynchronizerRibbon
      // 
      this.Name = "CalDavSynchronizerRibbon";
      this.RibbonType = "Microsoft.Outlook.Explorer";
      this.Tabs.Add(this.tab1);
      this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.CalDavSynchronizerRibbon_Load);
      this.tab1.ResumeLayout(false);
      this.tab1.PerformLayout();
      this.group1.ResumeLayout(false);
      this.group1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
    internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
    internal Microsoft.Office.Tools.Ribbon.RibbonButton SynchronizeNowButton;
    internal Microsoft.Office.Tools.Ribbon.RibbonButton OptionsButton;
    internal Microsoft.Office.Tools.Ribbon.RibbonButton AboutButton;
    internal Microsoft.Office.Tools.Ribbon.RibbonButton GeneralOptionsButton;
    internal Microsoft.Office.Tools.Ribbon.RibbonButton ReportsButton;
    internal Microsoft.Office.Tools.Ribbon.RibbonButton StatusesButton;
  }

  partial class ThisRibbonCollection
  {
    internal CalDavSynchronizerRibbon CalDavSynchronizerRibbon
    {
      get { return this.GetRibbon<CalDavSynchronizerRibbon> (); }
    }
  }
}
