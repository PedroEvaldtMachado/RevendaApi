using Microsoft.EntityFrameworkCore;
using RevendaApi.Data;
using System;

namespace RevendaApi.Querys.Implementations;

public abstract class BaseQuery
{
    protected Lazy<NoTrackingDbContext> DbContext;

    protected BaseQuery(BaseQueryParams baseParams)
    {
        baseParams.DbContext.Value.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTrackingWithIdentityResolution;
        DbContext = baseParams.DbContext;
    }
}

public class BaseQueryParams
{
    public BaseQueryParams(Lazy<NoTrackingDbContext> dbContext)
    {
        DbContext = dbContext;
    }
    public Lazy<NoTrackingDbContext> DbContext { get; }
}
