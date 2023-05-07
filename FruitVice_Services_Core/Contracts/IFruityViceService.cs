using FruitVice_API_Services_Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitVice_Services_Core.Contracts
{
    public interface IFruityViceService 
    {
        Task<List<FruityViceResponseModel>> GetAllFruitsCollection();
        Task<List<FruityViceResponseModel>> GetAllFruitsByFamily(string family);


    }
}
