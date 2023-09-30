using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace v2ray订阅更新
{
    public class UpSubItem : Form
    {
        public void Up(string url, string remarks, string id, string convertTarget)
        {
            string outputValue = new Form1().GetOutputTextBoxValue();
            string dbFilePath = $@"{outputValue}\guiConfigs\guiNDB.db";

            string connectionString = $"Data Source={dbFilePath};Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Define the SQL command to insert or replace a record in the SubItem table
                string insertOrUpdateSql = "INSERT OR REPLACE INTO SubItem (remarks, url, id, convertTarget,sort) VALUES (@Remarks, @Url, @Id, @ConvertTarget, @Sort)";

                using (SQLiteCommand cmd = new SQLiteCommand(insertOrUpdateSql, connection))
                {
                    cmd.Parameters.AddWithValue("@Remarks", remarks);
                    cmd.Parameters.AddWithValue("@Url", url);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@ConvertTarget", convertTarget);
                    cmd.Parameters.AddWithValue("@Sort", id);

                    // Execute the command to insert or replace the record
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}