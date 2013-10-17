﻿// Name:    Kerbal Engineer Redux
// Author:  CYBUTEK
// License: Attribution-NonCommercial-ShareAlike 3.0 Unported

namespace Engineer.Extensions
{
    public static class DoubleExtensions
    {
        /// <summary>
        /// Convert to a string formatted as a mass.
        /// </summary>
        public static string ToMass(this double value, bool showNotation = true)
        {
            value *= 1000;

            if (showNotation)
                return value.ToString("#,0.") + "kg";
            else
                return value.ToString("#,0.");
        }

        /// <summary>
        /// Convert to string formatted as a force.
        /// </summary>
        public static string ToForce(this double value, bool showNotation = true)
        {
            if (HighLogic.LoadedSceneIsFlight)
            {
                if (showNotation)
                    return value.ToString("#,0.00") + "kN";
                else
                    return value.ToString("#,0.00");
            }
            else
            {
                if (showNotation)
                    return value.ToString("#,0.##") + "kN";
                else
                    return value.ToString("#,0.##");
            }
        }

        /// <summary>
        /// Convert to string formatted as a speed.
        /// </summary>
        public static string ToSpeed(this double value, bool showNotation = true)
        {
            if (showNotation)
                return value.ToString("#,0.00") + "m/s";
            else
                return value.ToString("#,0.00");
        }

        /// <summary>
        /// Convert to string formatted as a distance.
        /// </summary>
        public static string ToDistance(this double value)
        {
            bool negative = value < 0d;

            if (negative) value = -value;

            if (value < 1000000d)
            {
                if (value < 1d)
                {
                    value *= 1000d;

                    if (negative) value = -value;
                    return value.ToString("#,0.") + "mm";
                }
                else
                {
                    if (negative) value = -value;
                    return value.ToString("#,0.") + "m";
                }
            }
            else
            {
                value /= 1000d;
                if (value >= 1000000d)
                {
                    value /= 1000d;
                    if (negative) value = -value;
                    return value.ToString("#,0." + "Mm");
                }
                else
                {
                    if (negative) value = -value;
                    return value.ToString("#,0." + "km");
                }
            }
        }

        /// <summary>
        /// Convert to string formatted as a rate.
        /// </summary>
        public static string ToRate(this double value)
        {
            if (value > 0)
                return value.ToString("0.0") + "/sec";
            else
                return (60d * value).ToString("0.0") + "/min";
        }

        /// <summary>
        /// Convert to string formatted as an angle.
        /// </summary>
        public static string ToAngle(this double value)
        {
            return value.ToString("0.000") + "°";
        }

        /// <summary>
        /// Convert to string formatted as a time.
        /// </summary>
        public static string ToTime(this double value)
        {
            double s = value;
            int m = 0;
            int h = 0;
            double d = 0d;
            double y = 0d;

            if (s >= 31536000)
            {
                while (s >= 31536000)
                {
                    y++;
                    s -= 31536000;
                }

                y += (s / 31536000);
                return y.ToString("0.000") + "y";
            }

            if (s >= 86400)
            {
                while (s >= 86400)
                {
                    d++;
                    s -= 86400;
                }

                d += (s / 86400);
                return d.ToString("0.000") + "d";
            }

            while (s >= 60)
            {
                m++;
                s -= 60;
            }

            while (m >= 60)
            {
                h++;
                m -= 60;
            }

            while (h >= 24)
            {
                d++;
                h -= 24;
            }

            if (h > 0)
            {
                return h + "h " + m.ToString("00") + "m " + s.ToString("00.0") + "s";
            }

            if (m > 0)
            {
                return m + "m " + s.ToString("00.0") + "s";
            }

            return s.ToString("0.0") + "s";
        }
    }
}
