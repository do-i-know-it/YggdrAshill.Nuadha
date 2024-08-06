using YggdrAshill.Nuadha;
using YggdrAshill.Nuadha.Samples;

var module = new SampleModule();
using var disposableHardware = module.Hardware.Input.Import(signal =>
{
    var content = signal.Content;
    Console.WriteLine($"Received {content} from device.");
    module.Hardware.Output.Export(new Note()
    {
        Content = string.Join("", content.Reverse())
    });
});
using var disposableSoftware = module.Software.Output.Import(signal =>
{
    Console.WriteLine($"Received {signal.Content} from system.");
});
while (true)
{
    Console.WriteLine("Please enter any keys to send signal.");
    Console.WriteLine("If you quit this program, enter \"q\".");
    Console.Write("Key: ");

    var input = Console.ReadLine();
    if (input == null)
    {
        throw new Exception($"{nameof(input)} is null.");
    }
    if (input == "q")
    {
        Console.WriteLine("quit.");
        return;
    }
    module.Software.Input.Export(new Note()
    {
        Content = input
    });
    Console.WriteLine();
}
