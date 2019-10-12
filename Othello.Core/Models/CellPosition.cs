using System;
using System.Collections.Generic;
using System.Text;

namespace Othello.Core.Models
{
    public class CellPosition
    {
        public CellPosition()
        {

        }

        public CellPosition(int rowIndex, int colIndex)
        {
            RowIndex = rowIndex;
            ColumnIndex = colIndex;
        }

        public static CellPosition Empty { get; } = new CellPosition(0, 0);

        public int RowIndex { get; set; }

        public int ColumnIndex { get; set; }

        public bool Equals(int rowIndex, int colIndex)
        {
            var pos = new CellPosition()
            {
                RowIndex = rowIndex,
                ColumnIndex = colIndex
            };
            return Equals(pos);
        }

        public override bool Equals(object obj)
        {
            var target = obj as CellPosition;
            if (target == null)
            {
                return false;
            }
            return target.RowIndex == RowIndex && target.ColumnIndex == ColumnIndex;
        }
    }
}
