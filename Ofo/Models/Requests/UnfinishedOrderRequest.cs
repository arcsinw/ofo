using Ofo.Services;

namespace Ofo.Models.Requests
{
    /// <summary>
    /// 未完成订单查询请求
    /// </summary>
    public class UnfinishedOrderRequest : BaseRequest
    {
         

        /// <summary>
        /// 未完成订单查询请求
        /// </summary>
        public UnfinishedOrderRequest()
        {
            ApiUrl = ApiUrls.GetUnfinishedOrder;
        }

         

        #region 方法

        public override string GetFormString()
        {
            return base.GetFormString() + $"&timestamp={GetTimeStamp()}";
        }

        #endregion 方法
    }
}