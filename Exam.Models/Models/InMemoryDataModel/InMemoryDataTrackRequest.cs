using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models.Models.InMemoryDataModel
{
    public class InMemoryDataTrackRequest
    {

        public int TId { get; set; }
        public string TrackingNum { get; set; }
        public string Type { get; set; }
        public int status { get; set; }

    }
}
