using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vtex.Challenge.Domain.Model.Cupoms;

namespace Vtex.Challenge.Application.Services.Cupoms
{
    public interface ICupomService
    {
        Task<Cupom> GetCupom(Guid id);
        Task<IList<Guid>> GetAllCupoms();
    }
}
