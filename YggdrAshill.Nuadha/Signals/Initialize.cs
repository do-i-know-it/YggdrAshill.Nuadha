using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Transformation;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    internal static class Initialize
    {
        internal static IGeneration<Pulse> Pulse { get; } = Generate.Signal(() => Transformation.Pulse.IsDisabled);

        internal static IGeneration<Touch> Touch { get; } = Generate.Signal(() => Signals.Touch.Disabled);

        internal static IGeneration<Push> Push { get; } = Generate.Signal(() => Signals.Push.Disabled);

        internal static IGeneration<Pull> Pull { get; } = Generate.Signal(() => new Pull(0.0f));

        internal static IGeneration<Tilt> Tilt { get; } = Generate.Signal(() => Signals.Tilt.Origin);

        internal static class Space3D
        {
            internal static IGeneration<Signals.Space3D.Direction> Direction { get; } = Generate.Signal(() => Signals.Space3D.Direction.Forward);

            internal static IGeneration<Signals.Space3D.Position> Position { get; } = Generate.Signal(() => Signals.Space3D.Position.Origin);

            internal static IGeneration<Signals.Space3D.Rotation> Rotation { get; } = Generate.Signal(() => Signals.Space3D.Rotation.None);
        }
    }
}
