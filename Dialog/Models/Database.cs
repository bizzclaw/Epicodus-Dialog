using System;
using MySql.Data.MySqlClient;
using Dialog;

namespace Dialog.Models
{
  public class DB
  {
    public static MySqlConnection Connection()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      return conn;
    }

    public static void DatabaseTest()
		{
			// DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=3306;database=dialog_test;";
			DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=dialog_test;";
		}
  }
}
