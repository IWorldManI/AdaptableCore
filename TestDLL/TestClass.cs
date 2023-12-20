using System;
using Plugin;

public class TestDll : IPlugin
{
    public void PerfomanceAction()
    {
        Console.WriteLine(GetType() + " connected.");
    }
}