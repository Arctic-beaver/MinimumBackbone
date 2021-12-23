using NUnit.Framework;

namespace GraphLogic.Tests
{
    public class MergeSortTests
    {
        [SetUp]
        public void Setup()
        {
        }


        [TestCase(new int[] { 1, -2, 3, 2, -98, -56, -33 }, "-98 -56 -33 -2 1 2 3 ")]
        [TestCase(new int[] { 0, 3, 67, 23, -45, -67, -23, -23, 56, 3 }, "-67 -45 -23 -23 0 3 3 23 56 67 ")]
        [TestCase(new int[] { 0, 0, 0 }, "0 0 0 ")]
        public void SortTest(int[] array, string expected)
        {
            //arrange
            string actual = string.Empty;

            Edge[] edgeArr = new Edge[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                edgeArr[i] = new Edge(array[i]);
            } 

            //act
            MergeSort.Sort(edgeArr);

            for (int i = 0; i < edgeArr.Length; i++)
            {
                actual += $"{edgeArr[i].EdgeWeight} ";
            }

            //assert
            Assert.AreEqual(expected, actual);
        }
    }
}