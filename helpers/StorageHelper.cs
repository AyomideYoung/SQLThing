using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLThing.helpers
{
    public class StorageHelper
    {
        public static string ConnectionString = Environment.GetEnvironmentVariable("MYSQL_CONNECTION_STRING") ?? "";

        public void InitializeStorage()
        {
            string sql = @"
CREATE TABLE IF NOT EXISTS `inverted_index_table` (
  `id` int NOT NULL AUTO_INCREMENT,
  `value` varchar(200) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `value_UNIQUE` (`value`),
  KEY `ID_VALUE` (`id`,`value`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE IF NOT EXISTS `posting_list` (
  `id` int NOT NULL AUTO_INCREMENT,
  `document_id` int DEFAULT NULL,
  `token_id` int DEFAULT NULL,
  `frequency` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `DOCUMENT_ID_TK_ID` (`token_id`,`document_id`),
  KEY `DOCUMENT_ID` (`document_id`),
  KEY `TOKEN_ID` (`token_id`)
) ENGINE=InnoDB AUTO_INCREMENT=273 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE IF NOT EXISTS `token_posting_list_size` (
  `id` int NOT NULL AUTO_INCREMENT,
  `size` int DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE IF NOT EXISTS `documents` (
  `id` int NOT NULL AUTO_INCREMENT,
  `document_link` varchar(255) NOT NULL,
  `document_type` varchar(100) DEFAULT NULL,
  `total_term_count` int DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

";

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        // ExecuteNonQuery is used for commands that do not return data, like CREATE TABLE.
                        command.ExecuteNonQuery();
                        Console.WriteLine("All tables created successfully.");
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"An error occurred while initializing storage: {ex.Message}");
                    // It is often a good practice to log the full exception details
                    // and re-throw if it's a critical error.
                    throw;
                }
            }
        }
    }
}
