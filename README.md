To get started with the Sailing Backend, first rename `example.config.json` to `config.json` and fill in the appropriate database credentials. 
On first startup, and after every update, the application should be ran in Migration mode. In your favorite IDE, you can select the `SailingBackend (Migrate)` or `IIS Express (Migrate)` option and run the application.
Alternatively, when you're running the application from a commandline, you can run it like so:
Windows: `SailingBackend.exe --migrate`
Mac & Linux: `dotnet run SailingBackend.dll --migrate`
When running in a production environment, you need to manually specify the host and port. For example: `SailingBackend.exe --urls http://0.0.0.0:80 --migrate`