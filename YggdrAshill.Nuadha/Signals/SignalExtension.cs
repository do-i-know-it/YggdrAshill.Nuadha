using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Conversion;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public static class SignalExtension
    {
        #region Position

        public static IConnection<Position> Correct(this IConnection<Position> connection, Func<Position> generation)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return connection.Correct(new Generation<Position>(generation));
        }

        #endregion

        #region Rotation

        public static IConnection<Rotation> Correct(this IConnection<Rotation> connection, Func<Rotation> generation)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return connection.Correct(new Generation<Rotation>(generation));
        }

        #endregion

        #region Direction

        public static IConnection<Direction> Correct(this IConnection<Direction> connection, Func<Direction> generation)
        {
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return connection.Correct(new Generation<Direction>(generation));
        }

        #endregion
    }
}
