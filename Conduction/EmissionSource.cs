using System;
using System.Linq;
using System.Collections.Generic;

namespace YggdrAshill.Nuadha.Conduction
{
    /// <summary>
    /// Collects <see cref="IEmission"/>s to build.
    /// </summary>
    public sealed class EmissionSource
    {
        /// <summary>
        /// Creates default state <see cref="EmissionSource"/>.
        /// </summary>
        public static EmissionSource Default => new EmissionSource(new IEmission[0]);

        private readonly IEnumerable<IEmission> candidates;

        private EmissionSource(IEnumerable<IEmission> candidates)
        {
            this.candidates = candidates;
        }

        /// <summary>
        /// Adds <see cref="IEmission"/> to <see cref="EmissionSource"/>.
        /// </summary>
        /// <param name="emission">
        /// <see cref="IEmission"/> to collect.
        /// </param>
        /// <returns>
        /// <see cref="EmissionSource"/> added.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="emission"/> is null.
        /// </exception>
        public EmissionSource Synthesize(IEmission emission)
        {
            if (emission == null)
            {
                throw new ArgumentNullException(nameof(emission));
            }

            if (candidates.Contains(emission))
            {
                return this;
            }

            return new EmissionSource(candidates.Append(emission));
        }

        /// <summary>
        /// Builds <see cref="IEmission"/> to cancel collected <see cref="IEmission"/>s.
        /// </summary>
        /// <returns>
        /// <see cref="IEmission"/> to cancel collected <see cref="IEmission"/>s.
        /// </returns>
        public IEmission Build()
        {
            return new Emission(candidates.ToArray());
        }
        private sealed class Emission :
            IEmission
        {
            private readonly IEmission[] emissions;

            internal Emission(IEmission[] emissions)
            {
                this.emissions = emissions;
            }

            public void Emit()
            {
                foreach (var emission in emissions)
                {
                    emission.Emit();
                }
            }
        }
    }
}
