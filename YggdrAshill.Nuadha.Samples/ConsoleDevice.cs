using YggdrAshill.Nuadha.Signalization;

namespace YggdrAshill.Nuadha.Samples;

internal sealed class ConsoleDevice : IDevice
{
    private readonly Flow<Request> flow = new();
    public IIncomingFlow<Request> Keyboard => flow;
    public IOutgoingFlow<Response> Display { get; }

    public ConsoleDevice()
    {
        Display = new OutgoingFlow<Response>(signal =>
        {
            switch (signal.Result)
            {
                case Response.ResultType.Success:
                    Console.WriteLine($"Received: {signal.Content}.");
                    break;
                case Response.ResultType.HowToUse:
                    ShowHowToUse();
                    break;
                default:
                    Console.WriteLine("Error occured.");
                    break;
            }
        });
    }

    private static void ShowHowToUse()
    {
        Console.WriteLine("Please enter any keys to send signal.");
        Console.WriteLine("If you quit this program, enter \"q\".");
        Console.Write("Key: ");
    }

    public void Run()
    {
        while (true)
        {
            ShowHowToUse();
            var input = Console.ReadLine() ?? string.Empty;
            if (input == "q")
            {
                Console.WriteLine("quit.");
                return;
            }
            Console.WriteLine($"Sent: {input}.");
            flow.Export(new Request()
            {
                Content = input
            });
            Console.WriteLine();
        }
    }
}
