using System;
using System.Data.SQLite;

namespace v2ray订阅更新
{
    public class UpSubItem
    {
        public void Up(string url, string remarks,string id )
        {
            string dbFilePath = @"D:\APP\v2rayN-With-Core\guiConfigs\guiNDB.db";
            string connectionString = $"Data Source={dbFilePath};Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                // 新增一条记录到SubItem表
                string insertOrUpdateSql = "INSERT OR REPLACE INTO SubItem (remarks, url, id) VALUES (@Remarks, @Url, @id)";

                using (SQLiteCommand cmd = new SQLiteCommand(insertOrUpdateSql, connection))
                {
                    cmd.Parameters.AddWithValue("@Remarks", remarks);
                    cmd.Parameters.AddWithValue("@Url", url);
                    cmd.Parameters.AddWithValue("@id", id);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"Rows affected: {rowsAffected}");
                }
            }
        }
    }
}