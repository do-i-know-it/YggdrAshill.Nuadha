using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Signals
{
    public interface IPositionSystem :
        IDivider<Position>,
        IOutputTerminal<Position>,
        IDisconnection
    {

    }
}
