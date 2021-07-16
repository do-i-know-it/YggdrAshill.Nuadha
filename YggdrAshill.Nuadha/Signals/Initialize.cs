using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    internal static class Initialize
    {
        internal static IGeneration<Pulse> Pulse { get; } = Generation.Of(() => Transformation.Pulse.IsDisabled);

        internal static IGeneration<Touch> Touch { get; } = Generation.Of(() => Signals.Touch.Disabled);

        internal static IGeneration<Push> Push { get; } = Generation.Of(() => Signals.Push.Disabled);

        internal static IGeneration<Pull> Pull { get; } = Generation.Of(() => new Pull(0.0f));

        internal static IGeneration<Tilt> Tilt { get; } = Generation.Of(() => Signals.Tilt.Origin);

        internal static class Space3D
        {
            internal static IGeneration<Signals.Space3D.Direction> Direction { get; } = Generation.Of(() => Signals.Space3D.Direction.Forward);

            internal static IGeneration<Signals.Space3D.Position> Position { get; } = Generation.Of(() => Signals.Space3D.Position.Origin);

            internal static IGeneration<Signals.Space3D.Rotation> Rotation { get; } = Generation.Of(() => Signals.Space3D.Rotation.None);
        }
    }
}
