// This file is Part of CalDavSynchronizer (http://outlookcaldavsynchronizer.sourceforge.net/)
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
using System.Collections.Generic;
using System.Threading.Tasks;
using GenSync.Logging;

namespace GenSync.Synchronization
{
    /// <summary>
    /// A Synchronizer :-P
    /// </summary>
    public interface IPartialSynchronizer<in TAtypeEntityId, in TAtypeEntityVersion, in TBtypeEntityId, in TBtypeEntityVersion> : ISynchronizer
    {
        Task SynchronizePartial(
            IEnumerable<IIdWithHints<TAtypeEntityId, TAtypeEntityVersion>> aIds,
            IEnumerable<IIdWithHints<TBtypeEntityId, TBtypeEntityVersion>> bIds,
            ISynchronizationLogger logger);
    }

    public interface IPartialSynchronizer<in TAtypeEntityId, in TAtypeEntityVersion, in TBtypeEntityId, in TBtypeEntityVersion, TContext>
        : ISynchronizer<TContext>
    {
        Task<bool> SynchronizePartial(
            IEnumerable<IIdWithHints<TAtypeEntityId, TAtypeEntityVersion>> aIds,
            IEnumerable<IIdWithHints<TBtypeEntityId, TBtypeEntityVersion>> bIds,
            ISynchronizationLogger logger,
            Func<Task<TContext>> contextFactoryAsync,
            Func<TContext, Task> syncronizationFinishedAsync);
    }
}