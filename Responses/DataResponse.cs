using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TulparResponses.v1.Common;

namespace TulparResponses.v1.Responses
{
    public class DataResponse<Tkey>
    {
        public string Message { get; set; } = string.Empty;

        public bool Success { get; set; } = false;

        public IEnumerable<ApiError>? Error { get; set; } = null;

        public Tkey Data { get; set; } = default!;

        public int StatusCode { get; set; } = 200;

        public bool AddError(ApiError err)
        {
            try
            {
                var errList = Error.ToList();

                errList.Add(err);

                Error = errList;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }          
    }
}
