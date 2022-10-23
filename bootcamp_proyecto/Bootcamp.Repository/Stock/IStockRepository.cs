using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Repository.Stock
{
    public interface IStockRepository
    {
        Task<int> Create(Model.Stock stock);

        Task<int> Update(Model.Stock stock);

        Task<int> Delete(int id);
    }
}
