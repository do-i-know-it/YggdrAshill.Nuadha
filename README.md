# YggdrAshill.Nuadha: a device system framework

Nuadha defines how to

- send
- receive
- convert

data for I/O of applications for mainly XR (VR/AR/MR).  
This framework is able to isolate definitions from implementations for specific platforms like below,

- ex) [Unity](https://unity.com/ja)
- ex) [Xamarin](https://docs.microsoft.com/ja-jp/xamarin/get-started/what-is-xamarin)
- ex) [Windows Presentation Foundation (WPF)](https://docs.microsoft.com/ja-jp/visualstudio/designers/getting-started-with-wpf?view=vs-2019)

or devices like below.

- ex) [Oculus store](https://www.oculus.com/)
- ex) [Steam VR](https://store.steampowered.com/steamvr)

## Dependencies

This framework depends on .NET Standard 2.0.

## Installation

Developers should

1. Go to [Release pages](https://github.com/do-i-know-it/YggdrAshill.Nuadha/releases).
1. Download the latest version.

to use this framework.

## Usage

Now writing samples for this framework.

## Architecture

This framework consists of core modules below.

- [Signalization](./Documentation/Signalization.md)
- [Transformation](./Documentation/Transformation.md)
- [Unitization](./Documentation/Unitization.md)

This framework also includes sub modules below.

- [Signals](./Documentation/Signals.md)
- [Units](./Documentation/Units.md)

### Implementation

This module includes [Implementation](./Documentation/Implementation.md) to provide implementations and extensions for above.

## Known issues

Please see [issues](https://github.com/do-i-know-it/YggdrAshill.Nuadha/issues).

## Future works

- Adds definitions for Signals.
  - ex) Blink
  - ex) Pupil
  - ex) Vibration
- Adds definitions for Units.
  - ex) Tablet
  - ex) Gamepad
  - ex) Eye tracker
  - ex) Face tracker
  - ex) Hand pose tracker
  - ex) Treadmill
- Adds contributing guidelines.

## License

This framework is under the MIT License, see [LICENSE](./LICENSE.txt).

## Remarks

This framework is a part of YggdrAshill framework.
Other frameworks will be produced soon for YggdrAshill.
