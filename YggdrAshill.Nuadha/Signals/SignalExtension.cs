using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Translation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public static class SignalExtension
    {
        #region Position

        public static IOutputTerminal<Position> Calibrate(this IOutputTerminal<Position> terminal, Func<Position> calibration)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            return terminal.Calibrate(Signals.Calibrate.Position, new Calibration<Position>(calibration));
        }

        #endregion

        #region Rotation

        public static IOutputTerminal<Rotation> Calibrate(this IOutputTerminal<Rotation> terminal, Func<Rotation> calibration)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            return terminal.Calibrate(Signals.Calibrate.Rotation, new Calibration<Rotation>(calibration));
        }

        #endregion

        #region Direction

        public static IOutputTerminal<Direction> Calibrate(this IOutputTerminal<Direction> terminal, Func<Direction> calibration)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (calibration == null)
            {
                throw new ArgumentNullException(nameof(calibration));
            }

            return terminal.Calibrate(Signals.Calibrate.Direction, new Calibration<Direction>(calibration));
        }

        #endregion
    }
}
