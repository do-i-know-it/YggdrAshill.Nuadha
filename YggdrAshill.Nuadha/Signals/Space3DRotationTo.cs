using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations of Transformation for <see cref="Space3D.Rotation"/>.
    /// </summary>
    public static class Space3DRotationTo
    {
        /// <summary>
        /// Corrects <see cref="Space3D.Rotation"/> to calibrate.
        /// </summary>
        /// <param name="generation">
        /// <see cref="IGeneration{TSignal}"/> to generate offset of <see cref="Space3D.Rotation"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITranslation{TInput, TOutput}"/> to correct <see cref="Space3D.Rotation"/>.
        /// </returns>
        public static ITranslation<Space3D.Rotation, Space3D.Rotation> Calibrate(IGeneration<Space3D.Rotation> generation)
        {
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return SignalInto.Signal<Space3D.Rotation>(signal =>
            {
                var offset = generation.Generate();

                return signal + offset;
            });
        }
    }
}
