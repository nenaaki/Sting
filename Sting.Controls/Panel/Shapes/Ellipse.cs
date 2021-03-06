﻿using Sting.Controls.Panel.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace Sting.Controls.Panel.Shapes
{
    public class Ellipse : ShapeBase
    {
        public override void OnRender(DrawingContext drawingContext)
        {
            var pen = (Pen ?? EmptyPen.Instance).GetPen();
            var background = (Background ?? EmptyBrush.Instance).GetBrush();

            var bounds = Bounds;

            var halfWidth = bounds.Width;
            var halfHeight = bounds.Height;
            drawingContext.DrawEllipse(background, pen, bounds.Location + new Vector(halfWidth, halfHeight), halfWidth, halfHeight);
        }
    }
}