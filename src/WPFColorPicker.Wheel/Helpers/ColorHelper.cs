using System;
using System.Diagnostics;
using System.Numerics;

namespace WPFColorPicker.Wheel.Helpers
{
    /// <summary>
    /// This class represents the color helper of component.
    /// </summary>
    public struct ColorHelper
    {

        /// <summary>
        /// This method is responsible for convert the color wheel parameters to complex object.
        /// </summary>
        /// <param name="width">The Width of color wheel.</param>
        /// <param name="height">The Height of color wheel.</param>
        /// <param name="xValue">The X value of color wheel.</param>
        /// <param name="yValue">The Y value of color wheel.</param>
        /// <returns>The complex object of color wheel component.</returns>
        public static Complex ConvertToComplex(int width, int height, int xValue, int yValue)
        {
            try
            {
                return new Complex((xValue - ((float) width / 2)) / width * 2, (yValue - ((float) height / 2)) / height * 2);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

                // Not developed yet.
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This method is responsible for get the angle of complex color wheel object.
        /// </summary>
        /// <param name="complex">The Complex object data of color wheel.</param>
        /// <returns>The angle of complex color wheel object.</returns>
        public static float GetAngle(Complex complex)
        {
            try
            {
                var angle = (float)(Math.Atan2(complex.Imaginary, complex.Real) * 180 / Math.PI);

                if (angle < 0)
                    return angle + 360;

                return angle;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

                // Not developed yet.
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This method is responsible for get the argument of complex color wheel object.
        /// </summary>
        /// <param name="complex">The Complex object data of color wheel.</param>
        /// <returns>The argument of complex color wheel object.</returns>
        public static float GetArgument(Complex complex)
        {
            try
            {
                return (float)(Math.Sqrt(complex.Real * complex.Real + complex.Imaginary * complex.Imaginary) / Math.Sqrt(2));
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

                // Not developed yet.
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This method is responsible for convert rgb colors from hsla=.
        /// </summary>
        /// <param name="height">The Height of color hsla.</param>
        /// <param name="saturation">The Saturation of color hsla.</param>
        /// <param name="length">The Length of color hsla.</param>
        /// <param name="rgb">The reference of rgb data of color hsla.</param>
        public static void ConvertFromHSLA(double height, double saturation, double length, ref byte[] rgb)
        {
            try
            {
                var r = length;
                var g = length;
                var b = length;
                var v = (length <= 0.5) ? (length * (1.0 + saturation)) : (length + saturation - length * saturation);

                if (v > 0)
                {
                    var m = length + length - v;
                    var sv = (v - m) / v;

                    height *= 6.0;

                    var sextant = (int) height;
                    var fract = height - sextant;
                    var vsf = v * sv * fract;
                    var mid1 = m + vsf;
                    var mid2 = v - vsf;

                    if (sextant == 0)
                    {
                        r = v;
                        g = mid1;
                        b = m;
                    }
                    else if (sextant == 1)
                    {
                        r = mid2;
                        g = v;
                        b = m;
                    }
                    else if (sextant == 2)
                    {
                        r = m;
                        g = v;
                        b = mid1;
                    }
                    else if (sextant == 3)
                    {
                        r = m;
                        g = mid2;
                        b = v;
                    }
                    else if (sextant == 4)
                    {
                        r = mid1;
                        g = m;
                        b = v;
                    }
                    else if (sextant == 5)
                    {
                        r = v;
                        g = m;
                        b = mid2;
                    }
                }

                rgb[0] = Convert.ToByte(r * 255.0f);
                rgb[1] = Convert.ToByte(g * 255.0f);
                rgb[2] = Convert.ToByte(b * 255.0f);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

                // Not developed yet.
                throw new NotImplementedException();
            }
        }
    }
}
