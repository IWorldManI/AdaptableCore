using System;
using Plugin;

public class TestConsoleApp : IPlugin
{
    static void Main()
    {
        TestConsoleApp testConsole = new TestConsoleApp();
        testConsole.PerformAction();
    }

    public void PerformAction()
    {
        Console.WriteLine(GetType() + " connected.");
    }
}