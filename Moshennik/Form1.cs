using System.Drawing.Drawing2D;
using System.IO;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Moshennik
{
    public partial class Form1 : Form
    {
        private DirectBitmap? _originalImage; //Оригинальное изображение

        private DirectBitmap? _originalImageFiltered; //Обработанное оригинальное изображение

        private DirectBitmap? _scamImage; //Поддельное изображение

        private DirectBitmap? _tempImage;

        private Rectangle _tempImageRectangle;

        private float _tempImageAngle;

        private List<Point> _path;
        public Form1()
        {
            _path = new List<Point>();
            InitializeComponent();
            panel2.MouseWheel += Panel2_MouseWheel;
        }

        private void Panel2_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (_tempImage == null)
                return;

            _tempImageRectangle.Height = (int)(_tempImageRectangle.Height * (e.Delta > 0 ? 1.1 : 0.9));
            _tempImageRectangle.Width = (int)(_tempImageRectangle.Width * (e.Delta > 0 ? 1.1 : 0.9));
            panel2.Refresh();
        }

        private string? OpenFileDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dialogResult = ofd.ShowDialog();
            return dialogResult == DialogResult.OK ? ofd.FileName : null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string? filename = OpenFileDialog();
            if (filename == null)
                return;
            _originalImage = DirectBitmap.FromFile(filename);
            panel1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string? filename = OpenFileDialog();
            if (filename == null)
                return;
            _scamImage = DirectBitmap.FromFile(filename);
            panel2.Refresh();
        }
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            if (_originalImage == null)
                return;
            Rectangle src = new Rectangle(0, 0, _originalImage.Width, _originalImage.Height);
            double k = GetK(src.Size, panel2.Size);
            Rectangle dst = new Rectangle(0, 0, (int)(_originalImage.Width / k), (int)(_originalImage.Height / k));
            if (checkBox1.Checked && _originalImageFiltered != null)
                e.Graphics.DrawImage(_originalImageFiltered.Bitmap, dst, src, GraphicsUnit.Pixel);
            else
                e.Graphics.DrawImage(_originalImage.Bitmap, dst, src, GraphicsUnit.Pixel);
            if (_path.Count == 0)
                return;
            SolidBrush brush = new SolidBrush(Color.Red);
            GraphicsPath path = GetPath();
            e.Graphics.FillPath(brush, path);
        }
        private GraphicsPath GetPath()
        {
            Point[] points = _path.ToArray();
            byte[] types = new byte[points.Length];
            Array.Fill(types, (byte)PathPointType.Line);
            types[0] = (byte)PathPointType.Start;
            types[types.Length - 1] |= (byte)PathPointType.CloseSubpath;
            return new GraphicsPath(points, types);
        }
        private void Panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            if (_scamImage == null)
                return;
            Rectangle src = new Rectangle(0, 0, _scamImage.Width, _scamImage.Height);
            double k = GetK(src.Size, panel2.Size);
            Rectangle dst = new Rectangle(0, 0, (int)(_scamImage.Width / k), (int)(_scamImage.Height / k));
            e.Graphics.DrawImage(_scamImage.Bitmap, dst, src, GraphicsUnit.Pixel);
            if (_tempImage == null)
                return;
            Rectangle ssrc = new Rectangle(0, 0, _tempImage.Width, _tempImage.Height);
            e.Graphics.DrawImage(_tempImage.Bitmap, _tempImageRectangle, ssrc, GraphicsUnit.Pixel);
        }
        private double GetK(Size size1, Size size2)
        {
            double kw = (double)size1.Width / size2.Width;
            double kh = (double)size1.Height / size2.Height;
            return kw > kh ? kw : kh;
        }
        private void Value_Changed(object sender, EventArgs e)
        {
            _originalImageFiltered = null;
            if (checkBox1.Checked)
            {
                checkBox1.Checked = false;
                panel1.Refresh();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && _originalImageFiltered == null)
                CreateFilteredImage();
            panel1.Refresh();
        }
        private void CreateFilteredImage()
        {
            if (_originalImage == null)
                return;
            _originalImageFiltered?.Dispose();
            _originalImageFiltered = new DirectBitmap(_originalImage.Width, _originalImage.Height);
            DrawFilteredImage(_originalImage, _originalImageFiltered, 0, 0);
        }
        private void DrawFilteredImage(DirectBitmap src, DirectBitmap dst, int src_x, int srx_y)
        {
            float hueThreshold = (float)numericUpDown2.Value;
            float hueCenter = (float)numericUpDown1.Value;
            float saturationThreshold = trackBar1.Value / 100f;
            float brightnessThreshold = trackBar2.Value / 100f;
            for (int y = 0; y < dst.Height; y++)
            {
                for (int x = 0; x < dst.Width; x++)
                {
                    Color color = src.GetPixel(x + src_x, y + srx_y);
                    ColorToHSV(color, out float hue, out float saturation, out float value);
                    if (hueCenter + hueThreshold >= hue
                        && hueCenter - hueThreshold <= hue
                        && saturation >= saturationThreshold
                        && value >= brightnessThreshold)
                    {
                        dst.SetPixel(x, y, color);
                    }
                }
            }
        }
        private void ColorToHSV(Color color, out float hue, out float saturation, out float value)
        {
            int max = Math.Max(color.R, Math.Max(color.G, color.B));
            int min = Math.Min(color.R, Math.Min(color.G, color.B));

            hue = color.GetHue();
            saturation = (max == 0) ? 0 : 1f - (1f * min / max);
            value = max / 255f;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            DirectBitmap? bitmap = GetSelected();
            if (bitmap != null)
            {
                pictureBox1.Image = bitmap.Bitmap;
                pictureBox1.Refresh();
            }
        }
        private DirectBitmap? GetSelected()
        {
            if (_path.Count == 0 || _originalImage == null)
                return null;
            double k = GetK(_originalImage.Bitmap.Size, panel2.Size);
            Point[] pixels = _path
                .Select(x => new Point((int)(x.X * k), (int)(x.Y * k)))
                .ToArray();
            byte[] types = new byte[pixels.Length];
            Array.Fill(types, (byte)PathPointType.Line);
            types[0] = (byte)PathPointType.Start;
            types[types.Length - 1] |= (byte)PathPointType.CloseSubpath;
            GraphicsPath path = new GraphicsPath(pixels, types);

            RectangleF bounds = path.GetBounds();
            if (bounds.IsEmpty)
                return null;
            Point[] points = pixels.Select(x => new Point(x.X - (int)bounds.X, x.Y - (int)bounds.Y)).ToArray();
            GraphicsPath shifted_path = new GraphicsPath(points, types);

            using DirectBitmap mask = new DirectBitmap((int)bounds.Width, (int)bounds.Height);
            using Graphics mask_graphics = Graphics.FromImage(mask.Bitmap);
            mask_graphics.FillPath(new SolidBrush(Color.Red), shifted_path);

            DirectBitmap preview = new DirectBitmap((int)bounds.Width, (int)bounds.Height);
            using Graphics preview_graphics = Graphics.FromImage(preview.Bitmap);

            DrawFilteredImage(_originalImage, preview, (int)bounds.X, (int)bounds.Y);
            return preview;
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            _path.Clear();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point point = GetMousePositionInPanel(panel1);
                _path.Add(point);
                panel1.Refresh();
            }
        }
        private Point GetMousePositionInPanel(Panel panel)
        {
            var relativePoint = panel.PointToClient(Cursor.Position);
            float mx = relativePoint.X;
            float my = relativePoint.Y;
            mx = Math.Min(Math.Max(0, mx), panel.Width - 1);
            my = Math.Min(Math.Max(0, my), panel.Height - 1);
            return new Point((int)mx, (int)my);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (_scamImage == null)
                return;
            _tempImage?.Dispose();
            _tempImage = GetSelected();
            if (_tempImage != null)
            {
                _tempImageRectangle = new Rectangle(0, 0, _tempImage.Width, _tempImage.Height);
            }
            panel2.Refresh();
        }

        private Point OldPoint;
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && _tempImage != null)
            {
                Point point = GetMousePositionInPanel(panel2);
                _tempImageRectangle.X += point.X - OldPoint.X;
                _tempImageRectangle.Y += point.Y - OldPoint.Y;
                OldPoint = point;
                panel2.Refresh();
            }
        }
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                OldPoint = GetMousePositionInPanel(panel2);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (_scamImage == null || _tempImage == null)
                return;
            using Graphics graphics = Graphics.FromImage(_scamImage.Bitmap);

            Rectangle src = new Rectangle(0, 0, _tempImage.Width, _tempImage.Height);

            double k = GetK(_scamImage.Bitmap.Size, panel2.Size);
            int x = (int)(_tempImageRectangle.X * k);
            int y = (int)(_tempImageRectangle.Y * k);
            int width = (int)(_tempImageRectangle.Width * k);
            int height = (int)(_tempImageRectangle.Height * k);

            Rectangle dst = new Rectangle(x, y, width, height);
            graphics.DrawImage(_tempImage.Bitmap, dst, src, GraphicsUnit.Pixel);
            _tempImage = null;
            panel2.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (_scamImage == null) 
                return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                _scamImage.Bitmap.Save(saveFileDialog.FileName);
            }
        }
    }
}