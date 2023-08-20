using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericStackTask
{
    /// <summary>
    /// Represents extendable last-in-first-out (LIFO) collection of the specified type T.
    /// </summary>
    /// <typeparam name="T">Specifies the type of elements in the stack.</typeparam>
#pragma warning disable CA1711
    public class Stack<T> : IEnumerable<T>
#pragma warning restore CA1711
    {
        private T[] stack;
        private int topPointer;

        /// <summary>
        /// Initializes a new instance of the <see cref="Stack{T}"/> class that is empty and has the default initial capacity.
        /// </summary>
        public Stack()
        {
            this.stack = new T[1];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stack{T}"/> class that is empty and has
        /// the specified initial capacity.
        /// </summary>
        /// <param name="capacity">The initial number of elements of stack.</param>
        public Stack(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Stack capasity must be gerater than 0.");
            }

            this.stack = new T[capacity];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stack{T}"/> class that contains elements copied
        /// from the specified collection and has sufficient capacity to accommodate the
        /// number of elements copied.
        /// </summary>
        /// <param name="collection">The collection to copy elements from.</param>
        public Stack(IEnumerable<T> collection)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            this.stack = new T[1];

            foreach (T item in collection)
            {
                if (this.topPointer == this.stack.Length)
                {
                    Resize(ref this.stack);
                }

                this.stack[this.topPointer++] = item;
            }
        }

        /// <summary>
        /// Gets the number of elements contained in the stack.
        /// </summary>
        public int Count => this.topPointer;

        /// <summary>
        /// Removes and returns the object at the top of the stack.
        /// </summary>
        /// <returns>The object removed from the top of the stack.</returns>
        public T Pop()
        {
            if (this.topPointer <= 0)
            {
                throw new InvalidOperationException();
            }

            T output = this.stack[--this.topPointer];
            this.stack[this.topPointer] = default!;
            return output;
        }

        /// <summary>
        /// Returns the object at the top of the stack without removing it.
        /// </summary>
        /// <returns>The object at the top of the stack.</returns>
        public T Peek()
        {
            if (this.topPointer < 1)
            {
                throw new InvalidOperationException();
            }

            return this.stack[this.topPointer - 1];
        }

        /// <summary>
        /// Inserts an object at the top of the stack.
        /// </summary>
        /// <param name="item">The object to push onto the stack.
        /// The value can be null for reference types.</param>
        public void Push(T item)
        {
            if (this.topPointer == this.stack.Length)
            {
                Resize(ref this.stack);
            }

            this.stack[this.topPointer++] = item;
        }

       /// <summary>
       /// Copies the elements of stack to a new array.
       /// </summary>
       /// <returns>A new array containing copies of the elements of the stack.</returns>
        public T[] ToArray()
        {
            T[] output = new T[this.Count];
            for (int i = 0, j = this.Count - 1; i < output.Length; i++, j--)
            {
                output[i] = this.stack[j];
            }

            return output;
        }

        /// <summary>
        /// Determines whether an element is in the stack.
        /// </summary>
        /// <param name="item">The object to locate in the stack. The value can be null for reference types.</param>
        /// <returns>Return true if item is found in the stack; otherwise, false.</returns>
        public bool Contains(T item)
        {
            if (item is null)
            {
                foreach (T comparedItem in this.stack)
                {
                    if (comparedItem is null)
                    {
                        return true;
                    }
                }

                return false;
            }

            foreach (T comparedItem in this.stack)
            {
                if (item.Equals(comparedItem))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Removes all objects from the stack.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < this.topPointer; i++)
            {
                this.stack[i] = default!;
            }

            this.topPointer = 0;
        }

        /// <summary>
        /// Returns an enumerator for the stack.
        /// </summary>
        /// <returns>Return Enumerator object for the stack.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new StackIterator(this);
        }

        /// <summary>
        /// Returns an enumerator for the stack.
        /// </summary>
        /// <returns>Return Enumerator object for the stack.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private static void Resize(ref T[] array)
        {
            T[] newStack = new T[array.Length * 2];
            array.CopyTo(newStack, 0);
            array = newStack;
        }

        /// <summary>
        /// Represents iterator for the <see cref="Stack{T}"/> class.
        /// </summary>
        public struct StackIterator : IEnumerator<T>
        {
            private readonly Stack<T> collection;
            private int currentIndex;

            /// <summary>
            /// Initializes a new instance of the <see cref="StackIterator"/> struct.
            /// </summary>
            /// <param name="collection">Source collection for initializing a new instance of the <see cref="StackIterator"/> struct.</param>
            internal StackIterator(Stack<T> collection)
            {
                this.collection = collection;
                this.currentIndex = collection.Count;
            }

            /// <summary>
            /// Gets current item in the sequence.
            /// </summary>
            public T Current
            {
                get
                {
                    if (this.currentIndex < 0 || this.currentIndex >= this.collection.Count)
                    {
                        throw new InvalidOperationException();
                    }

                    return this.collection.stack[this.currentIndex];
                }
            }

            /// <summary>
            /// Gets current item in the sequence as <see cref="object"/> instance.
            /// </summary>
            object IEnumerator.Current => this.Current!;

            /// <summary>
            /// Moves <see cref="currentIndex"/> to the next position.
            /// </summary>
            /// <returns><see langword="false"/> if the end of the sequence is reached, otherwise <see langword="true"/>.</returns>
            public bool MoveNext() => --this.currentIndex >= 0;

            /// <summary>
            /// Turns pointer <see cref="currentIndex"/> to its initial position.
            /// </summary>
            public void Reset()
            {
                this.currentIndex = this.collection.Count;
            }

            /// <summary>
            /// Not implemented.
            /// </summary>
            public void Dispose()
            {
            }
        }
    }
}
