namespace OnlySpans.PolyLeads.Api.Exceptions;

public sealed class UnsupportedRecognitionFileTypeException : ApiException
{
    public UnsupportedRecognitionFileTypeException(string? mimeType, Exception? innerException = null) :
        base($"Файл с типом {mimeType} не поддерживается для распознавания", innerException) { }
}
