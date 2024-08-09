using YggdrAshill.Nuadha;
using YggdrAshill.Nuadha.Samples;

var device = new ConsoleDevice();

using var disposable = device.Keyboard.Convert(signal =>
{
    var content = signal.Content;
    if (string.IsNullOrWhiteSpace(content))
    {
        return new Response()
        {
            Result = Response.ResultType.HowToUse,
            Content = string.Empty,
        };
    }
    return new Response()
    {
        Result = Response.ResultType.Success,
        Content = string.Join("", content.Reverse()),
    };
}).Import(device.Display);

device.Run();
