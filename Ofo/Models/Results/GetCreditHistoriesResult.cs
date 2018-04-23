﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Ofo.Models.Results
{
    /// <summary>
    /// 信用记录信息
    /// </summary>
    public class CreditHistoriesInfo
    {
         

        [JsonProperty("data")]
        public List<CreditItem> CreditItemList { get; set; }

        [JsonProperty("curPage")]
        public int CurPage { get; set; }

        [JsonProperty("totalPage")]
        public int TotalPage { get; set; }

         
    }

    /// <summary>
    /// 信用记录项
    /// </summary>
    public class CreditItem
    {
         

        [JsonProperty("create_time")]
        public string CreateTime { get; set; }

        [JsonProperty("credit")]
        public int Credit { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

         
    }

    /// <summary>
    /// 信用记录请求结果
    /// </summary>
    public class GetCreditHistoriesResult : BaseResult
    {
         

        [JsonProperty("values")]
        public CreditHistoriesInfo Data { get => Value?.Info; }

        /// <summary>
        /// 返回的值
        /// </summary>
        [JsonProperty("values")]
        public Values Value { get; set; }

         

         

        /// <summary>
        ///
        /// </summary>
        public class Values
        {
             

            [JsonProperty("info")]
            public CreditHistoriesInfo Info { get; set; }

             
        }

         
    }
}