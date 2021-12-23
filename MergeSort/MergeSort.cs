using System;

namespace MergeSortClass
{
    public static class MergeSort
    {
        public static Edge[] Sort(int[] array)
        {
            return Sort(array, 0, array.Length - 1);
        }

        private static int[] Sort(int[] array, int leftIndex, int rightIndex)
        {
            if (leftIndex < rightIndex)
            {
                //рекурсивно вызываем сортировку
                var middleIndex = (leftIndex + rightIndex) / 2;
                Sort(array, leftIndex, middleIndex);
                Sort(array, middleIndex + 1, rightIndex);
                Merge(array, leftIndex, middleIndex, rightIndex);
            }
            return array;
        }

        //метод для слияния массивов
        private static void Merge(int[] array, int leftIndex, int middleIndex, int rightIndex)
        {
            var left = leftIndex;
            var right = middleIndex + 1;
            var tempArray = new int[rightIndex - leftIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= rightIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= rightIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[leftIndex + i] = tempArray[i];
            }
        }
    }
}
