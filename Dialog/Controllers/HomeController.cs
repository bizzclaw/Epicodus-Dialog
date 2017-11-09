using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Dialog.Models;

namespace Dialog.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
        return Redirect("/topics");
      }

      [HttpGet("/topics")]
      public ActionResult Topics()
      {
        List<Topic> allTopics = Topic.GetAll();
        return View(allTopics);
      }

      [HttpGet("/thread")]
      public ActionResult ThreadView()
      {
        return View();
      }

      [HttpGet("/topics/new")]
      public ActionResult NewTopic()
      {
        return View();
      }

      [HttpPost("/topics/new")]
      public ActionResult AddTopic()
      {
        string name = Request.Form["topic-name"];
        Topic newTopic = new Topic(0, name ?? "ERROR");

        if (name != "")
        {
          newTopic.Save();
          return Redirect("/topics/" + newTopic.Id + "/0");
        }
        else
        {
          return Redirect("/");
        }
      }

      [HttpGet("/topics/{topicId}/{start}")]
      public ActionResult TopicView(int topicId, int start = 0)
      {
        Topic thisTopic = Topic.Find(topicId);

        List<Thread> threads = thisTopic.GetThreads(start, start+20);

        TopicView topicView = new TopicView(thisTopic, threads);

        return View(topicView);
      }

      [HttpGet("/topics/{topicId}/threads/new")]
      public ActionResult NewThread(int topicId)
      {
        Topic thisTopic = Topic.Find(topicId);
        return View(thisTopic);
      }

      [HttpPost("/topics/{topicId}/threads/new")]
      public ActionResult AddThread(int topicId)
      {
        Topic verified = Topic.Find(topicId);
        if (verified.Name == "")
        {
          return Redirect("/");
        }
        else
        {
          Thread newThread = new Thread(0, topicId);
          newThread.Save();

          string subject = Request.Form["post-subject"];
          string message = Request.Form["post-message"];
          string author = Request.Form["post-author"];
          string avatar = Request.Form["post-avatar"];
          string date = DB.GetNow();

          Post originalPost = new Post(0, newThread.Id, subject, message, date, author, avatar);
          originalPost.Save();

          return Redirect("/topics/" + topicId +  "/threads/" + newThread.Id + "/1");
        }
      }

      [HttpGet("/topics/{topicId}/threads/{threadId}/{start}")]
      public ActionResult ThreadView(int topicId, int threadId, int start = 1)
      {
        Topic topic = Topic.Find(topicId);
        Thread thread = Thread.Find(threadId);
        ThreadView threadView = new ThreadView(topic, thread, start);
        return View(threadView);
      }

      [HttpPost("/topics/{topicIs}/threads/{threadId}/reply")]
      public ActionResult ThreadReply(int topicId, int threadId)
      {
        string subject = Request.Form["post-subject"];
        string message = Request.Form["post-message"];
        string author = Request.Form["post-author"];
        string avatar = Request.Form["post-avatar"];
        string date = DB.GetNow();

        Post replyPost = new Post(0, threadId, subject, message, date, author, avatar);
        replyPost.Save();
        return Redirect("/topics/" + topicId + "/threads/ " + threadId +  "/1");
      }
    }
}
