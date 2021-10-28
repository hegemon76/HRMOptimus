using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Common.Interfaces
{
    public interface IHRMOptimusDbContext
    {
        // DbSet<Project> Projects { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}