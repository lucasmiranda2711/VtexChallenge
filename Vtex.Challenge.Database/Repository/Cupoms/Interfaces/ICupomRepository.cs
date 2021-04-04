using System;
using System.Collections.Generic;
using Vtex.Challenge.Domain.Model.Cupoms;

namespace Vtex.Challenge.Database.Repository.Cupoms.Interfaces
{
    public interface ICupomRepository
    {
        Cupom FindById(Guid id);
        IList<Cupom> FindAll();
    }
}
