using PrikolShopBusinessLogic.BindingModels;
using PrikolShopBusinessLogic.BusinessLogics;
using PrikolShopBusinessLogic.Interfaces;
using PrikolShopBusinessLogic.ViewModels;
using System;
using System.Windows.Forms;
using Unity;

namespace PrikolShopView
{
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IGiftBoxLogic logicG;
        private readonly MainLogic logicM;
        public FormCreateOrder(IGiftBoxLogic logicG, MainLogic logicM)
        {
            InitializeComponent();
            this.logicG = logicG;
            this.logicM = logicM;
        }
        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                var list = logicG.Read(null);
                comboBoxGiftBox.DataSource = list;
                comboBoxGiftBox.DisplayMember = "GiftBoxName";
                comboBoxGiftBox.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void CalcSum()
        {
            if (comboBoxGiftBox.SelectedValue != null &&
           !string.IsNullOrEmpty(TextBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxGiftBox.SelectedValue);
                    GiftBoxViewModel product = logicG.Read(new GiftBoxBindingModel
                    {
                        Id =
                    id
                    })?[0];
                    int count = Convert.ToInt32(TextBoxCount.Text);
                    TextBoxSum.Text = (count * product?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void ComboBoxGiftBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxGiftBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logicM.CreateOrder(new CreateOrderBindingModel
                {
                    GiftBoxId = Convert.ToInt32(comboBoxGiftBox.SelectedValue),
                    Count = Convert.ToInt32(TextBoxCount.Text),
                    Sum = Convert.ToDecimal(TextBoxSum.Text)
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
