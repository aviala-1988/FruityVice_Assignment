using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.Entity;

namespace FruitVice_API_Services_Data
{
    public partial class DataContext : DbContext
    {
        DataTableDesign _TableDesign = new DataTableDesign();



        public Task<int> SaveChangesAsync(string currentUserName, CancellationToken cancellationToken = default(CancellationToken))
        {

            return SaveChangesAsync(cancellationToken);
        }


    }
}
