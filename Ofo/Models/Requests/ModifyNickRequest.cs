using Ofo.Services;

namespace Ofo.Models.Requests
{
    /// <summary>
    /// 昵称修改请求
    /// </summary>
    public class ModifyNickRequest : BaseRequest
    {
         

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nick { get; set; }

         

         

        /// <summary>
        /// 昵称修改请求
        /// </summary>
        public ModifyNickRequest()
        {
            ApiUrl = ApiUrls.ModifyUserNick;
        }

         

        #region 方法

        public override string GetFormString()
        {
            return base.GetFormString() + $"&nickname={Nick}";
        }

        #endregion 方法
    }
}