//Реализация арифметической прогрессии с шагом 3.

using System.Collections;
using System.Collections.Generic;

namespace SetTypes
{
    internal class Progression : IEnumerable<int>
    {
        private readonly int _itemCount;    //Максимальное кол-во чисел в последовательности.

        public Progression(int itemCount)
        {
            _itemCount = itemCount;
        }

        public IEnumerator<int> GetEnumerator()
        {
            int current = 1;

            for (int i = 0; i < _itemCount - 1; i++)
            {
                if (i == 0) yield return 1;

                current += 3;

                yield return current;
            }

            /* Закомментируйте int current, и весь цикл for.
             * Раскомментируйте return new ProgressionIterator(_itemCount), и запустите проект.
             * Не получитось запустить проект?
             * Добавьте в метод Main(), метод  SequencesIEnumerableTest();
             * Затем нажмите -> F5 или ctrl + F5 
             */

            //return new ProgressionIterator(_itemCount);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
