using System;
using System.Collections.Generic;
using System.Linq;
using Vtex.Challenge.Database.Repository.Cupoms.Interfaces;
using Vtex.Challenge.Domain.Model.Cupoms;

namespace Vtex.Challenge.Database.Repository.Cupoms
{
    public class CupomRepository : ICupomRepository
    {
        public static List<Cupom> Cupoms = new List<Cupom>() { new Cupom() { Name= "Freak Friday", Available = true, DiscountValue = 20, Id = Guid.NewGuid() }, 
            new Cupom() { Name= "Mega Month", Available = true, DiscountValue = 35, Id = Guid.NewGuid() }, 
            new Cupom() { Name= "Total Thursdays", Available = false, DiscountValue = 10, Id = Guid.NewGuid() } };

        public IList<Cupom> FindAll()
        {
            return Cupoms;
        }

        public Cupom FindById(Guid id)
        {
            return Cupoms.FirstOrDefault(cupom => cupom.Id == id);
        }
    }
}
