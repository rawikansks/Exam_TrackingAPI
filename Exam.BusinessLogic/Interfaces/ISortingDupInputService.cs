using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Models.Models.SortingDupInputModel;

namespace Exam.BusinessLogic.Interfaces
{
    public interface ISortingDupInputService
    {
        List<SortingDupResponse> SortingDupInput(SortingDupRequest request);
    }
}
