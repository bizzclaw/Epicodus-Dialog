using System;
using System.Collections.Generic;

namespace Dialog.Models
{

  public class Post
  {
    public int Id {get; set;}
    public int ThreadId {get; set;}
    public string Subject {get; set;}
    public string Message {get; set;}
    public string Poster {get; set;}
    public string Image {get; set;}

    public Post(int id = 0, int threadId = 0, string subject = "--", string message = "...", string poster = "Anonymous", string image = "")
    {
      Id = id;
      ThreadId = threadId;
      Subject = subject;
      Message = message;
      Poster = poster;
      Image = image;
    }

    public void Save()
    {
      Query savePost = new Query("INSERT INTO POSTS (thread_id, subject, message, poster, image) VALUES(@ThreadId, @Subject, @Message, @Poster, @Image)");
      savePost.AddParameter("@ThreadId", ThreadId.ToString());
      savePost.AddParameter("@Subject", Subject);
      savePost.AddParameter("@Message", Message);
      savePost.AddParameter("@Poster", Poster);
      savePost.AddParameter("@Image", Image);
      savePost.Execute();
      Console.WriteLine("SUBJECT: " + Subject);
    }

    public static List<Post> GetAll()
    {
      Query getAllPosts = new Query("SELECT * FROM POSTS");
      List<Post> allPosts = new List<Post> {};

      var rdr = getAllPosts.Read();
      while (rdr.Read())
      {
        int id = rdr.GetInt32(0);
        int threadId = rdr.GetInt32(1);
        string subject = rdr.GetString(2);
        string message = rdr.GetString(3);
        string poster = rdr.GetString(4);
        string image = rdr.GetString(5);

        Post memberPost = new Post(id, threadId, subject, message, poster, image);

        allPosts.Add(memberPost);
      }
      return allPosts;
    }

    public static void ClearAll()
    {
      Query clearPosts = new Query("DElETE FROM posts");
      clearPosts.Execute();
    }
  }
}
