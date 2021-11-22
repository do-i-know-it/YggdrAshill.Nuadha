using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha
{
    public static class PulsatedHandControllerExtension
    {
        public static IConnection<IPulsatedHandControllerHardware> Connect(this IPulsatedHandControllerSoftware software)
        {
            if (software == null)
            {
                throw new ArgumentNullException(nameof(software));
            }

            return Nuadha.Connect.PulsatedHandController(software);
        }

        public static IConnection<IPulsatedHandControllerSoftware> Connect(this IPulsatedHandControllerHardware hardware)
        {
            if (hardware == null)
            {
                throw new ArgumentNullException(nameof(hardware));
            }

            return Nuadha.Connect.PulsatedHandController(hardware);
        }
    }
}
