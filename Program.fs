// Learn more about F# at http://fsharp.org

open System
open System.Device.Gpio
open System.Threading

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let controller = new GpioController(PinNumberingScheme.Logical)
    let pin = 17
    let lightTime = 300

    controller.OpenPin(pin, PinMode.Output)
    try
        while true do
            controller.Write(pin, PinValue.High)
            Thread.Sleep(lightTime)
            controller.Write(pin, PinValue.Low)
            Thread.Sleep(lightTime)
    finally
        controller.Write(pin, PinValue.Low)
        controller.ClosePin(pin)

    0 // return an integer exit code
