using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace controller.Models
{
   
    [Serializable]
    public class GioHangItem
    {
        public MENU monAn { get; set; }

        public int sO_LUONG { get; set; }

        internal object SingleOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}