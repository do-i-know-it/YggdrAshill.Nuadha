using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines implementations to imitate signals and units.
    /// </summary>
    public static class Imitate
    {
        /// <summary>
        /// Imitated <see cref="IGeneration{TSignal}"/> for <see cref="Signals.Touch"/>.
        /// </summary>
        public static IGeneration<Touch> Touch => imitation;

        /// <summary>
        /// Imitated <see cref="IGeneration{TSignal}"/> for <see cref="Signals.Push"/>.
        /// </summary>
        public static IGeneration<Push> Push => imitation;

        /// <summary>
        /// Imitated <see cref="IGeneration{TSignal}"/> for <see cref="Signals.Pull"/>.
        /// </summary>
        public static IGeneration<Pull> Pull => imitation;

        /// <summary>
        /// Imitated <see cref="IGeneration{TSignal}"/> for <see cref="Signals.Tilt"/>.
        /// </summary>
        public static IGeneration<Tilt> Tilt => imitation;

        /// <summary>
        /// Imitated <see cref="IGeneration{TSignal}"/> for <see cref="Space3D.Position"/>.
        /// </summary>
        public static IGeneration<Space3D.Position> Position => imitation;

        /// <summary>
        /// Imitated <see cref="IGeneration{TSignal}"/> for <see cref="Space3D.Rotation"/>.
        /// </summary>
        public static IGeneration<Space3D.Rotation> Rotation => imitation;

        /// <summary>
        /// Imitated <see cref="IGeneration{TSignal}"/> for <see cref="Space3D.Direction"/>.
        /// </summary>
        public static IGeneration<Space3D.Direction> Direction => imitation;

        /// <summary>
        /// Imitated <see cref="IButtonConfiguration"/>.
        /// </summary>
        public static IButtonConfiguration Button => imitation;

        /// <summary>
        /// Imitated <see cref="ITriggerConfiguration"/>.
        /// </summary>
        public static ITriggerConfiguration Trigger => imitation;

        /// <summary>
        /// Imitated <see cref="IStickConfiguration"/>.
        /// </summary>
        public static IStickConfiguration Stick => imitation;

        /// <summary>
        /// Imitated <see cref="IPoseTrackerConfiguration"/>.
        /// </summary>
        public static IPoseTrackerConfiguration PoseTracker => imitation;

        /// <summary>
        /// Imitated <see cref="IHeadTrackerConfiguration"/>.
        /// </summary>
        public static IHeadTrackerConfiguration HeadTracker => imitation;

        /// <summary>
        /// Imitated <see cref="IHandControllerConfiguration"/>.
        /// </summary>
        public static IHandControllerConfiguration HandController => imitation;

        private static readonly Imitation imitation = new Imitation();

        private sealed class Imitation :
            IGeneration<Touch>,
            IGeneration<Push>,
            IGeneration<Pull>,
            IGeneration<Tilt>,
            IGeneration<Space3D.Position>,
            IGeneration<Space3D.Rotation>,
            IGeneration<Space3D.Direction>,
            IButtonConfiguration,
            ITriggerConfiguration,
            IStickConfiguration,
            IPoseTrackerConfiguration,
            IHeadTrackerConfiguration,
            IHandControllerConfiguration
        {
            public IGeneration<Touch> Touch => this;

            public IGeneration<Push> Push => this;

            public IGeneration<Pull> Pull => this;

            public IGeneration<Tilt> Tilt => this;

            public IGeneration<Space3D.Position> Position => this;

            public IGeneration<Space3D.Rotation> Rotation => this;

            public IGeneration<Space3D.Direction> Direction => this;

            IPoseTrackerConfiguration IHeadTrackerConfiguration.Pose => this;

            IPoseTrackerConfiguration IHandControllerConfiguration.Pose => this;

            IStickConfiguration IHandControllerConfiguration.Thumb => this;

            ITriggerConfiguration IHandControllerConfiguration.IndexFinger => this;

            ITriggerConfiguration IHandControllerConfiguration.HandGrip => this;

            Touch IGeneration<Touch>.Generate()
            {
                return Signals.Touch.Disabled;
            }

            Push IGeneration<Push>.Generate()
            {
                return Signals.Push.Disabled;
            }

            Pull IGeneration<Pull>.Generate()
            {
                return Signals.Pull.Minimum.ToPull();
            }

            Tilt IGeneration<Tilt>.Generate()
            {
                return Signals.Tilt.Origin;
            }

            Space3D.Position IGeneration<Space3D.Position>.Generate()
            {
                return Space3D.Position.Origin;
            }

            Space3D.Rotation IGeneration<Space3D.Rotation>.Generate()
            {
                return Space3D.Rotation.None;
            }

            Space3D.Direction IGeneration<Space3D.Direction>.Generate()
            {
                return Space3D.Direction.Forward;
            }
        }
    }
}
