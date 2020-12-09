using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conduction;

namespace YggdrAshill.Nuadha.Signals
{
    public interface IRotationSystem :
        IDivider<Rotation>,
        IOutputTerminal<Rotation>,
        IDisconnection
    {

    }
}
