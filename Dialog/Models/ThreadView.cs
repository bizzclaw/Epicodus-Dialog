using System;
using System.Collections.Generic;

namespace Dialog.Models
{
  public class ThreadView
  {
    public Topic ThisTopic {get; set;}
    public Thread ThisThread {get; set;}
    public List<Post> Posts {get; set;}

    public ThreadView(Topic topic, Thread thread,List<Post> posts)
    {
      ThisTopic = topic;
      ThisThread = thread;
      Posts = posts;
    }
  }
}
