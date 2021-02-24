# Signalization

Signalization defines how to

- send
- receive

data for I/O in applications.

## Dependencies

Nothing.

## Architecture

![Image not found.](./Resources/Signalization.jpg "Architecture of Signalization.")

| Word | Abstraction |
|:-----------|:------------|
| Signal | Data for I/O. |
| Consumption | Receives `Signal`. |
| Production | Sends `Signal` to `Consumption`. |
| Emission | Token to send `Signal`. |
| Connection | Collects `Consumption`. |
| Disconnection | Token to disconnect. |
| Propagation | Distributes `Signal`. |

`Consumption` receives `Signal` for interaction between devices and systems.
`Production` produces `Emission` token that sends `Signal` to `Consumption`.
Every time `Emission` token is executed, generated `Signal` is sent to `Consumption`.

`Connection` collects `Consumption` to distribute `Signal` sent when `Emission` is executed.
When `Connection` connects to `Consumption`, it provides `Disconnection` token to disconnect `Consumption` from `Connection`.
`Propagation` is `Consumption` and `Connection`.
When `Propagation` consumes `Signal`, it distributes `Signal` to each connected `Consumption`.

## Implementation

Nothing because this module only defines how to

- send
- receive

`Signal`.
