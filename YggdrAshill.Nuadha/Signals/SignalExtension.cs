using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    /// <summary>
    /// Defines extensions for Signals.
    /// </summary>
    public static class SignalExtension
    {
        #region Touch

        /// <summary>
        /// Converts <see cref="bool"/> to <see cref="Touch"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="bool"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Touch"/> converted.
        /// </returns>
        public static Touch ToTouch(this bool signal)
        {
            return (Touch)signal;
        }

        /// <summary>
        /// Converts <see cref="Touch"/> to <see cref="bool"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Touch"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="bool"/> converted.
        /// </returns>
        public static bool ToBoolean(this Touch signal)
        {
            return (bool)signal;
        }

        /// <summary>
        /// Produces <see cref="Touch"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to produce <see cref="Touch"/>.
        /// </param>
        /// <param name="consumption">
        /// <see cref="Action{T}"/> executed when this has consumed <see cref="Touch"/>.
        /// </param>
        /// <returns>
        /// <see cref="ICancellation"/> to cancel.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static ICancellation Produce(this IProduction<Touch> production, Action<bool> consumption)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return production.Produce(signal =>
            {
                consumption.Invoke(signal.ToBoolean());
            });
        }

        /// <summary>
        /// Converts <see cref="IPropagation{TSignal}"/> for <see cref="Touch"/> into <see cref="ITransmission{TSignal}"/> for <see cref="Touch"/>.
        /// </summary>
        /// <param name="propagation">
        /// <see cref="IPropagation{TSignal}"/> to produce <see cref="Touch"/>.
        /// </param>
        /// <param name="generation">
        /// <see cref="Func{TResult}"/> to generate <see cref="Touch"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TSignal}"/> to transmit <see cref="Touch"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="propagation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static ITransmission<Touch> Transmit(this IPropagation<Touch> propagation, Func<bool> generation)
        {
            if (propagation == null)
            {
                throw new ArgumentNullException(nameof(propagation));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return propagation.Transmit(() =>
            {
                return generation.Invoke().ToTouch();
            });
        }

        #endregion

        #region Push

        /// <summary>
        /// Converts <see cref="bool"/> to <see cref="Push"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="bool"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Push"/> converted.
        /// </returns>
        public static Push ToPush(this bool signal)
        {
            return (Push)signal;
        }

        /// <summary>
        /// Converts <see cref="Push"/> to <see cref="bool"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Push"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="bool"/> converted.
        /// </returns>
        public static bool ToBoolean(this Push signal)
        {
            return (bool)signal;
        }

        /// <summary>
        /// Produces <see cref="Push"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to produce <see cref="Push"/>.
        /// </param>
        /// <param name="consumption">
        /// <see cref="Action{T}"/> executed when this has consumed <see cref="Push"/>.
        /// </param>
        /// <returns>
        /// <see cref="ICancellation"/> to cancel.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static ICancellation Produce(this IProduction<Push> production, Action<bool> consumption)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return production.Produce(signal =>
            {
                consumption.Invoke(signal.ToBoolean());
            });
        }

        /// <summary>
        /// Converts <see cref="IPropagation{TSignal}"/> for <see cref="Push"/> into <see cref="ITransmission{TSignal}"/> for <see cref="Push"/>.
        /// </summary>
        /// <param name="propagation">
        /// <see cref="IPropagation{TSignal}"/> to produce <see cref="Push"/>.
        /// </param>
        /// <param name="generation">
        /// <see cref="Func{TResult}"/> to generate <see cref="Push"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TSignal}"/> to transmit <see cref="Push"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="propagation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static ITransmission<Push> Transmit(this IPropagation<Push> propagation, Func<bool> generation)
        {
            if (propagation == null)
            {
                throw new ArgumentNullException(nameof(propagation));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return propagation.Transmit(() =>
            {
                return generation.Invoke().ToPush();
            });
        }

        #endregion

        #region Pull

        /// <summary>
        /// Converts <see cref="float"/> to <see cref="Pull"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="float"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Pull"/> converted.
        /// </returns>
        public static Pull ToPull(this float signal)
        {
            return (Pull)signal;
        }

        /// <summary>
        /// Converts <see cref="Pull"/> to <see cref="float"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Pull"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="float"/> converted.
        /// </returns>
        public static float ToSingle(this Pull signal)
        {
            return (float)signal;
        }

        /// <summary>
        /// Produces <see cref="Pull"/>.
        /// </summary>
        /// <param name="production">
        /// <see cref="IProduction{TSignal}"/> to produce <see cref="Pull"/>.
        /// </param>
        /// <param name="consumption">
        /// <see cref="Action{T}"/> executed when this has consumed <see cref="Pull"/>.
        /// </param>
        /// <returns>
        /// <see cref="ICancellation"/> to cancel.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="production"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="consumption"/> is null.
        /// </exception>
        public static ICancellation Produce(this IProduction<Pull> production, Action<float> consumption)
        {
            if (production == null)
            {
                throw new ArgumentNullException(nameof(production));
            }
            if (consumption == null)
            {
                throw new ArgumentNullException(nameof(consumption));
            }

            return production.Produce(signal =>
            {
                consumption.Invoke(signal.ToSingle());
            });
        }

        /// <summary>
        /// Converts <see cref="IPropagation{TSignal}"/> for <see cref="Pull"/> into <see cref="ITransmission{TSignal}"/> for <see cref="Pull"/>.
        /// </summary>
        /// <param name="propagation">
        /// <see cref="IPropagation{TSignal}"/> to produce <see cref="Pull"/>.
        /// </param>
        /// <param name="generation">
        /// <see cref="Func{TResult}"/> to generate <see cref="Pull"/>.
        /// </param>
        /// <returns>
        /// <see cref="ITransmission{TSignal}"/> to transmit <see cref="Pull"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="propagation"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="generation"/> is null.
        /// </exception>
        public static ITransmission<Pull> Transmit(this IPropagation<Pull> propagation, Func<float> generation)
        {
            if (propagation == null)
            {
                throw new ArgumentNullException(nameof(propagation));
            }
            if (generation == null)
            {
                throw new ArgumentNullException(nameof(generation));
            }

            return propagation.Transmit(() =>
            {
                return generation.Invoke().ToPull();
            });
        }

        #endregion

        #region Angle

        /// <summary>
        /// Converts <see cref="float"/> to <see cref="Angle.Radian"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="float"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Angle.Radian"/> converted.
        /// </returns>
        public static Angle.Radian ToRadian(this float signal)
        {
            return (Angle.Radian)signal;
        }

        /// <summary>
        /// Converts <see cref="Angle.Radian"/> to <see cref="float"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Angle.Radian"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="float"/> converted.
        /// </returns>
        public static float ToSingle(this Angle.Radian signal)
        {
            return (float)signal;
        }

        /// <summary>
        /// Converts <see cref="float"/> to <see cref="Angle.Degree"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="float"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Angle.Degree"/> converted.
        /// </returns>
        public static Angle.Degree ToDegree(float signal)
        {
            return (Angle.Degree)signal;
        }

        /// <summary>
        /// Converts <see cref="Angle.Degree"/> to <see cref="float"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Angle.Degree"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="float"/> converted.
        /// </returns>
        public static float ToSingle(Angle.Degree signal)
        {
            return (float)signal;
        }

        /// <summary>
        /// Converts <see cref="Angle.Degree"/> to <see cref="Angle.Radian"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Angle.Degree"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Angle.Radian"/> converted.
        /// </returns>
        public static Angle.Radian ToRadian(this Angle.Degree signal)
        {
            return (Angle.Radian)signal;
        }

        /// <summary>
        /// Converts <see cref="Angle.Radian"/> to <see cref="Angle.Degree"/>.
        /// </summary>
        /// <param name="signal">
        /// <see cref="Angle.Radian"/> to covert.
        /// </param>
        /// <returns>
        /// <see cref="Angle.Degree"/> converted.
        /// </returns>
        public static Angle.Degree ToDegree(Angle.Radian signal)
        {
            return (Angle.Degree)signal;
        }

        #endregion
    }
}
