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
  }

  public class Query
  {
    private MySqlCommand _cmd;
    private MySqlConnection _conn;

    public MySqlCommand GetCommand()
    {
      return _cmd;
    }

    public MySqlConnection GetConnection()
    {
      return _conn;
    }

    public Query(string query)
    {
      _conn = DB.Connection();
      _cmd = _conn.CreateCommand();

      _conn.Open();
      _cmd.CommandText = @query;
    }

    public void AddParameter(string key, string value)
    {
      MySqlParameter parameter = new MySqlParameter();
      parameter.ParameterName = "@"+key;
      parameter.Value = value;
      _cmd.Parameters.Add(parameter);
    }

    public void Update()
    {
      _cmd.ExecuteNonQuery();
      Close();
    }
    public MySqlDataReader Read()
    {
      MySqlDataReader rdr = _cmd.ExecuteReader() as MySqlDataReader;
      return rdr;
    }
    public void Close()
    {
      _conn.Close();
      if (_conn != null)
      {
        _conn.Dispose();
      }
    }
  }
}
