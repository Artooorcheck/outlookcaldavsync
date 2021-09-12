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
using System.Drawing;
using System.Windows.Forms;
using CalDavSynchronizer.Globalization;
using CalDavSynchronizer.Properties;
using CalDavSynchronizer.Utilities;
using GenSync.Logging;
using log4net;

namespace CalDavSynchronizer.Ui.SystrayNotification
{
    class TrayNotifier : ITrayNotifier
    {
        private static readonly ILog s_logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly NotifyIcon _nofifyIcon;
        private readonly ICalDavSynchronizerCommands _calDavSynchronizerCommands;


        public TrayNotifier(ICalDavSynchronizerCommands calDavSynchronizerCommands)
        {
            if (calDavSynchronizerCommands == null)
                throw new ArgumentNullException(nameof(calDavSynchronizerCommands));
            _calDavSynchronizerCommands = calDavSynchronizerCommands;

            var trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add(Strings.Get($"Synchronize now"), delegate { SynchronizeNow(); });
            trayMenu.MenuItems.Add(Strings.Get($"Reports"), delegate { ShowReports(); });
            trayMenu.MenuItems.Add(Strings.Get($"Status"), delegate { ShowProfileStatuses(); });
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add(Strings.Get($"Synchronization Profiles"), delegate { ShowOptions(); });
            trayMenu.MenuItems.Add(Strings.Get($"General Options"), delegate { ShowGeneralOptions(); });
            trayMenu.MenuItems.Add("-");
            trayMenu.MenuItems.Add(Strings.Get($"About"), delegate { ShowAbout(); });

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            _nofifyIcon = new NotifyIcon();
            _nofifyIcon.Text = ComponentContainer.MessageBoxTitle;
            _nofifyIcon.Icon = Resources.ApplicationIcon;

            // Add menu to tray icon and show it.
            _nofifyIcon.ContextMenu = trayMenu;
            _nofifyIcon.Visible = true;
            _nofifyIcon.MouseDoubleClick += _nofifyIcon_MouseDoubleClick;
        }

        private void ShowAbout()
        {
            try
            {
                _calDavSynchronizerCommands.ShowAbout();
            }
            catch (Exception x)
            {
                ExceptionHandler.Instance.DisplayException(x, s_logger);
            }
        }

        private void ShowProfileStatuses()
        {
            try
            {
                _calDavSynchronizerCommands.ShowProfileStatuses();
            }
            catch (Exception x)
            {
                ExceptionHandler.Instance.DisplayException(x, s_logger);
            }
        }

        private void ShowReports()
        {
            try
            {
                _calDavSynchronizerCommands.ShowReports();
            }
            catch (Exception x)
            {
                ExceptionHandler.Instance.DisplayException(x, s_logger);
            }
        }

        private void ShowGeneralOptions()
        {
            try
            {
                _calDavSynchronizerCommands.ShowGeneralOptionsAsync();
            }
            catch (Exception x)
            {
                ExceptionHandler.Instance.DisplayException(x, s_logger);
            }
        }

        private void ShowOptions()
        {
            try
            {
                _calDavSynchronizerCommands.ShowOptionsAsync();
            }
            catch (Exception x)
            {
                ExceptionHandler.Instance.DisplayException(x, s_logger);
            }
        }

        private void SynchronizeNow()
        {
            try
            {
                ComponentContainer.EnsureSynchronizationContext();
                _calDavSynchronizerCommands.SynchronizeNowAsync();
            }
            catch (Exception x)
            {
                ExceptionHandler.Instance.DisplayException(x, s_logger);
            }
        }

        private void _nofifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                _calDavSynchronizerCommands.ShowProfileStatuses();
            }
            catch (Exception x)
            {
                ExceptionHandler.Instance.DisplayException(x, s_logger);
            }
        }

        public void NotifyUser(SynchronizationReport report, bool notifyWarnings, bool notifyErrors)
        {
            if (report.HasErrors && notifyErrors)
            {
                _nofifyIcon.ShowBalloonTip(
                    10 * 1000,
                    ComponentContainer.MessageBoxTitle,
                    Strings.Get($"Synchronization profile '{report.ProfileName}' executed with error(s)."),
                    ToolTipIcon.Error);
            }
            else if (report.HasWarnings && notifyWarnings)
            {
                _nofifyIcon.ShowBalloonTip(
                    10 * 1000,
                    ComponentContainer.MessageBoxTitle,
                    Strings.Get($"Synchronization profile '{report.ProfileName}' executed with warning(s)."),
                    ToolTipIcon.Warning);
            }
        }

        public void Dispose()
        {
            _nofifyIcon.Visible = false;
            _nofifyIcon.Icon = null;
            _nofifyIcon.Dispose();
        }
    }
}