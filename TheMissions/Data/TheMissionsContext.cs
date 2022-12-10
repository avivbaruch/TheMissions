using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheMissions.MissionModel;

namespace TheMissions.Data
{
    public class TheMissionsContext : DbContext
    {
        public TheMissionsContext (DbContextOptions<TheMissionsContext> options)
            : base(options)
        {
        }

        public DbSet<TheMissions.MissionModel.MissionsModel> MissionsModel { get; set; } = default!;
    }
}
