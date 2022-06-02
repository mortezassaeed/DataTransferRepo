using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SQL.Repositories
{
    public interface IDataRepository
    {
        Task SaveAsync(string value);
    }
}
