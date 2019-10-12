using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Othello.Core.Commons;
using System.Threading.Tasks;

namespace Othello.Core.Models
{
    public class Board
    {
        public Board()
        {
            Cells = new Cells();
            _cellsBackup = null;
        }

        public Cells Cells { get; private set; }

        private Cells _cellsBackup;

        /// <summary>
        /// 勝敗を確認する
        /// </summary>
        /// <returns></returns>
        public GameResult GetGameResult(out int whiteCount, out int blackCount)
        {
            whiteCount = 0;
            blackCount = 0;

            if (GetSelectableCells(StoneType.White).Any() || GetSelectableCells(StoneType.Black).Any())
            {
                return GameResult.None;
            }

            whiteCount = GetCellsWithStone(StoneType.White).Count();
            blackCount = GetCellsWithStone(StoneType.Black).Count();

            if (whiteCount > blackCount)
            {
                return GameResult.WinWhite;
            }
            else if (whiteCount < blackCount)
            {
                return GameResult.WinBlack;
            }
            else
            {
                return GameResult.Draw;
            }
        }

        /// <summary>
        /// 空のセルを取得
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Cell> GetEmptyCells()
        {
            return Cells.Where(c => c.Value == StoneType.None);
        }

        /// <summary>
        /// 石を置けるセルを取得
        /// </summary>
        /// <param name="stoneType"></param>
        /// <returns></returns>
        public IEnumerable<Cell> GetSelectableCells(StoneType stoneType)
        {
            foreach (var cell in GetEmptyCells())
            {
                if (CanSelectCell(cell.Position, stoneType))
                {
                    yield return cell;
                }
            }
        }

        /// <summary>
        /// 石があるセルを取得する
        /// </summary>
        /// <param name="stoneType"></param>
        /// <returns></returns>
        public IEnumerable<Cell> GetCellsWithStone(StoneType stoneType)
        {
            return Cells.Where(c => c.Value == stoneType);
        }

