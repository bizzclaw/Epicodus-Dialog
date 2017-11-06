using System;
using System.Collections.Generic;

namespace Dialog.Models
{
  public class Thread
  {
    public int Id {get; set;}
    public int TopicId {get; set;}

    public Thread(int id = 0, int topicId = 0)
    {
      Id = id;
      TopicId = topicId;
    }

    public void Save()
    {
      Query saveThread = new Query("INSERT INTO threads (topic_id) VALUES (@TopicId)");
      saveThread.AddParameter("@TopicId", TopicId.ToString());
      saveThread.Execute();
      Id = (int)saveThread.GetCommand().LastInsertedId;
    }

    public static Thread Find(int id)
    {
      Query findThread = new Query("SELECT * FROM threads WHERE id = @Id");
      findThread.AddParameter("@Id", id.ToString());
      var rdr = findThread.Read();

      int topicId = 0;

      while (rdr.Read())
      {
        topicId = rdr.GetInt32(1);
      }

      Thread foundThread = new Thread(id, topicId);
      return foundThread;
    }

    public static List<Thread> GetAll()
    {
      Query getAllThreads = new Query("SELECT * FROM threads");
      List<Thread> allThreads = new List<Thread> {};

      var rdr = getAllThreads.Read();
      while (rdr.Read())
      {
        int threadId = rdr.GetInt32(0);
        int topicId = rdr.GetInt32(1);

        Thread memberThread = new Thread(threadId, topicId);

        allThreads.Add(memberThread);
      }
      return allThreads;
    }

    public static void ClearAll()
    {
      Query clearThreads = new Query("DElETE FROM threads");
      clearThreads.Execute();
    }
  }
}
