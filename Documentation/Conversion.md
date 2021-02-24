# Conversion

Conversion extends [Signalization](./Signalization.md) to define how to operate `Signal`.

## Dependencies

This module depends on [Signalization](./Signalization.md).

## Architecture

| Word | Abstraction |
|:-----------|:------------|
| Translation | Converts one `Signal` to another `Signal`. |
| Correction | Calculates `Signal` to correct. |
| Calculation | Reduces `Signal`. |
| Detection | Detects `Signal`. |
| Pulse | `Signal` to send when `Signal` is detected. |

This module provides operations on `Signal` below.

- `Translation`
- `Correction`
- `Detection`

## Implementation

Nothing except internal implementation for some interfaces of [Signalization](./Signalization.md), because this module only defines how to operate `Signal`.
