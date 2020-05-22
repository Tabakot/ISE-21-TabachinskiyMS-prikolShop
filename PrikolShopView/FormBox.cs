using PrikolShopBusinessLogic.Interfaces;
using PrikolShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Unity;


namespace PrikolShopView
{
    public partial class FormBox : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id
        {
            get { return Convert.ToInt32(comboBoxGift.SelectedValue); }
            set { comboBoxGift.SelectedValue = value; }
        }
        public string GiftName { get { return comboBoxGift.Text; } }
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }
        public FormBox(IGiftLogic logic)
        {
            InitializeComponent();
            List<GiftViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxGift.DisplayMember = "GiftName";
                comboBoxGift.ValueMember = "Id";
                comboBoxGift.DataSource = list;
                comboBoxGift.SelectedItem = null;
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxGift.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
