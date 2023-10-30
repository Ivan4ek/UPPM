using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Drawing;
using System.Collections.Generic;

namespace UP_PM_MDK_4ekmaroyv
{
    public partial class Form1 : Form
    {
        private DatabaseManager DataBaseManager = new DatabaseManager();

        private string connectionString = "Data Source=FullDB.db;Version=3;";
        private string Creator = "FirmCreator";
        private string Seller = "FirmSeller";
        private string Volume = "Volume";
        private string Specifications = "Specifications";

        public Form1()
        {
            InitializeComponent();

        }
        #region Load/Closing
        private void Form1_Load(object sender, EventArgs e)
        {
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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region ContexMenuSplit
        private void CreateAndShowContextMenu(TextBox textBox, Button button, string tableName, string columnName)
        {
            // Создайте новое контекстное меню
            ContextMenuStrip contextMenuStrip = new ContextMenuStrip();

            // Создайте пустой пункт меню
            ToolStripMenuItem emptyItem = new ToolStripMenuItem("Пусто");

            // Добавьте обработчик события для пустой кнопки
            emptyItem.Click += (sender, e) =>
            {
                // Установите текст в TextBox как пустую строку
                textBox.Text = string.Empty;
            };

            // Добавьте пустую кнопку в начало контекстного меню
            contextMenuStrip.Items.Add(emptyItem);

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(connection))
                {
                    command.CommandText = $"SELECT {columnName} FROM {tableName}";
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        // Используйте HashSet для хранения уникальных значений
                        HashSet<string> uniqueValues = new HashSet<string>();

                        while (reader.Read())
                        {
                            string cellValue = reader[columnName].ToString();

                            // Проверьте, что значение не было добавлено ранее
                            if (!uniqueValues.Contains(cellValue))
                            {
                                ToolStripMenuItem item = new ToolStripMenuItem(cellValue);

                                // Обработчик события для выбора значения
                                item.Click += (sender, e) =>
                                {
                                    // Записать выбранное значение в TextBox
                                    textBox.Text = cellValue;
                                };

                                contextMenuStrip.Items.Add(item);

                                // Добавьте значение в HashSet
                                uniqueValues.Add(cellValue);
                            }
                        }
                    }
                }
            }

