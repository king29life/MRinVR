using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace MRinVR.Data
{
    /// <summary>
    /// WebAPIの共通機能を提供するクラスです。
    /// </summary>
    public abstract class TransferAPIBase
    {
        /// <summary>
        /// クライアント
        /// </summary>
        protected HttpClient client;

        /// <summary>
        /// 新しいインスタンスを生成します。
        /// </summary>
        public TransferAPIBase()
        {
            client = new HttpClient();
        }

        /// <summary>
        /// GETリクエストを送信します。
        /// </summary>
        protected UniTask GetAsync(string requestUri, Dictionary<string, string> headers)
        {
            return SendAsync(HttpMethod.Get, requestUri, headers);
        }

        /// <summary>
        /// GETリクエストを送信します。
        /// </summary>
        protected UniTask GetAsync<T>(string requestUri, Dictionary<string, string> headers, T content)
        {
            return SendAsync(HttpMethod.Get, requestUri, headers, content);
        }

        /// <summary>
        /// GETリクエストを送信します。
        /// </summary>
        protected UniTask<U> GetAsync<U>(string requestUri, Dictionary<string, string> headers)
        {
            return SendAsync<U>(HttpMethod.Get, requestUri, headers);
        }

        /// <summary>
        /// GETリクエストを送信します。
        /// </summary>
        protected UniTask<U> GetAsync<U, T>(string requestUri, Dictionary<string, string> headers, T content)
        {
            return SendAsync<U, T>(HttpMethod.Get, requestUri, headers, content);
        }

        /// <summary>
        /// POSTリクエストを送信します。
        /// </summary>
        protected UniTask PostAsync(string requestUri, Dictionary<string, string> headers)
        {
            return SendAsync(HttpMethod.Post, requestUri, headers);
        }

        /// <summary>
        /// POSTリクエストを送信します。
        /// </summary>
        protected UniTask PostAsync<T>(string requestUri, Dictionary<string, string> headers, T content)
        {
            return SendAsync(HttpMethod.Post, requestUri, headers, content);
        }

        /// <summary>
        /// POSTリクエストを送信します。
        /// </summary>
        protected UniTask<U> PostAsync<U>(string requestUri, Dictionary<string, string> headers)
        {
            return SendAsync<U>(HttpMethod.Post, requestUri, headers);
        }

        /// <summary>
        /// POSTリクエストを送信します。
        /// </summary>
        protected UniTask<U> PostAsync<U, T>(string requestUri, Dictionary<string, string> headers, T content)
        {
            return SendAsync<U, T>(HttpMethod.Post, requestUri, headers, content);
        }

        /// <summary>
        /// PUTリクエストを送信します。
        /// </summary>
        protected UniTask PutAsync(string requestUri, Dictionary<string, string> headers)
        {
            return SendAsync(HttpMethod.Put, requestUri, headers);
        }

        /// <summary>
        /// PUTリクエストを送信します。
        /// </summary>
        protected UniTask PutAsync<T>(string requestUri, Dictionary<string, string> headers, T content)
        {
            return SendAsync(HttpMethod.Put, requestUri, headers, content);
        }

        /// <summary>
        /// PUTリクエストを送信します。
        /// </summary>
        protected UniTask<U> PutAsync<U>(string requestUri, Dictionary<string, string> headers)
        {
            return SendAsync<U>(HttpMethod.Put, requestUri, headers);
        }

        /// <summary>
        /// PUTリクエストを送信します。
        /// </summary>
        protected UniTask<U> PutAsync<U, T>(string requestUri, Dictionary<string, string> headers, T content)
        {
            return SendAsync<U, T>(HttpMethod.Put, requestUri, headers, content);
        }

        /// <summary>
        /// DELETEリクエストを送信します。
        /// </summary>
        protected UniTask DeleteAsync(string requestUri, Dictionary<string, string> headers)
        {
            return SendAsync(HttpMethod.Delete, requestUri, headers);
        }

        /// <summary>
        /// DELETEリクエストを送信します。
        /// </summary>
        protected UniTask DeleteAsync<T>(string requestUri, Dictionary<string, string> headers, T content)
        {
            return SendAsync(HttpMethod.Delete, requestUri, headers, content);
        }

        /// <summary>
        /// DELETEリクエストを送信します。
        /// </summary>
        protected UniTask<U> DeleteAsync<U>(string requestUri, Dictionary<string, string> headers)
        {
            return SendAsync<U>(HttpMethod.Delete, requestUri, headers);
        }

        /// <summary>
        /// DELETEリクエストを送信します。
        /// </summary>
        protected UniTask<U> DeleteAsync<U, T>(string requestUri, Dictionary<string, string> headers, T content)
        {
            return SendAsync<U, T>(HttpMethod.Delete, requestUri, headers, content);
        }

        /// <summary>
        /// リクエストを送信します。
        /// </summary>
        private async UniTask SendAsync(HttpMethod method, string requestUri, Dictionary<string, string> headers)
        {
            var request = GetRequest(method, requestUri, headers);
            var response = await SendAsync(request);
            return;
        }

        /// <summary>
        /// リクエストを送信します。
        /// </summary>
        private async UniTask SendAsync<T>(HttpMethod method, string requestUri, Dictionary<string, string> headers, T content)
        {
            var request = GetRequest(method, requestUri, headers, content);
            var response = await SendAsync(request);
            return;
        }

        /// <summary>
        /// リクエストを送信します。
        /// </summary>
        private async UniTask<U> SendAsync<U>(HttpMethod method, string requestUri, Dictionary<string, string> headers)
        {
            var request = GetRequest(method, requestUri, headers);
            var response = await SendAsync(request);
            return await GetResponse<U>(response);
        }

        /// <summary>
        /// リクエストを送信します。
        /// </summary>
        private async UniTask<U> SendAsync<U, T>(HttpMethod method, string requestUri, Dictionary<string, string> headers, T content)
        {
            var request = GetRequest(method, requestUri, headers, content);
            var response = await SendAsync(request);
            return await GetResponse<U>(response);
        }

        /// <summary>
        /// リクエストを送信してレスポンスを受信します。
        /// </summary>
        private async UniTask<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return await client.SendAsync(request);
        }

        /// <summary>
        /// リクエストを取得します。
        /// </summary>
        private HttpRequestMessage GetRequest(HttpMethod method, string requestUri, Dictionary<string, string> headers)
        {
            var request = new HttpRequestMessage()
            {
                Method = method,
                RequestUri = new Uri(requestUri),
            };
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }
            return request;
        }

        /// <summary>
        /// リクエストを取得します。
        /// </summary>
        private HttpRequestMessage GetRequest<T>(HttpMethod method, string requestUri, Dictionary<string, string> headers, T content)
        {
            var request = GetRequest(method, requestUri, headers);
            if (content != null)
            {
                request.Content = GetRequestContent(content);
            }
            return request;
        }

        /// <summary>
        /// レスポンスを取得します。
        /// </summary>
        private UniTask<T> GetResponse<T>(HttpResponseMessage response)
        {
            return GetResponseContent<T>(response.Content);
        }

        /// <summary>
        /// リクエストをシリアライズします。
        /// </summary>
        private HttpContent GetRequestContent<T>(T data)
        {
            var contenData = ProtocolUtility.SerializeMessagePack(data);
            var content = new ByteArrayContent(contenData);
            return content;
        }

        /// <summary>
        /// レスポンスをデシリアライズします。
        /// </summary>
        private async UniTask<T> GetResponseContent<T>(HttpContent content)
        {
            var contenData = await content.ReadAsByteArrayAsync();
            var data = ProtocolUtility.DeserializeMessagePack<T>(contenData);
            return data;
        }
    }
}
