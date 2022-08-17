# Signals

This module extends

- [Signalization](./Signalization.md)
- [Transformation](./Transformation.md)
- [Conduction](./Conduction.md)

to define implementations of

- `Signal`.
- `Consumption`.
- `Conversion`.
- `Detection`.

## Dependencies

This module depends on below.

- [Signalization](./Signalization.md)
- [Transformation](./Transformation.md)
- [Conduction](./Conduction.md)

## Architecture

Nothing.

## Implementation

This module defines

- `Touch`
- `Push`
- `Pull`
- `Tilt`
- `Angle`
- `Space 2D position`
- `Space 2D rotation`
- `Space 2D pose`
- `Space 3D position`
- `Space 3D rotation`
- `Space 3D pose`
- `Button`
- `Trigger`
- `Stick`
- `Battery`
- `MemoryUsage`
- `Note`
- `Report`

as `Signal`.

Each of `Signal` may have implementations to

- convert from other `Signal`.
- convert into other `Signal`.
- detect `Pulse` of it.
- consume it.
