using YggdrAshill.Nuadha.Conduction;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Emission :
        IEmission
    {
        private readonly Action onEmitted;

        #region Constructor

        public Emission(Action onEmitted)
        {
            if (onEmitted == null)
            {
                throw new ArgumentNullException(nameof(onEmitted));
            }

            this.onEmitted = onEmitted;
        }
        
        public Emission()
        {
            onEmitted = () =>
            {

            };
        }

        #endregion

        #region IEmission

        public void Emit()
        {
            onEmitted.Invoke();
        }

        #endregion
    }
}
