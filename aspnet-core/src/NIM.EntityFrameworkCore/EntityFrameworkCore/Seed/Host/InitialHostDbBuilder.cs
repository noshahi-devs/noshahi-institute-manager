namespace NIM.EntityFrameworkCore.Seed.Host;

public class InitialHostDbBuilder
{
    private readonly NIMDbContext _context;

    public InitialHostDbBuilder(NIMDbContext context)
    {
        _context = context;
    }

    public void Create()
    {
        new DefaultEditionCreator(_context).Create();
        new DefaultLanguagesCreator(_context).Create();
        new HostRoleAndUserCreator(_context).Create();
        new DefaultSettingsCreator(_context).Create();

        _context.SaveChanges();
    }
}
