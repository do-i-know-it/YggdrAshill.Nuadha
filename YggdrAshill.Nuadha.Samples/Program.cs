using YggdrAshill.Nuadha.Monitorization;
using System;
using System.Linq;

namespace YggdrAshill.Nuadha.Samples
{
    internal sealed class Program
    {
        private static void Main(string[] arguments)
        {
            var module = new SampleModule();

            using (module.Hardware.Input.Send(signal =>
            {
                Console.WriteLine($"Received {signal} from device.");

                var output = string.Join("", signal.Reverse());

                module.Hardware.Output.Consume((Note)output);
            }).ToDisposable())
            using (module.Software.Output.Send(signal =>
            {
                Console.WriteLine($"Received {signal} from system.");
            }).ToDisposable())
            {
                while (true)
                {
                    Console.WriteLine("Please enter any keys to send signal.");
                    Console.WriteLine("If you quit this program, enter \"q\".");
                    Console.Write("Key: ");

                    var input = Console.ReadLine();

                    if (input == "q")
                    {
                        Console.WriteLine("quit.");
                        return;
                    }

                    module.Software.Input.Consume((Note)input);

                    Console.WriteLine();
                }
            }
        }
    }
}
