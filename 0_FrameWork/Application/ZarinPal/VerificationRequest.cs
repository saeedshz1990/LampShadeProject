using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_FrameWork.Application.ZarinPal
{
    public class VerificationRequest
    {
        public int Amount { get; set; }
        public string MerchantID { get; set; }
        public string Authority { get; set; }
    }
}
