using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

namespace AdiddaClub.WebApi.Database
{
    public class ResultModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ErrorCode { get; set; }

        public ResultModel()
        {
            Success = false;
            Message = string.Empty;
            ErrorCode = "500";
        }

    }

    public class GetOneResult<TEntity> : ResultModel where TEntity : class, new()
    {
        public TEntity Entity { get; set; }
    }

    public class GetManyResult<TEntity> : ResultModel where TEntity : class, new()
    {
        public IEnumerable<TEntity> Entities { get; set; }
    }

    public class GetListResult<T> : ResultModel
    {
        public List<T> Entities { get; set; }
    }
}
