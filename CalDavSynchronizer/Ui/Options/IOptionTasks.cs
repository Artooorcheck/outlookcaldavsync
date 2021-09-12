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

using System.Threading.Tasks;
using CalDavSynchronizer.Ui.ConnectionTests;
using CalDavSynchronizer.Ui.Options.Models;
using Microsoft.Office.Interop.Outlook;

namespace CalDavSynchronizer.Ui.Options
{
    public interface IOptionTasks
    {
        string GetFolderAccountNameOrNull(string folderStoreId);
        OutlookFolderDescriptor GetFolderFromId(string entryId, object storeId);
        OutlookFolderDescriptor PickFolderOrNull();
        IProfileExportProcessor ProfileExportProcessor { get; }
        void SaveOptions(Contracts.Options[] options, string fileName);
        Contracts.Options[] LoadOptions(string fileName);
        Task<string> TestGoogleConnection(OptionsModel options, string url);
        Task<string> TestWebDavConnection(OptionsModel options);
        void ValidateBulkProfile(OptionsModel options, AccessPrivileges privileges, CalendarOwnerProperties ownerPropertiesOrNull);

        OutlookFolderDescriptor GetDefaultCalendarFolderOrNull();
    }
}