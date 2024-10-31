using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambdapractice
{
    internal class Booking
    {
        public int BookingNumber {  get; set; }
        public DateTime BookingDate { get; set; }
        public Movie Movie { get; set; }
        public byte CustomerAge {  get; set; }
    }
}
