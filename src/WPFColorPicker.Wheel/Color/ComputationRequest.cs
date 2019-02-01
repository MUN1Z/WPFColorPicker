using System;
using System.Numerics;

namespace WPFColorPicker.Wheel.Color
{
    /// <summary>
    /// This class represents the computation request of component.
    /// </summary>
    public class ComputationRequest
    {
        #region Properties

        /// <summary>
        /// The Id of computation.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// The Width of computation.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// The Height of computation.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// The PartialHeight of computation.
        /// </summary>
        public int PartialHeight { get; }

        /// <summary>
        /// The bytes Data of computation.
        /// </summary>
        public byte[] Data { get; }

        /// <summary>
        /// The complex Transform of computation.
        /// </summary>
        public Func<Complex, Complex> Transform { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// The public constructor of the <see cref="ComputationRequest"/> class.
        /// </summary>
        /// <param name="id">The Id of computation.</param>
        /// <param name="width">The Width of computation.</param>
        /// <param name="height">The Height of computation.</param>
        /// <param name="partialHeight">The PartialHeight of computation.</param>
        /// <param name="data">The bytes Data of computation.</param>
        /// <param name="transform">The complex Transform of computation.</param>
        public ComputationRequest(int id, int width, int height, int partialHeight, byte[] data, Func<Complex, Complex> transform)
        {
            Id = id;
            Width = width;
            Height = height;
            PartialHeight = partialHeight;
            Data = data;
            Transform = transform;
        }

        #endregion
    }
}
