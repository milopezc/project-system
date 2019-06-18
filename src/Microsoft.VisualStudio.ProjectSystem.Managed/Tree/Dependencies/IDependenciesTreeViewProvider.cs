﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Composition;
using Microsoft.VisualStudio.ProjectSystem.VS.Tree.Dependencies.Snapshot;

#nullable enable

namespace Microsoft.VisualStudio.ProjectSystem.VS.Tree.Dependencies
{
    /// <summary>
    /// Abstraction that helps to build different views for Dependencies node contents.
    /// Having multiple views implementations we could have some context commands switching 
    /// between different views. 
    /// View is responsible for building nodes hierarchy based on given dependencies snapshot.
    /// </summary>
    [ProjectSystemContract(ProjectSystemContractScope.UnconfiguredProject, ProjectSystemContractProvider.Private, Cardinality = ImportCardinality.ZeroOrMore)]
    internal interface IDependenciesTreeViewProvider
    {
        /// <summary>
        /// Builds Dependency node contents (target frameworks, groups and top level dependencies) for a given snapshot.
        /// </summary>
        /// <param name="dependenciesTree">Old dependencies node</param>
        /// <param name="snapshot">Current dependencies snapshot</param>
        /// <param name="cancellationToken">Cancellation token if need to stop building the view</param>
        /// <returns>New dependencies node</returns>
        Task<IProjectTree> BuildTreeAsync(
            IProjectTree dependenciesTree,
            IDependenciesSnapshot snapshot,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Finds node by path in current dependencies view hierarchy.
        /// </summary>
        /// <param name="root">Node where we start searching</param>
        /// <param name="path">Path to find</param>
        /// <returns></returns>
        IProjectTree? FindByPath(IProjectTree root, string path);
    }
}
