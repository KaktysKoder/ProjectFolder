using System;
using SetTypes.ICollection;

namespace SetTypes
{
    internal class Program
    {
        private static void Main()
        {
            ICollectionTest();

            Console.ReadLine();
        }

        private static void SequencesIEnumerableTest()
        {
            Progression progression = new Progression(100);

            foreach (int i in progression)
            {
                  //Console.Write($"{i} ");
                Console.WriteLine($"{i} ");
            }
        }
        
        private static void ICollectionTest()
        {
            StoreCollection collection = new StoreCollection(@"F:\test.txt");

            collection.Add(2020);
            collection.Remove(2020);

            foreach(int i in collection)
            {
                Console.WriteLine(i);
            }
        }
    }
}
