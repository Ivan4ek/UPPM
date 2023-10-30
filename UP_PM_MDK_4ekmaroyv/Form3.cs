using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UP_PM_MDK_4ekmaroyv
{
    public partial class Form3 : Form
    {
        private DatabaseManager DataBaseManager = new DatabaseManager();
        private string currentTableName; // Поле для хранения имени текущей таблицы
        private string connectionString = "Data Source=FullDB.db;Version=3;";
        private string Creator = "FirmCreator";

        public Form3()
        {
            InitializeComponent();

            if (!DataBaseManager.DatabaseExists())
            {
                DataBaseManager.CreateDatabase();
            }

            if (!DataBaseManager.TableExists(Creator))
            {
                DataBaseManager.CreateTables();
            }

            if (!DataBaseManager.DataExists())
            {
                DataBaseManager.InsertData();
            }

            DataBaseManager.LoadDataIntoDataGridView(dgv1, Creator);
            tbSearchMenu.Text = Creator;
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void CreateAndShowContextMenu(TextBox textBox, Button button, string tableName, string columnName)
        {
            // Создайте новое контекстное меню
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = $"SELECT {columnName} FROM {tableName}";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string cellValue = reader[columnName].ToString();
                            ToolStripMenuItem item = new ToolStripMenuItem(cellValue);

                            // Обработчик события для выбора значения
                            item.Click += (sender, e) =>
                            {
                                // Записать выбранное значение в TextBox
                                textBox.Text = cellValue;
                            };

                            contextMenuStrip.Items.Add(item);
                        }
                    }
                }
            }

            // Отобразите контекстное меню
            contextMenuStrip.Show(button, new Point(0, button.Height));
        }

        private void btnSearchMenu_Click(object sender, EventArgs e)
        {
            CreateAndShowContextMenu(tbSearchMenu, btnSearchMenu, "sqlite_sequence", "name");
        }

        // Загрузка в DataGridView
        private void LoadDataIntoDataGridView(DataGridView dataGridView, string tableName)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = $"SELECT * FROM {tableName}";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Очистим существующие столбцы в DataGridView
                    dataGridView.Columns.Clear();

                    // Создадим столбец DataGridViewButtonColumn
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.HeaderText = "Удалить";
                    buttonColumn.Text = "Удалить";
                    buttonColumn.UseColumnTextForButtonValue = true;

                    // Добавим столбцы в DataGridView
                    dataGridView.Columns.Add(buttonColumn);

                    // Устанавливаем источник данных для DataGridView
                    dataGridView.DataSource = dataTable;

                    // Автоматически подгоним размер столбцов
                    dataGridView.AutoResizeColumns();

                    currentTableName = tableName; // Сохраняем имя текущей таблицы
                }
            }

                        // Очистите dgv2 от существующих столбцов
            dgv2.Columns.Clear();

            // Добавьте все столбцы из dgv1, кроме первого столбца (с индексом 0), в dgv2
            foreach (DataGridViewColumn col in dgv1.Columns)
            {
                if (col.Index != 0 && col.Index != 1) // Исключаем первый столбец
                {
                    dgv2.Columns.Add((DataGridViewColumn)col.Clone());
                }
            }

            // Добавьте пустую строку в dgv2
            dgv2.Rows.Add();
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            string tableName = tbSearchMenu.Text;

            // Проверяем, существует ли указанная таблица
            if (DataBaseManager.TableExistsMenu(tableName))
            {
                // Если таблица существует, загружаем ее данные в dgv1
                LoadDataIntoDataGridView(dgv1, tableName);

                // Растянуть столбцы равномерно
                foreach (DataGridViewColumn column in dgv1.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                // Растянуть столбцы равномерно
                foreach (DataGridViewColumn column in dgv2.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            else
            {
                // Если таблица не существует, выводим сообщение об ошибке
                MessageBox.Show("Указанная таблица не существует.");
            }
        }


        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Проверяем, что событие произошло в столбце кнопок (колонке с индексом 0)
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                // Получаем значение столбца "ID" из ячейки
                int recordID = Convert.ToInt32(dgv1.Rows[e.RowIndex].Cells["ID"].Value);

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open(); // Открываем соединение

                    // Удалите строку из базы данных, используя currentTableName
                    using (SQLiteCommand deleteCommand = new SQLiteCommand($"DELETE FROM {currentTableName} WHERE ID = @id", connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@id", recordID);
                        deleteCommand.ExecuteNonQuery();
                    }

                    connection.Close(); // Закрываем соединение
                }

                // Удалите строку из DataGridView
                dgv1.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgv2.Rows.Count > 0)
            {
                bool isRowValid = true;

                foreach (DataGridViewCell cell in dgv2.Rows[0].Cells)
                {
                    if (cell.Value == null || string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        isRowValid = false;
                        break;
                    }
                }

                if (isRowValid)
                {
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();
                        using (SQLiteCommand insertCommand = new SQLiteCommand(connection))
                        {
                            StringBuilder columns = new StringBuilder();
                            StringBuilder values = new StringBuilder();

                            foreach (DataGridViewColumn column in dgv2.Columns)
                            {
                                if (columns.Length > 0)
                                {
                                    columns.Append(", ");
                                    values.Append(", ");
                                }
                                columns.Append(column.Name);
                                values.Append($"@{column.Name}");
                                insertCommand.Parameters.AddWithValue($"@{column.Name}", dgv2.Rows[0].Cells[column.Index].Value);
                            }

                            insertCommand.CommandText = $"INSERT INTO {currentTableName} ({columns}) VALUES ({values})";
                            insertCommand.ExecuteNonQuery();
                        }
                        connection.Close();

                        LoadDataIntoDataGridView(dgv1, currentTableName);

                        dgv2.Rows.RemoveAt(0);
                    }
                }
                else
                {
                    MessageBox.Show("Не все поля в строке таблицы заполнены. Заполните все поля перед добавлением.");
                }
            }
            else
            {
                MessageBox.Show("Таблица пуста. Нечего добавлять.");
            }
        }
    }
}
