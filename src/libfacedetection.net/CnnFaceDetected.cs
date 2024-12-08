using System;
using System.Diagnostics;
using System.Drawing;

namespace LibFaceDetection
{
    /// <summary>
    /// Represents an identified face. This object is returned after an image has been analyzed
    /// </summary>
    [DebuggerDisplay("{Rectangle} - {Confidence}")]
    public class CnnFaceDetected
    {
        internal CnnFaceDetected(Interop.FaceDetected faceDetected)
        {
            Rectangle = new Rectangle(faceDetected.x, faceDetected.y, faceDetected.width, faceDetected.height);
            Confidence = faceDetected.confidence;
            p1x = faceDetected.p1x;
            p1y = faceDetected.p1y;
            p2x = faceDetected.p2x;
            p2y = faceDetected.p2y;
            p3x = faceDetected.p3x;
            p3y = faceDetected.p3y;
            p4x = faceDetected.p4x;
            p4y = faceDetected.p4y;
            p5x = faceDetected.p5x;
            p5y = faceDetected.p5y;
        }

        private CnnFaceDetected(float confidence, Rectangle rectangle,
            int p1x, int p1y,
            int p2x, int p2y,
			int p3x, int p3y,
			int p4x, int p4y,
			int p5x, int p5y)
        {
            Confidence = confidence;
            Rectangle = rectangle;
            this.p1x = p1x;
			this.p1y = p1y;
			this.p2x = p2x;
			this.p2y = p2y;
			this.p3x = p3x;
			this.p3y = p3y;
			this.p4x = p4x;
			this.p4y = p4y;
			this.p5x = p5x;
			this.p5y = p5y;
        }

        /// <summary>
        /// Returns a scaled version of the detected face
        /// </summary>
        /// <param name="scaleX">Scale to multiply for x and width</param>
        /// <param name="scaleY">Scale to multiply for x and height</param>
        /// <returns></returns>
        public CnnFaceDetected Scale(float scaleX, float scaleY)
        {
            var rectangle = new Rectangle(
                Convert.ToInt32(Rectangle.X * scaleX),
                Convert.ToInt32(Rectangle.Y * scaleY),
                Convert.ToInt32(Rectangle.Width * scaleX),
                Convert.ToInt32(Rectangle.Height * scaleY));

            return new CnnFaceDetected(Confidence, rectangle,
				Convert.ToInt32(this.p1x * scaleX),
                Convert.ToInt32(this.p1y * scaleY),
				Convert.ToInt32(this.p2x * scaleX),
                Convert.ToInt32(this.p2y * scaleY),
				Convert.ToInt32(this.p3x * scaleX),
                Convert.ToInt32(this.p3y * scaleY),
				Convert.ToInt32(this.p4x * scaleX),
                Convert.ToInt32(this.p4y * scaleY),
				Convert.ToInt32(this.p5x * scaleX),
				Convert.ToInt32(this.p5y * scaleY));
        }

        /// <summary>
        /// Gets the confidence between 0 to 1 of the found face. 0 is low and 1 is high
        /// </summary>
        public float Confidence { get; }

        /// <summary>
        /// Gets the bounding box of the found face
        /// </summary>
        public Rectangle Rectangle { get; }

        /// <summary>
        /// eye-left x
        /// </summary>
        public int p1x { get; set; }
        /// <summary>
        /// eye-left y 
        /// </summary>
        public int p1y { get; set; }
        /// <summary>
        /// eye-right x
        /// </summary>
        public int p2x { get; set; }
        /// <summary>
        /// eye-right y
        /// </summary>
        public int p2y { get; set; }
        /// <summary>
        /// nose x
        /// </summary>
        public int p3x { get; set; }
        /// <summary>
        /// nose y
        /// </summary>
        public int p3y { get; set; }
        /// <summary>
        /// mouse-left x
        /// </summary>
        public int p4x { get; set; }
        /// <summary>
        /// mouse-left y
        /// </summary>
        public int p4y { get; set; }
        /// <summary>
        /// mouse-right x
        /// </summary>
        public int p5x { get; set; }
        /// <summary>
        /// mouse-right y
        /// </summary>
        public int p5y { get; set; }
    }
}