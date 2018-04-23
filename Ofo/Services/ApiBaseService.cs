﻿using Ofo.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace Ofo.Services
{
    public class ApiBaseService
    {
        protected async Task<T> GetResponseAsync<T>(string url) where T:class
        {
            try
            {
                string json = await HttpBaseService.SendGetRequest(url);
                if (json != null)
                {
                    return JsonHelper.Deserlialize<T>(json);
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        protected async Task<JsonObject> PostJsonAsync(string uri,string body)
        {
            try
            {
                string json = await HttpBaseService.SendPostRequest(uri, body);
                if(json!= null)
                {
                    return JsonObject.Parse(json);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Post
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public async Task<JsonObject> PostJsonAsync<T> (string uri,T t) where T : class
        {
            string body = JsonHelper.Serializer(t);
            try
            {
                string json = await HttpBaseService.SendPostRequest(uri, body);
                if (json != null)
                {
                    return JsonObject.Parse(json);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ReturnT> PostJsonAsync<SendT,ReturnT>(string uri,SendT sendT) where ReturnT : class
        {
            string body = JsonHelper.Serializer(sendT);
            try
            {
                string json = await HttpBaseService.SendPostRequest(uri, body);
                if (json != null)
                {
                    return JsonHelper.Deserlialize<ReturnT>(json);
                }
                return null;
            }
            catch (Exception e)
            {
                Debug.WriteLine("ApiBaseService PostJson" + e.Message);
                return null;
            }
        }
        
        protected async Task<string> GetHtmlAsync(string url)
        {
            try
            {
                string html = await HttpBaseService.SendGetRequest(url);
                //byte[] bytes = Encoding.UTF8.GetBytes(html);
                //html = Encoding.GetEncoding("GBK").GetString(bytes);
                return html;
            }
            catch
            {
                return null;
            }
        }
        protected async Task<WriteableBitmap> GetImageAsync(string url)
        {
            try
            {
                IBuffer buffer = await HttpBaseService.SendGetRequestAsBytes(url);
                if (buffer != null)
                {
                    BitmapImage bi = new BitmapImage();
                    
                    using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                    {
                        Stream stream2Write = stream.AsStreamForWrite();
                        await stream2Write.WriteAsync(buffer.ToArray(), 0, (int)buffer.Length);
                        await stream2Write.FlushAsync();
                        stream.Seek(0);

                        await bi.SetSourceAsync(stream);
                        WriteableBitmap wb = new WriteableBitmap(bi.PixelWidth, bi.PixelHeight);
                        stream.Seek(0);
                        await wb.SetSourceAsync(stream);

                        return wb;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
        
    }
}
