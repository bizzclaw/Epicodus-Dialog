using System;
using System.Collections.Generic;

namespace Dialog.Models
{
  public class Topic
  {
    public int Id {get; set;}
    public string Name {get; set;}

    public Topic(int id = 0, string name = "")
    {
      Id = id;
      Name = name;
    }

    public void Save()
    {
      Query saveTopic = new Query("INSERT INTO topics (name) VALUES (@Name)");
      saveTopic.AddParameter("@Name", Name);
      saveTopic.Execute();
      Id = (int)saveTopic.GetCommand().LastInsertedId;
    }

    public static Topic Find(int id)
    {
      Query findTopic = new Query("SELECT * FROM topics WHERE id = @Id");
      findTopic.AddParameter("@Id", id.ToString());
      var rdr = findTopic.Read();

      string name = "";

      while (rdr.Read())
      {
        name = rdr.GetString(1);
      }

      Topic foundTopic = new Topic(id, name);
      return foundTopic;
    }

    public void Delete()
    {
      Query deleteTopics = new Query("DELETE FROM topics WHERE id = @TopicId");
      deleteTopics.AddParameter("@TopicId", Id.ToString());
      deleteTopics.Execute();
    }

    public static List<Topic> GetAll()
    {
      Query getAllTopics = new Query("SELECT * FROM topics");
      List<Topic> allTopics = new List<Topic> {};

      var rdr = getAllTopics.Read();
      while (rdr.Read())
      {
        int id = rdr.GetInt32(0);
        string name = rdr.GetString(1);

        Topic memberTopic = new Topic(id, name);

        allTopics.Add(memberTopic);
      }
      return allTopics;
    }

    public static void ClearAll()
    {
      Query clearTopics = new Query("DElETE FROM topics");
      clearTopics.Execute();
    }
  }
}
