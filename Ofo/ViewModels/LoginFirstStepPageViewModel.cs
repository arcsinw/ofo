using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using Ofo.Services;
using Ofo.Utils;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Ofo.ViewModels
{ 
    public class LoginFirstStepPageViewModel : ViewModelBase
    {     
        #region Properties

        private string _captchaCode;
        /// <summary>
        /// 验证码
        /// </summary>
        public string CaptchaCode
        {
            get { return _captchaCode; }
            set
            {
                _captchaCode = value;
                RaisePropertyChanged();
            }
        }

        private bool _captchaCodeInputEnable = false;
        /// <summary>
        /// 验证码可输入状态
        /// </summary>
        public bool CaptchaCodeInputEnable
        {
            get { return _captchaCodeInputEnable; }
            set
            {
                _captchaCodeInputEnable = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 电话号码
        /// </summary>
        public string TelePhone { get; set; }

        private BitmapImage _verifyCodeImage = new BitmapImage();
        /// <summary>
        /// 验证码图片
        /// </summary>
        public BitmapImage VerifyCodeImage
        {
            get { return _verifyCodeImage; }
            set
            {
                _verifyCodeImage = value;
                RaisePropertyChanged();
    }
        }

        /// <summary>
        /// 验证ID
        /// </summary>
        private string VerifyId { get; set; }

        #endregion

        #region Commands
        /// <summary>
        /// 刷新验证码命令
        /// </summary>
        public ICommand RefreshCaptchaCodeCommand { get; set; }

        #endregion

        public LoginFirstStepPageViewModel()
        {
            RefreshCaptchaCodeCommand = new RelayCommand(async() =>
            {
                CaptchaCode = string.Empty;
                await GetCaptchaCodeAsync();
            });

            InitializationAsync();
        }
         

        #region Functions

        public async void InputCaptchaCodeTextChangedAsync(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (tb.Text.Length >= 4)
                {
                    CaptchaCode = tb.Text.Trim();
                    await SubmitCaptchaCodeAsync();
                    return;
                }
            }
        }

        protected async void InitializationAsync()
        {
            await GetCaptchaCodeAsync();
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        private async Task GetCaptchaCodeAsync()
        { 
            var captchaCodeResult = await OfoWebApiService.Current.GetCaptchaCodeAsync();
            if (captchaCodeResult.IsSuccess)
            {
                VerifyId = captchaCodeResult.Data.VerifyId;
                using (var imgStream = await AccessStreamUtility.GetRandomAccessStreamFormBase64String(captchaCodeResult.Data.CaptchaStr))
                {
                    await DispatcherHelper.RunAsync(() =>
                    {
                        VerifyCodeImage.SetSource(imgStream);
                    });
                }
            } 
        }

        /// <summary>
        /// 提交验证码
        /// </summary>
        /// <param name="state"></param>
        private async Task SubmitCaptchaCodeAsync()
        {
            if (string.IsNullOrWhiteSpace(CaptchaCode))
            {
                return;
            }

            OfoWebApiService.Current.User.TelPhone = TelePhone;
            OfoWebApiService.Current.SubmitCaptchaCodeAsync(CaptchaCode, VerifyId);
            //OfoApi.CurUser.TelPhone = TelPhone;
            //var verifyCode = await OfoApi.GetVerifyCodeAsync(CaptchaCode.Trim(), VerifyId);
            //if (await CheckOfoApiResult(verifyCode))
            //{
            //    ContentPageArgs args = new ContentPageArgs()
            //    {
            //        Name = "登录第二步",
            //        HeaderVisibility = Visibility.Collapsed,
            //        ContentElement = new LoginSecondStepContentView(),
            //    };

            //    ContentNavigation(args);
            //}
        }

        #endregion 方法
    }
}