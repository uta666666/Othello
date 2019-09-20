using Othello.Core.Commons;
using System;
using System.Collections.Generic;
using System.Text;

namespace Othello.Core.Models
{
    public class Cell : BindableBase
    {
        private CellStyle _style;
        public CellStyle Style {
            get {
                return _style;
            }
            set {
                if (_style == value)
                {
                    return;
                }
                SetProperty(ref _style, value);

                RaisePropertyChanged(nameof(ImagePath));
            }
        }

        public string ImagePath {
            get {
                switch (Style)
                {
                    case CellStyle.Black:
                        return "Resources/Black.png";
                    case CellStyle.Whhite:
                        return "Resources/White.png";
                    case CellStyle.None:
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
