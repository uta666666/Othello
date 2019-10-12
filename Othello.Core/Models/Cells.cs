using Othello.Core.Commons;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Othello.Core.Models
{
    public class Cells : IEnumerable<Cell>
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Cells()
        {
            var row1 = new List<Cell>()
            {
                new Cell(0, 0),
                new Cell(0, 1),
                new Cell(0, 2),
                new Cell(0, 3),
                new Cell(0, 4),
                new Cell(0, 5),
                new Cell(0, 6),
                new Cell(0, 7),
            };
            var row2 = new List<Cell>()
            {
                new Cell(1, 0),
                new Cell(1, 1),
                new Cell(1, 2),
                new Cell(1, 3),
                new Cell(1, 4),
                new Cell(1, 5),
                new Cell(1, 6),
                new Cell(1, 7)
            };
            var row3 = new List<Cell>()
            {
                new Cell(2, 0),
                new Cell(2, 1),
                new Cell(2, 2),
                new Cell(2, 3),
                new Cell(2, 4),
                new Cell(2, 5),
                new Cell(2, 6),
                new Cell(2, 7)
            };
            var row4 = new List<Cell>()
            {
                new Cell(3, 0),
                new Cell(3, 1),
                new Cell(3, 2),
                new Cell(3, 3),
                new Cell(3, 4),
                new Cell(3, 5),
                new Cell(3, 6),
                new Cell(3, 7)
            };
            var row5 = new List<Cell>()
            {
                new Cell(4, 0),
                new Cell(4, 1),
                new Cell(4, 2),
                new Cell(4, 3),
                new Cell(4, 4),
                new Cell(4, 5),
                new Cell(4, 6),
                new Cell(4, 7)
            };
            var row6 = new List<Cell>()
            {
                new Cell(5, 0),
                new Cell(5, 1),
                new Cell(5, 2),
                new Cell(5, 3),
                new Cell(5, 4),
                new Cell(5, 5),
                new Cell(5, 6),
                new Cell(5, 7)
            };
            var row7 = new List<Cell>()
            {
                new Cell(6, 0),
                new Cell(6, 1),
                new Cell(6, 2),
                new Cell(6, 3),
                new Cell(6, 4),
                new Cell(6, 5),
                new Cell(6, 6),
                new Cell(6, 7)
            };
            var row8 = new List<Cell>()
            {
                new Cell(7, 0),
                new Cell(7, 1),
                new Cell(7, 2),
                new Cell(7, 3),
                new Cell(7, 4),
                new Cell(7, 5),
                new Cell(7, 6),
                new Cell(7, 7)
            };

            _cells = new List<List<Cell>>()
            {
                row1,
                row2,
                row3,
                row4,
                row5,
                row6,
                row7,
                row8
            };
        }


        private List<List<Cell>> _cells;


        public List<Cell> this[int index] {
            get {
                return _cells[index];
            }
        }

        public int Count {
            get {
                return _cells.Count;
            }
        }

        public IEnumerator<Cell> GetEnumerator()
        {
            foreach (var row in _cells)
            {
                foreach (var cell in row)
                {
                    yield return cell;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Cells Clone()
        {
            var cloneCells = new Cells();
            for (int i = 0; i < _cells.Count; i++)
            {
                for (int j = 0; j < _cells[i].Count; j++)
                {
                    cloneCells[i][j] = _cells[i][j].Clone();
                }
            }

            return cloneCells;
        }
    }
}
