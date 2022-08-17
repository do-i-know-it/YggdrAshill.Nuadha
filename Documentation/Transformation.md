# Transformation

This module extends [Signalization](./Signalization.md) to define how to transform `Signal`.

## Dependencies

This module depends on [Signalization](./Signalization.md).

## Architecture

| Word | Description |
|:-|:-|
| Conversion | Converts one `Signal` to another `Signal`. |
| Detection | Detects `Signal`. |
| Pulse | `Signal` to send when `Signal` is detected. |

This module provides operations like:

- converting one `Signal` into another `Signal`.
- detecting `Pulse` when one `Signal` is detected.

## Implementation

This module has internal implementations for [Signalization](./Signalization.md) define how to:

- produce `Signal` converted.
- consume `Signal` to convert.
- produce `Pulse` detected from `Signal`.
- consume `Signal` to detect `Pulse`.
