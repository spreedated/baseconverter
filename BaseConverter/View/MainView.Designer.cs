using System.Drawing;
using System.Windows.Forms;

namespace BaseConverter
{
    partial class MainView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TXT_Dec = new TextBox();
            this.LBL_Dec = new Label();
            this.LBL_Hex = new Label();
            this.TXT_Hex = new TextBox();
            this.LBL_Bin = new Label();
            this.TXT_Bin = new TextBox();
            this.LBL_Oct = new Label();
            this.TXT_Oct = new TextBox();
            this.SuspendLayout();
            // 
            // TXT_Dec
            // 
            this.TXT_Dec.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.TXT_Dec.Location = new Point(47, 78);
            this.TXT_Dec.Name = "TXT_Dec";
            this.TXT_Dec.Size = new Size(269, 23);
            this.TXT_Dec.TabIndex = 2;
            this.TXT_Dec.Tag = "Decimal";
            this.TXT_Dec.TextChanged += this.TXT_Dec_TextChanged;
            this.TXT_Dec.KeyDown += this.Textbox_KeyDown;
            // 
            // LBL_Dec
            // 
            this.LBL_Dec.AutoSize = true;
            this.LBL_Dec.Location = new Point(12, 81);
            this.LBL_Dec.Name = "LBL_Dec";
            this.LBL_Dec.Size = new Size(27, 15);
            this.LBL_Dec.TabIndex = 1;
            this.LBL_Dec.Text = "Dec";
            // 
            // LBL_Hex
            // 
            this.LBL_Hex.AutoSize = true;
            this.LBL_Hex.Location = new Point(12, 110);
            this.LBL_Hex.Name = "LBL_Hex";
            this.LBL_Hex.Size = new Size(28, 15);
            this.LBL_Hex.TabIndex = 3;
            this.LBL_Hex.Text = "Hex";
            // 
            // TXT_Hex
            // 
            this.TXT_Hex.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.TXT_Hex.Location = new Point(47, 107);
            this.TXT_Hex.Name = "TXT_Hex";
            this.TXT_Hex.Size = new Size(269, 23);
            this.TXT_Hex.TabIndex = 3;
            this.TXT_Hex.Tag = "Hexadecimal";
            this.TXT_Hex.TextChanged += this.TXT_Hex_TextChanged;
            this.TXT_Hex.KeyDown += this.Textbox_KeyDown;
            // 
            // LBL_Bin
            // 
            this.LBL_Bin.AutoSize = true;
            this.LBL_Bin.Location = new Point(12, 23);
            this.LBL_Bin.Name = "LBL_Bin";
            this.LBL_Bin.Size = new Size(24, 15);
            this.LBL_Bin.TabIndex = 5;
            this.LBL_Bin.Text = "Bin";
            // 
            // TXT_Bin
            // 
            this.TXT_Bin.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.TXT_Bin.Location = new Point(47, 20);
            this.TXT_Bin.Name = "TXT_Bin";
            this.TXT_Bin.Size = new Size(269, 23);
            this.TXT_Bin.TabIndex = 0;
            this.TXT_Bin.Tag = "Binary";
            this.TXT_Bin.TextChanged += this.TXT_Bin_TextChanged;
            this.TXT_Bin.KeyDown += this.Textbox_KeyDown;
            // 
            // LBL_Oct
            // 
            this.LBL_Oct.AutoSize = true;
            this.LBL_Oct.Location = new Point(12, 52);
            this.LBL_Oct.Name = "LBL_Oct";
            this.LBL_Oct.Size = new Size(26, 15);
            this.LBL_Oct.TabIndex = 6;
            this.LBL_Oct.Text = "Oct";
            // 
            // TXT_Oct
            // 
            this.TXT_Oct.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.TXT_Oct.Location = new Point(47, 49);
            this.TXT_Oct.Name = "TXT_Oct";
            this.TXT_Oct.Size = new Size(269, 23);
            this.TXT_Oct.TabIndex = 1;
            this.TXT_Oct.Tag = "Octal";
            this.TXT_Oct.TextChanged += this.TXT_Oct_TextChanged;
            this.TXT_Oct.KeyDown += this.Textbox_KeyDown;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(328, 156);
            this.Controls.Add(this.LBL_Oct);
            this.Controls.Add(this.TXT_Oct);
            this.Controls.Add(this.LBL_Bin);
            this.Controls.Add(this.TXT_Bin);
            this.Controls.Add(this.LBL_Hex);
            this.Controls.Add(this.TXT_Hex);
            this.Controls.Add(this.LBL_Dec);
            this.Controls.Add(this.TXT_Dec);
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.Name = "MainView";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private TextBox TXT_Dec;
        private Label LBL_Dec;
        private Label LBL_Hex;
        private TextBox TXT_Hex;
        private Label LBL_Bin;
        private TextBox TXT_Bin;
        private Label LBL_Oct;
        private TextBox TXT_Oct;
    }
}
