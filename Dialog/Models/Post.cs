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
    public string Author {get; set;}
    public string Avatar {get; set;}

    public Post(int id = 0, int threadId = 0, string subject = "--", string message = "...", string author = "Anonymous", string avatar = "")
    {
      Id = id;
      ThreadId = threadId;
      Subject = subject;
      Message = message;
      Author = author;
      Avatar = avatar;
    }

    public void Save()
    {
      Query savePost = new Query("INSERT INTO POSTS (thread_id, subject, message, author, avatar) VALUES(@ThreadId, @Subject, @Message, @Author, @Avatar)");
      savePost.AddParameter("@ThreadId", ThreadId.ToString());
      savePost.AddParameter("@Subject", Subject);
      savePost.AddParameter("@Message", Message);
      savePost.AddParameter("@Author", Author);
      savePost.AddParameter("@Avatar", Avatar);
      savePost.Execute();
      Id = (int)savePost.GetCommand().LastInsertedId;
    }

    public static Post Find(int id)
    {
      Query findPost = new Query("SELECT * FROM posts WHERE id = @Id");
      findPost.AddParameter("@Id", id.ToString());
      var rdr = findPost.Read();
      int threadId = 0;
      string subject = "";
      string message = "";
      string author = "";
      string avatar = "";

      while (rdr.Read())
      {
        threadId = rdr.GetInt32(1);
        subject = rdr.GetString(2);
        message = rdr.GetString(3);
        author = rdr.GetString(4);
        avatar = rdr.GetString(5);
      }

      Post foundPost = new Post(id, threadId, subject, message, author, avatar);
      return foundPost;
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
        string author = rdr.GetString(4);
        string avatar = rdr.GetString(5);

        Post memberPost = new Post(id, threadId, subject, message, author, avatar);

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
