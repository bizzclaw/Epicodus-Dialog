using System;
using MySql.Data.MySqlClient;

namespace Dialog.Models
{
  public class Query
  {
    private MySqlCommand _cmd;
    private MySqlConnection _conn;

    private Query _lastQuery;

    public Query(string query)
    {
      if (_lastQuery != null)
      {
        _conn = _lastQuery.GetConnection();
      }
      else
      {
        _conn = DB.Connection();
      }
      _cmd = _conn.CreateCommand();
      _conn.Open();
      _cmd.CommandText = @query;
      _lastQuery = this;
    }

    // ~Query()
    // {
    //   Console.WriteLine("Disposing Connection");
    //   Close();
    // }

    public void Close()
    {
      _conn.Close();
      if (_conn != null)
      {
        _conn.Dispose();
      }
    }

    public MySqlCommand GetCommand()
    {
      return _cmd;
    }

    public MySqlConnection GetConnection()
    {
      return _conn;
    }

    public void AddParameter<T>(string key, T value)
    {
      MySqlParameter parameter = new MySqlParameter();
      parameter.ParameterName = key;
      parameter.Value = value;
      _cmd.Parameters.Add(parameter);
    }

    public void Execute()
    {
      _cmd.ExecuteNonQuery();
    }
    public MySqlDataReader Read()
    {
      MySqlDataReader rdr = _cmd.ExecuteReader() as MySqlDataReader;
      return rdr;
    }
  }
}
