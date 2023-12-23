using Sawnet.Cli;
using Spectre.Console;
using Spectre.Console.Cli;

var app = new CommandApp(CliConfigurator.BuildTypeRegistrar());

app.Configure(config =>
{
    config.PropagateExceptions();
    config.ConfigureApplication();
});

try
{
    return app.Run(args);
}
catch (Exception ex)
{
    DisplayException(ex);
    return -99;
}

static void DisplayException(Exception ex)
{
    AnsiConsole.MarkupLine("[red]Error:[/] {0}", ex.Message);

    if (ex.InnerException != null)
    {
        AnsiConsole.MarkupLine("[red]Inner Error:[/] {0}", ex.InnerException.Message);
    }

#if DEBUG
    WriteExceptionDetailsIfNotNull(ex);
    WriteExceptionDetailsIfNotNull(ex.InnerException);
#endif
}

static void WriteExceptionDetailsIfNotNull(Exception exception)
{
    if (exception is not null)
    {
        AnsiConsole.WriteLine();
        AnsiConsole.WriteException(exception, ExceptionFormats.ShortenEverything);
    }
}