using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dialog.Models;

namespace Dialog.Models.Tests
{
  [TestClass]
  public class ThreadTests : IDisposable
  {

    public void Dispose()
    {
    }

    public ThreadTests()
    {
      DB.DatabaseTest();
      Thread.ClearAll();
    }

    [TestMethod]
    public void GetAll_ReturnAllThreads_0()
    {
      List<Thread> allThreads = Thread.GetAll();
      Assert.AreEqual(0, allThreads.Count);
    }

    [TestMethod]
    public void ClearAll_ClearAllThreads_0()
    {
      Thread.ClearAll();
      List<Thread> allThreads = Thread.GetAll();
      Assert.AreEqual(0, allThreads.Count);
    }

    [TestMethod]
    public void Save_SaveThreadToDatabase_1()
    {
      Thread firstThread = new Thread(0);
      firstThread.Save();

      List<Thread> allThreads = Thread.GetAll();
      Assert.AreEqual(1, allThreads.Count);
    }

    [TestMethod]
    public void Find_ThreadContentMatchesThreadInDB_true()
    {
      Thread firstThread = new Thread(23);
      firstThread.Save();

      Thread findThread = Thread.Find(firstThread.Id);
      Assert.AreEqual(firstThread.TopicId, findThread.TopicId);
    }

    [TestMethod]
    public void GetPost_PostInThreadMatchesReference_true()
    {
      Thread testThread = new Thread(0);
      testThread.Save();

      Post dummyPost = new Post(0,0, "Bad Post", "This is the first post EVER posted on THIS forum YAY", DB.GetNow(), "First user");
      Post testPost = new Post(0,testThread.Id, "Good Post", "This is the first post EVER posted on THIS forum YAY", DB.GetNow(), "First user");
      dummyPost.Save();
      testPost.Save();

      List<Post> threadPosts = testThread.GetPosts();
      Assert.AreEqual(testPost.Subject, threadPosts[0].Subject);
    }
  }
}
