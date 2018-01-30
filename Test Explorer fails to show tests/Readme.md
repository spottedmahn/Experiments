## Repro for Test Explorer fails to show tests

Reference: [GitHub Issue](https://github.com/Microsoft/testfx/issues/241)

1. Create a Class Library (full framework v4.6.2)
1. Add a nuget reference to [System.Runtime v4.3.0](https://www.nuget.org/packages/System.Runtime/4.3.0)
   1. **This is the key** to getting Visual Studio to generate the app.config that breaks the tests from being discoverable
1. Create a sample method that will be called in your tests
   ```csharp
    public static string GetString()
    {
        return "hello world";
    }
   ```
1. Create Test Project
1. Add a reference to the Class Library
5. Create a test against `GetString()`
1. Verify the test is discoverable and passes
1. Add a Nuget reference to [Moq v4.8.1](https://www.nuget.org/packages/Moq/4.8.1)
1. Build test project
1. Verify the test is no longer discoverable
1. Verify test output window says
    >The given assembly name or codebase was invalid. (Exception from HRESULT: 0x80131047)
