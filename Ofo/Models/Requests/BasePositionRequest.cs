using Windows.Devices.Geolocation;

namespace Ofo.Models.Requests
{
    /// <summary>
    /// 需要地址的请求
    /// </summary>
    public class BasePositionRequest : BaseRequest
    {
         

        public BasicGeoposition Location { get; set; }

         

         

        /// <summary>
        /// 需要地址的请求
        /// </summary>
        public BasePositionRequest()
        {
        }

         

        #region 方法

        public override string GetFormString()
        {
            return base.GetFormString() + $"&lat={Location.Latitude}&lng={Location.Longitude}";
        }

        #endregion 方法
    }
}