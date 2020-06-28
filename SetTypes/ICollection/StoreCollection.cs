using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace SetTypes.ICollection
{
    internal class StoreCollection : ICollection<int>
    {
        private readonly string _filePath;

        public StoreCollection(string filePath)
        {
            _filePath = filePath;
        }

        
        private string[] GetNumbers()
        {
            //Открывает файл, разбивает строки с полощью запятой,
            //и возвращает массив скрок чисел.
            //Метод для -> Получение числел в виде строк.

            string line = File.ReadAllText(_filePath);

            string[] numbers = line.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            return numbers;
        }

        #region Реализация интерфейса ICollection<T>
        public IEnumerator<int> GetEnumerator()
        {
            string[] numbers = GetNumbers();

            //TODO: Проверка, являетс ли строка числом.

            foreach (string number in numbers)
            {
                yield return Int32.Parse(number);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #region Управление элементами множества.
        public void Add(int item)
        {
            string[] numbers = GetNumbers();

            if (numbers.Length == 0)
            {
                File.WriteAllText(_filePath, item.ToString());
            }
            else
            {
                File.AppendAllText(_filePath, "," + item.ToString());
            }
        }

        public void Clear()
        {
            File.WriteAllText(_filePath, "");
        }

        public bool Remove(int item)
        {
            string[] numbers = GetNumbers();
            string line = File.ReadAllText(_filePath);

            int symbolPosition = 0;

            foreach (string number in numbers)
            {
                if (Int32.Parse(number) == item)
                {
                    if (number.Length == 1)
                    {
                        line = "";
                    }
                    else if (symbolPosition == 0)
                    {
                        line = line.Substring(symbolPosition + number.Length + 1);
                    }
                    else
                    {
                        line = line.Remove(symbolPosition - 1, number.Length + 1);
                    }

                    File.WriteAllText(_filePath, line);

                    return true;
                }

                symbolPosition += number.Length + 1;
            }

            return true;
        }

        #endregion
        public bool Contains(int item)
        {
            string[] numbers = GetNumbers();

            foreach (string number in numbers)
            {
                if (Int32.Parse(number) == item) return true;
            }

            return false;
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            string[] numbers = GetNumbers();

            foreach (string number in numbers)
            {
                array[arrayIndex] = Int32.Parse(number);

                arrayIndex++;
            }
        }

        public int Count
        {
            get
            {
                string[] numbers = GetNumbers();
                return numbers.Length;
            }
        }

        public bool IsReadOnly { get => false; }

        #endregion
    }
}
