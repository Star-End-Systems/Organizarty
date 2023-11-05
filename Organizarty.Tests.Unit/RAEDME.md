# Organizarty Unit Tests

- Run tests
    ```sh
    dotnet test
    ```

- Get Coverage Metrics (in root dir)
    ```sh
    dotnet-coverage collect -o coverage.xml -f xml -s coverage.runsettings dotnet test
    reportgenerator -reports:coverage.xml -targetdir:coveragereport -reporttypes:Html
    ```

> After running, open the `coveragereport/index.html`
