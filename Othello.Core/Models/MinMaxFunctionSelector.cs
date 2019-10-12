using Othello.Core.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello.Core.Models
{
    /// <summary>
    /// MinMax法でセルを選択する
    /// </summary>
    public class MinMaxFunctionSelector : ICellSelector
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="board"></param>
        /// <param name="selfStoneType"></param>
        /// <param name="evaluator"></param>
        public MinMaxFunctionSelector(Board board, StoneType selfStoneType, IEvaluator evaluator)
        {
            _board = board;
            _selfType = selfStoneType;
            if (_selfType == StoneType.White)
            {
                _nonSelfType = StoneType.Black;
            }
            else if (_selfType == StoneType.Black)
            {
                _nonSelfType = StoneType.White;
            }
            else
            {
                _nonSelfType = StoneType.None;
            }

            _evaluationValues = new Dictionary<CellPosition, double>();
            _evaluator = evaluator;
        }

        private Board _board;
        private StoneType _selfType;
        private StoneType _nonSelfType;
        private IEvaluator _evaluator;
        /// <summary>
        /// 手を読む深さの上限
        /// 処理速度との兼ね合いで調整
        /// </summary>
        private const int MAXDEPTH = 20;

        private Dictionary<CellPosition, double> _evaluationValues;


        public async Task<CellPosition> SelectAsync()
        {
            return await Task.Run(() =>
            {
                _evaluationValues.Clear();
                var score = MinMax(_board.Clone(), true, 0);
                return score.Key;
            }).ConfigureAwait(true);
        }

        private double Evaluate(Board board, StoneType stoneType)
        {
            return _evaluator.Evaluate(board, stoneType);
        }

        private KeyValuePair<CellPosition, double> MinMax(Board board, bool isMyTurn, int depth)
        {
            double bestScore = isMyTurn ? int.MinValue : int.MaxValue;
            var stoneType = isMyTurn ? _selfType : _nonSelfType;

            var emptyCells = board.GetSelectableCells(stoneType).ToList();

            if (depth > MAXDEPTH || !emptyCells.Any())
            {
                return new KeyValuePair<CellPosition, double>(CellPosition.Empty, Evaluate(board, stoneType));
            }

            CellPosition bestCell = null;
            foreach (var cell in emptyCells)
            {
                board.SetStone(cell.Position, stoneType);
                board.TurnStoneAsync(cell.Position, stoneType).Wait();
                double tempScore = MinMax(board, !isMyTurn, depth + 1).Value;
                if (isMyTurn)
                {
                    if (tempScore > bestScore)
                    {
                        bestScore = tempScore;
                        bestCell = cell.Position;
                    }
                }
                else
                {
                    if (tempScore < bestScore)
                    {
                        bestScore = tempScore;
                        bestCell = cell.Position;
                    }
                }
                board.Undo();

                if (depth == 0)
                {
                    _evaluationValues.Add(cell.Position, tempScore);
                }
            }
            if (depth == 0)
            {
                return _evaluationValues.Where(e => e.Value == bestScore).OrderBy(e => Guid.NewGuid()).First();
            }
            else
            {
                return new KeyValuePair<CellPosition, double>(bestCell, bestScore);
            }
        }
    }
}

