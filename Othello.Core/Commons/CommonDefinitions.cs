using System;
using System.Collections.Generic;
using System.Text;

namespace Othello.Core.Commons
{
    public enum StoneType
    {
        Black,
        White,
        None
    }

    public enum StoneLineType
    {
        UpperLeft,
        UpperRight,
        LowerRight,
        LowerLeft,
        Upper,
        Lower,
        Left,
        Right
    }

    public enum GameResult
    {
        None,
        WinWhite,
        WinBlack,
        Draw
    }
}
