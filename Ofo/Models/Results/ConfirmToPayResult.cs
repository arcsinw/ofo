﻿using Newtonsoft.Json;
using System.IO;

namespace Ofo.Models.Results
{
    /// <summary>
    /// 确认支付结果
    /// </summary>
    public class ConfirmToPayResult : BaseResult
    {
         

        /// <summary>
        /// 用户信息
        /// </summary>
        public PaymentInfo Data { get => Value?.info; }

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
            public PaymentInfo info { get; set; }

             
        }

         
    }

    public class PaymentInfo
    {
        #region 字段

        private string _imgUrl;

        #endregion 字段

         

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("cityIndex")]
        public int CityIndex { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string classify { get; set; }

        /// <summary>
        /// 图片名称
        /// </summary>
        public string ImgName { get; set; }

        [JsonProperty("purl")]
        public string ImgUrl
        {
            get { return _imgUrl; }
            set
            {
                _imgUrl = value;
                ImgName = Path.GetFileName(value);
            }
        }

        /// <summary>
        ///
        /// </summary>
        public PaymentNotice notice { get; set; }

        /// <summary>
        ///
        /// </summary>
        public long orderno { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string ordernum { get; set; }

        /// <summary>
        /// 来领红包吧！
        /// </summary>
        public string pdescr { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int personalReward { get; set; }

        /// <summary>
        /// ofo小黄车邀你领红包
        /// </summary>
        public string ptitle { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string shareurl { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string show { get; set; }

        /// <summary>
        /// ofo红包
        /// </summary>
        public string title { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string url { get; set; }

        /// <summary>
        ///
        /// </summary>
        public int yap { get; set; }

         
    }

    public class PaymentNotice
    {
    }
}