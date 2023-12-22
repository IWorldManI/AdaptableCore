using System;
using Plugin;

public class TestDll : IPlugin
{
    public void PerformAction()
    {
        Console.WriteLine(GetType() + " connected.");
    }
}