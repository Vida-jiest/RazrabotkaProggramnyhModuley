using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShapeManagerApp
{
    public partial class Form1 : Form
    {
        private List<IShape> shapes = new List<IShape>();
        private string selectedShapeType = "Circle"; // По умолчанию выбран круг

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectCircle_Click(object sender, EventArgs e)
        {
            selectedShapeType = "Circle";
            lblSelectedType.Text = "Выбран: Круг";
            btnSelectCircle.BackColor = System.Drawing.Color.LightBlue;
            btnSelectSquare.BackColor = System.Drawing.SystemColors.Control;
        }

        private void btnSelectSquare_Click(object sender, EventArgs e)
        {
            selectedShapeType = "Square";
            lblSelectedType.Text = "Выбран: Квадрат";
            btnSelectSquare.BackColor = System.Drawing.Color.LightBlue;
            btnSelectCircle.BackColor = System.Drawing.SystemColors.Control;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtParameter.Text))
                {
                    MessageBox.Show("Введите значение параметра", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!double.TryParse(txtParameter.Text, out double value) || value <= 0)
                {
                    MessageBox.Show("Введите положительное число", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                IShape shape;

                if (selectedShapeType == "Circle")
                {
                    shape = new Circle(value);
                }
                else
                {
                    shape = new Square(value);
                }

                shapes.Add(shape);
                listShapes.Items.Add(shape);
                txtParameter.Clear();
                txtParameter.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listShapes.SelectedIndex >= 0)
            {
                shapes.RemoveAt(listShapes.SelectedIndex);
                listShapes.Items.RemoveAt(listShapes.SelectedIndex);
            }
        }

        private void listShapes_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemove.Enabled = listShapes.SelectedIndex >= 0;
        }
    }
}