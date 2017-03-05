RuntimeUnitTestToolkit
===
Unity unit test framework forcused on run play time and actual machine

![image](https://cloud.githubusercontent.com/assets/46207/23584717/4590d63e-01ad-11e7-8fe2-1dfcd83d06db.png)

Why needs this?
---
[Presentation Slide - RuntimeUnitTestToolkit for Unity](https://www.slideshare.net/neuecc/runtimeunittesttoolkit-for-unityenglish)

Unity Unit Test is not supported runtime unit test. IL2CPP or other machine specific issue is a serious issue. We should check it.

How to use?
---
get `.unitypackage` on [releases](https://github.com/neuecc/RuntimeUnitTestToolkit/releases) page.

Open `RuntimeUnitTestToolkit/UnitTest.scene`, it is test explorer.

Write first test class.

```csharp
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

        // wait asynchronous coroutine(UniRx coroutine runnner)
        yield return MainThreadDispatcher.StartCoroutine(MoveToRight(testObject));

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
            o.transform.position =  p;
            yield return null;
        }
    }
}
```

finally register test classes on test manager

```csharp
public static class UnitTestLoader
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Register()
    {
        // setup created test class to RegisterAllMethods<T>
        UnitTest.RegisterAllMethods<SampleGroup>();
     
        // and add other classes
    }
}
```

play UnitTest scene

![image](https://cloud.githubusercontent.com/assets/46207/23584863/79d6023a-01b1-11e7-86a5-b5d4cd0eaa53.png)


Assertion API
---

Standard API(static Assert methods)

* Assert.AreEqual
* Assert.AreNotEqual
* Assert.IsTrue
* Assert.IsNull
* Assert.IsNotNull
* Assert.Fail
* Assert.AreSame
* Assert.AreNotSame
* Assert.IsInstanceOfType
* Assert.IsNotInstanceOfType
* Assert.Catch
* Assert.Throws
* Assert.DoesNotThrow
* CollectionAssert.AreEqual
* CollectionAssert.AreNotEqual

Extension API(extension methods of object)  
These api makes standard api to fluent sytnax  
`AssertAreEqual(actual, expected)` -> `actual.Is(expected)`.

* Is
* IsCollection
* IsNot
* IsNotCollection
* IsEmpty
* IsNull
* IsNotNull
* IsTrue
* IsFalse
* IsSampeReferenceAs
* IsNotSampeReferenceAs
* IsInstanceOf
* IsNotInstanceOf

These API is port of [neuecc/ChainingAssertion](https://github.com/neuecc/ChainingAssertion)

with UniRx
---
[UniRx](http://github.com/neuecc/UniRx/) helps Unit test easily. event as `IObservable<T>`,  `ObserveOnEveryValueChanged`, `ObservableTriggers` can watch test target's state from outer environment.

```csharp
public IEnumerator WithUniRxTestA()
{
    // subscribe event callback
    var subscription = obj.SomeEventAsObservable().First().ToYieldInstruction();

    // raise event 
    obj.RaiseEventSomething();

    // check event raise complete
    yield return subscription;

    subscription.Result.Is();
}

public IEnumerator UniRxTestB()
{
    // monitor value changed
    var subscription = obj.ObserveEveryValueChanged(x => x.someValue).Skip(1).First().ToYieldInstruction();

    // do something
    obj.DoSomething();

    // wait complete
    yield return subscription;

    subscription.Result.Is();
}
```

Author Info
---
Yoshifumi Kawai(a.k.a. neuecc) is a software developer in Japan.  
He is the Director/CTO at Grani, Inc.  
He is awarding Microsoft MVP for Visual C# since 2011.  
He is known as the creator of [UniRx](http://github.com/neuecc/UniRx/)(Reactive Extensions for Unity)  

Blog: https://medium.com/@neuecc (English)  
Blog: http://neue.cc/ (Japanese)  
Twitter: https://twitter.com/neuecc (Japanese)   

License
---
This library is under the MIT License.