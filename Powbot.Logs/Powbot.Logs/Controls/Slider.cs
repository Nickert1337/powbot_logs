using Powbot.Logs.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powbot.Logs.Controls
{
    public class Slider : Control
    {
        private float _radius;
        private PointF _thumbPos;
        private SizeF _barSize;
        private PointF _barPos;

        public event EventHandler ValueChanged;

        public Slider()
        {
            // This reduces flicker
            DoubleBuffered = true;
        }

        private float _min = 0.0f;
        public float Min
        {
            get => _min;
            set
            {
                _min = value;
                RecalculateParameters();
            }
        }

        private float _max = 1.0f;
        public float Max
        {
            get => _max;
            set
            {
                _max = value;
                RecalculateParameters();
            }
        }

        private float _value = 0.3f;
        public float Value
        {
            get => _value;
            set
            {
                _value = value;
                ValueChanged?.Invoke(this, EventArgs.Empty);
                RecalculateParameters();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.FillRectangle(Brushes.DimGray,
                _barPos.X, _barPos.Y, _barSize.Width, _barSize.Height);
            e.Graphics.FillRectangle(Brushes.Blue,
                _barPos.X, _barPos.Y, _thumbPos.X - _barPos.X, _barSize.Height);

            e.Graphics.FillCircle(Brushes.White, _thumbPos.X, _thumbPos.Y, _radius);
            e.Graphics.FillCircle(Brushes.Blue, _thumbPos.X, _thumbPos.Y, 0.7f * _radius);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            RecalculateParameters();
        }

        private void RecalculateParameters()
        {
            _radius = 0.5f * ClientSize.Height;
            _barSize = new SizeF(ClientSize.Width - 2f * _radius, 0.5f * ClientSize.Height);
            _barPos = new PointF(_radius, (ClientSize.Height - _barSize.Height) / 2);
            _thumbPos = new PointF(
                _barSize.Width / (Max - Min) * Value + _barPos.X,
                _barPos.Y + 0.5f * _barSize.Height);
            Invalidate();
        }

        bool _moving = false;
        SizeF _delta;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // Difference between tumb and mouse position.
            _delta = new SizeF(e.Location.X - _thumbPos.X, e.Location.Y - _thumbPos.Y);
            if (_delta.Width * _delta.Width + _delta.Height * _delta.Height <= _radius * _radius)
            {
                // Clicking inside thumb.
                _moving = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_moving)
            {
                float thumbX = e.Location.X - _delta.Width;
                if (thumbX < _barPos.X)
                {
                    thumbX = _barPos.X;
                }
                else if (thumbX > _barPos.X + _barSize.Width)
                {
                    thumbX = _barPos.X + _barSize.Width;
                }
                Value = (thumbX - _barPos.X) * (Max - Min) / _barSize.Width;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            _moving = false;
        }
    }
}