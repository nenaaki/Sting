using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sting
{
    /// <summary>
    /// CollectionExtensions のユニットテスト
    /// </summary>
    [TestClass]
    public class CollectionExtensionsTest
    {
        [TestMethod]
        public void ToArraySimpleTest()
        {
            var intArray = new int[400];

            for (int idx = 0; idx < intArray.Length; idx++)
                intArray[idx] = idx;

            var result = intArray.ToArraySimple();

            for (int idx = 0; idx < intArray.Length; idx++)
                result[idx].Is(intArray[idx]);
        }

        [TestMethod]
        public void ToArrayFastTest()
        {
            var intArray = new int[400];

            for (int idx = 0; idx < intArray.Length; idx++)
                intArray[idx] = idx;

            var result = intArray.ToArrayFast();

            for (int idx = 0; idx < intArray.Length; idx++)
                result[idx].Is(intArray[idx]);
        }

        [TestMethod]
        public void AsRefTest()
        {
            var intArray = new int[400];

            for (int idx = 0; idx < intArray.Length; idx++)
                intArray[idx] = idx;

            var result = new int[intArray.Length];

            int idx2 = 0;
            foreach (ref var item in intArray.AsRef())
                result[idx2++] = item;

            for (int idx = 0; idx < intArray.Length; idx++)
                result[idx].Is(intArray[idx]);
        }

        [TestMethod]
        public void ToReferenceList()
        {
            var intArray = new int[400];

            for (int idx = 0; idx < intArray.Length; idx++)
                intArray[idx] = idx;

            var result = new int[intArray.Length];

            int idx2 = 0;
            foreach (ref var item in intArray.ToReferenceList())
                result[idx2++] = item;

            for (int idx = 0; idx < intArray.Length; idx++)
                result[idx].Is(intArray[idx]);
        }
    }
}