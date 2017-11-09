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
      saveThread.Close();
      Id = (int)saveThread.GetCommand().LastInsertedId;
    }

    public int CountPosts()
    {
      Query countPosts = new Query("SELECT COUNT(*) FROM posts WHERE thread_id = @ThreadId");
      countPosts.AddParameter("@ThreadId", Id);

      int count = 0;
      var rdr = countPosts.Read();
      while (rdr.Read())
      {
        count = rdr.GetInt32(0);
      }
      countPosts.Close();
      return count;
    }


    public List<Post> GetPosts(int start = 1, int end = 20)
    {
      Query getThreadPosts = new Query("SELECT * FROM posts WHERE thread_id = @ThreadId LIMIT @Start, @End");
      getThreadPosts.AddParameter("@ThreadId", Id);
      getThreadPosts.AddParameter("@Start", start);
      getThreadPosts.AddParameter("@End", end);
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

        Post memberPost = new Post(id, threadId, subject, message, date, author, avatar);

        threadPosts.Add(memberPost);
      }
      getThreadPosts.Close();
      return threadPosts;
    }

    public Post GetOriginalPost()
    {
      Query getOriginalPost = new Query("SELECT * FROM posts WHERE thread_id = @ThreadId LIMIT 0, 1");
      getOriginalPost.AddParameter("@ThreadId", Id);

      var rdr = getOriginalPost.Read();

      int id = 0;
      string subject = "";
      string message = "";
      string date = "";
      string author = "";
      string avatar = "";

      while (rdr.Read())
      {
        id = rdr.GetInt32(0);
        subject = rdr.GetString(2);
        message = rdr.GetString(3);
        date = rdr.GetDateTime(4).ToString();
        author = rdr.GetString(5);
        avatar = rdr.GetString(6);
      }
      getOriginalPost.Close();
      Post originalPost = new Post(id, Id, subject, message, date, author, avatar);
      return originalPost;
    }

    public void ClearPosts()
    {
      Query clearPosts = new Query("DELETE FROM posts WHERE thread_id = @ThreadId");
      clearPosts.AddParameter("@ThreadId", Id);
      clearPosts.Execute();
      clearPosts.Close();
    }

    public void Delete()
    {
      Query DeleteThread = new Query(@"
        DELETE FROM posts WHERE thread_id = @ThreadId;
        DELETE FROM threads WHERE id = @ThreadId
      ");
      DeleteThread.AddParameter("@ThreadId", Id.ToString());
      DeleteThread.Execute();
      DeleteThread.Close();
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
      findThread.Close();
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
      getAllThreads.Close();
      return allThreads;
    }

    public static void ClearAll()
    {
      Query clearThreads = new Query("DElETE FROM threads");
      clearThreads.Execute();
      clearThreads.Close();
    }
  }
}
