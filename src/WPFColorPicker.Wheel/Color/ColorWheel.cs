using System;
using System.Diagnostics;
using System.Numerics;
using System.Threading;
using WPFColorPicker.Wheel.Helpers;

namespace WPFColorPicker.Wheel.Color
{
    /// <summary>
    /// This class represents the color wheel of component.
    /// </summary>
    public class ColorWheel
    {

        #region Public Methods Implementation

        /// <summary>
        /// This method is responsible for initialize the color wheel.
        /// </summary>
        /// <param name="width">The Width of color wheel.</param>
        /// <param name="height">The Height of color wheel.</param>
        /// <param name="transform">The Transform of color wheel.</param>
        /// <returns>The color wheel image bytes.</returns>
        public static byte[] ColorWheelInitializer(int width, int height, Func<Complex, Complex> transform = null)
        {
            try
            {
                var data = new byte[width * height * 3];
                var worker = new Thread[Environment.ProcessorCount];

                for (var wk = 0; wk < worker.Length; wk++)
                {
                    worker[wk] = new Thread(ComputeColorWheel);
                    worker[wk].Start(new ComputationRequest(wk, width, height, height / worker.Length, data, transform));
                }

                foreach (var th in worker)
                    th.Join();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

                // Not developed yet.
                throw new NotImplementedException();
            }
            
            return null;
        }

        #endregion

        #region Private Methods Implementation

        /// <summary>
        /// This method is responsible for compute the color wheel.
        /// </summary>
        /// <param name="data">The data of color wheel computation.</param>
        private static void ComputeColorWheel(object data)
        {
            try
            {
                var request = (ComputationRequest) data;
                var rgb = new byte[3];

                for (var y = 0; y < request.PartialHeight; y++)
                {
                    for (var x = 0; x < request.Width; x++)
                    {
                        var c = ColorHelper.ConvertToComplex(request.Width, request.Height, x,
                            request.Id * request.PartialHeight + y);

                        if (request.Transform != null)
                            c = request.Transform(c);

                        var angle = ColorHelper.GetAngle(c);
                        var arg = ColorHelper.GetArgument(c);

                        if (float.IsNaN(angle) || float.IsNaN(arg))
                        {
                            rgb[0] = 0;
                            rgb[1] = 0;
                            rgb[2] = 0;
                        }
                        else
                            ColorHelper.ConvertFromHSLA(angle / 360, 1, 1 - (float) Math.Pow(2, -arg), ref rgb);

                        request.Data[((request.Id * request.PartialHeight + y) * request.Width + x) * 3 + 0] = rgb[2];
                        request.Data[((request.Id * request.PartialHeight + y) * request.Width + x) * 3 + 1] = rgb[1];
                        request.Data[((request.Id * request.PartialHeight + y) * request.Width + x) * 3 + 2] = rgb[0];
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");

                // Not developed yet.
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
