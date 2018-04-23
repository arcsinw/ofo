﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Ofo.Models.Results
{
    /// <summary>
    /// 活动中心首页详情
    /// </summary>
    public class ActivityHomePageDetail
    {
         

        /// <summary>
        /// 广告列表？
        /// </summary>
        [JsonProperty("adList")]
        public List<AdItem> AdList { get; set; }

        /// <summary>
        /// 关注列表？
        /// </summary>
        [JsonProperty("focusList")]
        public List<FocusItem> FocusList { get; set; }

        /// <summary>
        /// 操作列表？
        /// </summary>
        [JsonProperty("operationList")]
        public List<OperationItem> OperationList { get; set; }

         
    }

    /// <summary>
    /// 活动中心首页详情请求结果
    /// </summary>
    public class ActivityHomePageDetailResult : BaseResult
    {
         

        /// <summary>
        /// 返回的值
        /// </summary>
        [JsonProperty("values")]
        public ActivityHomePageDetail Data { get; set; }

         
    }

    public class AdItem
    {
         

        public string activityId { get; set; }

        /// <summary>
        /// 图片名称
        /// </summary>
        public string ImgName { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("imgUrl")]
        public string ImgUrl
        {
            get => _imgUrl;
            set
            {
                _imgUrl = value;

                ImgName = Path.GetFileName(value);
            }
        }

        [JsonProperty("jumpUrl")]
        public string JumpUrl { get; set; }

        private string _imgUrl { get; set; }

         
    }

    public class FocusItem
    {
         

        public string content { get; set; }
        public string lastItemTime { get; set; }
        public string lastItemTimeStamp { get; set; }

         
    }

    public class OperationItem
    {
         

        /// <summary>
        /// 图片名称
        /// </summary>
        public string IconName { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty("iconUrl")]
        public string IconUrl
        {
            get => _iconUrl;
            set
            {
                _iconUrl = value;

                IconName = Path.GetFileName(value);
            }
        }

        public string jumpUrl { get; set; }
        public string NO { get; set; }
        public string title { get; set; }
        private string _iconUrl { get; set; }

         
    }
}