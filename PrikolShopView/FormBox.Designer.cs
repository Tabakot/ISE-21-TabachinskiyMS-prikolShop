namespace PrikolShopView
{
    partial class FormBox
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.labelCount = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.comboBoxGift = new System.Windows.Forms.ComboBox();
            this.labelGift = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(383, 110);
            this.ButtonCancel.Name = "buttonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(110, 37);
            this.ButtonCancel.TabIndex = 7;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(257, 110);
            this.ButtonSave.Name = "buttonSave";
            this.ButtonSave.Size = new System.Drawing.Size(110, 37);
            this.ButtonSave.TabIndex = 6;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(24, 66);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(100, 20);
            this.labelCount.TabIndex = 5;
            this.labelCount.Text = "Количество";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(134, 66);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(359, 26);
            this.textBoxCount.TabIndex = 4;
            // 
            // comboBoxGift
            // 
            this.comboBoxGift.FormattingEnabled = true;
            this.comboBoxGift.Location = new System.Drawing.Point(135, 22);
            this.comboBoxGift.Name = "comboBoxGift";
            this.comboBoxGift.Size = new System.Drawing.Size(358, 28);
            this.comboBoxGift.TabIndex = 8;
            // 
            // labelGift
            // 
            this.labelGift.AutoSize = true;
            this.labelGift.Location = new System.Drawing.Point(24, 25);
            this.labelGift.Name = "labelGift";
            this.labelGift.Size = new System.Drawing.Size(65, 20);
            this.labelGift.TabIndex = 5;
            this.labelGift.Text = "Подарок";
            // 
            // FormBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 168);
            this.Controls.Add(this.comboBoxGift);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.labelGift);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.textBoxCount);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormBox";
            this.Text = "Подарочная упаковка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.ComboBox comboBoxGift;
        private System.Windows.Forms.Label labelGift;
    }
}