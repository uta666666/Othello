using Othello.Core.Commons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Othello.Core.Models
{
    public class Player
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="board"></param>
        /// <param name="selfStoneType"></param>
        public Player(Board board, StoneType selfStoneType)
        {
            _board = board;
            SelfStoneType = selfStoneType;
        }

        private Board _board;

        /// <summary>
        /// 自分の石
        /// </summary>
        public StoneType SelfStoneType { get; }

        /// <summary>
        /// 自分の石のリソース
        /// </summary>
        public string SelfStoneResource {
            get {
                if (SelfStoneType == StoneType.White)
                {
                    return Cell.WhiteResource;
                }
                else
                {
                    return Cell.BlackResource;
                }
            }
        }

        /// <summary>
        /// コンピュータか
        /// </summary>
        public bool IsCPU { get; set; }

        /// <summary>
        /// 石を置く
        /// </summary>
        /// <param name="position"></param>
        /// <returns>石を置けたとき：true</returns>
        public async Task<bool> SetStoneAsync(CellPosition position)
        {
            if (!_board.SetStone(position, SelfStoneType))
            {
                return false;
            }
            //石を置けたときは挟まれた石をうらがえす
            await _board.TurnStoneAsync(position, SelfStoneType).ConfigureAwait(true);
            return true;
        }

        /// <summary>
        /// 石を置く（CPU専用）
        /// </summary>
        /// <returns></returns>
        public async Task SetStoneAutoAsync()
        {
            ICellSelector selector = CreateCellSelector();
            var pos = await selector.SelectAsync().ConfigureAwait(true);
            await SetStoneAsync(pos).ConfigureAwait(true);
        }

        private ICellSelector CreateCellSelector()
        {
            return new MinMaxFunctionSelector(_board, SelfStoneType, CreateEvaluator());
        }

        private IEvaluator CreateEvaluator()
        {
            return new WeightedEvaluator();
        }
    }
}
