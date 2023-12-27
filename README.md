# AdaptableCore

**AdaptableCore** is a C# console application designed for dynamically loading and executing plugins provided as DLL files.

---

## Description

The **AdaptableCore** project provides an example implementation of a plugin architecture in C#. The main functionality of the application involves dynamically loading libraries from a specified directory and executing actions provided by plugins.

---

## Project Structure

- **AdaptableCore**: Main code for the console application.
- **Plugin**: The `IPlugin` interface, which all plugins must implement.
- **TestConsoleApp**: Example plugin in the form of a console application.
- **TestDll**: Example plugin in the form of a DLL library.

---

## How to Use

1. **Build the Project**: Build the AdaptableCore project and ensure that the resulting application is in a directory where it has access to the "AdaptableDLL" folder.

2. **Create Plugins**:
   - Implement the `IPlugin` interface in your project.
   - Compile the project into a DLL.
   - Place the DLL file in the "AdaptableDLL" folder.

3. **Run the Application**: Run AdaptableCore.exe. The application will dynamically load and execute all plugins from the "AdaptableDLL" folder.

---

## Example Plugins

### TestConsoleApp

```csharp
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
```

### TestDll
```csharp
using System;
using Plugin;

public class TestDll : IPlugin
{
    public void PerformAction()
    {
        Console.WriteLine(GetType() + " connected.");
    }
}
```

### IPlugin
```csharp
public interface IPlugin
    {
        void PerformAction();
    }
```