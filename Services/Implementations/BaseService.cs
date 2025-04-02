using RevendaApi.Data;
using System;

namespace RevendaApi.Services.Implementations;

public abstract class BaseService
{
    protected Lazy<AppDbContext> DbContext;

    public BaseService(BaseServiceParams baseParams)
    {
        DbContext = baseParams.DbContext;
    }
}

public class BaseServiceParams
{
    public BaseServiceParams(Lazy<AppDbContext> dbContext)
    {
        DbContext = dbContext;
    }

    public Lazy<AppDbContext> DbContext { get; }
}
