namespace PinkLady
{
    partial class FormPinkLady
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPinkLady));
            this.cmbStage = new System.Windows.Forms.ComboBox();
            this.picboxCur = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TopDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BottomUp_ClickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picboxNext = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picboxCur)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxNext)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.cmbStage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStage.FormattingEnabled = true;
            this.cmbStage.Items.AddRange(new object[] {
            "1面",
            "2面",
            "3面",
            "4面",
            "5面",
            "6面"});
            this.cmbStage.Location = new System.Drawing.Point(9, 12);
            this.cmbStage.Name = "comboBox1";
            this.cmbStage.Size = new System.Drawing.Size(130, 20);
            this.cmbStage.TabIndex = 0;
            this.cmbStage.SelectedIndexChanged += new System.EventHandler(this.ComboBoxSelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.picboxCur.Location = new System.Drawing.Point(9, 38);
            this.picboxCur.Name = "pictureBox1";
            this.picboxCur.Size = new System.Drawing.Size(130, 173);
            this.picboxCur.TabIndex = 1;
            this.picboxCur.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TopDownToolStripMenuItem,
            this.BottomUp_ClickToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(128, 48);
            // 
            // 上から下へToolStripMenuItem
            // 
            this.TopDownToolStripMenuItem.Name = "TopDownToolStripMenuItem";
            this.TopDownToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.TopDownToolStripMenuItem.Text = "上から下へ";
            this.TopDownToolStripMenuItem.Click += new System.EventHandler(this.TopDown_Click);
            // 
            // 下から上へToolStripMenuItem
            // 
            this.BottomUp_ClickToolStripMenuItem.Name = "BottomUpToolStripMenuItem";
            this.BottomUp_ClickToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.BottomUp_ClickToolStripMenuItem.Text = "下から上へ";
            this.BottomUp_ClickToolStripMenuItem.Click += new System.EventHandler(this.BottomUp_Click);
            // 
            // pictureBox2
            // 
            this.picboxNext.Location = new System.Drawing.Point(9, 217);
            this.picboxNext.Name = "pictureBox2";
            this.picboxNext.Size = new System.Drawing.Size(130, 16);
            this.picboxNext.TabIndex = 2;
            this.picboxNext.TabStop = false;
            // 
            // FormPinkLady
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(148, 236);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.picboxNext);
            this.Controls.Add(this.picboxCur);
            this.Controls.Add(this.cmbStage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormPinkLady";
            this.Text = "PinkLady";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picboxCur)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picboxNext)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbStage;
        private System.Windows.Forms.PictureBox picboxCur;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TopDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BottomUp_ClickToolStripMenuItem;
        private System.Windows.Forms.PictureBox picboxNext;
    }
}

