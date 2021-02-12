# Conversion

Conversion expands [Signalization](./Signalization.md) and [Conduction](./Conduction.md) to define how to convert `Signal`.

## Dependencies

This module depends on

- [Signalization](./Signalization.md).
- [Conduction](./Conduction.md).

## Architecture

| Word | Abstraction |
|:-----------|:------------|
| Translation | Converts one `Signal` to another `Signal`. |
| Correction | Calculates `Signal` to correct. |
| Calculation | Reducer of `Signal`. |
| Detection | Decides `Signal`. |
| Pulse | `Signal` to send when `Signal` is detected. |

this module provides operations on `Signal` below.

- `Translation`
- `Correction`
- `Detection`

## Implementation

Nothing except internal implementation for some interfaces of [Signalization](./Signalization.md) and [Conduction](./Conduction.md), because this module only defines how to convert `Signal`.
