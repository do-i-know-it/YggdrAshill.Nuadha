# Signalization

This module defines how to

- generate
- send
- receive

data for user's input/output in XR applications.

## Dependencies

Nothing.

## Architecture

![Image not found.](./Resources/Signalization.jpg "Architecture of Signalization.")

| Word | Abstraction |
|:-----------|:------------|
| Signal | Data for user's input/output. |
| Consumption | Receives `Signal`. |
| Production | Sends `Signal` to `Consumption`. |
| Cancellation | Token to stop producing. |
| Propagation | Collects `Consumption` to distribute `Signal`. |
| Emission | Token to send `Signal`. |
| Transmission | Collects `Consumption` to send `Signal`. |
| Generation | Creates `Signal`. |

`Consumption` receives `Signal` for interaction between devices and systems.
`Production` sends `Signal` to each of `Consumption`.
When `Production` starts to send, it provides `Cancellation` token to stop sending.

`Propagation` is `Consumption` and `Production`.
When `Propagation` receives `Signal`, it distributes `Signal` to each `Consumption`.

`Emission` is token to send `Signal`, and `Generation` is how to generate `Signal`.
`Transmission` is `Emission` and `Production`.
It has the `Generation`, so every time `Transmission` Emits, `Generation` generates `Signal`, then it sends `Signal` to each of `Consumption`.

## Implementation

Nothing because this module only defines how to

- generate
- send
- receive

`Signal`.
