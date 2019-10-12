using Othello.Core.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Othello.Core.Models
{
    public interface IEvaluator
    {
        double Evaluate(Board board, StoneType stoneType);
    }
}
