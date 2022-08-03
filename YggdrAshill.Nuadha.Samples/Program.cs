using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Samples
{
    internal sealed class Program
    {
        private static void Main(string[] arguments)
        {
            var propagation = Propagate.WithLatestCache(Imitate.Button);

            var cancellation
                = propagation
                .Produce(signal =>
                {
                    Console.WriteLine($"Touch: {signal.Touch}\nPush: {signal.Push}");
                });

            using (cancellation.ToDisposable())
            {
                var touch = false;
                var push = false;

                var generation = Generate.Signal(() =>
                {
                    return new Button(touch.ToTouch(), push.ToPush());
                });

                var emission
                    = propagation.Conduct(generation);

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

                    touch = input == "t";

                    push = input == "p";

                    emission.Emit();

                    Console.WriteLine($"{input}");
                    Console.WriteLine();
                }
            }
        }
    }
}
