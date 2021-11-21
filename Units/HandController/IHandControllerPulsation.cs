namespace YggdrAshill.Nuadha.Units
{
    public interface IHandControllerPulsation
    {
        IStickPulsation Thumb { get; }

        ITriggerPulsation IndexFinger { get; }

        ITriggerPulsation HandGrip { get; }
    }
}
