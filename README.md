RuntimeUnitTestToolkit
===
[![CircleCI](https://circleci.com/gh/Cysharp/RuntimeUnitTestToolkit.svg?style=svg)](https://circleci.com/gh/Cysharp/RuntimeUnitTestToolkit)

RuntimeUnitTestToolkit is the supplement of [Unity Test Runner](https://docs.unity3d.com/Manual/testing-editortestsrunner.html). Unity Test Runner works fine but player runner(any target platform) is very poor. RuntimeUnitTestToolkit provides CLI(for run on CI) and GUI(for run on any platforms(Windoes/Mac/iOS/Android/etc...)) frontend of Unity Test Runner. You can write test that work on Unity Test Runner, it also can build runtime player by RuntimeUnitTestToolkit.

![image](https://user-images.githubusercontent.com/46207/57200330-a04aae00-6fc5-11e9-82fa-39006fef583e.png)

Choose the settings(ScriptBackend - `Mono` or `IL2CPP`, BuildTarget, CLI(Headless) or GUI) and select `BuildUnitTest`.




![image](https://user-images.githubusercontent.com/46207/57200232-5b724780-6fc4-11e9-89ec-0e1ddbfc119b.png)


TODO:Moving to v2.

License
---
This library is under the MIT License.
