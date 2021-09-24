using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace SampleUnitTest
{
    [SetUpFixture]
    public class GlobalSetup
    {
        [OneTimeSetUp]
        public void Setup()
        {
            Debug.Log("Global Setup");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Debug.Log("Global Teardown");
        }
    }

    public class SampleGroup
    {
        [Test]
        public void SumTest()
        {
            var x = int.Parse("100");
            var y = int.Parse("200");

            Assert.AreEqual(300, x + y);
        }

        [Test]
        [TestCase(1, 2, 3)]
        [TestCase(10, 20, 30)]
        [TestCase(100, 200, 300)]
        public void ParameterTest(int x, int y, int answer)
        {
            Assert.AreEqual(answer, x + y);
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

        [SetUp]
        public void Setup()
        {
            Debug.Log("Called Setup");
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Debug.Log("Called OneTimeSetUp");
        }


        [TearDown]
        public void TearDown()
        {
            Debug.Log("Called Teardown");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Debug.Log("Called OneTimeTearDown");
        }

        [UnitySetUp]
        public IEnumerator UnitySetupRun()
        {
            Debug.Log("Unity Setup One:" + Time.frameCount);
            yield return null;
            Debug.Log("Unity Setup Two:" + Time.frameCount);
        }

        [UnityTearDown]
        public IEnumerator UnityTearDown()
        {
            Debug.Log("Unity Teardown One:" + Time.frameCount);
            yield return null;
            Debug.Log("Unity Teardown Two:" + Time.frameCount);
        }
    }

    public class Group2
    {
        [Test]
        public void SumTest()
        {
            var x = int.Parse("100");
            var y = int.Parse("200");

            Assert.AreEqual(300, x + y);
        }

        [Test]
        [TestCase(1, 2, 3)]
        [TestCase(10, 20, 30)]
        [TestCase(100, 200, 300)]
        public void ParameterTest(int x, int y, int answer)
        {
            Assert.AreEqual(answer, x + y);
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

        [SetUp]
        public void Setup()
        {
            Debug.Log("Called Setup");
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Debug.Log("Called OneTimeSetUp");
        }


        [TearDown]
        public void TearDown()
        {
            Debug.Log("Called Teardown");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Debug.Log("Called OneTimeTearDown");
        }

        [UnitySetUp]
        public IEnumerator UnitySetupRun()
        {
            Debug.Log("Unity Setup One:" + Time.frameCount);
            yield return null;
            Debug.Log("Unity Setup Two:" + Time.frameCount);
        }

        [UnityTearDown]
        public IEnumerator UnityTearDown()
        {
            Debug.Log("Unity Teardown One:" + Time.frameCount);
            yield return null;
            Debug.Log("Unity Teardown Two:" + Time.frameCount);
        }
    }

    public class TestCaseSourceGroup
    {
        private static readonly TestCaseData[] DivideCases =
        {
            new TestCaseData(12, 3, 4),
            new TestCaseData(12, 2, 6),
            new TestCaseData(12, 4, 3)
        };
        

        [Test, TestCaseSource(nameof(GetTestCases))]
        public void DivideTest(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }
        
        [UnityTest, TestCaseSource(nameof(GetTestCases))]
        public IEnumerator DivideUnityTest(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
            yield return null;
        }

        private static IEnumerable<TestCaseData> GetTestCases()
        {
            return DivideCases.Select((t, i) => t.SetName($"{i}").Returns(null));
        }
    }
}