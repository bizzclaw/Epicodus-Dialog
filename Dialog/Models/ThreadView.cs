using System;
using System.Collections.Generic;

namespace Dialog.Models
{
  public class ThreadView
  {
    public Topic ThisTopic {get; set;}
    public Thread ThisThread {get; set;}
    public Post OriginalPost {get; set;}
    public List<Post> Posts {get; set;}

    public ThreadView(Topic topic, Thread thread, int start)
    {
      ThisTopic = topic;
      ThisThread = thread;
      OriginalPost = thread.GetOriginalPost();
      Posts = thread.GetPosts((int)Math.Max(start, 1) );
    }
  }
}
