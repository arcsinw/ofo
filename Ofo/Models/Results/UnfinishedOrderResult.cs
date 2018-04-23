using Newtonsoft.Json;

namespace Ofo.Models.Results
{
    /// <summary>
    /// 未完成订单
    /// </summary>
    public class UnfinishedOrderResult : BaseResult
    {
         

        /// <summary>
        /// 配置信息
        /// </summary>
        public UnLockCarInfo Data { get => Value?.info; }

        /// <summary>
        /// 返回的值
        /// </summary>
        [JsonProperty("values")]
        public Values Value { get; set; }

         

         

        public class Values
        {
             

            /// <summary>
            ///
            /// </summary>
            public UnLockCarInfo info { get; set; }

             
        }

         
    }
}