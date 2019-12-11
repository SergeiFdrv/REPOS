using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json; // JsonObject etc.
using Newtonsoft.Json.Converters; // StringEnumConverter
using System.ComponentModel; // Description

namespace MicroserviceFdrv
{
    [JsonObject]
    public class ResponseResult
    {
        public static ResponseResult Success(ResponceCode code = ResponceCode.Ok) =>
            new ResponseResult
            {
                IsSuccess = true,
                Code = code
            };

        public enum ResponceCode
        {
            [Description("OK!")]
            Ok = 0,
            [Description("Common error!")]
            CommonError = 1,
            [Description("Not found!")]
            NotFound = 2,
            [Description("Forbidden!")]
            Forbidden = 3
        }

        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; protected set; }

        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
        public ResponceCode Code { get; protected set; }
    }
}
