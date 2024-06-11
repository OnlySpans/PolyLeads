namespace OnlySpans.PolyLeads.Api.Data.Records;

public readonly record struct MaybeSet<T>
{
    /// <summary>
    /// The name value.
    /// </summary>
    public T? Value { get; init; }

    /// <summary>
    /// <c>true</c> if the optional was explicitly set.
    /// </summary>
    public bool WasSet { get; init; }

    /// <summary>
    /// Initializes a new instance of the <see cref="MaybeSet{T}"/> struct.
    /// </summary>
    /// <param name="value">The actual value.</param>
    public MaybeSet(T? value) : this(value, true) { }

    private MaybeSet(T? value, bool wasSet)
    {
        Value = value;
        WasSet = wasSet;
    }

    /// <summary>
    /// Provides the name string.
    /// </summary>
    /// <returns>The name string value</returns>
    public override string ToString()
    {
        return WasSet ? Value?.ToString() ?? "null" : "unspecified";
    }

    /// <summary>
    /// Implicitly creates a new <see cref="MaybeSet{T}"/> from
    /// the given value.
    /// </summary>
    /// <param name="value">The value.</param>
    public static implicit operator MaybeSet<T>(T value)
        => new(value);

    /// <summary>
    /// Implicitly gets the optional value.
    /// </summary>
    public static implicit operator T?(MaybeSet<T> maybeSet)
        => maybeSet.Value;
}