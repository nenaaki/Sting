using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sting
{
    [TestClass]
    public class ImmutableGuidTest
    {
        [TestMethod]
        public void ImmutableGuidBasicTest()
        {
            var dic = new Dictionary<Immutable.Guid, Immutable.Guid>();

            var hashSets = new int[10000];

            for (int idx = 0; idx < 10000; idx++)
            {
                var guid = Guid.NewGuid();
                dic.Add(guid, Guid.NewGuid());
                hashSets[idx] = dic[guid].GetHashCode();
            }
        }
    }
}