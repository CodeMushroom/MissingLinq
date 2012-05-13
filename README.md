MissingLinq
===========

A simple library that provides some missing LINQ functionality, as well as a few enhancements and features.

Enumerable Extensions
---------------------

##### IEnumearble&lt;T&gt;.Append(T item)
Appends an item to a given set.

    IEnumerable<int> set = new int[] { 0, 1, 2 };
    set = set.Append(3);  // { 0, 1, 2, 3 }

##### IEnumearble&lt;T&gt;.Append(IEnumerable&lt;T&gt; item)
Appends a set to a given set.

    IEnumerable<int> set = new int[] { 0, 1, 2 };
    set = set.Append(new int[] { 3, 4, 5 });  // { 0, 1, 2, 3, 4, 5 }