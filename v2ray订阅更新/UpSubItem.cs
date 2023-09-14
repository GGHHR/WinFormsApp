using System;
using System.Data.SQLite;

namespace v2ray订阅更新
{
    public class UpSubItem
    {
        public void Up()
        {
        
            string dbFilePath = @"D:\APP\v2rayN-With-Core\guiConfigs\guiNDB.db";
            string connectionString = $"Data Source={dbFilePath};Version=3;";
            
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
            
                // 新增一条记录到SubItem表
                string insertSql = "INSERT INTO SubItem (remarks, url,id) VALUES (@Remarks, @Url,@id)";
            
                using (SQLiteCommand cmd = new SQLiteCommand(insertSql, connection))
                {
                    cmd.Parameters.AddWithValue("@Remarks", "a1");
                    cmd.Parameters.AddWithValue("@Url", "http://ok.com");
                    cmd.Parameters.AddWithValue("@id", "1");
                
                    int rowsAffected = cmd.ExecuteNonQuery();
                    Console.WriteLine($"Rows affected: {rowsAffected}");
                }
            }
        }
    }
}