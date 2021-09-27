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
        private static readonly object[] ObjectTestCases =
        {
            new object[] { 12, 3, 4 },
            new object[] { 12, 2, 6 },
            new object[] { 12, 4, 3 }
        };

        [Test, TestCaseSource(nameof(ObjectTestCases))]
        public void DivideTest(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }

        private static readonly TestCaseData[] TestCaseDataCases =
        {
            new TestCaseData(12, 3, 4).Returns(null),
            new TestCaseData(12, 2, 6).Returns(null),
            new TestCaseData(12, 4, 3).Returns(null)
        };

        [UnityTest, TestCaseSource(nameof(TestCaseDataCases))]
        public IEnumerator DivideUnityTest(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
            yield return null;
        }
    }



    public class Group3
    {
        // check the compatibility of TestCaseSource and TestCaseData
        // https://docs.nunit.org/articles/nunit/writing-tests/attributes/testcasesource.html
        // https://docs.nunit.org/articles/nunit/writing-tests/TestCaseData.html


        [Test]
        [TestCaseSource(nameof(DivideCases))]
        public void DivideTest(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }

        static object[] DivideCases =
        {
            new object[] { 12, 3, 4 },
            new object[] { 12, 2, 6 },
            new object[] { 12, 4, 3 }
        };

        [Test]
        [TestCaseSource(nameof(DivideCases2))]
        public void DivideTest_2(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }

        static object[][] DivideCases2 =
        {
            new object[] { 12, 3, 4 },
            new object[] { 12, 2, 6 },
            new object[] { 12, 4, 3 }
        };

        [Test]
        [TestCaseSource(typeof(AnotherClass), nameof(AnotherClass.DivideCases))]
        public void DivideTest2(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }


        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(12, 3).Returns(4);
                yield return new TestCaseData(12, 2).Returns(6);
                yield return new TestCaseData(12, 4).Returns(3);
            }
        }


        [Test]
        [TestCaseSource(nameof(TestCases))]
        public int DivideTest5(int n, int d)
        {
            return n / d;
        }

        [Test]
        [TestCaseSource(typeof(MyDataClass), nameof(MyDataClass.TestCases))]
        public int DivideTest4(int n, int d)
        {
            return n / d;
        }

        [Test]
        [TestCaseSource(typeof(DivideCases))]
        public void DivideTest3(int n, int d, int q)
        {
            Assert.AreEqual(q, n / d);
        }
    }

    public class AnotherClass
    {
        public static object[] DivideCases =
        {
            new object[] { 12, 3, 4 },
            new object[] { 12, 2, 6 },
            new object[] { 12, 4, 3 }
        };
    }

    class DivideCases : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { 12, 3, 4 };
            yield return new object[] { 12, 2, 6 };
            yield return new object[] { 12, 4, 3 };
        }
    }

    public class MyDataClass
    {
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(12, 3).Returns(4);
                yield return new TestCaseData(12, 2).Returns(6);
                yield return new TestCaseData(12, 4).Returns(3);
            }
        }
    }


}