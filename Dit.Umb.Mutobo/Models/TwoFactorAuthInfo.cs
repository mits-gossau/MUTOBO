using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dit.Umb.Mutobo.Models
{
    public class TwoFactorAuthInfo
    {
        public string Secret { get; set; }
        public string Email { get; set; }
        public string ApplicationName { get; set; }

        public string QrCodeSetupImageUrl { get; set; }
    }
}
