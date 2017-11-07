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

    public List<Post> GetPosts()
    {
      Query getThreadPosts = new Query("SELECT * FROM POSTS WHERE thread_id = @ThreadId");
      getThreadPosts.AddParameter("@ThreadId", Id.ToString());
      List<Post> threadPosts = new List<Post> {};

      var rdr = getThreadPosts.Read();
      while (rdr.Read())
      {
        int id = rdr.GetInt32(0);
        int threadId = rdr.GetInt32(1);
        string subject = rdr.GetString(2);
        string message = rdr.GetString(3);
        string date = rdr.GetDateTime(4).ToString();
        string author = rdr.GetString(5);
        string avatar = rdr.GetString(6);

        Post memberPost = new Post(id, threadId, subject, message, author, date, avatar);

        threadPosts.Add(memberPost);
      }
      return threadPosts;
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
