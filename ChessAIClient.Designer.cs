namespace ChessAI
{
    partial class ChessAIClient
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
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            richTextBox2 = new RichTextBox();
            cntSvr = new Button();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(708, 27);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(250, 288);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.BackColor = Color.LightGreen;
            button1.Font = new Font("Segoe UI", 13F);
            button1.Location = new Point(708, 336);
            button1.Name = "button1";
            button1.Size = new Size(140, 83);
            button1.TabIndex = 2;
            button1.Text = "Opponent move";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(708, 453);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(250, 288);
            richTextBox2.TabIndex = 3;
            richTextBox2.Text = "";
            // 
            // cntSvr
            // 
            cntSvr.BackColor = Color.Chartreuse;
            cntSvr.Font = new Font("Segoe UI", 13F);
            cntSvr.Location = new Point(854, 336);
            cntSvr.Name = "cntSvr";
            cntSvr.Size = new Size(104, 83);
            cntSvr.TabIndex = 4;
            cntSvr.Text = "Connect server";
            cntSvr.UseVisualStyleBackColor = false;
            cntSvr.Click += cntSvr_Click;
            // 
            // ChessAIClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 753);
            Controls.Add(cntSvr);
            Controls.Add(richTextBox2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Name = "ChessAIClient";
            Text = "Form1";
            Load += ClientForm_Load;
            Paint += boardPaint;
            MouseClick += boardClick;
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
        private Button button1;
        private RichTextBox richTextBox2;
        private Button cntSvr;
    }
}
