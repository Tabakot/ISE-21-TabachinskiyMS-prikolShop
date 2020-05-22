using PrikolShopBusinessLogic.BindingModels;
using PrikolShopBusinessLogic.Interfaces;
using System;
using System.Windows.Forms;
using Unity;
namespace PrikolShopView
{
    public partial class FormGift : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IGiftLogic logic;
        private int? id;
        public FormGift(IGiftLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormGift_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = logic.Read(new GiftBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.GiftName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new GiftBindingModel
                {
                    Id = id,
                    GiftName = textBoxName.Text
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
