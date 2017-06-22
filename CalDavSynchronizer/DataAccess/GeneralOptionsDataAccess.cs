﻿// This file is Part of CalDavSynchronizer (http://outlookcaldavsynchronizer.sourceforge.net/)
// Copyright (c) 2015 Gerhard Zehetbauer
// Copyright (c) 2015 Alexander Nimmervoll
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as
// published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
// 
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.IO;
using CalDavSynchronizer.Contracts;
using CalDavSynchronizer.Utilities;
using Microsoft.Win32;
using System.Configuration;
using log4net;
using log4net.Repository.Hierarchy;
using log4net.Core;
using Microsoft.Office.Core;

namespace CalDavSynchronizer.DataAccess
{
  public class GeneralOptionsDataAccess : IGeneralOptionsDataAccess
  {
    private const string s_shouldCheckForNewerVersionsValueName = "CheckForNewerVersions";
    private const string s_checkIfOnline = "CheckIfOnline";
    private const string s_storeAppDataInRoamingFolder = "StoreAppDataInRoamingFolder";
    private const string s_disableCertificateValidation = "DisableCertificateValidation";
    private const string s_enableClientCertificate = "EnableClientCertificate";
    private const string s_enableTls12 = "EnableTls12";
    private const string s_enableSsl3 = "EnableSsl3";
    private const string s_calDavConnectTimeout = "CalDavConnectTimeout";
    private const string s_fixInvalidSettings = "FixInvalidSettings";
    private const string s_OptionsRegistryKey = @"Software\CalDavSynchronizer";
    private const string s_IncludeCustomMessageClasses = "IncludeCustomMessageClasses";

    private const string s_QueryFoldersJustByGetTable = "QueryFoldersJustByGetTable";
    private const string s_LogReportsWithoutWarningsOrErrors = "LogReportsWithoutWarningsOrErrors";
    private const string s_LogReportsWithWarnings = "LogReportsWithWarnings";
    private const string s_ShowReportsWithWarningsImmediately = "ShowReportsWithWarningsImmediately";
    private const string s_ShowReportsWithErrorsImmediately = "ShowReportsWithErrorsImmediately";
    private const string s_MaxReportAgeInDays = "MaxReportAgeInDays";

    private const string s_EnableDebugLog = "EnableDebugLog";
    private const string s_EnableTrayIcon = "EnableTrayIcon";
    private const string s_EntityCacheVersion = "EntityCacheVersion";
    private const string s_AcceptInvalidCharsInServerResponse = "AcceptInvalidCharsInServerResponse";
    private const string s_UseUnsafeHeaderParsing = "UseUnsafeHeaderParsing";
    private const string s_TriggerSyncAfterSendReceive = "TriggerSyncAfterSendReceive";
    private const string s_ExpandAllSyncProfiles = "ExpandAllSyncProfiles";
    private const string s_EnableAdvancedView = "EnableAdvancedView";
    private const string s_ToolbarSettings = "ToolbarSettings";

    private const string s_ShowProgressBar = "ShowProgressBar";
    private const string s_ThresholdForProgressDisplay = "ThresholdForProgressDisplay";
    private const string s_MaxSucessiveWarnings = "MaxSucessiveWarnings";

