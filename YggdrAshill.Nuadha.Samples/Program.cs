using YggdrAshill.Nuadha.Conduction;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Samples
{
    internal class Program
    {
        private sealed class FixedButton :
            IButtonConfiguration
        {
            internal static FixedButton Instance { get; } = new FixedButton();

            private FixedButton()
            {

            }

            public IGeneration<Touch> Touch => Generation.Of(() => Signals.Touch.Enabled);

            public IGeneration<Push> Push => Generation.Of(() => Signals.Push.Disabled);
        }

        private static void Main(string[] arguments)
        {
            using (var protocol = Button.WithoutCache())
            using (var ignition = Button.WithoutCache().Convert(FixedButton.Instance))
            using (var composite = new CompositeCancellation())
            {
                protocol
                    .Software
                    .Touch
                    .Produce(signal =>
                    {
                        Console.WriteLine(signal);
                    })
                    .Synthesize(composite);
                protocol
                    .Software
                    .Push
                    .Produce(signal =>
                    {
                        Console.WriteLine(signal);
                    })
                    .Synthesize(composite);

                ignition
                    .Connect(protocol.Hardware)
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

                    ignition.Emit();

                    Console.WriteLine($"{input}");
                    Console.WriteLine();
                }
            }
        }
    }
}
