using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Units
{
    public interface IButtonModule
    {
        IPropagation<Touch> Touch { get; }

        IPropagation<Push> Push { get; }
    }
}
