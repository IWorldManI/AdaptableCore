using System;
using Plugin;

public class TestConsoleApp : IPlugin
{
    static void Main()
    {
        TestConsoleApp testConsole = new TestConsoleApp();
        testConsole.PerfomanceAction();
    }

    public void PerfomanceAction()
    {
        Console.WriteLine(GetType() + " connected.");
    }
}