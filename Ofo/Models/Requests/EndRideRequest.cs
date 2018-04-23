using Ofo.Services;

namespace Ofo.Models.Requests
{
    /// <summary>
    /// 结束骑行请求
    /// </summary>
    public class EndRideRequest : BasePositionRequest
    {
         

        /// <summary>
        /// 订单号
        /// </summary>
        public string Ordernum { get; set; }

         

         

        /// <summary>
        /// 结束骑行请求
        /// </summary>
        public EndRideRequest()
        {
            ApiUrl = ApiUrls.EndRide;
        }

         

        #region 方法

        public override string GetFormString()
        {
            return base.GetFormString() + $"&ordernum={Ordernum}";
        }

        #endregion 方法
    }
}