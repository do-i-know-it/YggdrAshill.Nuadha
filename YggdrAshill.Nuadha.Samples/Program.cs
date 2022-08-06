using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha.Samples
{
    internal sealed class Program
    {
        private static void Main(string[] arguments)
        {
            var propagation = Propagate<Button>.WithLatestCache(Button.None);

            var cancellation
                = propagation
                .Produce(signal =>
                {
                    Console.WriteLine($"Touch: {signal.Touch}\nPush: {signal.Push}");
                });

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

                    Console.WriteLine($"{input}");

                    var touch = (input == "t").ToTouch();

                    var push = (input == "p").ToPush();

                    var button = new Button(touch, push);

                    propagation.Consume(button);

                    Console.WriteLine();
                }
            }
        }
    }
}
