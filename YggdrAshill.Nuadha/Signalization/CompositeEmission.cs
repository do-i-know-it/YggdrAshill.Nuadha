using YggdrAshill.Nuadha.Signalization;
using System;
using System.Collections.Generic;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Executes each of synthesized <see cref="IEmission"/> simultaneously.
    /// </summary>
    public sealed class CompositeEmission :
        IEmission
    {
        private readonly List<IEmission> emissionList = new List<IEmission>();

        /// <inheritdoc/>
        public void Emit()
        {
            foreach (var emission in emissionList)
            {
                emission.Emit();
            }
        }

        internal void Synthesize(IEmission emission)
        {
            if (emission == null)
            {
                throw new ArgumentNullException(nameof(emission));
            }

            if (emissionList.Contains(emission))
            {
                return;
            }

            emissionList.Add(emission);
        }
    }
}
