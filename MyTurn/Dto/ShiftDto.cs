using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
   public class ShiftDto
    {
        public int id { get; set; }
        public int? idBranch { get; set; }
        public int? idService { get; set; }
        public int? MinTimeToCancel { get; set; }
        public decimal? PaymentforCancel { get; set; }
    }
}
