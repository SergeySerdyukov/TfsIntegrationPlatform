﻿// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)

using System.Collections.Generic;
using System.ComponentModel.Design;
using Microsoft.TeamFoundation.Migration.Toolkit;

namespace Microsoft.TeamFoundation.Migration.TfsVCAdapterCommon
{
    class TFSHistoryNotFoundConflictHandler : IConflictHandler
    {
        #region IConflictHandler Members

        public bool CanResolve(MigrationConflict conflict, ConflictResolutionRule rule)
        {
            return ConflictTypeHandled.ScopeInterpreter.IsInScope(conflict.ScopeHint, rule.ApplicabilityScope);
        }

        public ConflictResolutionResult Resolve(IServiceContainer serviceContainer, MigrationConflict conflict, ConflictResolutionRule rule, out List<MigrationAction> actions)
        {
            actions = null;
            if (rule.ActionRefNameGuid.Equals(new TFSHistoryNotFoundSuppressAction().ReferenceName))
            {
                if (rule.DataFieldDictionary.ContainsKey(TFSHistoryNotFoundSuppressAction.SupressChangeSetId))
                {
                    ConflictResolutionResult result = new ConflictResolutionResult(true, ConflictResolutionType.SuppressedConflictedChangeGroup);
                    result.Comment = rule.DataFieldDictionary[TFSHistoryNotFoundSuppressAction.SupressChangeSetId];
                    return result;
                }
                else
                {
                    return new ConflictResolutionResult(false, ConflictResolutionType.SuppressedConflictedChangeGroup);
                }
            }
            else if (rule.ActionRefNameGuid.Equals(new TFSHistoryNotFoundSkipAction().ReferenceName))
            {
                return new ConflictResolutionResult(true, ConflictResolutionType.SkipConflictedChangeAction);
            }
            else
            {
                return new ConflictResolutionResult(false, ConflictResolutionType.UnknownResolutionAction);
            }
        }

        public ConflictType ConflictTypeHandled
        {
            get;
            set;
        }

        #endregion

    }
}
