using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vtex.Challenge.Database.Repository.Cupoms.Interfaces;
using Vtex.Challenge.Domain.Model.Cupoms;

namespace Vtex.Challenge.Application.Services.Cupoms
{
    public class CupomService : ICupomService
    {
        ICupomRepository CupomRepository;

        public CupomService(ICupomRepository cupomRepository)
        {
            CupomRepository = cupomRepository;
        }

        public async Task<IList<Guid>> GetAllCupoms()
        {
            return CupomRepository.FindAll()
                .Select(cupom=> cupom.Id).ToList();
        }

        public async Task<Cupom> GetCupom(Guid id)
        {
            return CupomRepository.FindById(id);
        }
    }
}
