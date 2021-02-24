# Unitization

Unitization defines how to connect device to system.

## Dependencies

This module depends on [Signalization](./Signalization.md).

## Architecture

![Image not found.](./Resources/Unitization.jpg "Architecture of Unitization.")

| Word | Abstraction |
|:-----------|:------------|
| Device | Connects `Software`. |
| Software | I/O interface for users. |
| System | Connects `Hardware`. |
| Hardware | I/O interface for applications. |

`Device` is an entity that users of applications operates, and connects `Software` interface to send and receive some types of `Signal`.

`System` is an application itself to interact to users, and connects `Hardware` interfaces.

## Implementation

Nothing because this module only defines how to connect device to system.
