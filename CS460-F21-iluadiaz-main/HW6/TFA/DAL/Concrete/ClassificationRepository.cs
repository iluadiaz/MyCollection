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
            ctx = _ctx;
        }
    }
}
