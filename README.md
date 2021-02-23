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

<!-- ## Specifications

Now writing...

### Normal scenarios

Now writing...

### Abnormal scenarios

Now writing... -->

## Dependencies

Nuadha depends on .NET Standard 2.0.

## Installation

Developers should

1. Go to [Release pages](https://github.com/do-i-know-it/YggdrAshill.Nuadha/releases).
1. Download the latest version.

to use this framework.

## Usage

Now writing samples for this framework.

## Architecture

Nuadha consists of core modules below.

- [Signalization](./Documentation/Signalization.md)
- [Conduction](./Documentation/Conduction.md)
- [Conversion](./Documentation/Conversion.md)
- [Unitization](./Documentation/Unitization.md)

This framework also includes sub modules below.

- [Signals](./Documentation/Signals.md)
- [Units](./Documentation/Units.md)

### Implementation

Nuadha includes [Implementation](./Documentation/Implementation.md) to provide implementations and extensions for above.

## Known issues

Please see [issues](https://github.com/do-i-know-it/YggdrAshill.Nuadha/issues).

## Future works

### ~ Version 1.0.0

- Adds contributing guidelines.
- Adds samples.
- Writes documents completely.
  - [Conversion](./Documentation/Conversion.md)
  - [Unitization](./Documentation/Unitization.md)
  - [Signals](./Documentation/Signals.md)
  - [Units](./Documentation/Units.md)
  - [Implementation](./Documentation/Implementation.md)
- Writes document comments in codes completely.
  - [Unitization](./Documentation/Unitization.md)
  - [Signals](./Documentation/Signals.md)
  - [Units](./Documentation/Units.md)
  - [Implementation](./Documentation/Implementation.md)
- Writes test codes for specification completely.
  - [Units](./Documentation/Units.md)
  - [Implementation](./Documentation/Implementation.md)
- Renames definitions for [Unitization](./Documentation/Unitization.md).
  - ex) HardwareHandler -> System
  - ex) SoftwareHandler -> Device
  - ex) InputDevice -> ???
  - ex) OutputSystem -> ???
- Renames definitions for [Units](./Documentation/Units.md).
  - ex) IXXXXDetectionHardwareHandler -> ???
  - ex) IXXXXDetectionSoftwareHandler -> ???

### Version 1.0.0 ~

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

## License

Nuadha is under the MIT License, see [LICENSE](./LICENSE.txt).

## Remarks

Nuadha is a part of YggdrAshill framework.
Other frameworks will be produced soon for YggdrAshill.
