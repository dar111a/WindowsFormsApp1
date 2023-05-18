using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int operations; // Оголошуємо змінну на рівні класу
        private int BubbleSort(int[] array)
        {
            int n = array.Length;
            int operations = 0;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    operations++; // Збільшити лічильник операцій

                    if (array[j] > array[j + 1])
                    {
                        // Обмін значень між array[j] та array[j + 1]
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }

            return operations;
        }

        private int SelectionSort(int[] array)
        {
            int n = array.Length;
            int operations = 0;

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    operations++; // Збільшити лічильник операцій

                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                // Обмін значень між array[i] та array[minIndex]
                int temp = array[i];
                array[i] = array[minIndex];
                array[minIndex] = temp;
            }

            return operations;
        }

        private int InsertionSort(int[] array)
        {
            int n = array.Length;
            int operations = 0;

            for (int i = 1; i < n; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                    operations++; // Збільшуємо кількість операцій при здвигу елементів
                }

                array[j + 1] = key;
            }

            return operations;
        }

        private int QuickSort(int[] array, int low, int high, int operations)
        {
            if (low < high)
            {
                int pivotIndex = Partition(array, low, high, ref operations);
                operations = QuickSort(array, low, pivotIndex - 1, operations);
                operations = QuickSort(array, pivotIndex + 1, high, operations);
            }

            return operations;
        }

        private int Partition(int[] array, int low, int high, ref int operations)
        {
            int pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                operations++; // Збільшити лічильник операцій

                if (array[j] < pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }

            Swap(array, i + 1, high);
            return i + 1;
        }

        private void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
        private int[] GetIntArrayFromTextBox()
        {
            // Отримати введений рядок з TextBox
            string input = textBoxInput.Text;

            // Розділити рядок на окремі числа
            string[] numbers = input.Split(' ');

            // Конвертувати числа в масив цілих чисел
            int[] array = Array.ConvertAll(numbers, int.Parse);

            return array;
        }
        private int[] GetSortedArrayFromTextBox()
        {
            // Отримати введений рядок з TextBox
            string input = textBoxOutput.Text;

            // Розділити рядок на окремі числа
            string[] numbers = input.Split(' ');

            // Конвертувати числа в масив цілих чисел
            int[] array = Array.ConvertAll(numbers, int.Parse);

            return array;
        }

        private void DisplaySortedArray(int[] array)
        {
            // Перетворити відсортований масив на рядок
            string sortedArrayString = string.Join(" ", array);

            // Присвоїти відсортований рядок властивості Text TextBox
            textBoxOutput.Text = sortedArrayString;
        }
        private void SortBtn_Click(object sender, EventArgs e)
        {
            // Очистити текстове поле перед початком роботи
            textBoxOutput.Clear();
            textBoxOperations.Clear();

            string selectedSortMethod = comboBox1.SelectedItem.ToString();

            // Оголосити змінну для кількості операцій
            int operations = 0;

            switch (selectedSortMethod)
            {
                case "Bubble sorting":
                    // Отримати масив з TextBox
                    int[] array = GetIntArrayFromTextBox();

                    // Викликати метод бульбашкового сортування та отримати кількість операцій
                    operations = BubbleSort(array);

                    // Вивести відсортований масив
                    DisplaySortedArray(array);

                    // Вивести кількість операцій
                    textBoxOperations.Text = $" {operations}";

                    // Очистити змінну після використання, якщо це потрібно
                    operations = 0;
                    break;
                case "Selection sorting":
                    // Отримати масив з TextBox
                    int[] array1 = GetIntArrayFromTextBox();

                    // Викликати метод сортування вибором та отримати кількість операцій
                    operations = SelectionSort(array1);

                    // Вивести відсортований масив
                    DisplaySortedArray(array1);

                    // Вивести кількість операцій
                    textBoxOperations.Text = $" {operations}";

                    // Очистити змінну після використання, якщо це потрібно
                    operations = 0;
                    break;
                case "Insertion sorting":
                    // Отримати масив з TextBox
                    int[] array2 = GetIntArrayFromTextBox();

                    // Викликати метод сортування вибором та отримати кількість операцій
                    operations = InsertionSort(array2);

                    // Вивести відсортований масив
                    DisplaySortedArray(array2);

                    // Вивести кількість операцій
                    textBoxOperations.Text = $" {operations}";

                    // Очистити змінну після використання, якщо це потрібно
                    operations = 0;
                    break;
                case "Quick sorting":
                    // Отримати масив з TextBox
                    int[] array3 = GetIntArrayFromTextBox();

                    // Викликати метод сортування вибором та отримати кількість операцій
                    operations = QuickSort(array3, 0, array3.Length - 1, operations);

                    // Вивести відсортований масив
                    DisplaySortedArray(array3);
                    // Вивести кількість операцій
                    textBoxOperations.Text = $" {operations}";

                    // Очистити змінну після використання, якщо це потрібно
                    operations = 0;
                    break;

            }

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
                // Отримати початковий масив з TextBox
                int[] inputArray = GetIntArrayFromTextBox();

                // Отримати відсортований масив з TextBox
                int[] sortedArray = GetSortedArrayFromTextBox();

                // Отримати кількість операцій з TextBox
                string operations = textBoxOperations.Text;

                // Створити вікно вибору місця збереження файлу
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files|*.txt";
                saveFileDialog.Title = "Save Results";

                // Відобразити вікно вибору місця збереження
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Отримати шлях до обраного файлу
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        // Відкрити файл для запису
                        using (StreamWriter writer = new StreamWriter(filePath))
                        {
                            // Записати початковий масив
                            writer.WriteLine("Початковий масив - " + string.Join(" ", inputArray));

                            // Записати відсортований масив
                            writer.WriteLine("Відсортований масив - " + string.Join(" ", sortedArray));

                            // Записати кількість операцій
                            writer.WriteLine(operations);
                        }

                        MessageBox.Show("Результати збережено у файл " + filePath, "Збережено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка при збереженні результатів: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            // Очистити текстове поле перед початком роботи
            textBoxInput.Clear();
            textBoxOutput.Clear();
            textBoxOperations.Clear();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files|*.txt";
            openFileDialog.Title = "Select File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string[] lines = File.ReadAllLines(filePath);

                    string inputArrayLine = "";

                    // Знайти рядок з "Початковий масив"
                    foreach (string line in lines)
                    {
                        if (line.Contains("Початковий масив"))
                        {
                            inputArrayLine = line;
                            break;
                        }
                    }

                    // Витягнути масив з рядка
                    string[] numbers = inputArrayLine.Replace("Початковий масив - ", "").Split(' ');
                    int[] inputArray = Array.ConvertAll(numbers, int.Parse);

                    textBoxInput.Text = string.Join(" ", inputArray);

                    MessageBox.Show("Масив завантажено з файлу " + filePath, "Завантажено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка при завантаженні масиву: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
    }

