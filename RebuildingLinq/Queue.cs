using System;
using System.Collections.Generic;

namespace RebuildingLinq
{
  public class NumberQueue
  {
    private List<int> _queue;

    public NumberQueue()
    {
      _queue = new List<int>();
    }

    public void Add(int x)
    {
      _queue.Add(x);
    }

    public int Pop()
    {
      if (_queue.Count == 0) 
        throw new Exception("queue is empty!");
      int value = _queue[0];
      _queue.RemoveAt(0);
      return value;
    }
  }

  public class StringQueue
  {
    private List<string> _queue;

    public StringQueue()
    {
      _queue = new List<string>();

      Queue<string> stringQueue = new Queue<string>();
      Queue<int> numberQueue = new Queue<int>();

    }

    public void Add(string x)
    {
      _queue.Add(x);
    }

    public string Pop()
    {
      if (_queue.Count == 0) 
        throw new Exception("queue is empty!");
      string value = _queue[0];
      _queue.RemoveAt(0);
      return value;
    }
  }

  public class Queue<T>
  {
    private readonly List<T> _queue;

    public Queue()
    {
      _queue = new List<T>();
    }

    public void Add(T item)
    {
      _queue.Add(item);
    }

    public T Pop()
    {
      if (_queue.Count == 0) 
        throw new Exception("queue is empty");
      T value = _queue[0];
      _queue.RemoveAt(0);
      return value;
    }
  }
}