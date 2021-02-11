# Signalization

This module defines how you send and receive data for I/O.

## Dependencies

Nothing.

## Architecture

![Image not found.](./Resources/Signalization.jpg "Architecture of Signalization.")

| Word | Abstraction |
|:-----------|:------------|
| Signal | Data to send. |
| Emission | Token to send Signal. |
| Consumption | Receiver of Signal. |
| Production | Sender of Signal. |

In this module, `Consumption` consumes `Signal` for interaction between your system and users of your system.  
`Production` produces `Emission` token to send `Signal` to `Consumption`.  
Every time `Emission` token is executed, generated `Signal` is sent to `Consumption`.

## Implementation

Nothing because this module defines only interfaces how you send and receive `Signal`.
