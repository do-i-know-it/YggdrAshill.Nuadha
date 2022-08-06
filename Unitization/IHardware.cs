namespace YggdrAshill.Nuadha.Unitization
{
    /// <summary>
    /// Defines device.
    /// If it sends some <see cref="Signalization.ISignal"/>s to <see cref="ISoftware"/>, define <see cref="Signalization.IProduction{TSignal}"/>s.
    /// If it receives some <see cref="Signalization.ISignal"/>s from <see cref="ISoftware"/>, define <see cref="Signalization.IConsumption{TSignal}"/>s.
    /// </summary>
    public interface IHardware
    {

    }
}
