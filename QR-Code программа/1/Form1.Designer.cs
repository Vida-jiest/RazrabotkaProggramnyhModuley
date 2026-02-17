namespace ShapeManagerApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtParameter;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox listShapes;
        private System.Windows.Forms.Button btnSelectCircle;
        private System.Windows.Forms.Button btnSelectSquare;
        private System.Windows.Forms.Label lblSelectedType;

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
            this.txtParameter = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.listShapes = new System.Windows.Forms.ListBox();
            this.btnSelectCircle = new System.Windows.Forms.Button();
            this.btnSelectSquare = new System.Windows.Forms.Button();
            this.lblSelectedType = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // txtParameter
            this.txtParameter.Location = new System.Drawing.Point(20, 20);
            this.txtParameter.Name = "txtParameter";
            this.txtParameter.Size = new System.Drawing.Size(200, 23);
            this.txtParameter.TabIndex = 0;

            // btnSelectCircle
            this.btnSelectCircle.Location = new System.Drawing.Point(20, 60);
            this.btnSelectCircle.Name = "btnSelectCircle";
            this.btnSelectCircle.Size = new System.Drawing.Size(90, 30);
            this.btnSelectCircle.TabIndex = 1;
            this.btnSelectCircle.Text = "Круг";
            this.btnSelectCircle.UseVisualStyleBackColor = true;
            this.btnSelectCircle.Click += new System.EventHandler(this.btnSelectCircle_Click);

            // btnSelectSquare
            this.btnSelectSquare.Location = new System.Drawing.Point(130, 60);
            this.btnSelectSquare.Name = "btnSelectSquare";
            this.btnSelectSquare.Size = new System.Drawing.Size(90, 30);
            this.btnSelectSquare.TabIndex = 2;
            this.btnSelectSquare.Text = "Квадрат";
            this.btnSelectSquare.UseVisualStyleBackColor = true;
            this.btnSelectSquare.Click += new System.EventHandler(this.btnSelectSquare_Click);

            // lblSelectedType
            this.lblSelectedType.AutoSize = true;
            this.lblSelectedType.Location = new System.Drawing.Point(20, 100);
            this.lblSelectedType.Name = "lblSelectedType";
            this.lblSelectedType.Size = new System.Drawing.Size(92, 15);
            this.lblSelectedType.TabIndex = 3;
            this.lblSelectedType.Text = "Выбран: Круг";

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(20, 130);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnRemove
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(130, 130);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(90, 30);
            this.btnRemove.TabIndex = 5;
            this.btnRemove.Text = "Удалить";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);

            // listShapes
            this.listShapes.FormattingEnabled = true;
            this.listShapes.ItemHeight = 15;
            this.listShapes.Location = new System.Drawing.Point(20, 180);
            this.listShapes.Name = "listShapes";
            this.listShapes.Size = new System.Drawing.Size(200, 154);
            this.listShapes.TabIndex = 6;
            this.listShapes.SelectedIndexChanged += new System.EventHandler(this.listShapes_SelectedIndexChanged);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 350);
            this.Controls.Add(this.listShapes);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblSelectedType);
            this.Controls.Add(this.btnSelectSquare);
            this.Controls.Add(this.btnSelectCircle);
            this.Controls.Add(this.txtParameter);
            this.Name = "Form1";
            this.Text = "Управление формами";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}