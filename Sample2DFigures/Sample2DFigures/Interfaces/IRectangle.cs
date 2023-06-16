﻿using Sample2DFigures.Common;

namespace Sample2DFigures.Interfaces
{
    internal interface IRectangle : IFigure
    {
        int Width { get; }
        int Height { get; }
        CustomPoint StartPoint { get; }
    }
}
