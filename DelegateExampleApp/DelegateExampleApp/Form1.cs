using System;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace DelegateExampleApp
{
    public partial class Form1 : Form
    {
        // Объявление делегата
        public delegate void ChangeTextDelegate(string newText);

        // Объявляем переменную делегата на уровне класса
        ChangeTextDelegate changeTextDel;
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        // Метод для изменения текста на приветствие
        private void ChangeTextToHello(string newText)
        {
            label1.Text = "Текст изменён на: " + newText;
        }

        // Метод для изменения текста на "Добро пожаловать!"
        private void ChangeTextToWelcome(string newText)
        {
            label1.Text = "Добро пожаловать!";
        }

        // Метод для изменения текста на "Как дела?"
        private void ChangeTextToHowAreYou(string newText)
        {
            label1.Text = "Как дела?";
        }

        // Обработчик события нажатия кнопки
        private void button1_Click(object sender, EventArgs e)
        {
            // Случайный выбор метода (от 1 до 3)
            int methodIndex = random.Next(1, 4);

            // Привязка делегата к выбранному методу
            switch (methodIndex)
            {
                case 1:
                    changeTextDel = ChangeTextToHello;
                    break;
                case 2:
                    changeTextDel = ChangeTextToWelcome;
                    break;
                case 3:
                    changeTextDel = ChangeTextToHowAreYou;
                    break;
                default:
                    changeTextDel = ChangeTextToHello;
                    break;
            }

            // Вызов метода через делегат
            changeTextDel("Новый текст");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}