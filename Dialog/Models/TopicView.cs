using System;
using System.Collections.Generic;

namespace Dialog.Models
{
  public class TopicView
  {
    public Topic ThisTopic {get; set;}
    public List<Thread> Threads {get; set;}

    public TopicView(Topic topic,List<Thread> threads)
    {
      ThisTopic = topic;
      Threads = threads;
    }
  }
}
