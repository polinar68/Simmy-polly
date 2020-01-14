﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Polly.Contrib.Simmy.Behavior
{
    /// <summary>
    /// A policy that injects any custom behaviour before the execution of delegates.
    /// </summary>
    public class AsyncInjectBehaviourPolicy : AsyncMonkeyPolicy
    {
        private readonly Func<Context, CancellationToken, Task> _behaviour;

        internal AsyncInjectBehaviourPolicy(InjectBehaviourAsyncOptions options)
            : base(options.InjectionRate, options.Enabled)
        {
            _behaviour = options.BehaviourInternal ?? throw new ArgumentNullException(nameof(options.BehaviourInternal));
        }

        /// <inheritdoc/>
        protected override Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken,
            bool continueOnCapturedContext)
        {
            return AsyncMonkeyEngine.InjectBehaviourImplementationAsync(
                action,
                context,
                cancellationToken,
                _behaviour,
                InjectionRate,
                Enabled,
                continueOnCapturedContext);
        }
    }

    /// <summary>
    /// A policy that injects any custom behaviour before the execution of delegates returning <typeparamref name="TResult"/>.
    /// </summary>
    /// <typeparam name="TResult">The type of return values this policy will handle.</typeparam>
    public class AsyncInjectBehaviourPolicy<TResult> : AsyncMonkeyPolicy<TResult>
    {
        private readonly Func<Context, CancellationToken, Task> _behaviour;

        internal AsyncInjectBehaviourPolicy(InjectBehaviourAsyncOptions options)
            : base(options.InjectionRate, options.Enabled)
        {
            _behaviour = options.BehaviourInternal ?? throw new ArgumentNullException(nameof(options.BehaviourInternal));
        }

        /// <inheritdoc/>
        protected override Task<TResult> ImplementationAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
        {
            return AsyncMonkeyEngine.InjectBehaviourImplementationAsync(
                action,
                context,
                cancellationToken,
                _behaviour,
                InjectionRate,
                Enabled,
                continueOnCapturedContext);
        }
    }
}
