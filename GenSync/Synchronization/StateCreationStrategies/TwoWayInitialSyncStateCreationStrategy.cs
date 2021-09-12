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
using GenSync.EntityRelationManagement;
using GenSync.Synchronization.StateCreationStrategies.ConflictStrategies;
using GenSync.Synchronization.StateFactories;
using GenSync.Synchronization.States;

namespace GenSync.Synchronization.StateCreationStrategies
{
    /// <summary>
    /// Creates initial states in that way, so that it results in a merge in both directions
    /// </summary>
    /// <remarks>
    /// since two way-merging can result in conflicts, this class requires a strategy to resolve conflicts
    /// </remarks>
    public class TwoWayInitialSyncStateCreationStrategy<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext>
        : IInitialSyncStateCreationStrategy<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext>
    {
        private readonly IEntitySyncStateFactory<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext> _stateFactory;
        private readonly IConflictInitialSyncStateCreationStrategy<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext> _conflictInitialStateCreationStrategy;


        public TwoWayInitialSyncStateCreationStrategy(IEntitySyncStateFactory<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext> factory, IConflictInitialSyncStateCreationStrategy<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext> conflictInitialStateCreationStrategy)
        {
            _stateFactory = factory;
            _conflictInitialStateCreationStrategy = conflictInitialStateCreationStrategy;
        }

        public IEntitySyncState<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext> CreateFor_Changed_Changed(IEntityRelationData<TAtypeEntityId, TAtypeEntityVersion, TBtypeEntityId, TBtypeEntityVersion> knownData, TAtypeEntityVersion newA, TBtypeEntityVersion newB)
        {
            return _conflictInitialStateCreationStrategy.Create_Changed_Changed(knownData, newA, newB);
        }

        public IEntitySyncState<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext> CreateFor_Changed_Unchanged(IEntityRelationData<TAtypeEntityId, TAtypeEntityVersion, TBtypeEntityId, TBtypeEntityVersion> knownData, TAtypeEntityVersion newA)
        {
            return _stateFactory.Create_UpdateAtoB(knownData, newA, knownData.BtypeVersion);
        }

        public IEntitySyncState<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext> CreateFor_Changed_Deleted(IEntityRelationData<TAtypeEntityId, TAtypeEntityVersion, TBtypeEntityId, TBtypeEntityVersion> knownData, TAtypeEntityVersion newA)
        {
            return _conflictInitialStateCreationStrategy.Create_Changed_Deleted(knownData, newA);
        }

        public IEntitySyncState<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext> CreateFor_Unchanged_Changed(IEntityRelationData<TAtypeEntityId, TAtypeEntityVersion, TBtypeEntityId, TBtypeEntityVersion> knownData, TBtypeEntityVersion newB)
        {
            return _stateFactory.Create_UpdateBtoA(knownData, newB, knownData.AtypeVersion);
        }

        public IEntitySyncState<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext> CreateFor_Deleted_Changed(IEntityRelationData<TAtypeEntityId, TAtypeEntityVersion, TBtypeEntityId, TBtypeEntityVersion> knownData, TBtypeEntityVersion newB)
        {
            return _conflictInitialStateCreationStrategy.Create_Deleted_Changed(knownData, newB);
        }

        public IEntitySyncState<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext> CreateFor_Deleted_Deleted(IEntityRelationData<TAtypeEntityId, TAtypeEntityVersion, TBtypeEntityId, TBtypeEntityVersion> knownData)
        {
            return _stateFactory.Create_Discard();
        }

        public IEntitySyncState<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext> CreateFor_Deleted_Unchanged(IEntityRelationData<TAtypeEntityId, TAtypeEntityVersion, TBtypeEntityId, TBtypeEntityVersion> knownData)
        {
            return _stateFactory.Create_DeleteInB(knownData, knownData.BtypeVersion);
        }

        public IEntitySyncState<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext> CreateFor_Unchanged_Deleted(IEntityRelationData<TAtypeEntityId, TAtypeEntityVersion, TBtypeEntityId, TBtypeEntityVersion> knownData)
        {
            return _stateFactory.Create_DeleteInA(knownData, knownData.AtypeVersion);
        }

        public IEntitySyncState<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext> CreateFor_Unchanged_Unchanged(IEntityRelationData<TAtypeEntityId, TAtypeEntityVersion, TBtypeEntityId, TBtypeEntityVersion> knownData)
        {
            return _stateFactory.Create_DoNothing(knownData);
        }

        public IEntitySyncState<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext> CreateFor_Added_NotExisting(TAtypeEntityId aId, TAtypeEntityVersion newA)
        {
            return _stateFactory.Create_CreateInB(aId, newA);
        }

        public IEntitySyncState<TAtypeEntityId, TAtypeEntityVersion, TAtypeEntity, TBtypeEntityId, TBtypeEntityVersion, TBtypeEntity, TContext> CreateFor_NotExisting_Added(TBtypeEntityId bId, TBtypeEntityVersion newB)
        {
            return _stateFactory.Create_CreateInA(bId, newB);
        }
    }
}