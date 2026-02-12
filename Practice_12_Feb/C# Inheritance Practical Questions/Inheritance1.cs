// 1. Create a simple base class `Animal` with a method
//   `Speak()`. Derive a `Dog` class that overrides it

using System;
class Animal{
    public virtual void Speak(){
        Console.WriteLine("Animal makes a sound");
    }
}

class Dog : Animal{
    public override void Speak()
    {
        Console.WriteLine("Dog barks");
    }
}


public class Program
{
    public static void Main()
    {
        Animal a = new Animal();
        a.Speak();

        Animal d = new Dog();
        d.Speak(); 
    }
}
