using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public static class Initialize
    {
        public static IGeneration<Pulse> Pulse { get; } = Generation.Of(() => Transformation.Pulse.IsDisabled);

        public static IGeneration<Touch> Touch { get; } = Generation.Of(() => Signals.Touch.Disabled);

        public static IGeneration<Push> Push { get; } = Generation.Of(() => Signals.Push.Disabled);

        public static IGeneration<Pull> Pull { get; } = Generation.Of(() => new Pull(0.0f));

        public static IGeneration<Tilt> Tilt { get; } = Generation.Of(() => Signals.Tilt.Origin);

        public static class Space3D
        {
            public static IGeneration<Signals.Space3D.Direction> Direction { get; } = Generation.Of(() => Signals.Space3D.Direction.Forward);

            public static IGeneration<Signals.Space3D.Position> Position { get; } = Generation.Of(() => Signals.Space3D.Position.Origin);

            public static IGeneration<Signals.Space3D.Rotation> Rotation { get; } = Generation.Of(() => Signals.Space3D.Rotation.None);
        }
    }
}
