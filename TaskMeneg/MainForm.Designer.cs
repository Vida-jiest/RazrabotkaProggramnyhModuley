namespace TaskManagerApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.listTasks = new System.Windows.Forms.ListBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // txtTitle
            this.txtTitle.Location = new System.Drawing.Point(15, 35);
            this.txtTitle.Size = new System.Drawing.Size(370, 23);
            this.txtTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            // В .NET 4.8 нет PlaceholderText, используем Text с подсказкой
            this.txtTitle.Text = "";
            this.txtTitle.Enter += new System.EventHandler(this.TxtTitle_Enter);
            this.txtTitle.Leave += new System.EventHandler(this.TxtTitle_Leave);

            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(15, 85);
            this.txtDescription.Size = new System.Drawing.Size(370, 23);
            this.txtDescription.Text = "";
            this.txtDescription.Enter += new System.EventHandler(this.TxtDescription_Enter);
            this.txtDescription.Leave += new System.EventHandler(this.TxtDescription_Leave);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Text = "Название задачи:";
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 65);
            this.lblDescription.Text = "Описание:";

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(15, 120);
            this.btnAdd.Size = new System.Drawing.Size(85, 30);
            this.btnAdd.Text = "Добавить";
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);

            // btnComplete
            this.btnComplete.Location = new System.Drawing.Point(106, 120);
            this.btnComplete.Size = new System.Drawing.Size(85, 30);
            this.btnComplete.Text = "Выполнено";
            this.btnComplete.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnComplete.ForeColor = System.Drawing.Color.White;
            this.btnComplete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComplete.UseVisualStyleBackColor = false;
            this.btnComplete.Click += new System.EventHandler(this.BtnComplete_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(197, 120);
            this.btnDelete.Size = new System.Drawing.Size(85, 30);
            this.btnDelete.Text = "Удалить";
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(288, 120);
            this.btnRefresh.Size = new System.Drawing.Size(97, 30);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(158, 158, 158);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);

            // listTasks
            this.listTasks.Location = new System.Drawing.Point(15, 165);
            this.listTasks.Size = new System.Drawing.Size(370, 250);
            this.listTasks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listTasks.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listTasks.SelectedIndexChanged += new System.EventHandler(this.ListTasks_SelectedIndexChanged);
            this.listTasks.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListTasks_DrawItem);

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(15, 430);
            this.lblStatus.Text = "Выберите задачу для просмотра деталей";
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(100, 100, 100);
            this.lblStatus.MaximumSize = new System.Drawing.Size(380, 0);

            // statusStrip
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusText});
            this.statusStrip.Location = new System.Drawing.Point(0, 495);
            this.statusStrip.Size = new System.Drawing.Size(400, 22);

            // lblStatusText
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(50, 17);
            this.lblStatusText.Text = "Готово";

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 517);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.listTasks);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task Manager - Менеджер задач";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListBox listTasks;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusText;
    }
}