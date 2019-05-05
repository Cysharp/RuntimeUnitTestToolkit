using UnityEngine;
using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace SampleUnitTest
{
    public class SampleGroup
    {
        [Test]
        public void SumTest()
        {
            var x = int.Parse("100");
            var y = int.Parse("200");

            Assert.AreEqual(300, x + y);
        }

        [UnityTest]
        public IEnumerator AsyncTest()
        {
            var testObject = new GameObject("Test");

            var e = MoveToRight(testObject);
            while (e.MoveNext())
            {
                yield return null;
            }

            Assert.AreEqual(60, testObject.transform.position.x);
            GameObject.Destroy(testObject);
        }

        IEnumerator MoveToRight(GameObject o)
        {
            for (int i = 0; i < 60; i++)
            {
                var p = o.transform.position;
                p.x += 1;
                o.transform.position = p;
                yield return null;
            }
        }
    }
}