# YggdrAshill.Nuadha: a device management framework

[![Deployment](https://github.com/do-i-know-it/YggdrAshill.Nuadha/actions/workflows/Deployment.yml/badge.svg)](https://github.com/do-i-know-it/YggdrAshill.Nuadha/actions/workflows/Deployment.yml)
[![GitHub](https://img.shields.io/github/license/do-i-know-it/YggdrAshill.Nuadha)](https://github.com/do-i-know-it/YggdrAshill.Nuadha/blob/main/LICENSE.md)
[![GitHub Release Date](https://img.shields.io/github/release-date/do-i-know-it/YggdrAshill.Nuadha)](https://github.com/do-i-know-it/YggdrAshill.Nuadha/releases)
![GitHub repo size](https://img.shields.io/github/repo-size/do-i-know-it/YggdrAshill.Nuadha)
![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/do-i-know-it/YggdrAshill.Nuadha)

Nuadha is a framework defining how to

- send
- receive
- convert
- detect

I/O data of applications, for mainly XR (VR/AR/MR).  
This framework is able to isolate definitions from implementations for specific platforms like:

- [Unity](https://unity.com/ja)
- [Xamarin](https://docs.microsoft.com/ja-jp/xamarin/get-started/what-is-xamarin)
- [Windows Presentation Foundation (WPF)](https://docs.microsoft.com/ja-jp/visualstudio/designers/getting-started-with-wpf?view=vs-2019)
- [Oculus Store](https://www.oculus.com/)
- [Steam VR](https://store.steampowered.com/steamvr)

## Dependencies

This framework depends on [.NET Standard](https://docs.microsoft.com/ja-jp/dotnet/standard/net-standard) 2.1.

## Installation

Developers should

1. Go to [release pages](https://github.com/do-i-know-it/YggdrAshill.Nuadha/releases).
1. Download DLLs in the latest version.
1. Put the DLLs in C# projects.

to use this framework.

## Usage

Please see [sample applications](https://github.com/do-i-know-it/YggdrAshill.Nuadha/blob/main/YggdrAshill.Nuadha.Samples).

## Architecture

Now writing...

## Known issues

Please see [issues](https://github.com/do-i-know-it/YggdrAshill.Nuadha/issues).

## Future works

Please see [GitHub Project for road map](https://github.com/do-i-know-it/YggdrAshill.Nuadha/projects/1).

- Adds definitions for Signals.
  - ex) Touch
  - ex) Push
  - ex) Pull
  - ex) Tilt
  - ex) Battery
  - ex) MemoryUsage
  - ex) Blink
  - ex) Pupil
  - ex) Vibration
  - ex) Button
  - ex) Trigger
  - ex) Stick
- Adds contributing guidelines.

## License

This framework is under the MIT License, see [LICENSE](./LICENSE.md).

## Remarks

This framework is a part of YggdrAshill framework.
We also provides framework below.

- [YggdrAshill.Ragnarok](https://github.com/do-i-know-it/YggdrAshill.Ragnarok)
- [YggdrAshill.Unity](https://github.com/do-i-know-it/YggdrAshill.Unity)
