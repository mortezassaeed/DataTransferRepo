using Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.SQL.Repositories
{
    internal class DataRespository : IDataRepository
    {
        private readonly IDbContextFactory<DatabaseContext> _contextFactory;
        public DataRespository(IDbContextFactory<DatabaseContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task SaveAsync(string value)
        {
            using var context = _contextFactory.CreateDbContext();
            var result = await context.Datas.AddAsync(new Data
            {
                Value = value
            });
            await context.SaveChangesAsync();
        }
    }
}
