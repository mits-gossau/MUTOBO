using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPoco;

namespace Dit.Umb.Mutobo.Models
{
    [TableName(Constants.TfaConstants.ProductName)]
    [PrimaryKey("userId", AutoIncrement = false)]
    public class TwoFactor
    {
        [Column("userId")]
        public int UserId { get; set; }

        [Column("key")]
        public string Key { get; set; }

        [Column("value")]
        public string Value { get; set; }

        [Column("confirmed")]
        public bool Confirmed { get; set; }
    }
}
