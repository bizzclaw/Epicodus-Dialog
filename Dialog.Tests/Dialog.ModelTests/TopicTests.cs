using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dialog.Models;

namespace Dialog.Models.Tests
{
  [TestClass]
  public class TopicTests : IDisposable
  {

    public void Dispose()
    {
    }

    public TopicTests()
    {
      DB.DatabaseTest();
      Post.ClearAll();
      Thread.ClearAll();
      Topic.ClearAll();
    }

    [TestMethod]
    public void GetAll_ReturnAllTopics_0()
    {
      List<Topic> allTopics = Topic.GetAll();
      Assert.AreEqual(0, allTopics.Count);
    }

    [TestMethod]
    public void ClearAll_ClearAllTopics_0()
    {
      Topic.ClearAll();
      List<Topic> allTopics = Topic.GetAll();
      Assert.AreEqual(0, allTopics.Count);
    }

    [TestMethod]
    public void Save_SaveTopicToDatabase_1()
    {
      Topic firstTopic = new Topic(0);
      firstTopic.Save();

      List<Topic> allTopics = Topic.GetAll();
      Assert.AreEqual(1, allTopics.Count);
    }

    [TestMethod]
    public void Find_TopicContentMatchesTopicInDB_true()
    {
      Topic firstTopic = new Topic(23);
      firstTopic.Save();

      Topic findTopic = Topic.Find(firstTopic.Id);
      Assert.AreEqual(firstTopic.Name, findTopic.Name);
    }

    [TestMethod]
    public void Delete_TopicNameCanBeFOundAfterDeletion_false()
    {
      Topic testTopic = new Topic(0, "Testing");
      testTopic.Save();

      testTopic.Delete();

      Topic findTopic = Topic.Find(testTopic.Id);
      Assert.AreNotEqual(testTopic.Name, findTopic.Name); // the found topic's Name will default to 0 because it can't be found
    }

    [TestMethod]
    public void GetThreads_ThreadInTopicMatchesReference_true()
    {
      Topic testTopic = new Topic(0, "Testing");
      testTopic.Save();

      Thread testThread = new Thread(0, testTopic.Id);
      testThread.Save();

      List<Thread> topicThreads = testTopic.GetThreads();
      Assert.AreEqual(testThread.TopicId, topicThreads[0].TopicId);
    }
  }
}
