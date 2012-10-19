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

##### IEnumearble&lt;T&gt;.DistinctUntilChanged() where T : IEquatable<T>
Returns an enumerable set that contains no two equal objects are next to each other.

    IEnumerable<int> set = new int[] { 0, 1, 2, 3, 3, 2, 2, 1, 1, 1, 1, 2, 1, 1 };
    set = set.DistinctUntilChanged();  // { 0, 1, 2, 3, 2, 1, 2, 1 }

##### IEnumearble&lt;T&gt;.ForEach(Action&lt;T&gt; action)
Performs an action against each element in a set.

    class Person {
        public bool IsActive { get; set; }
    }

    IEnumerable<Person> set = new Person[] { 
        new Person(),
        new Person(),
        new Person()
    };
    set = set.ForEach(p => p.IsActive = true);  // All three objects will now have IsActive set to true.

##### IEnumearble&lt;T&gt;.ForEach(Action&lt;T, int&gt; action)
Performs an action against each element in a set.

    class Person {
        public bool IsActive { get; set; }
        public int Index { get; set; }
    }

    IEnumerable<Person> set = new Person[] { 
        new Person(),
        new Person(),
        new Person()
    };
    set = set.ForEach((p, i) => p.Index = i);  // Each object now contains its index in the array.

##### IEnumearble.IsNullOrEmpty()
Performs an action against each element in a set.

    IEnumerable<int> set = null;
    bool isEmpty;
    isEmpty = set.IsNullOrEmpty();  // True

    set = new int[] { };
    isEmpty = set.IsNullOrEmpty();  // True

    set = new int[] { 1 };
    isEmpty = set.IsNullOrEmpty();  // False