using System;
using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Windows.Forms;

public class DatabaseManager
{
    private string connectionString = "Data Source=FullDB.db;Version=3;";

    public bool DatabaseExists()
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            return true;
        }
    }

    public bool TableExists(string tableName)
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT name FROM sqlite_master WHERE type='table'";
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["name"].ToString() == tableName)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    // Метод для проверки существования таблицы
    public bool TableExistsMenu(string tableName)
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT name FROM sqlite_master WHERE type='table'";
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["name"].ToString() == tableName)
                        {
                            return true; // Таблица существует
                        }
                    }
                }
            }
        }
        return false; // Таблица не существует
    }

    public bool DataExists()
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                command.CommandText = "SELECT COUNT(*) FROM FirmCreator";
                int count = Convert.ToInt32(command.ExecuteScalar());
                return count > 0;
            }
        }
    }

    public void CreateDatabase()
    {
        SQLiteConnection.CreateFile("FullDB.db");
    }

    public void CreateTables()
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                // Создание таблицы FirmCreator
                command.CommandText = "CREATE TABLE IF NOT EXISTS FirmCreator (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, City TEXT, NameComputer TEXT)";
                command.ExecuteNonQuery();

                // Создание таблицы FirmSeller
                command.CommandText = "CREATE TABLE IF NOT EXISTS FirmSeller (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, City TEXT, PhoneNumber TEXT, NameComputer TEXT)";
                command.ExecuteNonQuery();

                // Создание таблицы Volume
                command.CommandText = "CREATE TABLE IF NOT EXISTS Volume (ID INTEGER PRIMARY KEY AUTOINCREMENT, NameComputer TEXT, TypeCPU TEXT, ClockFrequency TEXT, RAM TEXT, HHD TEXT, Date TEXT)";
                command.ExecuteNonQuery();

                // Создание таблицы Specifications
                command.CommandText = "CREATE TABLE IF NOT EXISTS Specifications (ID INTEGER PRIMARY KEY AUTOINCREMENT, NameComputer TEXT, BatchVolume TEXT, BatchPrice TEXT)";
                command.ExecuteNonQuery();
            }
        }
    }

    // Создание записей в таблицах
    public void InsertData()
    {
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            using (SQLiteCommand command = new SQLiteCommand(connection))
            {
                string[] namesCreator = new string[40];
                string[] cities = new string[40];
                string[] nameComputers = new string[40];

                string[] namesSeller = new string[30];
                string[] phoneNumbersSeller = new string[30];

                string[] CPUtypeVolume = new string[40];
                string[] clockFrequencyVolume = new string[40];
                string[] RAMVolume = new string[40];
                string[] HHDVolume = new string[40];
                string[] date = new string[40];

                string[] batchVolumeSpecifications = new string[40];
                string[] batchPriceSpecifications = new string[40];

                Random random = new Random();

                // Генерация случайных данных
                for (int i = 0; i < 40; i++)
                {
                    namesCreator[i] = GenerateRandomCompanyNameCreators(random);
                    cities[i] = GenerateRandomCityInRussia(random);
                    nameComputers[i] = GenerateRandomComputerName(random);

                    CPUtypeVolume[i] = GenerateRandomCPU(random);
                    clockFrequencyVolume[i] = GenerateRandomGhz(random);
                    RAMVolume[i] = GenerateRandomRAM(random);
                    HHDVolume[i] = GenerateRandomHDD(random);
                    date[i] = GenerateRandomDate(random);

                    batchVolumeSpecifications[i] = GenerateRandomVolume(random);
                    batchPriceSpecifications[i] = GenerateRandomPrice(random);
                }
                for (int i = 0; i < 30; i++)
                {
                    namesSeller[i] = GenerateRandomCompanyNameSellers(random);
                    phoneNumbersSeller[i] = GenerateRandomPhoneNumbers(random);
                }

                command.CommandText = "INSERT INTO FirmCreator (Name, City, NameComputer) VALUES (@Name, @City, @NameComputer)";

                for (int i = 0; i < namesCreator.Length; i++)
                {
                    command.Parameters.AddWithValue("@Name", namesCreator[i]);
                    command.Parameters.AddWithValue("@City", cities[i]);
                    command.Parameters.AddWithValue("@NameComputer", nameComputers[i]);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear(); // Очистка параметров
                }

                command.CommandText = "INSERT INTO FirmSeller (Name, City, PhoneNumber, NameComputer) VALUES (@Name, @City, @PhoneNumber, @NameComputer)";

                for (int i = 0; i < namesSeller.Length; i++)
                {
                    command.Parameters.AddWithValue("@Name", namesSeller[i]);
                    command.Parameters.AddWithValue("@City", cities[i]);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumbersSeller[i]);
                    command.Parameters.AddWithValue("@NameComputer", nameComputers[i]);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear(); // Очистка параметров
                }

                command.CommandText = "INSERT INTO Volume (NameComputer, TypeCPU, ClockFrequency, RAM, HHD, Date) VALUES (@NameComputer, @TypeCPU, @ClockFrequency, @RAM, @HHD, @Date)";

                for (int i = 0; i < namesSeller.Length; i++)
                {
                    command.Parameters.AddWithValue("@NameComputer", nameComputers[i]);
                    command.Parameters.AddWithValue("@TypeCPU", CPUtypeVolume[i]);
                    command.Parameters.AddWithValue("@ClockFrequency", clockFrequencyVolume[i]);
                    command.Parameters.AddWithValue("@RAM", RAMVolume[i]);
                    command.Parameters.AddWithValue("@HHD", HHDVolume[i]);
                    command.Parameters.AddWithValue("@Date", date[i]);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear(); // Очистка параметров
                }

                command.CommandText = "INSERT INTO Specifications (NameComputer, BatchVolume, BatchPrice) VALUES (@NameComputer, @BatchVolume, @BatchPrice)";

                for (int i = 0; i < namesCreator.Length; i++)
                {
                    command.Parameters.AddWithValue("@NameComputer", nameComputers[i]);
                    command.Parameters.AddWithValue("@BatchVolume", batchVolumeSpecifications[i]);
                    command.Parameters.AddWithValue("@BatchPrice", batchPriceSpecifications[i]);
                    command.ExecuteNonQuery();
                    command.Parameters.Clear(); // Очистка параметров
                }
            }
        }
    }

    public void LoadDataIntoDataGridView(DataGridView dataGridView, string tableName)
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
                dataGridView.DataSource = dataTable;

                // Растянуть столбцы равномерно
                foreach (DataGridViewColumn column in dataGridView.Columns)
                {
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }
    }

    // Метод для генерации случайного названия компании-производителя
    public static string GenerateRandomCompanyNameCreators(Random random)
    {
        string[] companyNames = { "HyperPC", "TopShop", "ИП Чекмарёв", "Rapter" };
        int index = random.Next(companyNames.Length);
        return companyNames[index];
    }

    // Метод для генерации случайного города в России
    public static string GenerateRandomCityInRussia(Random random)
    {
        string[] russianCities = { "Москва", "Санкт-Петербург", "Новосибирск", "Екатеринбург", "Ижевск" };
        int index = random.Next(russianCities.Length);
        return russianCities[index];
    }

    // Метод для генерации случайного названия компьютера
    public static string GenerateRandomComputerName(Random random)
    {
        string[] computerNames = { "Computer1", "Computer2", "Computer3", "Computer4", "Computer5" };
        int index = random.Next(computerNames.Length);
        return computerNames[index];
    }

    // Метод для генерации случайного названия компании-продавца
    public static string GenerateRandomCompanyNameSellers(Random random)
    {
        string[] namesSeller = { "CompanyAA", "CompanyBB", "CompanyCC", "CompanyDD", "CompanyEE" };
        int index = random.Next(namesSeller.Length);
        return namesSeller[index];
    }

    // Метод для генерации случайного номера телефона
    public static string GenerateRandomPhoneNumbers(Random random)
    {
        string[] phoneNumbersSeller = { "+79511957821", "89511644356", "+795119578412", "89975127800", "+79503712059" };
        int index = random.Next(phoneNumbersSeller.Length);
        return phoneNumbersSeller[index];
    }

    // Метод для генерации случайного процессора
    public static string GenerateRandomCPU(Random random)
    {
        string[] CPUtypeVolume = { "Core i3", "Core i5", "Pentium", "Celeron" };
        int index = random.Next(CPUtypeVolume.Length);
        return CPUtypeVolume[index];
    }

    // Метод для генерации случайной герцовки
    public static string GenerateRandomGhz(Random random)
    {
        string[] clockFrequencyVolume = { "1.1 Ghz", "2.8 Ghz", "1.7 Ghz", "2.9 Ghz", "3.1 Ghz" };
        int index = random.Next(clockFrequencyVolume.Length);
        return clockFrequencyVolume[index];
    }

    // Метод для генерации случайного объёма оперативной памяти
    public static string GenerateRandomRAM(Random random)
    {
        string[] RAMVolume = { "1 GB", "2 GB", "4 GB", "512 MB", "256 MB" };
        int index = random.Next(RAMVolume.Length);
        return RAMVolume[index];
    }

    // Метод для генерации случайного объёма памяти
    public static string GenerateRandomHDD(Random random)
    {
        string[] HHDVolume = { "256 GB", "512 GB", "128 GB", "64 GB", "32 GB" };
        int index = random.Next(HHDVolume.Length);
        return HHDVolume[index];
    }

    public static string GenerateRandomDate(Random random)
    {
        string[] HHDVolume = { "12.11.2007", "27.09.2005", "6.10.2015", "17.03.2017", "24.05.2009" };
        int index = random.Next(HHDVolume.Length);
        return HHDVolume[index]; 
    }

    public static string GenerateRandomVolume(Random random)
    {
        string[] batchVolumeSpecifications = { "123 тыс.", "543 тыс.", "12 тыс.", "563 тыс.", "23 тыс." };
        int index = random.Next(batchVolumeSpecifications.Length);
        return batchVolumeSpecifications[index];
    }

    public static string GenerateRandomPrice(Random random)
    {
        string[] batchPriceSpecifications = { "91 тыс.", "34 тыс.", "53 тыс.", "68 тыс.", "65 тыс." };
        int index = random.Next(batchPriceSpecifications.Length);
        return batchPriceSpecifications[index];
    }
}
