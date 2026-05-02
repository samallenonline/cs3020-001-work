/*
Practice using delegates and events
*/

using System;

// define a delegate 
public delegate void MyEventHandler(string message);

class Program
{
    // declare an event using the delegate 
    public static event MyEventHandler MyEvent;

    static void Main()
    {
        // subscribe to the event with a handler method 
        MyEvent += EventHandlerMethod;

        // raise the event by invoking it
        OnMyEvent("Hi, this is a custom event");

        // unsubscribe from the event (optional)
        MyEvent -= EventHandlerMethod;
    }

    // this methods handles an event 
    static void EventHandlerMethod(string message)
    {
        Console.WriteLine("Event received" + message);
    }
}