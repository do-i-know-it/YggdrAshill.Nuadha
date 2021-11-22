using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public static class Conduct
    {
        public static IEmission Button(IButtonConfiguration configuration, IButtonSoftware software)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            var composite = new CompositeEmission();

            software.Touch.Conduct(configuration.Touch).Synthesize(composite);
            software.Push.Conduct(configuration.Push).Synthesize(composite);

            return composite;
        }

        public static IEmission Trigger(ITriggerConfiguration configuration, ITriggerSoftware software)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            var composite = new CompositeEmission();

            software.Touch.Conduct(configuration.Touch).Synthesize(composite);
            software.Pull.Conduct(configuration.Pull).Synthesize(composite);

            return composite;
        }

        public static IEmission Stick(IStickConfiguration configuration, IStickSoftware software)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            var composite = new CompositeEmission();

            software.Touch.Conduct(configuration.Touch).Synthesize(composite);
            software.Tilt.Conduct(configuration.Tilt).Synthesize(composite);

            return composite;
        }

        public static IEmission PoseTracker(IPoseTrackerConfiguration configuration, IPoseTrackerSoftware software)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            var composite = new CompositeEmission();

            software.Position.Conduct(configuration.Position).Synthesize(composite);
            software.Rotation.Conduct(configuration.Rotation).Synthesize(composite);

            return composite;
        }

        public static IEmission HeadTracker(IHeadTrackerConfiguration configuration, IHeadTrackerSoftware software)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            var composite = new CompositeEmission();

            software.Pose.Position.Conduct(configuration.Pose.Position).Synthesize(composite);
            software.Pose.Rotation.Conduct(configuration.Pose.Rotation).Synthesize(composite);
            software.Direction.Conduct(configuration.Direction).Synthesize(composite);

            return composite;
        }

        public static IEmission HandController(IHandControllerConfiguration configuration, IHandControllerSoftware software)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            var composite = new CompositeEmission();

            software.HandGrip.Touch.Conduct(configuration.HandGrip.Touch).Synthesize(composite);
            software.HandGrip.Pull.Conduct(configuration.HandGrip.Pull).Synthesize(composite);

            software.IndexFinger.Touch.Conduct(configuration.IndexFinger.Touch).Synthesize(composite);
            software.IndexFinger.Pull.Conduct(configuration.IndexFinger.Pull).Synthesize(composite);

            software.Thumb.Touch.Conduct(configuration.Thumb.Touch).Synthesize(composite);
            software.Thumb.Tilt.Conduct(configuration.Thumb.Tilt).Synthesize(composite);

            software.Pose.Position.Conduct(configuration.Pose.Position).Synthesize(composite);
            software.Pose.Rotation.Conduct(configuration.Pose.Rotation).Synthesize(composite);

            return composite;
        }
    }
}
