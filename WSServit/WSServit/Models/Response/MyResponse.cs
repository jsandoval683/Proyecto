using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WSServit.Models.Response
{
    public class MyResponse
    {
        public int Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public MyResponse()
        {
            this.Success = 0;
        }
    }
}
