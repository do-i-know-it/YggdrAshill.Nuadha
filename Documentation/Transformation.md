# Transformation

This module extends [Signalization](./Signalization.md) to define how to operate`Signal`.

## Dependencies

This module depends on [Signalization](./Signalization.md).

## Architecture

| Word | Abstraction |
|:-----------|:------------|
| Conversion | Converts one `Signal` to another `Signal`. |
| Pulse | `Signal` to explain state of `Signal` change. |
| Detection | Detects `Signal`. |
| Notice | `Signal` to send when `Signal` is detected. |

This module provides operations on `Signal` below.

- `Conversion`
  - Converts `Production` for one `Signal` into that for other `Signal`.
- `Detection`
  - Converts `Production` for one `Signal` into that for `Notice` when `Signal` is detected.

## Implementation

Nothing except internal implementation for some interfaces of [Signalization](./Signalization.md), because this module only defines how to operate `Signal`.
