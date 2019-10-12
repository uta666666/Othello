using Othello.Core.Commons;
using Othello.Core.Models;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Othello.Core.ViewModels
{
    public class MainViewModel
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainViewModel()
        {
            _board = new Board();
            _player1 = new Player(_board, StoneType.White);
            _player2 = new Player(_board, StoneType.Black);
            _player2.IsCPU = true;
            _currentPlayer = _player1;

            InitializeProperty();
            InitializeCommand();
        }

        private Board _board;
        private Player _player1;
        private Player _player2;
        private Player _currentPlayer;

        /// <summary>
        /// プロパティ初期化
        /// </summary>
        private void InitializeProperty()
        {
            InitializeCellProperty();

            PlayerImage = new ReactiveProperty<string>(Cell.WhiteResource);
            WhiteCount = new ReactiveProperty<string>();
            BlackCount = new ReactiveProperty<string>();
            IsWhiteWin = new ReactiveProperty<bool>();
            IsBlackWin = new ReactiveProperty<bool>();
            IsDispResult = new ReactiveProperty<bool>();
        }

        /// <summary>
        /// セルにバインドするためのプロパティを初期化
        /// 数が多いので別メソッドにしてまとめる
        /// </summary>
        private void InitializeCellProperty()
        {
            Cell1_1 = _board.Cells[0][0].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell1_2 = _board.Cells[0][1].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell1_3 = _board.Cells[0][2].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell1_4 = _board.Cells[0][3].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell1_5 = _board.Cells[0][4].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell1_6 = _board.Cells[0][5].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell1_7 = _board.Cells[0][6].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell1_8 = _board.Cells[0][7].ObserveProperty(c => c.ImagePath).ToReactiveProperty();

            Cell2_1 = _board.Cells[1][0].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell2_2 = _board.Cells[1][1].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell2_3 = _board.Cells[1][2].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell2_4 = _board.Cells[1][3].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell2_5 = _board.Cells[1][4].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell2_6 = _board.Cells[1][5].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell2_7 = _board.Cells[1][6].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell2_8 = _board.Cells[1][7].ObserveProperty(c => c.ImagePath).ToReactiveProperty();

            Cell3_1 = _board.Cells[2][0].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell3_2 = _board.Cells[2][1].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell3_3 = _board.Cells[2][2].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell3_4 = _board.Cells[2][3].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell3_5 = _board.Cells[2][4].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell3_6 = _board.Cells[2][5].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell3_7 = _board.Cells[2][6].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell3_8 = _board.Cells[2][7].ObserveProperty(c => c.ImagePath).ToReactiveProperty();

            Cell4_1 = _board.Cells[3][0].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell4_2 = _board.Cells[3][1].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell4_3 = _board.Cells[3][2].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell4_4 = _board.Cells[3][3].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell4_5 = _board.Cells[3][4].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell4_6 = _board.Cells[3][5].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell4_7 = _board.Cells[3][6].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell4_8 = _board.Cells[3][7].ObserveProperty(c => c.ImagePath).ToReactiveProperty();

            Cell5_1 = _board.Cells[4][0].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell5_2 = _board.Cells[4][1].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell5_3 = _board.Cells[4][2].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell5_4 = _board.Cells[4][3].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell5_5 = _board.Cells[4][4].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell5_6 = _board.Cells[4][5].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell5_7 = _board.Cells[4][6].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell5_8 = _board.Cells[4][7].ObserveProperty(c => c.ImagePath).ToReactiveProperty();

            Cell6_1 = _board.Cells[5][0].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell6_2 = _board.Cells[5][1].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell6_3 = _board.Cells[5][2].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell6_4 = _board.Cells[5][3].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell6_5 = _board.Cells[5][4].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell6_6 = _board.Cells[5][5].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell6_7 = _board.Cells[5][6].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell6_8 = _board.Cells[5][7].ObserveProperty(c => c.ImagePath).ToReactiveProperty();

            Cell7_1 = _board.Cells[6][0].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell7_2 = _board.Cells[6][1].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell7_3 = _board.Cells[6][2].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell7_4 = _board.Cells[6][3].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell7_5 = _board.Cells[6][4].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell7_6 = _board.Cells[6][5].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell7_7 = _board.Cells[6][6].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell7_8 = _board.Cells[6][7].ObserveProperty(c => c.ImagePath).ToReactiveProperty();

            Cell8_1 = _board.Cells[7][0].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell8_2 = _board.Cells[7][1].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell8_3 = _board.Cells[7][2].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell8_4 = _board.Cells[7][3].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell8_5 = _board.Cells[7][4].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell8_6 = _board.Cells[7][5].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell8_7 = _board.Cells[7][6].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
            Cell8_8 = _board.Cells[7][7].ObserveProperty(c => c.ImagePath).ToReactiveProperty();
        }

        /// <summary>
        /// コマンド作成
        /// </summary>
        private void InitializeCommand()
        {
            //セルをクリックしたときの動作
            CellClickCommand = new ReactiveCommand<string>();
            CellClickCommand.Subscribe(async (string posString) =>
            {
                var position = GetPosition(posString);
                //石を置く
                if (!await _currentPlayer.SetStoneAsync(position).ConfigureAwait(true))
                {
                    //置けない場所だったときは終了
                    return;
                }
                //置けたときはプレイヤー切り替え
                if (CheckGameResult())
                {
                    return;
                }

                //相手がCPUの場合
                if (_currentPlayer.IsCPU)
                {
                    //石を置く
                    //置ける置けない関係なくプレイヤーを切り替える
                    //CPUの場合、間違ったセルを選ぶことがないので、置けないということは、置く場所がないということ
                    await _currentPlayer.SetStoneAutoAsync().ConfigureAwait(true);
                    if (CheckGameResult())
                    {
                        return;
                    }
                }
            });

            //パスしたときの動作
            PassCommand = new ReactiveCommand();
            PassCommand.Subscribe(async () =>
            {
                ChangePlayer();
                //相手がCPUの場合
                if (_currentPlayer.IsCPU)
                {
                    //石を置く
                    //置ける置けない関係なくプレイヤーを切り替える
                    //CPUの場合、間違ったセルを選ぶことがないので、置けないということは、置く場所がないということ
                    await _currentPlayer.SetStoneAutoAsync().ConfigureAwait(true);
                    if (CheckGameResult())
                    {
                        return;
                    }
                }
            });

            ResetCommand = new ReactiveCommand();
            ResetCommand.Subscribe(() =>
            {
                _board.Clear();
                _currentPlayer = _player1;

                WhiteCount.Value = string.Empty;
                BlackCount.Value = string.Empty;
                IsWhiteWin.Value = false;
                IsBlackWin.Value = false;
                IsDispResult.Value = false;
            });
        }

        /// <summary>
        /// コロン区切りの座標をCellPositionクラスに変換する
        /// </summary>
        /// <param name="posString"></param>
        /// <returns></returns>
        private CellPosition GetPosition(string posString)
        {
            var pos = posString.Split(":");
            return new CellPosition()
            {
                RowIndex = int.Parse(pos[0]),
                ColumnIndex = int.Parse(pos[1])
            };
        }

        /// <summary>
        /// ゲーム結果の確認　ターン変更
        /// </summary>
        /// <returns>勝負がついた</returns>
        private bool CheckGameResult()
        {
            int whiteCount;
            int blackCount;

            var result = _board.GetGameResult(out whiteCount, out blackCount);
            if (result != GameResult.None)
            {
                WhiteCount.Value = $"：{whiteCount}";
                BlackCount.Value = $"：{blackCount}";
                IsWhiteWin.Value = result == GameResult.WinWhite;
                IsBlackWin.Value = result == GameResult.WinBlack;
                IsDispResult.Value = true;
                return true;
            }
            ChangePlayer();
            return false;
        }

        /// <summary>
        /// ターン変更
        /// </summary>
        private void ChangePlayer()
        {
            _currentPlayer = _currentPlayer == _player1 ? _player2 : _player1;

            if (_currentPlayer.SelfStoneType == StoneType.White)
            {
                PlayerImage.Value = Cell.WhiteResource;
            }
            else if (_currentPlayer.SelfStoneType == StoneType.Black)
            {
                PlayerImage.Value = Cell.BlackResource;
            }
        }


        #region Property

        #region Row1
        public ReactiveProperty<string> Cell1_1 { get; set; }
        public ReactiveProperty<string> Cell1_2 { get; set; }
        public ReactiveProperty<string> Cell1_3 { get; set; }
        public ReactiveProperty<string> Cell1_4 { get; set; }
        public ReactiveProperty<string> Cell1_5 { get; set; }
        public ReactiveProperty<string> Cell1_6 { get; set; }
        public ReactiveProperty<string> Cell1_7 { get; set; }
        public ReactiveProperty<string> Cell1_8 { get; set; }
        #endregion Row1
        #region Row2
        public ReactiveProperty<string> Cell2_1 { get; set; }
        public ReactiveProperty<string> Cell2_2 { get; set; }
        public ReactiveProperty<string> Cell2_3 { get; set; }
        public ReactiveProperty<string> Cell2_4 { get; set; }
        public ReactiveProperty<string> Cell2_5 { get; set; }
        public ReactiveProperty<string> Cell2_6 { get; set; }
        public ReactiveProperty<string> Cell2_7 { get; set; }
        public ReactiveProperty<string> Cell2_8 { get; set; }
        #endregion Row2
        #region Row3
        public ReactiveProperty<string> Cell3_1 { get; set; }
        public ReactiveProperty<string> Cell3_2 { get; set; }
        public ReactiveProperty<string> Cell3_3 { get; set; }
        public ReactiveProperty<string> Cell3_4 { get; set; }
        public ReactiveProperty<string> Cell3_5 { get; set; }
        public ReactiveProperty<string> Cell3_6 { get; set; }
        public ReactiveProperty<string> Cell3_7 { get; set; }
        public ReactiveProperty<string> Cell3_8 { get; set; }
        #endregion Row3
        #region Row4
        public ReactiveProperty<string> Cell4_1 { get; set; }
        public ReactiveProperty<string> Cell4_2 { get; set; }
        public ReactiveProperty<string> Cell4_3 { get; set; }
        public ReactiveProperty<string> Cell4_4 { get; set; }
        public ReactiveProperty<string> Cell4_5 { get; set; }
        public ReactiveProperty<string> Cell4_6 { get; set; }
        public ReactiveProperty<string> Cell4_7 { get; set; }
        public ReactiveProperty<string> Cell4_8 { get; set; }
        #endregion Row4
        #region Row5
        public ReactiveProperty<string> Cell5_1 { get; set; }
        public ReactiveProperty<string> Cell5_2 { get; set; }
        public ReactiveProperty<string> Cell5_3 { get; set; }
        public ReactiveProperty<string> Cell5_4 { get; set; }
        public ReactiveProperty<string> Cell5_5 { get; set; }
        public ReactiveProperty<string> Cell5_6 { get; set; }
        public ReactiveProperty<string> Cell5_7 { get; set; }
        public ReactiveProperty<string> Cell5_8 { get; set; }
        #endregion Row5
        #region Row6
        public ReactiveProperty<string> Cell6_1 { get; set; }
        public ReactiveProperty<string> Cell6_2 { get; set; }
        public ReactiveProperty<string> Cell6_3 { get; set; }
        public ReactiveProperty<string> Cell6_4 { get; set; }
        public ReactiveProperty<string> Cell6_5 { get; set; }
        public ReactiveProperty<string> Cell6_6 { get; set; }
        public ReactiveProperty<string> Cell6_7 { get; set; }
        public ReactiveProperty<string> Cell6_8 { get; set; }
        #endregion Row6
        #region Row7
        public ReactiveProperty<string> Cell7_1 { get; set; }
        public ReactiveProperty<string> Cell7_2 { get; set; }
        public ReactiveProperty<string> Cell7_3 { get; set; }
        public ReactiveProperty<string> Cell7_4 { get; set; }
        public ReactiveProperty<string> Cell7_5 { get; set; }
        public ReactiveProperty<string> Cell7_6 { get; set; }
        public ReactiveProperty<string> Cell7_7 { get; set; }
        public ReactiveProperty<string> Cell7_8 { get; set; }
        #endregion Row7
        #region Row8
        public ReactiveProperty<string> Cell8_1 { get; set; }
        public ReactiveProperty<string> Cell8_2 { get; set; }
        public ReactiveProperty<string> Cell8_3 { get; set; }
        public ReactiveProperty<string> Cell8_4 { get; set; }
        public ReactiveProperty<string> Cell8_5 { get; set; }
        public ReactiveProperty<string> Cell8_6 { get; set; }
        public ReactiveProperty<string> Cell8_7 { get; set; }
        public ReactiveProperty<string> Cell8_8 { get; set; }
        #endregion Row8

        /// <summary>
        /// 白○　黒○
        /// </summary>
        public ReactiveProperty<string> PlayerImage { get; set; }

        public ReactiveProperty<string> WhiteCount { get; set; }

        public ReactiveProperty<string> BlackCount { get; set; }

        public ReactiveProperty<bool> IsWhiteWin { get; set; }

        public ReactiveProperty<bool> IsBlackWin { get; set; }

        public ReactiveProperty<bool> IsDispResult { get; set; }

        #endregion Property

        /// <summary>
        /// セルをクリックしたときのコマンド
        /// </summary>
        public ReactiveCommand<string> CellClickCommand { get; private set; }

        /// <summary>
        /// パスしたときのコマンド
        /// </summary>
        public ReactiveCommand PassCommand { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ReactiveCommand ResetCommand { get; private set; }
    }
}
