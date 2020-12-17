using YggdrAshill.Nuadha.Signals;

namespace YggdrAshill.Nuadha
{
    public sealed class EyeTrackerThreshold :
        IEyeTrackerThreshold
    {
        public HysteresisThreshold Pupil { get; }
        
        public HysteresisThreshold Blink { get; }
        
        public EyeTrackerThreshold(HysteresisThreshold pupil, HysteresisThreshold blink)
        {
            Pupil = pupil;
     
            Blink = blink;
        }
    }
}