        /// <summary>
        /// 選択
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="stoneType"></param>
        /// <returns>石を置けたとき：true</returns>
        public bool SetStone(CellPosition pos, StoneType stoneType)
        {
            if (CanSelectCell(pos, stoneType))
            {
                _cellsBackup = Cells.Clone();
                Cells.First(c => c.Position.Equals(pos)).Value = stoneType;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 選択できるか
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="stoneType"></param>
        /// <returns></returns>
        public bool CanSelectCell(CellPosition pos, StoneType stoneType)
        {
            if (!GetEmptyCells().Any(c => c.Position.Equals(pos)))
            {
                return false;
            }

            if (GetUpperRightLineStones(pos, stoneType).Any())
            {
                return true;
            }
            if (GetRightLineStones(pos, stoneType).Any())
            {
                return true;
            }
            if (GetLowerRightLineStones(pos, stoneType).Any())
            {
                return true;
            }
            if (GetLowerLineStones(pos, stoneType).Any())
            {
                return true;
            }
            if (GetLowerLeftLineStones(pos, stoneType).Any())
            {
                return true;
            }
            if (GetLeftLineStones(pos, stoneType).Any())
            {
                return true;
            }
            if (GetUpperLeftLineStones(pos, stoneType).Any())
            {
                return true;
            }
            if (GetUpperLineStones(pos, stoneType).Any())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 石を裏返す
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="stoneType"></param>
        public Task TurnStoneAsync(CellPosition pos, StoneType stoneType)
        {
            return Task.Run(() =>
            {
                foreach (var stone in GetUpperRightLineStones(pos, stoneType))
                {
                    stone.Turn();
                }
                foreach (var stone in GetRightLineStones(pos, stoneType))
                {
                    stone.Turn();
                }
                foreach (var stone in GetLowerRightLineStones(pos, stoneType))
                {
                    stone.Turn();
                }
                foreach (var stone in GetLowerLineStones(pos, stoneType))
                {
                    stone.Turn();
                }
                foreach (var stone in GetLowerLeftLineStones(pos, stoneType))
                {
                    stone.Turn();
                }
                foreach (var stone in GetLeftLineStones(pos, stoneType))
                {
                    stone.Turn();
                }
                foreach (var stone in GetUpperLeftLineStones(pos, stoneType))
                {
                    stone.Turn();
                }
                foreach (var stone in GetUpperLineStones(pos, stoneType))
                {
                    stone.Turn();
                }
            });
        }

        //private IEnumerable<StoneLineType> GetOtherStonesAround(CellPosition pos, StoneType cellType)
        //{
        //    var otherCellType = cellType == StoneType.Black ? StoneType.White : StoneType.Black;

        //    if (_cells[pos.RowIndex - 1][pos.ColumnIndex - 1].Value == otherCellType)
        //    {
        //        yield return StoneLineType.UpperLeft;
        //    }
        //    if (_cells[pos.RowIndex - 1][pos.ColumnIndex].Value == otherCellType)
        //    {
        //        yield return StoneLineType.Upper;
        //    }
        //    if (_cells[pos.RowIndex - 1][pos.ColumnIndex + 1].Value == otherCellType)
        //    {
        //        yield return StoneLineType.UpperRight;
        //    }
        //    if (_cells[pos.RowIndex][pos.ColumnIndex - 1].Value == otherCellType)
        //    {
        //        yield return StoneLineType.Left;
        //    }
        //    if (_cells[pos.RowIndex][pos.ColumnIndex + 1].Value == otherCellType)
        //    {
        //        yield return StoneLineType.Right;
        //    }
        //    if (_cells[pos.RowIndex + 1][pos.ColumnIndex - 1].Value == otherCellType)
        //    {
        //        yield return StoneLineType.LowerLeft;
        //    }
        //    if (_cells[pos.RowIndex + 1][pos.ColumnIndex].Value == otherCellType)
        //    {
        //        yield return StoneLineType.Lower;
        //    }
        //    if (_cells[pos.RowIndex + 1][pos.ColumnIndex + 1].Value == otherCellType)
        //    {
        //        yield return StoneLineType.LowerRight;
        //    }
        //}

        //private bool IsTurnStones(CellPosition pos, StoneType selfCellType)
        //{
        //    var otherCellType = selfCellType == StoneType.Black ? StoneType.White : StoneType.Black;

        //    var aroundStoneLines = GetOtherStonesAround(pos, selfCellType);
        //    foreach (var line in aroundStoneLines)
        //    {
        //        switch (line)
        //        {
        //            case StoneLineType.UpperLeft:
        //                _cells[pos.RowIndex - 2][pos.ColumnIndex - 2].Value == otherCellType
        //                break;
        //            case StoneLineType.UpperRight:
        //                break;
        //            case StoneLineType.LowerRight:
        //                break;
        //            case StoneLineType.LowerLeft:
        //                break;
        //            case StoneLineType.Upper:
        //                break;
        //            case StoneLineType.Lower:
        //                break;
        //            case StoneLineType.Left:
        //                break;
        //            case StoneLineType.Right:
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}


        /// <summary>
        /// 右上の座標
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="selfType"></param>
        private List<Cell> GetUpperRightLineStones(CellPosition pos, StoneType selfType)
        {
            return GetTurnableStones(GetUpperRightLinePosition(pos), selfType);
        }

        private IEnumerable<CellPosition> GetUpperRightLinePosition(CellPosition pos)
        {
            for (int i = 1; (pos.RowIndex - i) >= 0 && (pos.ColumnIndex + i) < 8; i++)
            {
                yield return new CellPosition(pos.RowIndex - i, pos.ColumnIndex + i);
            }
        }

        /// <summary>
        /// 右の座標
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="selfType"></param>
        private List<Cell> GetRightLineStones(CellPosition pos, StoneType selfType)
        {
            return GetTurnableStones(GetRightLinesPosition(pos), selfType);
        }

        private IEnumerable<CellPosition> GetRightLinesPosition(CellPosition pos)
        {
            for (int i = 1; (pos.ColumnIndex + i) < 8; i++)
            {
                yield return new CellPosition(pos.RowIndex, pos.ColumnIndex + i);
            }
        }

        /// <summary>
        /// 右下の座標
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="selfType"></param>
        private List<Cell> GetLowerRightLineStones(CellPosition pos, StoneType selfType)
        {
            return GetTurnableStones(GetLowerRightLinePosition(pos), selfType);
        }

        private IEnumerable<CellPosition> GetLowerRightLinePosition(CellPosition pos)
        {
            for (int i = 1; (pos.RowIndex + i) < 8 && (pos.ColumnIndex + i) < 8; i++)
            {
                yield return new CellPosition(pos.RowIndex + i, pos.ColumnIndex + i);
            }
        }

        /// <summary>
        /// 下の座標
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="selfType"></param>
        private List<Cell> GetLowerLineStones(CellPosition pos, StoneType selfType)
        {
            return GetTurnableStones(GetLowerLinePosition(pos), selfType);
        }

        private IEnumerable<CellPosition> GetLowerLinePosition(CellPosition pos)
        {
            for (int i = 1; (pos.RowIndex + i) < 8; i++)
            {
                yield return new CellPosition(pos.RowIndex + i, pos.ColumnIndex);
            }
        }

        /// <summary>
        /// 左下の座標
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="selfType"></param>
        private List<Cell> GetLowerLeftLineStones(CellPosition pos, StoneType selfType)
        {
            return GetTurnableStones(GetLowerLeftLinePosition(pos), selfType);
        }

        private IEnumerable<CellPosition> GetLowerLeftLinePosition(CellPosition pos)
        {
            for (int i = 1; (pos.RowIndex + i) < 8 && (pos.ColumnIndex - i) >= 0; i++)
            {
                yield return new CellPosition(pos.RowIndex + i, pos.ColumnIndex - i);
            }
        }

        /// <summary>
        /// 左の座標
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="selfType"></param>
        private List<Cell> GetLeftLineStones(CellPosition pos, StoneType selfType)
        {
            return GetTurnableStones(GetLeftLinePosition(pos), selfType);
        }

        private IEnumerable<CellPosition> GetLeftLinePosition(CellPosition pos)
        {
            for (int i = 1; (pos.ColumnIndex - i) >= 0; i++)
            {
                yield return new CellPosition(pos.RowIndex, pos.ColumnIndex - i);
            }
        }

        /// <summary>
        /// 左上の座標
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="selfType"></param>
        private List<Cell> GetUpperLeftLineStones(CellPosition pos, StoneType selfType)
        {
            return GetTurnableStones(GetUpperLeftLinePosition(pos), selfType);
        }

        private IEnumerable<CellPosition> GetUpperLeftLinePosition(CellPosition pos)
        {
            for (int i = 1; (pos.RowIndex - i) >= 0 && (pos.ColumnIndex - i) >= 0; i++)
            {
                yield return new CellPosition(pos.RowIndex - i, pos.ColumnIndex - i);
            }
        }

        /// <summary>
        /// 上の座標
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="selfType"></param>
        private List<Cell> GetUpperLineStones(CellPosition pos, StoneType selfType)
        {
            return GetTurnableStones(GetUpperLinePosition(pos), selfType);
        }

        private IEnumerable<CellPosition> GetUpperLinePosition(CellPosition pos)
        {
            for (int i = 1; (pos.RowIndex - i) >= 0; i++)
            {
                yield return new CellPosition(pos.RowIndex - i, pos.ColumnIndex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="posList"></param>
        /// <param name="selfType"></param>
        /// <returns></returns>
        private List<Cell> GetTurnableStones(IEnumerable<CellPosition> posList, StoneType selfType)
        {
            var otherType = selfType == StoneType.Black ? StoneType.White : StoneType.Black;
            var turnableStones = new List<Cell>();

            foreach (var p in posList)
            {
                if (Cells[p.RowIndex][p.ColumnIndex].Value == otherType)
                {
                    turnableStones.Add(Cells[p.RowIndex][p.ColumnIndex]);
                    continue;
                }
                if (Cells[p.RowIndex][p.ColumnIndex].Value == selfType)
                {
                    return turnableStones;
                }
                if (Cells[p.RowIndex][p.ColumnIndex].Value == StoneType.None)
                {
                    return new List<Cell>();
                }
            }
            return new List<Cell>();
        }

        /// <summary>
        /// 直前の手を戻す
        /// </summary>
        public void Undo()
        {
            Cells = _cellsBackup;
        }

        /// <summary>
        /// 消す
        /// </summary>
        public void Clear()
        {
            foreach (var cell in Cells)
            {
                if (cell.Position.Equals(3, 3) || cell.Position.Equals(4, 4))
                {
                    cell.Value = StoneType.White;

                }
                else if (cell.Position.Equals(3, 4) || cell.Position.Equals(4, 3))
                {
                    cell.Value = StoneType.Black;
                }
                else
                {
                    cell.Value = StoneType.None;
                }
            }
        }

        /// <summary>
        /// クローン
        /// </summary>
        /// <returns></returns>
        public Board Clone()
        {
            var cloneCells = Cells.Clone();
            return new Board() { Cells = cloneCells };
        }
    }
}
