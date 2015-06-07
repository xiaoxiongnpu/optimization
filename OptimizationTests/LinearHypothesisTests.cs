﻿using System.Linq;
using FluentAssertions;
using MathNet.Numerics.LinearAlgebra;
using NUnit.Framework;
using widemeadows.Optimization.Hypotheses;

namespace widemeadows.Optimization.Tests
{
    [TestFixture]
    public class LinearHypothesisTests
    {
        /// <summary>
        /// Asserts that the trivial linear hypothesis is the identity function.
        /// </summary>
        /// <param name="value">The value.</param>
        [Test]
        public void TrivialLinearHypothesisIsIdentity([Random(5)] double value)
        {
            var h = new LinearHypothesis(1);
            var theta = Vector<double>.Build.Dense(new[] {0D, 1D});
            var inputs = Vector<double>.Build.Dense(1, value);

            var outputs = h.Evaluate(inputs, theta);
            outputs.Count.Should().Be(1, "because one output is expected");
            outputs.Single().Should().BeApproximately(value, 1E-5D, "because the function is linear");

            var derivative = h.Derivative(inputs, theta, outputs);
            derivative.Count.Should().Be(2, "because two coefficients are evaluated");
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            derivative.Should().OnlyContain(d => d == 1D, "because the function is linear");
        }

        /// <summary>
        /// Asserts that the linear hypothesis is indeed a line equation
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="offset">The offset.</param>
        [Test]
        public void LinearHypothesisIsLineEquation([Random(5)] double value, [Random(5)] double scale, [Random(5)] double offset)
        {
            var h = new LinearHypothesis(1);
            var theta = Vector<double>.Build.Dense(new[] { offset, scale });
            var inputs = Vector<double>.Build.Dense(1, value);

            var outputs = h.Evaluate(inputs, theta);

            outputs.Count.Should().Be(1, "because one output is expected");

            var output = outputs.Single();
            var expectedresult = value * scale + offset;
            output.Should().BeApproximately(expectedresult, 1E-5D, "because the function is linear");

            var derivative = h.Derivative(inputs, theta, outputs);
            derivative.Count.Should().Be(2, "because two coefficients are evaluated");
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            derivative.Should().OnlyContain(d => d == 1D, "because the function is linear");
        }
    }
}
