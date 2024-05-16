using Microsoft.EntityFrameworkCore;
using OnlySpans.PolyLeads.Api.Data.Contexts;
using OnlySpans.PolyLeads.Api.Exceptions;

namespace OnlySpans.PolyLeads.Api.Utils;

public static class UrlGuard
{
    public static async Task EnsureSourceIsPermittedAsync(
        ApplicationDbContext context,
        Uri sourceUrl,
        CancellationToken cancellationToken)
    {
        var permittedUrls = await context
            .PermittedSources
            .Select(x => x.BaseUrl)
            .ToListAsync(cancellationToken);

        if (permittedUrls.Any(x => x.IsBaseOf(sourceUrl))) return;

        throw new UnpermittedResourceException($"Ресурс {sourceUrl} не является доверенным");
    }
}