using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Samples
{
    internal class Program
    {
        private static void Main(string[] arguments)
        {
            using (var module = ButtonModule.WithoutCache())
            using (var device = ButtonModule.WithoutCache().Convert(new Button()))
            using (device.Connect(module.HardwareHandler).ToDisposable())
            using (var composite = new CompositeCancellation())
            {
                var software = module.SoftwareHandler;
                software
                    .Touch.Produce<Touch>(signal =>
                    {
                        Console.WriteLine(signal);
                    })
                    .Synthesize(composite);
                software
                    .Push.Produce<Push>(signal =>
                    {
                        Console.WriteLine(signal);
                    })
                    .Synthesize(composite);

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

                    device.Emit();

                    Console.WriteLine($"{input}");
                    Console.WriteLine();
                }
            }
        }
    }
}
