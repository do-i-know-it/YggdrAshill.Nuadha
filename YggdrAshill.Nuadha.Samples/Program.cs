using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Unitization;
using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using YggdrAshill.Nuadha.Units;
using System;

namespace YggdrAshill.Nuadha.Samples
{
    internal class Program
    {
        private static IProtocol<IButtonHardware, IButtonSoftware> Device { get; } = Button.WithLatestCache();

        private static IProtocol<IPulsatedButtonHardware, IPulsatedButtonSoftware> DeviceEvent { get; } = PulsatedButton.WithLatestCache();

        private static void Main(string[] arguments)
        {
            // Device
            var configuration = new ToggleButton();

            // System
            var connection = new ShowInConsole();

            // Button to pulsated button
            var conversion = Device.Hardware.Pulsate().Connect();

            // Button transmission
            var transmission = Button.Transmit(configuration);

            var cancellation
                = CancellationSource
                .Default
                .Synthesize(transmission.Connect(Device.Software))
                .Synthesize(connection.Connect(Device.Hardware))
                .Synthesize(conversion.Connect(DeviceEvent.Software))
                .Synthesize(connection.Connect(DeviceEvent.Hardware))
                .Build();

            using (cancellation.ToDisposable())
            {
                while (true)
                {
                    Console.WriteLine("Please enter any key to emit signals.");
                    Console.WriteLine("Please enter \"q\" to quit this program.");
                    Console.Write("Key: ");

                    var input = Console.ReadLine();
                    if (input == "q")
                    {
                        Console.WriteLine("quit.");
                        return;
                    }

                    transmission.Emit();

                    Console.WriteLine($"{input}");
                    Console.WriteLine();
                }
            }
        }

        private sealed class ToggleButton :
            IButtonConfiguration
        {
            private bool touch;

            private bool push;

            public IGeneration<Touch> Touch => Generate.Signal(() =>
            {
                touch = !touch;

                return touch.ToTouch();
            });

            public IGeneration<Push> Push => Generate.Signal(() =>
            {
                push = !push;

                return push.ToPush();
            });
        }

        private sealed class ShowInConsole :
            IConnection<IButtonHardware>,
            IConnection<IPulsatedButtonHardware>
        {
            public ICancellation Connect(IButtonHardware module)
                => CancellationSource
                .Default
                .Synthesize(module.Touch.Produce(signal =>
                {
                    Console.WriteLine(signal);
                }))
                .Synthesize(module.Push.Produce(signal =>
                {
                    Console.WriteLine(signal);
                }))
                .Build();

            public ICancellation Connect(IPulsatedButtonHardware module)
                => CancellationSource
                .Default
                .Synthesize(module.Touch.Detect(PulseIs.Enabled).Produce(() =>
                {
                    Console.WriteLine("Touched.");
                }))
                .Synthesize(module.Push.Detect(PulseIs.Enabled).Produce(() =>
                {
                    Console.WriteLine("Pushed.");
                }))
                .Build();
        }
    }
}
