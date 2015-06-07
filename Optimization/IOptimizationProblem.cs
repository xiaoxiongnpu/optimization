﻿using System;
using JetBrains.Annotations;
using widemeadows.Optimization.Cost;

namespace widemeadows.Optimization
{
    /// <summary>
    /// Interface IOptimizationProblem
    /// </summary>
    public interface IOptimizationProblem<TData, out TCost>
        where TData : struct, IEquatable<TData>, IFormattable
        where TCost : ICost<TData>
    {
        /// <summary>
        /// Gets the hypothesis.
        /// </summary>
        /// <value>The hypothesis.</value>
        [NotNull]
        IHypothesis<TData> Hypothesis { get; }

        /// <summary>
        /// Gets the cost function.
        /// </summary>
        /// <value>The cost function.</value>
        [NotNull]
        ICostFunction<TData, TCost> CostFunction { get; }
    }
}
