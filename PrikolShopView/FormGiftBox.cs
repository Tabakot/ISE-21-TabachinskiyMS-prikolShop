using PrikolShopBusinessLogic.BindingModels;
using PrikolShopBusinessLogic.Interfaces;
using PrikolShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace PrikolShopView
{
    public partial class FormGiftBox : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IGiftBoxLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> boxes;
        public FormGiftBox(IGiftBoxLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }
        private void FormGiftBox_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    GiftBoxViewModel view = logic.Read(new GiftBoxBindingModel
                    {
                        Id =
                   id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.GiftBoxName;
                        textBoxPrice.Text = view.Price.ToString();
                        boxes = view.Boxes;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                boxes = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (boxes != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in boxes)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormBox>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (boxes.ContainsKey(form.Id))
                {
                    boxes[form.Id] = (form.GiftName, form.Count);
                }
                else
                {
                    boxes.Add(form.Id, (form.GiftName, form.Count));
                }
                LoadData();
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormBox>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = boxes[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    boxes[form.Id] = (form.GiftName, form.Count);
                    LoadData();
                }
            }
        }
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        boxes.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (boxes == null || boxes.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new GiftBoxBindingModel
                {
                    Id = id,
                    GiftBoxName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    Boxes = boxes
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
