using System;
using System.Collections;
using System.Collections.Generic;

public class Bag<T> : IEnumerable<T>
{
    private List<T> _elements;

    public Bag()
    {
        _elements = new List<T>();
    }

    // Add an element to the bag
    public void Add(T element)
    {
        _elements.Add(element);
    }

    // Get the size of the bag
    public int Size()
    {
        return _elements.Count;
    }

    // Remove all instances of an element from the bag
    public int RemoveAll(T element)
    {
        int count = 0;
        while (_elements.Remove(element))
        {
            count++;
        }
        return count;
    }

    // Get an iterator for the bag
    public IEnumerator<T> GetEnumerator()
    {
        return _elements.GetEnumerator();
    }

    // Explicit interface implementation for non-generic IEnumerable
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
