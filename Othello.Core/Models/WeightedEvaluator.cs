using Othello.Core.Commons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Othello.Core.Models
{
    public class WeightedEvaluator : IEvaluator
    {
        private readonly List<List<int>> _weight = new List<List<int>>()
        {
            new List<int>(){30,-12,0,-1,-1,0,-12,30},
            new List<int>(){-12,-15,-3,-3,-3,-3,-15,-12},
            new List<int>(){0,-3,0,-1,-1,0,-3,0},
            new List<int>(){-1,-3,-1,-1,-1,-1,-3,-1},
            new List<int>(){-1,-3,-1,-1,-1,-1,-3,-1},
            new List<int>(){0,-3,0,-1,-1,0,-3,0},
            new List<int>(){-12,-15,-3,-3,-3,-3,-15,-12},
            new List<int>(){30,-12,0,-1,-1,0,-12,30}
        };


        public double Evaluate(Board board, StoneType stoneType)
        {
            if (board == null)
            {
                throw new ArgumentNullException(nameof(board));
            }

            return board.GetCellsWithStone(stoneType).Sum(c => _weight[c.Position.RowIndex][c.Position.ColumnIndex]);
        }
    }
}
