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

    public List<Thread> GetThreads()
    {
      Query getThreads = new Query("SELECT * FROM threads WHERE topic_id = @TopicId");
      getThreads.AddParameter("@TopicId", Id.ToString());
      List<Thread> postThreads = new List<Thread> {};

      var rdr = getThreads.Read();
      while (rdr.Read())
      {
        int threadId = rdr.GetInt32(0);
        int topicId = rdr.GetInt32(1);

        Thread memberThread = new Thread(threadId, topicId);

        postThreads.Add(memberThread);
      }
      return postThreads;
    }

    public void Delete()
    {
      Query deleteTopics = new Query("DELETE FROM topics WHERE id = @TopicId");
      deleteTopics.AddParameter("@TopicId", Id.ToString());
      deleteTopics.Execute();
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
