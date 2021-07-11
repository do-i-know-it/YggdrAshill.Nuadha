namespace YggdrAshill.Nuadha.Units
{
    public interface IPulsatedHandControllerModule
    {
        IPulsatedStickModule Thumb { get; }

        IPulsatedTriggerModule IndexFinger { get; }

        IPulsatedTriggerModule HandGrip { get; }
    }
}
