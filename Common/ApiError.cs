using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TulparResponses.v1.Common
{
    public class ApiError
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

        public ApiError(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }       
}
