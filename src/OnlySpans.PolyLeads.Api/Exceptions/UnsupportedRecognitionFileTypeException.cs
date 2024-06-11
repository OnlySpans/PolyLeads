namespace OnlySpans.PolyLeads.Api.Exceptions;

public sealed class UnsupportedRecognitionFileTypeException : ApiException
{
    public UnsupportedRecognitionFileTypeException(string? mimeType) :
        base($"Файл с типом {mimeType} не поддерживается для распознавания") { }
}