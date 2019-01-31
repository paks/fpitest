// Learn more about F# at http://fsharp.org

open System.Device.Gpio

let blinker pin lightTime = async {
    use controller = new GpioController(PinNumberingScheme.Logical)
    controller.OpenPin(pin, PinMode.Output)
    try
        while true do
            controller.Write(pin, PinValue.High)
            do! Async.Sleep(lightTime)
            controller.Write(pin, PinValue.Low)
            do! Async.Sleep(lightTime)
    finally
        controller.Write(pin, PinValue.Low)
        controller.ClosePin(pin)
}

[<EntryPoint>]
let main argv =
    printfn "Hello World from F# in a RaspberryPi!"
    let pin = 17
    let lightTime = 300

    Async.RunSynchronously <| blinker pin lightTime

    0 // return an integer exit code
