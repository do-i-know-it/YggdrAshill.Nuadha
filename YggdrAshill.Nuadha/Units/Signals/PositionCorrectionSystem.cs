using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class PositionCorrectionSystem : CorrectionSystem<Position>
    {
        protected override IPropagation<Position> Propagation { get; } = new Propagation<Position>();

        protected override ICalculation<Position> Calculation { get; } = Signals.Calculation.Position;

        protected override IGeneration<Position> Generation { get; }

        #region Constructor

        public PositionCorrectionSystem(IGeneration<Position> generation)
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            Generation = generation;
        }

        public PositionCorrectionSystem(Func<Position> generation)
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            Generation = new Generation<Position>(generation);
        }

        #endregion
    }
}
