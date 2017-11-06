using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dialog.Models;

namespace Dialog.Models.Tests
{
  [TestClass]
  public class PostTest : IDisposable
  {

    public void Dispose()
    {
    }

    public PostTest()
    {
      DB.DatabaseTest();
      Post.ClearAll();
    }

    [TestMethod]
    public void GetAll_ReturnAllPosts_0()
    {
      List<Post> allPosts = Post.GetAll();
      Assert.AreEqual(0, allPosts.Count);
    }

    [TestMethod]
    public void ClearAll_ClearAllPosts_0()
    {
      Post.ClearAll();
      List<Post> allPosts = Post.GetAll();
      Assert.AreEqual(0, allPosts.Count);
    }

    [TestMethod]
    public void Save_SavePostToDatabase_1()
    {
      Post firstPost = new Post(0,0, "First Post!", "This is the first post EVER posted on THIS forum YAY", "First user");
      firstPost.Save();

      List<Post> allPosts = Post.GetAll();
      Assert.AreEqual(1, allPosts.Count);
    }

    [TestMethod]
    public void Find_PostContentMatchesPostInDB_true()
    {
      Post firstPost = new Post(0,0, "First Post!", "This is the first post EVER posted on THIS forum YAY", "First user");
      firstPost.Save();

      Post findPost = Post.Find(firstPost.Id);
      Assert.AreEqual(firstPost.Subject, findPost.Subject);
    }

  }
}
