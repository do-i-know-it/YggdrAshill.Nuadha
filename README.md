# YggdrAshill.Nuadha: a device system framework

Nuadha provides how to isolate definitions and implementations for device system.  
This framework supports your XR (VR/AR/MR) application to be convertible in any platforms or devices.  
You can develop your application for

- Oculus store
- Steam VR
- anything else

by implementing interfaces included in this framework for above.  

<!-- ## Specifications

Now writing...

### Normal scenarios

Now writing...

### Abnormal scenarios

Now writing... -->

## Dependencies

Nuadha depends on

- Now writing...

## Installation

In future, we will deploy dlls built to this repository, but now you should

1. Clone this repository.
1. Open cloned directory with Visual Studio.
1. Build for any CPU as Debug or Release.
1. Include built dlls to your project.

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
- [Implementation](./Documentation/Implementation.md)

### Implementation

Nuadha provides no implementations for specific

- devices
- runtimes
- game engines

because it only defines how to isolate device from system.

## Known issues

Nothing now.

## Future works

### ~ Version 1.0.0

- Sets up build pipeline.
  - auto testing
  - auto building
- Writes documents completely.
  - [Conversion](./Documentation/Conversion.md)
  - [Unitization](./Documentation/Unitization.md)
  - [Signals](./Documentation/Signals.md)
  - [Units](./Documentation/Units.md)
  - [Implementation](./Documentation/Implementation.md)
  - samples
  - templates for Pull requests, issue, and contributing guidelines.
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

Nuadha is a part of the framework of YggdrAshill.  
We will produce other frameworks for YggdrAshill.
