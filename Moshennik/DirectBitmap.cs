using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Moshennik
{
    public class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        protected GCHandle BitsHandle { get; private set; }
        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, BitsHandle.AddrOfPinnedObject());
        }
        public void SetPixel(int x, int y, Color colour)
        {
            int index = x + (y * Width);
            int col = colour.ToArgb();

            Bits[index] = col;
        }
        public void SetPixelArgb(int x, int y, int colour)
        {
            int index = x + (y * Width);
            Bits[index] = colour;
        }
        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);
            return result;
        }
        public int GetPixelArgb(int x, int y)
        {
            int index = x + (y * Width);
            return Bits[index];
        }
        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
        public static DirectBitmap FromBitmap(Bitmap bitmap)
        {
            DirectBitmap directBitmap = new DirectBitmap(bitmap.Width, bitmap.Height);
            using Graphics directBitmapGraphics = Graphics.FromImage(directBitmap.Bitmap);
            Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            directBitmapGraphics.DrawImage(bitmap, rectangle, rectangle, GraphicsUnit.Pixel);
            return directBitmap;
        }
        public static DirectBitmap FromFile(string fileName)
        {
            using Bitmap bitmap = (Bitmap)Image.FromFile(fileName);
            DirectBitmap directBitmap = new DirectBitmap(bitmap.Width, bitmap.Height);
            using Graphics graphics = Graphics.FromImage(directBitmap.Bitmap);
            Rectangle rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            graphics.DrawImage(bitmap, rectangle, rectangle, GraphicsUnit.Pixel);
            return directBitmap;
        }
    }
}
