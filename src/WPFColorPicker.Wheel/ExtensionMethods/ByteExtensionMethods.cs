using System;
using System.Diagnostics;

namespace WPFColorPicker.Wheel.ExtensionMethods
{
    /// <summary>
    /// This class represents the byte extension methods of component.
    /// </summary>
    public static class ByteExtensionMethods
    {
        /// <summary>
        /// This method is responsible for return the percent value to byte data.
        /// </summary>
        /// <param name="number">The number value of percent.</param>
        /// <returns>The percent value from byte data.</returns>
        public static int AsPercent(this byte number)
        {
            try
            {
                return Convert.ToInt32((double)number / 255 * 100);
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
