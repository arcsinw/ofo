using Ofo.Services;

namespace Ofo.Models.Requests
{
    /// <summary>
    /// 消费明细请求
    /// </summary>
    public class DetailsRequest : BaseRequest
    {
         

        /// <summary>
        /// 类别 0消费 1充值
        /// </summary>
        public int Classify { get; set; } = 0;

        /// <summary>
        /// 页
        /// </summary>
        public int Page { get; set; } = 1;

         

         

        /// <summary>
        /// 消费明细请求
        /// </summary>
        public DetailsRequest()
        {
            ApiUrl = ApiUrls.GetDetails;
        }

         

        #region 方法

        public override string GetFormString()
        {
            return base.GetFormString() + $"&classify={Classify}&page={Page}";
        }

        #endregion 方法
    }
}