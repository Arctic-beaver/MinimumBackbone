using NUnit.Framework;

namespace StackClass.Tests
{
    public class StackTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(2)]
        [TestCase(300)]
        [TestCase(-8)]
        public void PushAndPeekTest(int data)
        {
            //arrange
            Stack<int> stack = new Stack<int>();

            //act          
            stack.Push(data);

            //assert
            Assert.AreEqual(data, stack.Peek());
        }

        [TestCase(2)]
        [TestCase(300)]
        [TestCase(-8)]
        public void PushAndPopTest(int data)
        {
            //arrange
            Stack<int> stack = new Stack<int>();

            //act          
            stack.Push(data);

            //assert
            Assert.AreEqual(data, stack.Pop());
        }

        [TestCase(2)]
        [TestCase(300)]
        [TestCase(-8)]
        public void PushAndContainsTest(int data)
        {
            //arrange
            Stack<int> stack = new Stack<int>();

            //act          
            stack.Push(data);

            //assert
            Assert.AreEqual(true, stack.Contains(data));        
        }

        [TestCase(-8)]
        public void ContainsTest(int data)
        {
            //arrange
            Stack<int> stack = new Stack<int>();

            //act          

            //assert
            Assert.AreEqual(false, stack.Contains(data));
        }

        [TestCase(new int[] { 2, 4, 5, 6, 7, 8})]
        public void ContainsTest(int[] data)
        {
            //arrange
            Stack<int> stack = new Stack<int>();

            //act          
            for (int i = 0; i < data.Length; i++)
            {
                stack.Push(data[i]);
            }

            //assert
            Assert.AreEqual(data.Length, stack.GetLength());
        }

    }
}