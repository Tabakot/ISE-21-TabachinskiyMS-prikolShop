namespace PrikolShopView
{
    partial class FormCreateOrder
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
            this.comboBoxGiftBox = new System.Windows.Forms.ComboBox();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.labelGift = new System.Windows.Forms.Label();
            this.labelSum = new System.Windows.Forms.Label();
            this.TextBoxCount = new System.Windows.Forms.TextBox();
            this.TextBoxSum = new System.Windows.Forms.TextBox();
            this.labelCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxGiftBox
            // 
            this.comboBoxGiftBox.FormattingEnabled = true;
            this.comboBoxGiftBox.Location = new System.Drawing.Point(159, 28);
            this.comboBoxGiftBox.Name = "comboBoxGiftBox";
            this.comboBoxGiftBox.Size = new System.Drawing.Size(358, 28);
            this.comboBoxGiftBox.TabIndex = 14;
            this.comboBoxGiftBox.SelectedIndexChanged += new System.EventHandler(this.ComboBoxGiftBox_SelectedIndexChanged);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(407, 158);
            this.ButtonCancel.Name = "buttonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(110, 37);
            this.ButtonCancel.TabIndex = 13;
            this.ButtonCancel.Text = "Отмена";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(281, 158);
            this.ButtonSave.Name = "buttonSave";
            this.ButtonSave.Size = new System.Drawing.Size(110, 37);
            this.ButtonSave.TabIndex = 12;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // labelGift
            // 
            this.labelGift.AutoSize = true;
            this.labelGift.Location = new System.Drawing.Point(48, 31);
            this.labelGift.Name = "labelGift";
            this.labelGift.Size = new System.Drawing.Size(53, 20);
            this.labelGift.TabIndex = 10;
            this.labelGift.Text = "Подарок";
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(48, 113);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(58, 20);
            this.labelSum.TabIndex = 11;
            this.labelSum.Text = "Сумма";
            // 
            // TextBoxCount
            // 
            this.TextBoxCount.Location = new System.Drawing.Point(158, 72);
            this.TextBoxCount.Name = "textBoxCount";
            this.TextBoxCount.Size = new System.Drawing.Size(359, 26);
            this.TextBoxCount.TabIndex = 9;
            this.TextBoxCount.TextChanged += new System.EventHandler(this.TextBoxCount_TextChanged);
            // 
            // TextBoxSum
            // 
            this.TextBoxSum.Location = new System.Drawing.Point(158, 113);
            this.TextBoxSum.Name = "textBoxSum";
            this.TextBoxSum.ReadOnly = true;
            this.TextBoxSum.Size = new System.Drawing.Size(359, 26);
            this.TextBoxSum.TabIndex = 9;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(48, 72);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(100, 20);
            this.labelCount.TabIndex = 10;
            this.labelCount.Text = "Количество";
            // 
            // FormCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 224);
            this.Controls.Add(this.comboBoxGiftBox);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelGift);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.TextBoxSum);
            this.Controls.Add(this.TextBoxCount);
            this.Name = "FormCreateOrder";
            this.Text = "Заказ";
            this.Load += new System.EventHandler(this.FormCreateOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxGiftBox;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Label labelGift;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.TextBox TextBoxCount;
        private System.Windows.Forms.TextBox TextBoxSum;
        private System.Windows.Forms.Label labelCount;
    }
}