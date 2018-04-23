using Ofo.Services;

namespace Ofo.Models.Requests
{
    /// <summary>
    /// 确认支付
    /// </summary>
    public class ConfirmToPayRequest : BaseRequest
    {
         

        /// <summary>
        /// 骑行卡ID?
        /// </summary>
        public string CardId { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public long OrderNum { get; set; }

        /// <summary>
        /// 钱包Id?默认为0
        /// </summary>
        public long Packetid { get; set; } = 0;

         

         

        /// <summary>
        /// 确认支付
        /// </summary>
        public ConfirmToPayRequest()
        {
            ApiUrl = ApiUrls.ConfirmToPay;
        }

         

        #region 方法

        public override string GetFormString()
        {
            return base.GetFormString() + $"&ordernum={OrderNum}&packetid={Packetid}&cardId={CardId}";
        }

        #endregion 方法
    }
}