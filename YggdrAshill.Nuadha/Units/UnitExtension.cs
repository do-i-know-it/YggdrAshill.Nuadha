using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public static class UnitExtension
    {
        public static IButton Convert(this IButtonConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new Button(configuration);
        }

        public static ITrigger Convert(this ITriggerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new Trigger(configuration);
        }

        public static IStick Convert(this IStickConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new Stick(configuration);
        }

        public static IPoseTracker Convert(this IPoseTrackerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new PoseTracker(configuration);
        }

        public static IHeadTracker Convert(this IHeadTrackerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new HeadTracker(configuration);
        }

        public static IHandController Convert(this IHandControllerConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new HandController(configuration);
        }

        public static IConnection<IPoseTrackerHardwareHandler> Calibrate(this IPoseTrackerSoftwareHandler handler, IPoseTrackerConfiguration configuration)
        {
            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            return new ConnectCalibratedPoseTracker(handler, configuration);
        }
    }
}
