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
        List<Topic> allTopics = Topic.GetAll();
        return View(allTopics);
      }

      [HttpGet("/thread")]
      public ActionResult ThreadView()
      {
        return View();
      }

      [HttpPost("/topics/new")]
      public ActionResult NewTopic()
      {
        string name = Request.Form["topic-name"];
        Topic newTopic = new Topic(0, name ?? "ERROR");

        if (name != "")
        {
          newTopic.Save();
          return Redirect("/topics/" + newTopic.Id + "/threads/0");
        }
        else
        {
          return Redirect("/");
        }
      }

      [HttpGet("/topics/{topicId}/threads/{start}")]
      public ActionResult TopicView(int topicId, int start = 0)
      {
        Topic thisTopic = Topic.Find(topicId);

        List<Thread> threads = thisTopic.GetThreads(start, start+20);

        TopicView topicView = new TopicView(thisTopic, threads);

        return View(topicView);
      }

      [HttpPost("/topics/{topicId}/thread/new/")]
      public ActionResult NewThread(int topicId)
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

          string subject = Request.Form["thread-subject"];
          string message = Request.Form["thread-message"];
          string author = Request.Form["thread-author"];
          string avatar = Request.Form["thread-avatar"];

          Post originalPost = new Post(0, newThread.Id, subject ?? "ERROR", message ?? "ERROR", author ?? "ERROR", avatar);
          originalPost.Save();

          return Redirect("/topics/" + topicId +  "/threads/" + newThread.Id + "/0");
        }
      }

      [HttpGet("/topics/{topicId}/threads/{threadId}/{start}")]
      public ActionResult ViewThread(int topicId, int threadId, int start)
      {
        Topic topic = Topic.Find(topicId);
        Thread thread = Thread.Find(threadId);

        ThreadView threadView = new ThreadView(topic, thread, thread.GetPosts());
        return View(threadView);
      }
    }
}
