using YggdrAshill.Nuadha.Signalization;
using System;

namespace YggdrAshill.Nuadha
{
    public sealed class Emission :
        IEmission
    {
        private readonly Action onActuated;

        #region Constructor

        public Emission(Action onActuated)
        {
            if (onActuated == null)
            {
                throw new ArgumentNullException(nameof(onActuated));
            }

            this.onActuated = onActuated;
        }
        
        public Emission()
        {
            onActuated = () =>
            {

            };
        }

        #endregion

        #region IEmission

        public void Emit()
        {
            onActuated.Invoke();
        }

        #endregion
    }
}
