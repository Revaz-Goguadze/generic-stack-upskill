# Generic Stack

Intermediate level task for practice generic classes and interfaces. 

Estimated time to complete the task - 2h.  

The task requires .NET 6 SDK installed.   

## Task Description

In this task you have to implement a class that represents a growable array based generic stack. The class should fulfill these requirements:
- Fields
    - The class should have a private `items` field to store a stack elements. The field type should be `T[]`.
    - The class should have a private `count` field to store a count of the items in the stack. The field type should be `int`.
    - The class should have a private  `version` field to store a version of the stack object. The field type should be `int`. It used by enumerator.
- Properties
    - The class should have a public `Count` property to access the `count` field. The property sould have the public get accessor only.
- Constructors
    - The class should have a public parameterless constructor that initializes a class object with default values. The default value for `count` field is `0`, the default value for `items` is an empty array with length `0`, the default value for `version` is `0`.
    - The class should have a public constructor with `capacity` that initializes an initial capacity of the `items` array. The initial capacity
should be a non-negative number. The value for `version` is `0`.
    - The class should have a public constructor with `IEnumerable<T>?` parameter and fill a stack with the content of a particular collection.
- Instance Methods
    - The class should have a public `Push` method that inserts an object at the top of the stack. The `count` and `version` values increase by one.
    - The class should have a public `Pop` method that removes and returns the object at the top of the stack. The `count` value decreases by one and `version` value increaces by one.
    - The class should have a public `Peek` method that returns the object at the top of the stack without removing it. The `count` and `version` values are not changed.
    - The class should have a public `ToArray` method that copies the elements of stack to a new array.
    - The class should have a public `Contains` method that determines whether an element is in the stack. To compare items use the default equality comparer (`EqualityComparer<T>.Default`).
- The class should implement `IEnumerable<T>` interface. 

The detailed explanations of the task are provided in the XML-comments for the methods and in test cases of unit tests.


## Additional Materials

* [Growable array based stack](https://www.geeksforgeeks.org/growable-array-based-stack/) 
* [NotImplementedException ](https://docs.microsoft.com/en-us/dotnet/api/system.notimplementedexception?view=net-5.0#:~:text=The%20NotImplementedException%20exception%20indicates%20that,member%20invocation%20from%20your%20code.)
* [IEnumerator interface](https://docs.microsoft.com/en-us/dotnet/api/system.collections.ienumerator?view=net-5.0) 
* [IEnumerable<T>.GetEnumerator method ](https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.ienumerable-1.getenumerator?view=net-5.0)
