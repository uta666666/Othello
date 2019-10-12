using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Othello.Core.Models
{
    public interface ICellSelector
    {
        Task<CellPosition> SelectAsync();
    }
}
