using System;
using System.Collections;
using System.Collections.Generic;

namespace stuff
{
    public class BinaryTree<T> : IEnumerable<T>
    {
        public BinaryTree(T value)
        { Value = value; }
        public T Value { get; }
        public Pair<BinaryTree<T>> SubItems { get; set; }

        #region IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            yield return Value;

            foreach (BinaryTree<T>? tree in SubItems)
            {
                if (tree != null)
                {
                    foreach (T item in tree)
                    {
                        yield return item;
                    }
                }
            }
        }
        #endregion IEnumerable<T>

        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
    public class CSharpBuiltInTypes : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "object";
            yield return "byte";
            yield return "uint";
            yield return "ulong";
            yield return "float";
            yield return "char";
            yield return "bool";
            yield return "ushort";
            yield return "decimal";
            yield return "int";
            yield return "sbyte";
            yield return "short";
            yield return "long";
            yield return "void";
            yield return "double";
            yield return "string";
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public struct Pair<T> : IEnumerable<T>
    {
        public Pair(T first, T second) : this()
        {
            First = first;
            Second = second;
        }
        public T First { get; } // C# 6.0 Getter- only Autoproperty
        public T Second { get; } // C# 6.0 Getter- only Autoproperty

        #region IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            yield return First;
            yield return Second;
        }
        #endregion IEnumerable<T>

        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }

    public class Program
    {
        static void Main()
        {
            var fullname = new Pair<string>("Inigo", "Montoya");
            foreach (string name in fullname)
            {
                Console.WriteLine(name);
            }

            var keywords = new CSharpBuiltInTypes();
            foreach (string keyword in keywords)
            {
                Console.WriteLine(keyword);
            }

            var jfkFamilyTree = new BinaryTree<string>("John Fitzgerald Kennedy")
            {
                SubItems = new Pair<BinaryTree<string>>(new BinaryTree<string>("Joseph Patrick Kennedy")
                {
                    SubItems = new Pair<BinaryTree<string>>(
                    new BinaryTree<string>("Patrick Joseph Kennedy"),
                    new BinaryTree<string>("Mary Augusta Hickey"))
                },
                new BinaryTree<string>("Rose Elizabeth Fitzgerald")
                {
                    SubItems = new Pair<BinaryTree<string>>(
                    new BinaryTree<string>("John Francis Fitzgerald"),
                    new BinaryTree<string>("Mary Josephine Hannon"))
                })
            };
            foreach (string name in jfkFamilyTree)
            {
                Console.WriteLine(name);
            }


            var FamilyTree = new BinaryTree<string>("Billy")
            {
                SubItems = new Pair<BinaryTree<string>>(new BinaryTree<string>("Dad")
                {
                    SubItems = new Pair<BinaryTree<string>>(
                    new BinaryTree<string>("Dad's Dad"),
                    new BinaryTree<string>("Dad's Mom"))
                },
                new BinaryTree<string>("Mom")
                {
                    SubItems = new Pair<BinaryTree<string>>(
                    new BinaryTree<string>("Mom's Dad"),
                    new BinaryTree<string>("Mom's Mom")
                    {
                        SubItems = new Pair<BinaryTree<string>>(
                        new BinaryTree<string>("Mom's Mom's Dad"),
                        new BinaryTree<string>("Mom's Mom's Mom"))
                    })
                })
            };
            foreach (string name in FamilyTree)
            {
                Console.WriteLine(name);
            }
        }
    }
}