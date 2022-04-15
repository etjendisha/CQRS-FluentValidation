using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Parameters
{
    public class RequestParameter
    {
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public RequestParameter()
        {
            this.pageNumber = 1;
            this.pageSize = 10;
        }
        public RequestParameter(int pageNumber, int pageSize)
        {
            this.pageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.pageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
