using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeague.Models.ViewModels
{
    public class PageNumberingInfo
    {
        public int NumPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalNum { get; set; }

        //calculate number of pages
        public int NumPages => (int) (Math.Ceiling((decimal) TotalNum / NumPerPage));
    }
}
