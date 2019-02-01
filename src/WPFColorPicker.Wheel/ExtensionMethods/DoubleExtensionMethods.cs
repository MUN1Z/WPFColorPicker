using System;
using System.Diagnostics;

namespace WPFColorPicker.Wheel.ExtensionMethods
{
    /// <summary>
    /// This class represents the double extension methods of component.
    /// </summary>
    public static class DoubleExtensionMethods
    {
        /// <summary>
        /// This method is responsible for return the percent value to double value.
        /// </summary>
        /// <param name="number">The number value of percent.</param>
        /// <returns>The percent value from double value.</returns>
        public static int AsPercent(this double number)
        {
            try
            {
                return Convert.ToInt32(number * 100);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

                // Not developed yet.
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This method is responsible for return the percent value from double value.
        /// </summary>
        /// <param name="number">The number value to percent.</param>
        /// <param name="value">The value of percent.</param>
        /// <returns>The percent value from double value.</returns>
        public static double PercentageOf(this double number, double value)
        {
            try
            {
                return (number / value) * 100;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

                // Not developed yet.
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This method is responsible for restrict number in min and max values.
        /// </summary>
        /// <param name="number">The number value to range.</param>
        /// <param name="min">The min value of range.</param>
        /// <param name="max">The max value of range.</param>
        /// <returns>The restricted value.</returns>
        public static double RestrictToRange(this double number, double min, double max)
        {
            try
            {
                return Math.Min(Math.Max(number, min), max);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

                // Not developed yet.
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// This method is responsible for restrict number to byte.
        /// </summary>
        /// <param name="number">The number value to restrict.</param>
        /// <returns>The restricted byte value.</returns>
        public static byte RestrictToByte(this double number)
        {

            try
            {
                return Convert.ToByte(number.RestrictToRange(0, 255));
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
