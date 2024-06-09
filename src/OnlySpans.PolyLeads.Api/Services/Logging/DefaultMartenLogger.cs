using Marten;
using Marten.Services;
using Npgsql;

namespace OnlySpans.PolyLeads.Api.Services.Logging;

public sealed class DefaultMartenLogger :
    IMartenSessionLogger,
    IMartenLogger
{
    private readonly ILogger<IDocumentSession> _logger;

    public DefaultMartenLogger(ILogger<IDocumentSession> logger)
    {
        _logger = logger;
    }

    public void LogSuccess(NpgsqlCommand command)
    {
        LogSuccess(command.CommandText);
    }

    public void LogFailure(NpgsqlCommand command, Exception ex)
    {
        LogFailure(ex, command.CommandText);
    }

    public void LogSuccess(NpgsqlBatch batch)
    {
        foreach (var command in batch.BatchCommands)
            LogSuccess(command.CommandText);
    }

    public void LogFailure(NpgsqlBatch batch, Exception ex)
    {
        foreach (var command in batch.BatchCommands)
            LogFailure(ex, command.CommandText);
    }

    public void RecordSavedChanges(IDocumentSession session, IChangeSet commit)
    {
    }

    public void OnBeforeExecute(NpgsqlCommand command)
    {
    }

    public void OnBeforeExecute(NpgsqlBatch batch)
    {
    }

    public IMartenSessionLogger StartSession(IQuerySession session)
    {
        return this;
    }

    public void SchemaChange(string sql)
    {
        _logger.LogInformation("Executing change schema command \n{Sql}", sql);
    }

    private void LogSuccess(string commandText)
    {
        _logger.LogInformation(
            "Executing Marten command \n {CommandText}",
            commandText);
    }

    public void LogFailure(Exception exception, string commandText)
    {
        _logger.LogError(exception,
            "Failed to executed Marten command \n{CommandText}",
            commandText);
    }
}
