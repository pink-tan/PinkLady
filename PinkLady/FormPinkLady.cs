using System;
using System.Drawing;
using System.Windows.Forms;

namespace PinkLady
{
    /// <summary>
    /// フォームクラス
    /// </summary>
    public partial class FormPinkLady : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormPinkLady()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 上から下フラグ
        /// </summary>
        private bool TopDown = true;
        /// <summary>
        /// フォントクラスのインスタンス使いまわし用クラス
        /// </summary>
        private readonly FontManager fontManager = new FontManager();

        /// <summary>
        /// フォームロードイベントハンドラ
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            // 面選択状態初期化
            cmbStage.Text = "1面";
            // 描画制御
            Draw();
        }

        /// <summary>
        /// 面選択状態変化イベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            // 描画制御
            Draw();
        }

        /// <summary>
        /// 描画制御
        /// </summary>
        private void Draw()
        {
            // リソーステープル
            string[] DATA = 
            {
                PinkLady.Properties.Resources._1,
                PinkLady.Properties.Resources._2,
                PinkLady.Properties.Resources._3,
                PinkLady.Properties.Resources._4,
                PinkLady.Properties.Resources._5,
                PinkLady.Properties.Resources._6,
                string.Empty
            };

            // 面選択状態取得
            int index = cmbStage.SelectedIndex;
            // 面選択状態が有効な範囲の場合
            if ((index >= 0) && (index < 6))
            {
                // 現在の面についてリソース読み込み
                string data = DATA[index];
                // 改行コードでsplit
                string[] splited = data.Replace("\r\n", "\n").Split('\n');
                /// 上から下の場合
                if (TopDown)
                {
                    // PictureBoxの配置
                    picboxCur.Top =  38;
                    picboxNext.Top = 214;
                }
                /// 下から上の場合
                else
                {
                    // PictureBoxの配置
                    picboxCur.Top = 58;
                    picboxNext.Top = 38;
                    // リソースの反転
                    Array.Reverse(splited);
                }
                // ファイル単位の描画
                Draw(picboxCur, splited, true, 3, false);


                // 次の面についてリソース読み込み
                string nextdata = DATA[index + 1];
                // 改行コードでsplitした先頭のみを予告
                string[] nextsplited = new string[1];
                nextsplited[0] = nextdata.Replace("\r\n", "\n").Split('\n')[0];
                // ファイル単位の描画
                Draw(picboxNext, nextsplited, false, 3, true);
            }
        }

        /// <summary>
        /// ファイル単位の描画
        /// </summary>
        /// <param name="pictureBox">描画対象PictureBox</param>
        /// <param name="data">ファイルの内容</param>
        /// <param name="big">フォントサイズ大きいフラグ</param>
        /// <param name="startPosY">描画開始Y座標</param>
        /// <param name="nextStage">次の面フラグ</param>
        private void Draw(PictureBox pictureBox, string[] data, bool big, int startPosY, bool nextStage)
        {
            // Graphicsの取得
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics graphics = Graphics.FromImage(pictureBox.Image);
            // 描画対象PictureBoxの初期化
            using (Brush brush = new SolidBrush(Color.FromArgb(255, 240, 240)))
            {
                graphics.FillRectangle(brush, graphics.VisibleClipBounds);
            }

            // 基本フォント取得
            Font defaultFont = fontManager.GetFont(big);

            // 1行ずつ処理
            int y = startPosY;
            for (int i = 0; i < data.Length; i++)
            {
                // foreach使いたいけど我慢
                string line = data[i];
                // 空行の場合
                if (line.Length == 0)
                {
                    // 読み飛ばし
                    continue;
                }
                // --の場合
                else if (line == "--")
                {
                    // 隙間を作る
                    y += (int)defaultFont.Size / 2 + 2;
                }
                // 上記以外の場合
                else
                {
                    // | でsplit
                    string[] ufos = line.Split('|');

                    // 1UFOずつ処理
                    int x = ((int)graphics.VisibleClipBounds.Width - (ufos.Length * ((int)(defaultFont.Size * 1.3)))) / 2;
                    for (int j = 0; j < ufos.Length; j++)
                    {
                        // foreach使いたいけど我慢
                        string ufo = ufos[j];
                        // UFO単位の描画
                        Draw(graphics, ufo, big, x, y);
                        // 右に移動
                        x += (int)defaultFont.Size + 3;
                    }

                    // 次の面についての場合
                    if (nextStage)
                    {
                        // "Next"描画
                        graphics.DrawString("Next", defaultFont, Brushes.Gray, 0, y);
                    }

                    // 下に移動
                    y += (int)defaultFont.Size + 4;
                }
            }
            // Graphicsの破棄
            graphics.Dispose();
        }

        /// <summary>
        /// UFO単位の描画
        /// </summary>
        /// <param name="graphics">Graphics</param>
        /// <param name="ufo">UFO情報</param>
        /// <param name="big">フォントサイズ大きいフラグ</param>
        /// <param name="x">X座標</param>
        /// <param name="y">Y座標</param>
        private void Draw(Graphics graphics, string ufo, bool big, int x, int y)
        {
            Font font;
            Brush color = Brushes.BlueViolet;

            // 文字の色
            switch (ufo)
            {
                case "赤":
                case "R赤":
                    color = Brushes.Red;
                    break;
                case "緑":
                case "R緑":
                    color = Brushes.Green;
                    break;
                case "青":
                case "R青":
                    color = Brushes.Blue;
                    break;
                default:
                    break;
            }

            // 文字とフォント
            switch (ufo)
            {
                case "R赤":
                case "R緑":
                case "R青":
                    ufo = "虹";
                    font = fontManager.GetFont(big, false);
                    break;
                default:
                    font = fontManager.GetFont(big, true);
                    break;
            }

            // 描画
            graphics.DrawString(ufo, font, color, x, y);
        }

        /// <summary>
        /// 上から下へクリック時動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopDown_Click(object sender, EventArgs e)
        {
            // 上から下へフラグを立てる
            TopDown = true;
            // 描画制御
            Draw();
        }

        /// <summary>
        /// 下から上へクリック時動作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BottomUp_Click(object sender, EventArgs e)
        {
            // 上から下へフラグを落とす
            TopDown = false;
            // 描画制御
            Draw();
        }
    }

    /// <summary>
    /// フォントクラスのインスタンス使いまわし用クラス
    /// </summary>
    public class FontManager
    {
        /// <summary>
        /// フォント名
        /// </summary>
        private const string FONTNAME = "ＭＳ ゴシック";
        /// <summary>
        /// 大きくて太い
        /// </summary>
        public Font BigBold { get; set; }
        /// <summary>
        /// 大きくて太くない
        /// </summary>
        public Font Big { get; set; }
        /// <summary>
        /// 大きくなくて太い
        /// </summary>
        public Font SmallBold { get; set; }
        /// <summary>
        /// 大きくなくて太くない
        /// </summary>
        public Font Small { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FontManager()
        {
            // 初期化
            BigBold     = new Font(FONTNAME, 12, FontStyle.Bold);
            Big         = new Font(FONTNAME, 12);
            SmallBold   = new Font(FONTNAME, 9, FontStyle.Bold);
            Small       = new Font(FONTNAME, 9);
        }
        /// <summary>
        /// ファイナライザ
        /// </summary>
        ~FontManager()
        {
            // 解放
            BigBold.Dispose();
            Big.Dispose();
            SmallBold.Dispose();
            Small.Dispose();
        }

        /// <summary>
        /// フォントクラスのインスタンス取得
        /// </summary>
        /// <param name="big">大きい</param>
        /// <returns>フォントクラスのインスタンス</returns>
        public Font GetFont(bool big)
        {
            return GetFont(big, false);
        }

        /// <summary>
        /// フォントクラスのインスタンス取得
        /// </summary>
        /// <param name="big">大きい</param>
        /// <param name="bold">太い</param>
        /// <returns>フォントクラスのインスタンス</returns>
        public Font GetFont(bool big, bool bold)
        {
            Font font;
            if (big)
            {
                if (bold)
                {
                    font = BigBold;
                }
                else
                {
                    font = Big;
                }
            }
            else
            {
                if (bold)
                {
                    font = SmallBold;
                }
                else
                {
                    font = Small;
                }
            }

            return font;
        }
    }
}
