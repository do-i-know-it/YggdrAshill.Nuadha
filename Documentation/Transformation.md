# Transformation

This module extends [Signalization](./Signalization.md) to define how to operate `Signal`.

## Dependencies

This module depends on [Signalization](./Signalization.md).

## Architecture

| Word | Description |
|:-|:-|
| Conversion | Converts one `Signal` to another `Signal`. |
| Pulse | `Signal` to explain state of `Signal` change. |
| Detection | Detects `Signal`. |
| Notice | `Signal` to send when `Signal` is detected. |
| Note | `Signal` to describe value of `Signal`. |

This module provides operations on `Signal` like:

- converting one `Signal` into another `Signal`.
- detecting `Notice` when one `Signal` is detected.

## Implementation

This module has internal implementations for [Signalization](./Signalization.md) in order to provide features of it.
