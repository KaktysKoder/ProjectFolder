//Реализация арифметической прогрессии с шагом 3, используя класс итератор.

using System.Collections;
using System.Collections.Generic;

namespace SetTypes
{
    internal class ProgressionIterator : IEnumerator<int>
    {
        private readonly int _itemCount;    //Максимальное кол-во чисел в последовательности.
        private int _position;              //Текущий номер последовательности.
        private int _current;               //Текщее значение последовательности.

        public ProgressionIterator(int itemCount)
        {
            _itemCount = itemCount;
            _current   = 1;
            _position  = 0;
        }

        #region Реализация интерфейса
        public void Dispose()
        {
            //Заглушка. Нам не надо освобождать ресурсы.
        }

        //Осуществляет движение по последовательности, и вычисляет текущий элемент.
        public bool MoveNext()
        {
            if (_position > 0) _current += 3;

            if (_position < _itemCount)
            {
                _position++;

                return true;
            }

            return false;
        }

        public void Reset()
        {
            _position = 0;
            _current  = 1;
        }

        public int Current { get => _current; }

        object IEnumerator.Current { get => Current; }
        #endregion
    }
}