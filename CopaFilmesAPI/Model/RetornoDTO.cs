using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CopaFilmesAPI.Model
{
    public class RetornoDTO<T>
    {
        public Exception MainException { get; set; }
        public T Data { get; set; }
        public List<T> DataList { get; set; }
        public bool Success => MainException == null;
    }
}