            // Отобразите контекстное меню
            contextMenuStrip.Show(button, new Point(0, button.Height));
        }


        private void btnRealigatorName_Click(object sender, EventArgs e)
        {
            CreateAndShowContextMenu(tbRealigatorName, btnRealigatorName, "FirmSeller", "Name");
        }

        private void btnRealigatorCity_Click(object sender, EventArgs e)
        {
            CreateAndShowContextMenu(tbRealigatorCity, btnRealigatorCity, "FirmSeller", "City");
        }

        private void btnRealigatorPhoneNumber_Click(object sender, EventArgs e)
        {
            CreateAndShowContextMenu(tbRealigatorPhoneNumber, btnRealigatorPhoneNumber, "FirmSeller", "PhoneNumber");
        }

        private void btnIzgotovitelName_Click(object sender, EventArgs e)
        {
            CreateAndShowContextMenu(tbIzgotovitelName, btnIzgotovitelName, "FirmCreator", "Name");
        }

        private void btnIzgotovitelCity_Click(object sender, EventArgs e)
        {
            CreateAndShowContextMenu(tbIzgotovitelCity, btnIzgotovitelCity, "FirmCreator", "City");
        }

        private void btnSpecificationsRAM_Click(object sender, EventArgs e)
        {
            CreateAndShowContextMenu(tbSpecificationsRAM, btnSpecificationsRAM, "Volume", "RAM");
        }

        private void btnSpecificationsHDD_Click(object sender, EventArgs e)
        {
            CreateAndShowContextMenu(tbSpecificationsHDD, btnSpecificationsHDD, "Volume", "HHD");
        }

        private void btnSpecificationsDate_Click(object sender, EventArgs e)
        {
            CreateAndShowContextMenu(tbSpecificationsDate, btnSpecificationsDate, "Volume", "Date");
        }

        private void btnSpecificationsTypeCPU_Click(object sender, EventArgs e)
        {
            CreateAndShowContextMenu(tbSpecificationsTypeCPU, btnSpecificationsTypeCPU, "Volume", "TypeCPU");
        }

        private void btnSpecificationsVolumeGhz_Click(object sender, EventArgs e)
        {
            CreateAndShowContextMenu(tbSpecificationsVolumeGhz, btnSpecificationsVolumeGhz, "Volume", "ClockFrequency");
        }

        private void btnBatchVolume_Click(object sender, EventArgs e)
        {
            CreateAndShowContextMenu(tbBatchVolume, btnBatchVolume, "Specifications", "BatchVolume");
        }

        private void btnBatchPrice_Click(object sender, EventArgs e)
        {
            CreateAndShowContextMenu(tbBatchPrice, btnBatchPrice, "Specifications", "BatchPrice");
        }

        private void btnSearchMenu_Click(object sender, EventArgs e)
        {
            CreateAndShowContextMenu(tbSearchMenu, btnSearchMenu, "sqlite_sequence", "name");
        }
        #endregion

        #region Work DataBase
        private void btnLoad_Click(object sender, EventArgs e)
        {
            string tableName = tbSearchMenu.Text;

            // Проверяем, существует ли указанная таблица
            if (DataBaseManager.TableExistsMenu(tableName))
            {
                // Если таблица существует, загружаем ее данные в dvg1
                DataBaseManager.LoadDataIntoDataGridView(dgv1, tableName);
            }
            else
            {
                // Если таблица не существует, выводим сообщение об ошибке
                MessageBox.Show("Указанная таблица не существует.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbSearchMenu.Text == Creator)
            {
                PerformSearch(Creator);
            }
            else if (tbSearchMenu.Text == Seller)
            {
                PerformSearch(Seller);
            }
            else if (tbSearchMenu.Text == Volume)
            {
                PerformSearch(Volume);
            }
            else if (tbSearchMenu.Text == Specifications)
            {
                PerformSearch(Specifications);
            }
            else
            {
                dgv1.DataSource = null;
                MessageBox.Show("Такой базы данных нет!");
            }
        }

        private void PerformSearch(string tableName)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Подготовим SQL-запрос на основе введенных данных в текстбоксы
                string query = "SELECT * FROM " + tableName + " WHERE ";
                List<string> conditions = new List<string>();

                if (tableName == Creator)
                {
                    if (!string.IsNullOrEmpty(tbIzgotovitelName.Text))
                        conditions.Add("Name = @Name");
                    if (!string.IsNullOrEmpty(tbIzgotovitelCity.Text))
                        conditions.Add("City = @City");
                }
                else if (tableName == Seller)
                {
                    if (!string.IsNullOrEmpty(tbRealigatorName.Text))
                        conditions.Add("Name = @Name");
                    if (!string.IsNullOrEmpty(tbRealigatorCity.Text))
                        conditions.Add("City = @City");
                    if (!string.IsNullOrEmpty(tbRealigatorPhoneNumber.Text))
                        conditions.Add("PhoneNumber = @PhoneNumber");
                }
                else if (tableName == Volume)
                {
                    if (!string.IsNullOrEmpty(tbSpecificationsTypeCPU.Text))
                        conditions.Add("TypeCPU = @TypeCPU");
                    if (!string.IsNullOrEmpty(tbSpecificationsVolumeGhz.Text))
                        conditions.Add("ClockFrequency = @ClockFrequency");
                    if (!string.IsNullOrEmpty(tbSpecificationsRAM.Text))
                        conditions.Add("RAM = @RAM");
                    if (!string.IsNullOrEmpty(tbSpecificationsHDD.Text))
                        conditions.Add("HHD = @HHD");
                    if (!string.IsNullOrEmpty(tbSpecificationsDate.Text))
                        conditions.Add("Date = @Date");
                }
                else if (tableName == Specifications)
                {
                    if (!string.IsNullOrEmpty(tbBatchVolume.Text))
                        conditions.Add("BatchVolume = @BatchVolume");
                    if (!string.IsNullOrEmpty(tbBatchPrice.Text))
                        conditions.Add("BatchPrice = @BatchPrice");
                }

                query += string.Join(" AND ", conditions);

                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    // Добавим параметры к запросу на основе введенных данных в текстбоксы
                    if (tableName == Creator)
                    {
                        if (!string.IsNullOrEmpty(tbIzgotovitelName.Text))
                            command.Parameters.AddWithValue("@Name", tbIzgotovitelName.Text);
                        if (!string.IsNullOrEmpty(tbIzgotovitelCity.Text))
                            command.Parameters.AddWithValue("@City", tbIzgotovitelCity.Text);
                    }
                    else if (tableName == Seller)
                    {
                        if (!string.IsNullOrEmpty(tbRealigatorName.Text))
                            command.Parameters.AddWithValue("@Name", tbRealigatorName.Text);
                        if (!string.IsNullOrEmpty(tbRealigatorCity.Text))
                            command.Parameters.AddWithValue("@City", tbRealigatorCity.Text);
                        if (!string.IsNullOrEmpty(tbRealigatorPhoneNumber.Text))
                            command.Parameters.AddWithValue("@PhoneNumber", tbRealigatorPhoneNumber.Text);
                    }
                    else if (tableName == Volume)
                    {
                        if (!string.IsNullOrEmpty(tbSpecificationsTypeCPU.Text))
                            command.Parameters.AddWithValue("@TypeCPU", tbSpecificationsTypeCPU.Text);
                        if (!string.IsNullOrEmpty(tbSpecificationsVolumeGhz.Text))
                            command.Parameters.AddWithValue("@ClockFrequency", tbSpecificationsVolumeGhz.Text);
                        if (!string.IsNullOrEmpty(tbSpecificationsRAM.Text))
                            command.Parameters.AddWithValue("@RAM", tbSpecificationsRAM.Text);
                        if (!string.IsNullOrEmpty(tbSpecificationsHDD.Text))
                            command.Parameters.AddWithValue("@HHD", tbSpecificationsHDD.Text);
                        if (!string.IsNullOrEmpty(tbSpecificationsDate.Text))
                            command.Parameters.AddWithValue("@Date", tbSpecificationsDate.Text);
                    }
                    else if (tableName == Specifications)
                    {
                        if (!string.IsNullOrEmpty(tbBatchVolume.Text))
                            command.Parameters.AddWithValue("@BatchVolume", tbBatchVolume.Text);
                        if (!string.IsNullOrEmpty(tbBatchPrice.Text))
                            command.Parameters.AddWithValue("@BatchPrice", tbBatchPrice.Text);
                    }

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgv1.DataSource = dataTable;
                }
            }
        }
        #endregion
    }
}
