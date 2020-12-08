using YggdrAshill.Nuadha.Signalization;
using YggdrAshill.Nuadha.Operation;
using YggdrAshill.Nuadha.Signals;
using System;

namespace YggdrAshill.Nuadha
{
    public static class SignalExtension
    {
        #region Touch

        public static Touch ToTouch(this bool signal)
        {
            return signal ? Touch.Enabled : Touch.Disabled;
        }

        public static bool ToBoolean(this Touch signal)
        {
            return signal == Touch.Enabled;
        }

        public static IEmission Connect(this ISource<Touch> source, Action<bool> onReceived)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (onReceived == null)
            {
                throw new ArgumentNullException(nameof(onReceived));
            }

            return source.Connect(signal =>
            {
                onReceived.Invoke(signal.ToBoolean());
            });
        }

        public static IDisconnection Connect(this IOutputTerminal<Touch> terminal, Action<bool> onReceived)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (onReceived == null)
            {
                throw new ArgumentNullException(nameof(onReceived));
            }

            return terminal.Connect(signal =>
            {
                onReceived.Invoke(signal.ToBoolean());
            });
        }

        public static IOutputTerminal<Pulse> Pulsate(this IOutputTerminal<Touch> terminal, IPulsation<Touch> pulsation)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return terminal.Pulsate(pulsation, Touch.Disabled);
        }

        public static IOutputTerminal<Pulse> Pulsate(this IOutputTerminal<Touch> terminal, Func<Touch, Touch, bool> onPulsated)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (onPulsated == null)
            {
                throw new ArgumentNullException(nameof(onPulsated));
            }

            return terminal.Pulsate(onPulsated, Touch.Disabled);
        }

        #endregion

        #region Push

        public static Push ToPush(this bool signal)
        {
            return signal ? Push.Enabled : Push.Disabled;
        }

        public static bool ToBoolean(this Push signal)
        {
            return signal == Push.Enabled;
        }

        public static IEmission Connect(this ISource<Push> source, Action<bool> onReceived)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (onReceived == null)
            {
                throw new ArgumentNullException(nameof(onReceived));
            }

            return source.Connect(signal =>
            {
                onReceived.Invoke(signal.ToBoolean());
            });
        }

        public static IDisconnection Connect(this IOutputTerminal<Push> terminal, Action<bool> onReceived)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (onReceived == null)
            {
                throw new ArgumentNullException(nameof(onReceived));
            }

            return terminal.Connect(signal =>
            {
                onReceived.Invoke(signal.ToBoolean());
            });
        }

        public static IOutputTerminal<Pulse> Pulsate(this IOutputTerminal<Push> terminal, IPulsation<Push> pulsation)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (pulsation == null)
            {
                throw new ArgumentNullException(nameof(pulsation));
            }

            return terminal.Pulsate(pulsation, Push.Disabled);
        }

        public static IOutputTerminal<Pulse> Pulsate(this IOutputTerminal<Push> terminal, Func<Push, Push, bool> onPulsated)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (onPulsated == null)
            {
                throw new ArgumentNullException(nameof(onPulsated));
            }

            return terminal.Pulsate(onPulsated, Push.Disabled);
        }

        #endregion

        #region Pull

        public static Pull ToPull(this float signal)
        {
            if (float.IsNaN(signal))
            {
                throw new ArgumentException($"{nameof(signal)} is NaN.");
            }

            const float Min = 0.0f;
            const float Max = 1.0f;
            if (signal < Min || Max < signal)
            {
                throw new ArgumentOutOfRangeException(nameof(signal));
            }

            return new Pull(signal);
        }

        public static float ToSingle(this Pull signal)
        {
            return signal.Strength;
        }

        public static IEmission Connect(this ISource<Pull> source, Action<float> onReceived)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (onReceived == null)
            {
                throw new ArgumentNullException(nameof(onReceived));
            }

            return source.Connect(signal =>
            {
                onReceived.Invoke(signal.ToSingle());
            });
        }

        public static IDisconnection Connect(this IOutputTerminal<Pull> terminal, Action<float> onReceived)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (onReceived == null)
            {
                throw new ArgumentNullException(nameof(onReceived));
            }

            return terminal.Connect(signal =>
            {
                onReceived.Invoke(signal.ToSingle());
            });
        }

        public static IOutputTerminal<Push> Convert(this IOutputTerminal<Pull> terminal, HysteresisThreshold threshold, bool isPushed = false)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }

            return terminal.Convert(new PullToPush(threshold, isPushed));
        }

        #endregion

        #region Pupil

        public static Pupil ToPupil(this float signal)
        {
            if (float.IsNaN(signal))
            {
                throw new ArgumentException($"{nameof(signal)} is NaN.");
            }

            const float Min = 0.0f;
            const float Max = 1.0f;
            if (signal < Min || Max < signal)
            {
                throw new ArgumentOutOfRangeException(nameof(signal));
            }

            return new Pupil(signal);
        }

        public static float ToSingle(this Pupil signal)
        {
            return signal.Ratio;
        }

        public static IEmission Connect(this ISource<Pupil> source, Action<float> onReceived)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (onReceived == null)
            {
                throw new ArgumentNullException(nameof(onReceived));
            }

            return source.Connect(signal =>
            {
                onReceived.Invoke(signal.ToSingle());
            });
        }

        public static IDisconnection Connect(this IOutputTerminal<Pupil> terminal, Action<float> onReceived)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (onReceived == null)
            {
                throw new ArgumentNullException(nameof(onReceived));
            }

            return terminal.Connect(signal =>
            {
                onReceived.Invoke(signal.ToSingle());
            });
        }

        #endregion

        #region Blink

        public static Blink ToBlink(this float signal)
        {
            if (float.IsNaN(signal))
            {
                throw new ArgumentException($"{nameof(signal)} is NaN.");
            }

            const float Min = 0.0f;
            const float Max = 1.0f;
            if (signal < Min || Max < signal)
            {
                throw new ArgumentOutOfRangeException(nameof(signal));
            }

            return new Blink(signal);
        }

        public static float ToSingle(this Blink signal)
        {
            return signal.Ratio;
        }

        public static IEmission Connect(this ISource<Blink> source, Action<float> onReceived)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (onReceived == null)
            {
                throw new ArgumentNullException(nameof(onReceived));
            }

            return source.Connect(signal =>
            {
                onReceived.Invoke(signal.ToSingle());
            });
        }

        public static IDisconnection Connect(this IOutputTerminal<Blink> terminal, Action<float> onReceived)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (onReceived == null)
            {
                throw new ArgumentNullException(nameof(onReceived));
            }

            return terminal.Connect(signal =>
            {
                onReceived.Invoke(signal.ToSingle());
            });
        }

        #endregion

        #region Angle

        public static Angle ToAngle(this float signal)
        {
            if (float.IsNaN(signal))
            {
                throw new ArgumentException($"{nameof(signal)} is NaN.");
            }

            const float Min = -180.0f;
            const float Max = 180.0f;
            if (signal < Min || Max < signal)
            {
                throw new ArgumentOutOfRangeException(nameof(signal));
            }

            return new Angle(signal);
        }

        public static float ToSingle(this Angle signal)
        {
            return signal.Degree;
        }

        public static IEmission Connect(this ISource<Angle> source, Action<float> onReceived)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (onReceived == null)
            {
                throw new ArgumentNullException(nameof(onReceived));
            }

            return source.Connect(signal =>
            {
                onReceived.Invoke(signal.ToSingle());
            });
        }

        public static IDisconnection Connect(this IOutputTerminal<Angle> terminal, Action<float> onReceived)
        {
            if (terminal == null)
            {
                throw new ArgumentNullException(nameof(terminal));
            }
            if (onReceived == null)
            {
                throw new ArgumentNullException(nameof(onReceived));
            }

            return terminal.Connect(signal =>
            {
                onReceived.Invoke(signal.ToSingle());
            });
        }

        #endregion
    }
}
