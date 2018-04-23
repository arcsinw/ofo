using Ofo.Services;

namespace Ofo.Models.Requests
{
    /// <summary>
    /// 保修原因列表获取请求
    /// </summary>
    public class RepairReasonListRequest : BaseRequest
    {
         

        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderNum { get; set; }

         

         

        /// <summary>
        /// 保修原因列表获取请求
        /// </summary>
        public RepairReasonListRequest()
        {
            ApiUrl = ApiUrls.GetRepairReason;
        }

         

        #region 方法

        public override string GetFormString()
        {
            return base.GetFormString() + $"&ordernum={OrderNum}";
        }

        #endregion 方法
    }
}