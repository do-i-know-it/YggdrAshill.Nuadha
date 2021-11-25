# Signals

This module extends

- [Signalization](./Signalization.md)
- [Unitization](./Unitization.md)
- [Transformation](./Transformation.md)

to define how to

- generate
- convert

`Signal`.

## Dependencies

This module depends on below.

- [Signalization](./Signalization.md)
- [Unitization](./Unitization.md)
- [Transformation](./Transformation.md)

## Architecture

| Word | Description |
|:-|:-|
| Emission | Token to send `Signal`. |
| Generation | Creates `Signal`. |
| Transmission | `Connection` to emit. |
| Calibration | Calibrates `Signal` to correct. |
| Filtration | Filtrates `Signal` to correct. |

`Emission` is token to send `Signal`.
`Generation` is how to generate `Signal` to convert `Transmission` that is `Emission` and `Production`.

`Transmission` is `Emission` and `Connection`.
Every time `Transmission` Emits,  it sends `Signal`s to each of connected `Module`s.

`Calibration` and `Filtration` is `Translation` of `Signal`.
`Calibration` calibrates `Signal` to correct, and `Filtration` filtrates `Signal` to correct.

## Implementation

This module has internal implementations for

- [Signalization](./Signalization.md)
- [Transformation](./Transformation.md)

in order to provide features of it.
