using UnityEngine;
using System.Collections;

// using RuntimeUnitTestToolkit;
using RuntimeUnitTestToolkit;

namespace SampleUnitTest
{
    // make unit test on plain C# class
    public class SampleGroup
    {
        // all public methods are automatically registered in test group
        public void SumTest()
        {
            var x = int.Parse("100");
            var y = int.Parse("200");

            // using RuntimeUnitTestToolkit;
            // 'Is' is Assertion method, same as Assert(actual, expected)
            (x + y).Is(300);
        }

        // return type 'IEnumerator' is marked as async test method
        public IEnumerator AsyncTest()
        {
            var testObject = new GameObject("Test");

            // wait asynchronous coroutine(If import UniRx, you can use MainThreadDispatcher.StartCoroutine)
            var e = MoveToRight(testObject);
            while (e.MoveNext())
            {
                yield return null;
            }

            // assrtion
            testObject.transform.position.x.Is(60);

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