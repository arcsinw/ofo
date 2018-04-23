﻿using Ofo.Http;
using System;
using System.Text;

namespace Ofo.Models.Requests
{
    /// <summary>
    /// 基础请求
    /// </summary>
    public class BaseRequest
    {
        #region 字段

        /// <summary>
        /// 格林威治标准时间
        /// </summary>
        private static DateTime _standardTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        #endregion 字段

         

        /// <summary>
        /// Api地址
        /// </summary>
        public string ApiUrl { get; set; }

        /// <summary>
        /// 表单参数 source 默认值0
        /// </summary>
        public int Source { get; set; } = 0;

        /// <summary>
        /// 表单参数source-version默认值9999
        /// </summary>
        public int SourceVersion { get; set; } = 9999;

        /// <summary>
        /// 用户Token
        /// </summary>
        public string Token { get; set; }

         

        #region 方法

        /// <summary>
        /// 获取当前时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetTimeStamp()
        {
            return Convert.ToInt64((DateTime.Now.ToUniversalTime() - _standardTime).TotalMilliseconds);
        }

        /// <summary>
        /// 获取表单字符串
        /// </summary>
        /// <returns></returns>
        public virtual string GetFormString()
        {
            if (string.IsNullOrEmpty(Token))
            {
                return $"source={Source}&source-version={SourceVersion}";
            }
            else
            {
                return $"token={Token}&source={Source}&source-version={SourceVersion}";
            }
        }

        /// <summary>
        /// 获取Http请求
        /// </summary>
        /// <returns></returns>
        public virtual HttpItem GetHttpItem()
        {
            HttpItem result = new HttpItem()
            {
                URL = ToString(),
            };
            var formString = GetFormString();
            if (!string.IsNullOrEmpty(formString))
            {
                result.Method = MethodType.POST;
                result.PostData = formString;
            }

            return result;
        }

        /// <summary>
        /// 获取查询字符串
        /// </summary>
        /// <returns></returns>
        public virtual string GetQueryString()
        {
            return string.Empty;
        }

        /// <summary>
        /// 获取请求的Url
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder(128);
            stringBuilder.Append(ApiUrl);
            var queryString = GetQueryString();

            if (!string.IsNullOrEmpty(queryString))
            {
                stringBuilder.Append('?');
                stringBuilder.Append(queryString);
            }

            return stringBuilder.ToString();
        }

        #endregion 方法
    }
}