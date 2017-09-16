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
using GenSync.Synchronization;

namespace GenSync.Logging
{
  public class NullSynchronizationLogger : ISynchronizationLogger
  {
    public static readonly ISynchronizationLogger Instance = new NullSynchronizationLogger();
  
    private NullSynchronizationLogger ()
    {
    }

    public ILoadEntityLogger ALoadEntityLogger => NullLoadEntityLogger.Instance;
    public ILoadEntityLogger BLoadEntityLogger => NullLoadEntityLogger.Instance;
    public IGetVersionsLogger AGetVersionsEntityLogger => NullGetVersionsLogger.Instance;
    public IGetVersionsLogger BGetVersionsEntityLogger => NullGetVersionsLogger.Instance;

    public void LogInitialEntityMatching ()
    {
    }

    public void LogAbortedDueToError (Exception exception)
    {
    }

    public void LogDeltas (VersionDeltaLoginInformation aDeltaLogInfo, VersionDeltaLoginInformation bDeltaLogInfo)
    {
    }
    
    public void Dispose()
    {
      
    }

    public ISynchronizationLogger CreateSubLogger(string subProfileName)
    {
      return this;
    }

    public void AddEntitySynchronizationLog(IEntitySynchronizationLog log)
    {
      
    }

    public void LogJobs(string aJobsInfo, string bJobsInfo)
    {
      
    }

    public void LogAbortedDueToWarning(Exception exception)
    {
      
    }
  }
}