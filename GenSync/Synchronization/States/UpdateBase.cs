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
using System.Reflection;
using GenSync.EntityRelationManagement;
using log4net;

namespace GenSync.Synchronization.States
{
    public abstract class UpdateBase<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext>
        : StateWithKnownData<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext>
    {
        // ReSharper disable once StaticFieldInGenericType
        private static readonly ILog s_logger = LogManager.GetLogger(MethodInfo.GetCurrentMethod().DeclaringType);

        protected TAtypeEntity _aEntity;
        protected TBtypeEntity _bEntity;


        protected UpdateBase(EntitySyncStateEnvironment<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext> environment, IEntityRelationData<TAtypeEntityId, TAtypeEntityVersion, TBtypeEntityId, TBtypeEntityVersion> knownData)
            : base(environment, knownData)
        {
        }

        public override void AddRequiredEntitiesToLoad(Func<TAtypeEntityId, bool> a, Func<TBtypeEntityId, bool> b)
        {
            a(KnownData.AtypeId);
            b(KnownData.BtypeId);
        }

        public override IEntitySyncState<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext> FetchRequiredEntities(IReadOnlyDictionary<TAtypeEntityId, TAtypeEntity> aEntities, IReadOnlyDictionary<TBtypeEntityId, TBtypeEntity> bEntites)
        {
            if (!aEntities.TryGetValue(KnownData.AtypeId, out _aEntity))
            {
                s_logger.ErrorFormat("Could not fetch entity '{0}'. Skipping operation.", KnownData.AtypeId);
                return CreateDoNothing();
            }

            if (!bEntites.TryGetValue(KnownData.BtypeId, out _bEntity))
            {
                s_logger.ErrorFormat("Could not fetch entity '{0}'. Skipping operation.", KnownData.BtypeId);
                return CreateDoNothing();
            }

            return this;
        }

        public override IEntitySyncState<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext> Resolve()
        {
            return this;
        }


        public override void AddNewRelationNoThrow(Action<IEntityRelationData<TAtypeEntityId, TAtypeEntityVersion, TBtypeEntityId, TBtypeEntityVersion>> addAction)
        {
            s_logger.Error("This state should have been left via PerformSyncActionNoThrow!");
        }

        public override void Dispose()
        {
            _aEntity = default(TAtypeEntity);
            _bEntity = default(TBtypeEntity);
        }
    }
}