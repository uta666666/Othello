using Othello.Core.Commons;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Media;
using Color = System.Windows.Media.Color;

namespace Othello.Core.Models
{
    public class Cell : BindableBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="colIndex"></param>
        public Cell(int rowIndex, int colIndex)
        {
            Position = new CellPosition()
            {
                RowIndex = rowIndex,
                ColumnIndex = colIndex
            };
            if (Position.Equals(3, 3) || Position.Equals(4, 4))
            {
                Value = StoneType.White;

            }
            else if (Position.Equals(3, 4) || Position.Equals(4, 3))
            {
                Value = StoneType.Black;
            }
            else
            {
                Value = StoneType.None;
            }

        }

        private StoneType _value;
        /// <summary>
        /// セルに置かれている石
        /// </summary>
        public StoneType Value {
            get {
                return _value;
            }
            set {
                if (_value == value)
                {
                    return;
                }
                SetProperty(ref _value, value);

                RaisePropertyChanged(nameof(ImagePath));
            }
        }

        /// <summary>
        /// セルに置かれてい石の画像
        /// </summary>
        public string ImagePath {
            get {
                switch (Value)
                {
                    case StoneType.Black:
                        return BlackResource;
                    case StoneType.White:
                        return WhiteResource;
                    case StoneType.None:
                    default:
                        return string.Empty;
                }
            }
        }

        /// <summary>
        /// セルの座標
        /// </summary>
        public CellPosition Position { get; private set; }

        private Brush _backGround = Brushes.LawnGreen;
        /// <summary>
        /// 
        /// </summary>
        public Brush BackGround {
            get {
                return _backGround;
            }
            set {
                if (_backGround == value)
                {
                    return;
                }
                SetProperty(ref _backGround, value);
            }
        }

        /// <summary>
        /// 石を返す
        /// </summary>
        public void Turn()
        {
            if (Value == StoneType.Black)
            {
                Value = StoneType.White;
            }
            else if (Value == StoneType.White)
            {
                Value = StoneType.Black;
            }
        }

        /// <summary>
        /// 複製
        /// </summary>
        /// <returns></returns>
        public Cell Clone()
        {
            var cell = new Cell(Position.RowIndex, Position.ColumnIndex);
            cell.Value = Value;
            return cell;
        }

        public static string BlackResource { get; } = "../Resources/Black.png";
        public static string WhiteResource { get; } = "../Resources/White.png";
    }
}
