using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha.Samples
{
    internal sealed class MockButton :
        IButtonConfiguration
    {
        public static MockButton Instance { get; } = new MockButton();

        private MockButton()
        {

        }

        public IGeneration<Touch> Touch => Generation.Of(() => Signals.Touch.Enabled);

        public IGeneration<Push> Push => Generation.Of(() => Signals.Push.Disabled);
    }
}
