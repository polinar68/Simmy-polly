﻿using System;
using Polly.Contrib.Simmy.Outcomes;

namespace Polly.Contrib.Simmy
{
    /// <summary>
    /// Fluent API for defining Monkey <see cref="Policy"/>. 
    /// </summary>
    public partial class MonkeyPolicy
    {
        /// <summary>
        /// Builds an <see cref="InjectOutcomePolicy"/> which injects a fault if <paramref name="configureOptions.Enabled"/> returns true and
        /// a random number is within range of <paramref name="configureOptions.InjectionRate"/>.
        /// </summary>
        /// <param name="configureOptions">A callback to configure policy options.</param>
        /// <returns>The policy instance.</returns>
        public static InjectOutcomePolicy InjectException(Action<InjectOutcomeOptions<Exception>> configureOptions)
        {
            var options = new InjectOutcomeOptions<Exception>();
            configureOptions(options);

            if (options.OutcomeInternal == null) throw new ArgumentNullException(nameof(options.OutcomeInternal));
            if (options.InjectionRate == null) throw new ArgumentNullException(nameof(options.InjectionRate));
            if (options.Enabled == null) throw new ArgumentNullException(nameof(options.Enabled));

            return new InjectOutcomePolicy(options);
        }

        /// <summary>
        /// Builds an <see cref="InjectOutcomePolicy"/> which injects a result if <paramref name="configureOptions.Enabled"/> returns true and
        /// a random number is within range of <paramref name="configureOptions.InjectionRate"/>.
        /// </summary>
        /// <param name="configureOptions">A callback to configure policy options.</param>
        /// <returns>The policy instance.</returns>
        public static InjectOutcomePolicy<TResult> InjectResult<TResult>(Action<InjectOutcomeOptions<TResult>> configureOptions)
        {
            var options = new InjectOutcomeOptions<TResult>();
            configureOptions(options);

            if (options.OutcomeInternal == null) throw new ArgumentNullException(nameof(options.OutcomeInternal));
            if (options.InjectionRate == null) throw new ArgumentNullException(nameof(options.InjectionRate));
            if (options.Enabled == null) throw new ArgumentNullException(nameof(options.Enabled));

            return new InjectOutcomePolicy<TResult>(options);
        }

        /// <summary>
        /// Builds an <see cref="InjectOutcomePolicy"/> which injects a fault as result if <paramref name="configureOptions.Enabled"/> returns true and
        /// a random number is within range of <paramref name="configureOptions.InjectionRate"/>.
        /// </summary>
        /// <param name="configureOptions">A callback to configure policy options.</param>
        /// <returns>The policy instance.</returns>
        public static InjectOutcomePolicy<TResult> InjectResult<TResult>(Action<InjectOutcomeOptions<Exception>> configureOptions)
        {
            var options = new InjectOutcomeOptions<Exception>();
            configureOptions(options);

            if (options.OutcomeInternal == null) throw new ArgumentNullException(nameof(options.OutcomeInternal));
            if (options.InjectionRate == null) throw new ArgumentNullException(nameof(options.InjectionRate));
            if (options.Enabled == null) throw new ArgumentNullException(nameof(options.Enabled));

            return new InjectOutcomePolicy<TResult>(options);
        }
    }
}
