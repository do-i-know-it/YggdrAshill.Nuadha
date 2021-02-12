# Signalization

Signalization defines how to send and receive data for I/O in an application.

## Dependencies

Nothing.

## Architecture

![Image not found.](./Resources/Signalization.jpg "Architecture of Signalization.")

| Word | Abstraction |
|:-----------|:------------|
| Signal | Data for I/O. |
| Emission | Token to send `Signal`. |
| Consumption | Receiver of `Signal`. |
| Production | Sender of `Signal`. |

`Consumption` consumes `Signal` for interaction between your system and users of your system.  
`Production` produces `Emission` token to send `Signal` to `Consumption`.  
Every time `Emission` token is executed, generated `Signal` is sent to `Consumption`.

## Implementation

Nothing because this module only defines how to send and receive `Signal`.
