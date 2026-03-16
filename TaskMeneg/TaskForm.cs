using System;
using System.Drawing;
using System.Windows.Forms;

public class TaskForm : Form
{
    private TaskManager taskManager = new TaskManager();
    private ListBox taskListBox;
    private TextBox titleTextBox;
    private TextBox descriptionTextBox;
    private Button addButton;
    private Button removeButton;
    private Label titleLabel;
    private Label descriptionLabel;

    public TaskForm()
    {
        InitializeComponents();
        SetupLayout();
    }

    private void InitializeComponents()
    {
        // Создание элементов управления
        taskListBox = new ListBox();
        titleTextBox = new TextBox();
        descriptionTextBox = new TextBox();
        addButton = new Button();
        removeButton = new Button();
        titleLabel = new Label();
        descriptionLabel = new Label();

        // Настройка Label для заголовка
        titleLabel.Text = "Заголовок:";
        titleLabel.Location = new Point(20, 20);
        titleLabel.Size = new Size(80, 25);

        // Настройка TextBox для заголовка
        titleTextBox.Location = new Point(110, 20);
        titleTextBox.Size = new Size(200, 25);

        // Настройка Label для описания
        descriptionLabel.Text = "Описание:";
        descriptionLabel.Location = new Point(20, 55);
        descriptionLabel.Size = new Size(80, 25);

        // Настройка TextBox для описания
        descriptionTextBox.Location = new Point(110, 55);
        descriptionTextBox.Size = new Size(200, 25);

        // Настройка кнопки добавления
        addButton.Text = "Добавить задачу";
        addButton.Location = new Point(20, 90);
        addButton.Size = new Size(140, 30);
        addButton.Click += AddButton_Click;

        // Настройка кнопки удаления
        removeButton.Text = "Удалить задачу";
        removeButton.Location = new Point(170, 90);
        removeButton.Size = new Size(140, 30);
        removeButton.Click += RemoveButton_Click;

        // Настройка ListBox для отображения задач
        taskListBox.Location = new Point(20, 130);
        taskListBox.Size = new Size(450, 200);
        taskListBox.DisplayMember = "Title";

        // Настройка формы
        this.Text = "Менеджер задач";
        this.Size = new Size(500, 400);
        this.StartPosition = FormStartPosition.CenterScreen;
    }

    private void SetupLayout()
    {
        // Добавление элементов на форму
        this.Controls.Add(titleLabel);
        this.Controls.Add(titleTextBox);
        this.Controls.Add(descriptionLabel);
        this.Controls.Add(descriptionTextBox);
        this.Controls.Add(addButton);
        this.Controls.Add(removeButton);
        this.Controls.Add(taskListBox);
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(titleTextBox.Text))
        {
            MessageBox.Show("Введите заголовок задачи!", "Предупреждение",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var task = new Task
        {
            Title = titleTextBox.Text,
            Description = descriptionTextBox.Text,
            IsCompleted = false
        };

        taskManager.AddTask(task);
        UpdateTaskList();

        // Очистка полей ввода
        titleTextBox.Clear();
        descriptionTextBox.Clear();
        titleTextBox.Focus();
    }

    private void RemoveButton_Click(object sender, EventArgs e)
    {
        if (taskListBox.SelectedItem is Task selectedTask)
        {
            var result = MessageBox.Show($"Удалить задачу '{selectedTask.Title}'?",
                "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                taskManager.RemoveTask(selectedTask.Id);
                UpdateTaskList();
            }
        }
        else
        {
            MessageBox.Show("Выберите задачу для удаления!", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void UpdateTaskList()
    {
        taskListBox.Items.Clear();
        foreach (var task in taskManager.GetTasks())
        {
            taskListBox.Items.Add(task);
        }
    }
}