    public GeneralOptions LoadOptions ()
    {
      using (var key = OpenOptionsKey())
      {
        int debugEnabledInConfig = ((Hierarchy) LogManager.GetRepository()).Root.Level == Level.Debug ? 1 : 0;

        return new GeneralOptions()
               {
                   ShouldCheckForNewerVersions = (int) (key.GetValue (s_shouldCheckForNewerVersionsValueName) ?? Convert.ToInt32 (Boolean.Parse (ConfigurationManager.AppSettings["checkForNewerVersions"] ?? bool.TrueString))) != 0,
                   CheckIfOnline = (int) (key.GetValue (s_checkIfOnline) ?? 1) != 0,
                   StoreAppDataInRoamingFolder = (int) (key.GetValue (s_storeAppDataInRoamingFolder) ?? Convert.ToInt32 (Boolean.Parse (ConfigurationManager.AppSettings["storeAppDataInRoamingFolder"] ?? bool.FalseString))) != 0,
                   DisableCertificateValidation = (int) (key.GetValue (s_disableCertificateValidation) ?? Convert.ToInt32 (Boolean.Parse (ConfigurationManager.AppSettings["disableCertificateValidation"] ?? bool.FalseString))) != 0,
                   EnableClientCertificate = (int) (key.GetValue (s_enableClientCertificate) ?? Convert.ToInt32 (Boolean.Parse (ConfigurationManager.AppSettings["enableClientCertificate"] ?? bool.FalseString))) != 0,
                   EnableTls12 = (int) (key.GetValue (s_enableTls12) ?? Convert.ToInt32 (Boolean.Parse (ConfigurationManager.AppSettings["enableTls12"] ?? bool.TrueString))) != 0,
                   EnableSsl3 = (int) (key.GetValue (s_enableSsl3) ?? Convert.ToInt32 (Boolean.Parse (ConfigurationManager.AppSettings["enableSsl3"] ?? bool.FalseString))) != 0,
                   CalDavConnectTimeout = TimeSpan.Parse ((string)(key.GetValue (s_calDavConnectTimeout) ?? ConfigurationManager.AppSettings["caldavConnectTimeout"] ?? "01:30")),
                   FixInvalidSettings = (int) (key.GetValue (s_fixInvalidSettings) ?? 1) != 0,
                   IncludeCustomMessageClasses = (int) (key.GetValue (s_IncludeCustomMessageClasses) ?? Convert.ToInt32 (Boolean.Parse (ConfigurationManager.AppSettings["includeCustomMessageClasses"] ?? bool.FalseString))) != 0,
                   LogReportsWithoutWarningsOrErrors = (int) (key.GetValue (s_LogReportsWithoutWarningsOrErrors) ?? 0) != 0,
                   LogReportsWithWarnings = (int) (key.GetValue (s_LogReportsWithWarnings) ?? 1) != 0,
                   ShowReportsWithWarningsImmediately = (int) (key.GetValue (s_ShowReportsWithWarningsImmediately) ?? 0) != 0,
                   ShowReportsWithErrorsImmediately = (int) (key.GetValue (s_ShowReportsWithErrorsImmediately) ?? 1) != 0,
                   MaxReportAgeInDays = (int) (key.GetValue (s_MaxReportAgeInDays) ?? 1),
                   EnableDebugLog = (int) (key.GetValue (s_EnableDebugLog) ?? debugEnabledInConfig) != 0,
                   EnableTrayIcon = (int) (key.GetValue (s_EnableTrayIcon) ?? 1) != 0,
                   AcceptInvalidCharsInServerResponse = (int) (key.GetValue (s_AcceptInvalidCharsInServerResponse) ?? 0) != 0,
                   UseUnsafeHeaderParsing = (int) (key.GetValue (s_UseUnsafeHeaderParsing) ?? Convert.ToInt32 (SystemNetSettings.UseUnsafeHeaderParsing)) !=0,
                   TriggerSyncAfterSendReceive = (int) (key.GetValue (s_TriggerSyncAfterSendReceive) ?? 0) != 0,
                   ExpandAllSyncProfiles = (int) (key.GetValue (s_ExpandAllSyncProfiles) ?? 1) != 0,
                   EnableAdvancedView = (int)(key.GetValue(s_EnableAdvancedView) ?? Convert.ToInt32 (Boolean.Parse (ConfigurationManager.AppSettings["enableAdvancedView"] ?? bool.FalseString))) != 0,
                   QueryFoldersJustByGetTable = (int) (key.GetValue (s_QueryFoldersJustByGetTable) ?? 1) != 0,
                   ShowProgressBar = (int) (key.GetValue (s_ShowProgressBar) ?? Convert.ToInt32 (Boolean.Parse (ConfigurationManager.AppSettings["showProgressBar"] ?? bool.FalseString))) != 0,
                   ThresholdForProgressDisplay = (int) (key.GetValue (s_ThresholdForProgressDisplay) ?? int.Parse(ConfigurationManager.AppSettings["loadOperationThresholdForProgressDisplay"] ?? "50")),
                   MaxSucessiveWarnings = (int) (key.GetValue (s_MaxSucessiveWarnings) ?? 2)
        };
      }
    }

    public static bool WpfRenderModeSoftwareOnly => bool.Parse(ConfigurationManager.AppSettings["wpfRenderModeSoftwareOnly"] ?? bool.FalseString);

