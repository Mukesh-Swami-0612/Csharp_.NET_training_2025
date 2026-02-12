//Create a `Vehicle` class with `StartEngine()`. Extend it to `Car` and `Motorcycle` with different behaviors.
using System;
class Vehicle {
    public virtual void StartEngine() {
        Console.WriteLine("Vehicle");
    }
}
class Car : Vehicle {
    public override void StartEngine() {
        Console.WriteLine("Car");
    }
}
class Motorcycle : Vehicle {
    public override void StartEngine() {
        Console.WriteLine("Motorcycle");
    }
}
class Program {
    static void Main() {
        Vehicle v1 = new Car();
        v1.StartEngine();
        
        Vehicle v2 = new Motorcycle();
        v2.StartEngine();
    }
}
