# Signalization

This module defines how to

- send
- receive

data for user's

- input
- output

in XR applications.

## Dependencies

Nothing.

## Architecture

| Word | Description |
|:-|:-|
| Signal | Data for user's input/output in applications. |
| Consumption | Receives `Signal`. |
| Production | Sends `Signal` to each of `Consumption`. |
| Cancellation | Token to stop sending. |
| Propagation | Collects `Consumption` to distribute `Signal`. |

`Consumption` receives `Signal` for interaction between devices and systems.
`Production` sends `Signal` to each of `Consumption`.
When `Production` starts to send, it provides `Cancellation` token to stop sending.

`Propagation` is `Consumption` and `Production`.
When `Propagation` receives `Signal`, it distributes `Signal` to each `Consumption`.

![Image not found.](./Resources/Signalization.jpg "Architecture of Signalization.")

## Implementation

Nothing.
