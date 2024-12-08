using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LibFaceDetection
{
    internal class Interop
    {
        private const string DllName = "libfacedetection";

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int DetectCallback(in FaceDetected faceDetected);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr Ctor();

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void Dtor(IntPtr instance);

        [DllImport(DllName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int Detect(IntPtr instance, IntPtr data, bool rgb2bgr, int width, int height, int step, DetectCallback callback);

        [StructLayout(LayoutKind.Sequential)]
        public struct FaceDetected
        {
            public int x, y;
            public int width, height;
            public float confidence;
            
            public int p1x;
            public int p1y;
            public int p2x;
            public int p2y;
            public int p3x;
            public int p3y;
            public int p4x;
            public int p4y;
            public int p5x;
            public int p5y;
        }
    }
}
