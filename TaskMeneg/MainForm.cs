using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskManagerApp
{
    public partial class MainForm : Form
    {
        private TaskManager _taskManager;

        public MainForm()
        {
            InitializeComponent();
            _taskManager = new TaskManager();
            LoadTasksToList();

            // Устанавливаем подсказки для полей ввода
            txtTitle.Text = "Введите название задачи...";
            txtTitle.ForeColor = Color.Gray;
            txtDescription.Text = "Введите описание (необязательно)...";
            txtDescription.ForeColor = Color.Gray;
        }

        // Обработчики для плейсхолдера Title
        private void TxtTitle_Enter(object sender, EventArgs e)
        {
            if (txtTitle.Text == "Введите название задачи...")
            {
                txtTitle.Text = "";
                txtTitle.ForeColor = Color.Black;
            }
        }

        private void TxtTitle_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                txtTitle.Text = "Введите название задачи...";
                txtTitle.ForeColor = Color.Gray;
            }
        }

        // Обработчики для плейсхолдера Description
        private void TxtDescription_Enter(object sender, EventArgs e)
        {
            if (txtDescription.Text == "Введите описание (необязательно)...")
            {
                txtDescription.Text = "";
                txtDescription.ForeColor = Color.Black;
            }
        }

        private void TxtDescription_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                txtDescription.Text = "Введите описание (необязательно)...";
                txtDescription.ForeColor = Color.Gray;
            }
        }

        private void LoadTasksToList()
        {
            listTasks.Items.Clear();
            var tasks = _taskManager.GetAllTasks();
            foreach (var task in tasks)
            {
                listTasks.Items.Add(task);
            }
            int notCompleted = 0;
            foreach (var task in tasks)
            {
                if (!task.IsCompleted) notCompleted++;
            }
            lblStatusText.Text = $"Всего задач: {tasks.Count} | Не выполнено: {notCompleted}";
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string title = txtTitle.Text;
                string description = txtDescription.Text;

                // Проверяем, не введены ли подсказки
                if (title == "Введите название задачи..." || string.IsNullOrWhiteSpace(title))
                {
                    MessageBox.Show("Введите название задачи!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (description == "Введите описание (необязательно)...")
                {
                    description = "";
                }

                _taskManager.AddTask(title, description);

                // Очищаем поля
                txtTitle.Text = "Введите название задачи...";
                txtTitle.ForeColor = Color.Gray;
                txtDescription.Text = "Введите описание (необязательно)...";
                txtDescription.ForeColor = Color.Gray;

                LoadTasksToList();
                lblStatus.Text = "Задача успешно добавлена!";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            if (listTasks.SelectedItem == null)
            {
                MessageBox.Show("Выберите задачу!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Task selected = (Task)listTasks.SelectedItem;
            _taskManager.ToggleComplete(selected.Id);
            LoadTasksToList();
            lblStatus.Text = $"Статус задачи '{selected.Title}' изменён!";
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (listTasks.SelectedItem == null)
            {
                MessageBox.Show("Выберите задачу!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Task selected = (Task)listTasks.SelectedItem;
            DialogResult result = MessageBox.Show($"Удалить задачу '{selected.Title}'?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _taskManager.RemoveTask(selected.Id);
                LoadTasksToList();
                lblStatus.Text = $"Задача '{selected.Title}' удалена!";
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadTasksToList();
            lblStatus.Text = "Список обновлён!";
        }

        private void ListTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listTasks.SelectedItem != null)
            {
                Task selected = (Task)listTasks.SelectedItem;
                Task fullTask = _taskManager.GetTaskById(selected.Id);
                if (fullTask != null)
                {
                    lblStatus.Text = fullTask.GetFullInfo().Replace("\n", " | ");
                }
            }
            else
            {
                lblStatus.Text = "Выберите задачу для просмотра деталей";
            }
        }

        private void ListTasks_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ListBox list = (ListBox)sender;
            Task task = (Task)list.Items[e.Index];

            e.DrawBackground();

            Color textColor;
            FontStyle fontStyle;

            if (task.IsCompleted)
            {
                textColor = Color.Gray;
                fontStyle = FontStyle.Strikeout;
            }
            else
            {
                textColor = Color.Black;
                fontStyle = FontStyle.Regular;
            }

            using (Brush brush = new SolidBrush(textColor))
            {
                Font font = new Font("Segoe UI", 10, fontStyle);
                e.Graphics.DrawString(task.ToString(), font, brush, e.Bounds.Left + 5, e.Bounds.Top + 5);
            }

            e.DrawFocusRectangle();
        }
    }
}