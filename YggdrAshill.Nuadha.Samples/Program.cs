using YggdrAshill.Nuadha;
using YggdrAshill.Nuadha.Samples;

var flow = new Flow<Note>();

using var disposable = flow.Convert(signal =>
{
    var content = signal.Content;
    return new Note()
    {
        Content = string.Join("", content.Reverse())
    };
}).Import(signal =>
{
    Console.WriteLine($"Received: {signal.Content}.");
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
    Console.WriteLine($"Sent: {input}.");
    flow.Export(new Note()
    {
        Content = input
    });
    Console.WriteLine();
}
