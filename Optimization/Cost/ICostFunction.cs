﻿using System;
using JetBrains.Annotations;
using MathNet.Numerics.LinearAlgebra;

namespace widemeadows.Optimization.Cost
{
    /// <summary>
    /// Interface <see cref="ICostFunction{TData}"/>
    /// </summary>
    /// <typeparam name="TData">The type of the data.</typeparam>
    public interface ICostFunction<TData>
        where TData : struct, IEquatable<TData>, IFormattable
    {
        /// <summary>
        /// Calculates the cost.
        /// </summary>
        /// <param name="coefficients">The coefficients.</param>
        /// <returns>TCost.</returns>
        double CalculateCost([NotNull] Vector<TData> coefficients);
    }
}
