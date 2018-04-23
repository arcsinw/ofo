using Ofo.Services;

namespace Ofo.Models.Requests
{
    /// <summary>
    /// 认证信息请求
    /// </summary>
    public class IdentificationRequest : BasePositionRequest
    {
         

        /// <summary>
        /// 登陆？默认值为1
        /// </summary>
        public int Login { get; set; } = 1;

         

         

        /// <summary>
        /// 认证信息请求
        /// </summary>
        public IdentificationRequest()
        {
            ApiUrl = ApiUrls.GetIdentificationInfo;
        }

         

        #region 方法

        public override string GetFormString()
        {
            return base.GetFormString() + $"&login={Login}";
        }

        #endregion 方法
    }
}