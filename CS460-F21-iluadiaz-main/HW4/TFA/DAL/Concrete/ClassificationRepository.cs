using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TFA.Models;
using TFA.DAL.Abstract;

namespace TFA.DAL.Concrete
{
    public class ClassificationRepository : Repository<Classification>, IClassificationRepository
    {
        private __TFADbContext _ctx;
        public ClassificationRepository(__TFADbContext ctx) : base(ctx)
        {
          _ctx = ctx;
        }
        public int lastId()
        {   
            if (!_ctx.Classifications.Any())
            {
                return 1;
            }
            else if (_ctx.Classifications.OrderByDescending(s => s.Id).First().Id >= 1)
            {
                int x = _ctx.Classifications.OrderByDescending(s => s.Id).First().Id;
                return x+1;
            }
            else return 1;
        }
    }
}
