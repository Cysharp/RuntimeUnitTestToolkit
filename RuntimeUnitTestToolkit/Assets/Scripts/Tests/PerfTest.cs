using NUnit.Framework;
using Unity.PerformanceTesting;
using UnityEngine;

namespace SampleUnitTest
{
    public class PerfTest
    {
        AnotherClass another;
        string anotherJson;

        public PerfTest()
        {
            another = new AnotherClass();
            anotherJson = JsonUtility.ToJson(another);
        }

        [Test, Performance]
        public void DummySerialize()
        {
            Measure.Method(() =>
            {
                JsonUtility.ToJson(another);
            })
            .WarmupCount(10)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(10)
            .Run();
        }

        [Test, Performance]
        public void DummyDeserialize()
        {
            Measure.Method(() =>
            {
                JsonUtility.FromJson<AnotherClass>(anotherJson);
            })
            .WarmupCount(10)
            .IterationsPerMeasurement(10000)
            .MeasurementCount(10)
            .Run();
        }
    }
}