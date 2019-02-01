using System;
using System.Diagnostics;

namespace WPFColorPicker.Wheel.ExtensionMethods
{
    /// <summary>
    /// This class represents the color extension methods of component.
    /// </summary>
    public static class ColorExtensionMethods
    {
        /// <summary>
        /// This method is responsible for return the intensity color value.
        /// </summary>
        /// <param name="color">The color to intensity.</param>
        /// <returns>The intensity color value.</returns>
        public static double Intensity(this System.Windows.Media.Color color)
        {
            try
            {
                return (double)(color.R + color.G + color.B) / (3 * 255);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

                // Not developed yet.
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This method is responsible for return the brightness color value.
        /// </summary>
        /// <param name="color">The color to brightness.</param>
        /// <returns>The brightness color value.</returns>
        public static double Brightness(this System.Windows.Media.Color color)
        {
            try
            {
                return (double)Math.Max(Math.Max(color.R, color.G), color.B) / 255;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

                // Not developed yet.
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This method is responsible for return the saturation HSB color value.
        /// </summary>
        /// <param name="color">The color to saturation HSB.</param>
        /// <returns>The saturation HSB color value.</returns>
        public static double SaturationHSB(this System.Windows.Media.Color color)
        {
            try
            {
                var max = (double)Math.Max(Math.Max(color.R, color.G), color.B) / 255;
                if (max == 0) return 0;
                var min = (double)Math.Min(Math.Min(color.R, color.G), color.B) / 255;
                return (max - min) / max;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

                // Not developed yet.
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This method is responsible for return the lightness color value.
        /// </summary>
        /// <param name="color">The color to lightness.</param>
        /// <returns>The lightness color value.</returns>
        public static double Lightness(this System.Windows.Media.Color color)
        {
            try
            {
                var max = (double)Math.Max(Math.Max(color.R, color.G), color.B) / 255;
                var min = (double)Math.Min(Math.Min(color.R, color.G), color.B) / 255;
                return (max + min) / 2;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

                // Not developed yet.
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This method is responsible for return the chroma color value.
        /// </summary>
        /// <param name="color">The color to chroma.</param>
        /// <returns>The chroma color value.</returns>
        public static double Chroma(this System.Windows.Media.Color color)
        {
            try
            {
                var max = (double)Math.Max(Math.Max(color.R, color.G), color.B) / 255;
                var min = (double)Math.Min(Math.Min(color.R, color.G), color.B) / 255;
                return max - min;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

                // Not developed yet.
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This method is responsible for return the saturation HSL color value.
        /// </summary>
        /// <param name="color">The color to saturation HSL.</param>
        /// <returns>The saturation HSL color value.</returns>
        public static double SaturationHSL(this System.Windows.Media.Color color)
        {
            try
            {
                var max = (double)Math.Max(Math.Max(color.R, color.G), color.B) / 255;
                var min = (double)Math.Min(Math.Min(color.R, color.G), color.B) / 255;
                var chroma = max - min;

                var lightness = (max + min) / 2;
                if (lightness <= .5)
                {
                    return chroma / (2 * lightness);
                }
                return chroma / (2 - 2 * lightness);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

                // Not developed yet.
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This method is responsible for return the With Alpha L color value.
        /// </summary>
        /// <param name="color">The color to With Alpha L.</param>
        /// <returns>The With Alpha L color value.</returns>
        public static System.Windows.Media.Color WithAlpha(this System.Windows.Media.Color color, byte alpha)
        {
            try
            {
                return System.Windows.Media.Color.FromArgb(alpha, color.R, color.G, color.B);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

                // Not developed yet.
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This method is responsible for return the With R color value.
        /// </summary>
        /// <param name="color">The color to With R.</param>
        /// <returns>The With R color value.</returns>
        public static System.Windows.Media.Color WithR(this System.Windows.Media.Color color, byte r)
        {
            try
            {
                return System.Windows.Media.Color.FromArgb(color.A, r, color.G, color.B);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

                // Not developed yet.
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This method is responsible for return the With G color value.
        /// </summary>
        /// <param name="color">The color to With G.</param>
        /// <returns>The With G color value.</returns>
        public static System.Windows.Media.Color WithG(this System.Windows.Media.Color color, byte g)
        {
            try
            {
                return System.Windows.Media.Color.FromArgb(color.A, color.R, g, color.B);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

                // Not developed yet.
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This method is responsible for return the With B color value.
        /// </summary>
        /// <param name="color">The color to With B.</param>
        /// <returns>The With B color value.</returns>
        public static System.Windows.Media.Color WithB(this System.Windows.Media.Color color, byte b)
        {
            try
            {
                return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, b);
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
