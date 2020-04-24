RuntimeUnitTestToolkit(v2)
===
[![GitHub Actions](https://github.com/Cysharp/RuntimeUnitTestToolkit/workflows/Unity-Build/badge.svg)](https://github.com/Cysharp/RuntimeUnitTestToolkit/actions) [![Releases](https://img.shields.io/github/release/Cysharp/RuntimeUnitTestToolkit.svg)](https://github.com/Cysharp/RuntimeUnitTestToolkit/releases)

RuntimeUnitTestToolkit is the supplement of [Unity Test Runner](https://docs.unity3d.com/Manual/testing-editortestsrunner.html). Unity Test Runner works fine but player runner(any target platform) is very poor. RuntimeUnitTestToolkit provides CLI(for run on CI) and GUI(for run on any platforms(Windows, Mac, iOS, Android, etc...)) frontend of Unity Test Runner.

You can write test that work on Unity Test Runner, it also can build runtime player by RuntimeUnitTestToolkit.

![image](https://user-images.githubusercontent.com/46207/57200330-a04aae00-6fc5-11e9-82fa-39006fef583e.png)

Choose the settings(ScriptBackend - `Mono` or `IL2CPP`, BuildTarget, CLI(Headless) or GUI) and select `BuildUnitTest`.

![image](https://user-images.githubusercontent.com/46207/57200618-29afaf80-6fc9-11e9-8515-167076b2f4d8.png)

You can see the test result of CUI(Headless) player or

![image](https://user-images.githubusercontent.com/46207/57200784-d2aada00-6fca-11e9-8182-944abb963316.png)

GUI player on your built platforms.

The test is same as listed on Unity Test Runner's PlayMode tests.

![image](https://user-images.githubusercontent.com/46207/57200806-27e6eb80-6fcb-11e9-9d86-dfe6c7a854c6.png)

Target test allows asmdef's Test Assemblies so does not includes test files when standard build(but include when build by RuntimeUnitTestToolkit automatically).

On CI(use CLI(Headless) mode), if fail the test, shows red. You can notify to Slack or other communication tools by CI's integration.

![image](https://user-images.githubusercontent.com/46207/57200862-d12de180-6fcb-11e9-8353-5a897dd2c952.png)

You can also use GUI test on UnityEditor, choose `LoadUnitTestScene` and play.

![image](https://user-images.githubusercontent.com/46207/80211233-4af12c00-8670-11ea-9c7c-29fb43d3031c.png)

Install
---
`RuntimeUnitTestToolkit.*version*.unitypackage` on [releases](https://github.com/Cysharp/RuntimeUnitTestToolkit/releases) page or `package.json` exists on `RuntimeUnitTestToolkit/Assets/RuntimeUnitTestToolkit` for package manager.

After Unity 2019.3.4f1, Unity 2020.1a21, that support path query parameter of git package. You can add `https://github.com/Cysharp/RuntimeUnitTestToolkit.git?path=RuntimeUnitTestToolkit/Assets/RuntimeUnitTestToolkit` to Package Manager UI, or add `"com.cysharp.runtimeunittesttoolkit": "https://github.com/Cysharp/RuntimeUnitTestToolkit.git?path=RuntimeUnitTestToolkit/Assets/RuntimeUnitTestToolkit"` to `Packages/manifest.json`.

If you want to set a target version, RuntimeUnitTestToolkit is using *.*.* release tag so you can specify a version like `#2.3.0`. For example `https://github.com/Cysharp/RuntimeUnitTestToolkit.git?path=RuntimeUnitTestToolkit/Assets/RuntimeUnitTestToolkit#2.3.0`.

CommandLine Reference
---
For example, this library's CI(GitHub Actions) itself.

```yml
# Execute scripts: RuntimeUnitTestToolkit(Linux64/Mono2x)
- name: Build UnitTest(Linux64, mono)
  run: /opt/Unity/Editor/Unity -quit -batchmode -nographics -silent-crashes -logFile -projectPath . -executeMethod UnitTestBuilder.BuildUnitTest /headless /ScriptBackend Mono2x /BuildTarget StandaloneLinux64
  working-directory: RuntimeUnitTestToolkit

# Execute player:
- name: Execute UnitTest
  run: ./RuntimeUnitTestToolkit/bin/UnitTest/StandaloneLinux64_Mono2x/test
```

You can invoke `-executeMethod UnitTestBuilder.BuildUnitTest` and some options.

| Command        | Desc |
| ---            | ---  |
| **/headless**      | Boolean switch, build CLI mode. Default is false. |
| **/scriptBackend** ScriptingImplementation | Enum string(`Mono2x` or `IL2CPP` or `WinRTDotNET` )|
| **/buildTarget** BuildTarget   |Enum string(`StandaloneWindows64`, `StandaloneLinux64`, `StandaloneOSX`, `iOS`, `Android`, etc...) | 
| **/buildPath** FilePath    | String path. Default is `bin/UnitTest/{BuildTarget}_{ScriptBackend}/test`(If windows `test.exe`, Android `test.apk`, OSX `test.app`) |

You can pass by `/` prefix.

License
---
This library is under the MIT License.
