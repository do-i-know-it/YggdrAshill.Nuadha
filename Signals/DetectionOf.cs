using YggdrAshill.Nuadha.Transformation;
using System;

namespace YggdrAshill.Nuadha.Signals
{
    public sealed class DetectionOf :
        IDetection<Touch>,
        IDetection<Push>
    {
        #region Singleton

        private static DetectionOf Instance { get; } = new DetectionOf();

        private DetectionOf()
        {

        }

        #endregion

        #region Touch

        public static IDetection<Touch> Touch => Instance;

        bool IDetection<Touch>.Detect(Touch signal)
        {
            if (signal == Signals.Touch.Enabled)
            {
                return true;
            }

            if (signal == Signals.Touch.Disabled)
            {
                return false;
            }

            throw new NotSupportedException($"{signal}");
        }

        #endregion

        #region Push

        public static IDetection<Push> Push => Instance;

        bool IDetection<Push>.Detect(Push signal)
        {
            if (signal == Signals.Push.Enabled)
            {
                return true;
            }

            if (signal == Signals.Push.Disabled)
            {
                return false;
            }

            throw new NotSupportedException($"{signal}");
        }

        #endregion
    }
}
