using Ofo.Models.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace Ofo.Services
{
    public class OfoWebApiService : ApiBaseService
    {
        #region Simpletion
        private OfoWebApiService() { }

        public static OfoWebApiService Current { get; } = new OfoWebApiService();

        #endregion


        #region Login

        /// <summary>
        /// 获取登录验证码
        /// </summary>
        public async Task GetCaptchaCodeAsync()
        {
            var captchaCode = await GetResponseAsync<GetCaptchaCodeResult>(ApiUrls.GetCaptchaCode);
            if (captchaCode.IsSuccess)
            {
                
            }
        }

        /// <summary>
        /// 提交登录验证码
        /// </summary>
        /// <returns></returns>
        public async void SubmitCaptchaCodeAsync()
        {

        }

        /// <summary>
        /// 第二步
        /// 获取手机短信验证码
        /// </summary>
        /// <param name="phoneNumber"></param>
        public void GetVerifyCodeAsync(string phoneNumber)
        {

        }

        public async void SubmitVerifyCode()
        {

        }

        #endregion

       /// <summary>
        /// 解锁车
        /// </summary>
        /// <param name="carNumber">车辆编号</param>
        public void UnlockBike(string carNumber)
        {

        }
    }
}
