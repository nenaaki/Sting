using Microsoft.Practices.Prism.PubSubEvents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sting
{
    [TestClass]
    public class PubSubTest
    {
        [TestMethod]
        public void PubSubBasicTest()
        {
            bool result = false;

            using (var sub = new Subscriber<bool>(args => result = args, ThreadOption.PublisherThread))
            {
                Publisher.Publish(true);

                result.IsTrue();
            }

            Publisher.Publish(false);

            result.IsTrue();
        }
    }
}