# Unitization

This module extends [Signalization](./Signalization.md) to define how to connect hardware to software.

## Dependencies

This module depends on [Signalization](./Signalization.md).

## Architecture

| Word | Description |
|:-|:-|
| Module | Provides `Production` or `Consumption`. |
| Connection | Connects `Module` to send and receive `Signal`. |
| Hardware | Sends `Signal` device generated and receives `Signal` system generated. |
| Software | Receives `Signal` device generated and sends `Signal` system generated. |
| Protocol | Defines `Module` for `Hardware` and `Software`. |

`Module` defines a interface providing `Production` or `Consumption`.
`Connection` enables `Module` to send and receive `Signal`.

![Image not found.](./Resources/Unitization.jpg "Architecture of Unitization.")

## Implementation

Nothing.
