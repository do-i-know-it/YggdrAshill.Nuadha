using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class RotationCorrectionSystem : CorrectionSystem<Rotation>
    {
        protected override IPropagation<Rotation> Propagation { get; } = new Propagation<Rotation>();

        protected override ICalculation<Rotation> Calculation { get; } = Signals.Calculation.Rotation;

        protected override IGeneration<Rotation> Generation { get; }

        #region Constructor

        public RotationCorrectionSystem(IGeneration<Rotation> generation)
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            Generation = generation;
        }

        public RotationCorrectionSystem(Func<Rotation> generation)
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            Generation = new Generation<Rotation>(generation);
        }

        #endregion
    }
}
