using System;
using UnityEngine;

namespace NonAllocPhysicsWrapper
{
    public abstract class NonAllocBase<TResult>
    {
        public ILogger logger { private get; set; } = Defaults.defaultLogger;
        protected readonly TResult[] resultsBuffer;

        protected NonAllocBase(TResult[] resultsBuffer)
        {
            if (resultsBuffer == null)
            {
                throw new ArgumentNullException(nameof(resultsBuffer), "Results buffer must not be null.");
            }

            if (resultsBuffer.Length == 0)
            {
                throw new ArgumentException("Results buffer must have a length greater than zero.", nameof(resultsBuffer));
            }

            this.resultsBuffer = resultsBuffer;
        }

        protected NonAllocBase(int resultsBufferSize)
        {
            if (resultsBufferSize <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(resultsBufferSize), "Results buffer size must be greater than zero.");
            }

            this.resultsBuffer = new TResult[resultsBufferSize];
        }

        protected ReadOnlySpan<TResult> ResultsBufferToSpan(int resultsCount)
        {
            if (resultsCount == resultsBuffer.Length)
            {
                logger?.LogWarning("NonAllocPhysicsWrapper", "Hit results buffer limit. Consider increasing buffer size.");
            }

            return new ReadOnlySpan<TResult>(resultsBuffer, 0, resultsCount);
        }
    }
}