    public void SaveOptions (GeneralOptions options)
    {
      using (var key = OpenOptionsKey())
      {
        key.SetValue (s_shouldCheckForNewerVersionsValueName, options.ShouldCheckForNewerVersions ? 1 : 0);
        key.SetValue (s_checkIfOnline, options.CheckIfOnline ? 1 : 0);
        key.SetValue (s_storeAppDataInRoamingFolder, options.StoreAppDataInRoamingFolder ? 1 : 0);
        key.SetValue (s_disableCertificateValidation, options.DisableCertificateValidation ? 1 : 0);
        key.SetValue (s_enableClientCertificate, options.EnableClientCertificate ? 1 : 0);
        key.SetValue (s_enableTls12, options.EnableTls12 ? 1 : 0);
        key.SetValue (s_enableSsl3, options.EnableSsl3 ? 1 : 0);
        key.SetValue (s_calDavConnectTimeout, options.CalDavConnectTimeout.ToString());
        key.SetValue (s_fixInvalidSettings, options.FixInvalidSettings ? 1 : 0);
        key.SetValue (s_IncludeCustomMessageClasses, options.IncludeCustomMessageClasses ? 1 : 0);
        key.SetValue (s_LogReportsWithoutWarningsOrErrors, options.LogReportsWithoutWarningsOrErrors ? 1 : 0);
        key.SetValue (s_LogReportsWithWarnings, options.LogReportsWithWarnings ? 1 : 0);
        key.SetValue (s_ShowReportsWithWarningsImmediately, options.ShowReportsWithWarningsImmediately ? 1 : 0);
        key.SetValue (s_ShowReportsWithErrorsImmediately, options.ShowReportsWithErrorsImmediately ? 1 : 0);
        key.SetValue (s_MaxReportAgeInDays, options.MaxReportAgeInDays);
        key.SetValue (s_EnableDebugLog, options.EnableDebugLog ? 1 : 0);
        key.SetValue (s_EnableTrayIcon, options.EnableTrayIcon ? 1 : 0);
        key.SetValue (s_AcceptInvalidCharsInServerResponse, options.AcceptInvalidCharsInServerResponse ? 1 : 0);
        key.SetValue (s_UseUnsafeHeaderParsing, options.UseUnsafeHeaderParsing ? 1 : 0);
        key.SetValue (s_TriggerSyncAfterSendReceive, options.TriggerSyncAfterSendReceive ? 1 : 0);
        key.SetValue (s_ExpandAllSyncProfiles, options.ExpandAllSyncProfiles ? 1 : 0);
        key.SetValue (s_EnableAdvancedView, options.EnableAdvancedView ? 1 : 0);
        key.SetValue (s_QueryFoldersJustByGetTable, options.QueryFoldersJustByGetTable ? 1 : 0);
        key.SetValue (s_ShowProgressBar, options.ShowProgressBar ? 1: 0);
        key.SetValue (s_ThresholdForProgressDisplay, options.ThresholdForProgressDisplay);
        key.SetValue (s_MaxSucessiveWarnings, options.MaxSucessiveWarnings);
      }
    }

    public Version IgnoreUpdatesTilVersion
    {
      get
      {
        using (var key = OpenOptionsKey())
        {
          var versionString = (string) key.GetValue ("IgnoreUpdatesTilVersion");
          if (!string.IsNullOrEmpty (versionString))
            return new Version (versionString);
          else
            return null;
        }
      }
      set
      {
        using (var key = OpenOptionsKey())
        {
          if (value != null)
            key.SetValue ("IgnoreUpdatesTilVersion", value.ToString());
          else
            key.DeleteValue ("IgnoreUpdatesTilVersion");
        }
      }
    }
    
    public int EntityCacheVersion
    {
      get
      {
        using (var key = OpenOptionsKey())
        {
          return (int) (key.GetValue (s_EntityCacheVersion) ?? 0);
        }
      }
      set
      {
        using (var key = OpenOptionsKey())
        {
          key.SetValue (s_EntityCacheVersion, value);
        }
      }
    }

    public static void SaveToolBarSettings(ToolbarSettings settings)
    {
      using (var key = OpenOptionsKey())
      {
        if (settings != null)
          key.SetValue(s_ToolbarSettings, Serializer<ToolbarSettings>.Serialize(settings));
        else
          key.DeleteValue(s_ToolbarSettings);
      }
    }

    public static ToolbarSettings LoadToolBarSettings()
    {
      using (var key = OpenOptionsKey())
      {
        var settings = (string) key.GetValue(s_ToolbarSettings);
        if (!string.IsNullOrEmpty(settings))
          return Serializer<ToolbarSettings>.Deserialize(settings);
        else
          return ToolbarSettings.CreateDefault();
      }
    }

    private static RegistryKey OpenOptionsKey ()
    {
      var key = Registry.CurrentUser.OpenSubKey (s_OptionsRegistryKey, true);
      if (key == null)
        key = Registry.CurrentUser.CreateSubKey (s_OptionsRegistryKey);
      return key;
    }
  }
}