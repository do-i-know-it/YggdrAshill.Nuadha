namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines configuration for three point tracker.
    /// </summary>
    public interface IThreePointTracker
    {
        /// <summary>
        /// <see cref="IHeadTracker"/> for head.
        /// </summary>
        IHeadTracker Head { get; }

        /// <summary>
        /// <see cref="IHandController"/> for left hand.
        /// </summary>
        IHandController LeftHand { get; }

        /// <summary>
        /// <see cref="IHandController"/> for right hand.
        /// </summary>
        IHandController RightHand { get; }
    }
}
