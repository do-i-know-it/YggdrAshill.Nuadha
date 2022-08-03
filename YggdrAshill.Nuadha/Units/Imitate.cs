using YggdrAshill.Nuadha.Transformation;
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
        /// Imitated <see cref="IGeneration{TSignal}"/> for <see cref="Transformation.Pulse"/>.
        /// </summary>
        public static IGeneration<Pulse> Pulse => imitation;

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
        /// Imitated <see cref="IGeneration{TSignal}"/> for <see cref="Space3D.Pose"/>.
        /// </summary>
        public static IGeneration<Space3D.Pose> Pose => imitation;

        /// <summary>
        /// Imitated <see cref="IGeneration{TSignal}"/> for <see cref="Signals.Button"/>.
        /// </summary>
        public static IGeneration<Button> Button => imitation;

        /// <summary>
        /// Imitated <see cref="IGeneration{TSignal}"/> for <see cref="Signals.Trigger"/>.
        /// </summary>
        public static IGeneration<Trigger> Trigger => imitation;

        /// <summary>
        /// Imitated <see cref="IGeneration{TSignal}"/> for <see cref="Signals.Stick"/>.
        /// </summary>
        public static IGeneration<Stick> Stick => imitation;

        private static readonly Imitation imitation = new Imitation();

        private sealed class Imitation :
            IGeneration<Pulse>,
            IGeneration<Touch>,
            IGeneration<Push>,
            IGeneration<Pull>,
            IGeneration<Tilt>,
            IGeneration<Space3D.Position>,
            IGeneration<Space3D.Rotation>,
            IGeneration<Space3D.Direction>,
            IGeneration<Space3D.Pose>,
            IGeneration<Button>,
            IGeneration<Trigger>,
            IGeneration<Stick>
        {
            Pulse IGeneration<Pulse>.Generate()
            {
                return Transformation.Pulse.IsDisabled;
            }

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

            Space3D.Pose IGeneration<Space3D.Pose>.Generate()
            {
                return Space3D.Pose.Origin;
            }

            Button IGeneration<Button>.Generate()
            {
                return Signals.Button.None;
            }

            Trigger IGeneration<Trigger>.Generate()
            {
                return Signals.Trigger.None;
            }

            Stick IGeneration<Stick>.Generate()
            {
                return Signals.Stick.None;
            }
        }
    }
}
