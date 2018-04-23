using Ofo.Services;

namespace Ofo.Models.Requests
{
    /// <summary>
    /// 信用记录请求
    /// </summary>
    public class GetCreditHistoriesRequest : BasePositionRequest
    {
        #region 字段

        private int _page = 1;

        #endregion 字段

         

        /// <summary>
        /// 获取的页面
        /// </summary>
        public int Page
        {
            get { return _page; }
            set
            {
                if (value < 0)
                {
                    _page = 1;
                }
                else
                {
                    _page = value;
                }
            }
        }

         

         

        /// <summary>
        /// 信用记录请求
        /// </summary>
        public GetCreditHistoriesRequest()
        {
            ApiUrl = ApiUrls.GetCreditHistories;
        }

         

        #region 方法

        public override string GetFormString()
        {
            return base.GetFormString() + $"&curPage={Page}";
        }

        #endregion 方法
    }
}