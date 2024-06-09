namespace OnlySpans.PolyLeads.Api.Utils;

public static class ApplicationRoleName
{
    public static IReadOnlyList<string> All { get; } =
        [Admin, Student, Headman, StudentUnionOrganizer];

    public const string Admin = "Admin";

    public const string Student = "Student";

    public const string Headman = "Headman";

    public const string StudentUnionOrganizer = "StudentUnionOrganizer";
}
