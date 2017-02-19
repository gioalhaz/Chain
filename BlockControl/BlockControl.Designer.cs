namespace BlockControl
{
    partial class BlockControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textData = new System.Windows.Forms.TextBox();
            this.textPrevBlock = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textPow = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textNonce = new System.Windows.Forms.TextBox();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.labelTimeSpan = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textNumber
            // 
            this.textNumber.Location = new System.Drawing.Point(28, 4);
            this.textNumber.Name = "textNumber";
            this.textNumber.ReadOnly = true;
            this.textNumber.Size = new System.Drawing.Size(57, 20);
            this.textNumber.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "N";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "მონაცემები";
            // 
            // textData
            // 
            this.textData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textData.Location = new System.Drawing.Point(5, 48);
            this.textData.Multiline = true;
            this.textData.Name = "textData";
            this.textData.Size = new System.Drawing.Size(227, 67);
            this.textData.TabIndex = 3;
            this.textData.TextChanged += new System.EventHandler(this.textData_TextChanged);
            // 
            // textPrevBlock
            // 
            this.textPrevBlock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPrevBlock.Location = new System.Drawing.Point(47, 121);
            this.textPrevBlock.Name = "textPrevBlock";
            this.textPrevBlock.ReadOnly = true;
            this.textPrevBlock.Size = new System.Drawing.Size(185, 20);
            this.textPrevBlock.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "<<==";
            // 
            // textPow
            // 
            this.textPow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textPow.Location = new System.Drawing.Point(47, 144);
            this.textPow.Name = "textPow";
            this.textPow.ReadOnly = true;
            this.textPow.Size = new System.Drawing.Size(185, 20);
            this.textPow.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "POW";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(85, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "ცდა";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textNonce
            // 
            this.textNonce.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textNonce.Location = new System.Drawing.Point(122, 4);
            this.textNonce.Name = "textNonce";
            this.textNonce.ReadOnly = true;
            this.textNonce.Size = new System.Drawing.Size(110, 20);
            this.textNonce.TabIndex = 8;
            // 
            // labelTimeSpan
            // 
            this.labelTimeSpan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTimeSpan.AutoSize = true;
            this.labelTimeSpan.Font = new System.Drawing.Font("Sylfaen", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimeSpan.Location = new System.Drawing.Point(119, 27);
            this.labelTimeSpan.Name = "labelTimeSpan";
            this.labelTimeSpan.Size = new System.Drawing.Size(0, 18);
            this.labelTimeSpan.TabIndex = 10;
            // 
            // BlockControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelTimeSpan);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textNonce);
            this.Controls.Add(this.textPow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textPrevBlock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textNumber);
            this.Name = "BlockControl";
            this.Size = new System.Drawing.Size(235, 169);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textData;
        private System.Windows.Forms.TextBox textPrevBlock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textPow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textNonce;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.Label labelTimeSpan;
    }
}
