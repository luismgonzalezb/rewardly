using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net.Http;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace BusinessLMSWeb.Helpers
{
	public class BaseClient
	{
		protected readonly string _endpoint;

		public BaseClient(string baseUrl, string controller, string action)
		{
			_endpoint = String.Concat(baseUrl, "/", controller, "/", action);
		}

		public T Get<T>(int top = 0, int skip = 0)
		{
			using (HttpClient httpClient = NewHttpClient())
			{
				string endpoint = _endpoint + "?";
				List<string> parameters = new List<string>();
				if (top > 0) parameters.Add(string.Concat("$top=", top));
				if (skip > 0) parameters.Add(string.Concat("$skip=", skip));
				endpoint += string.Join("&", parameters);
				HttpResponseMessage response = httpClient.GetAsync(endpoint).Result;
				return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
			}
		}

		public T Get<T>(int id)
		{
			using (HttpClient httpClient = NewHttpClient())
			{
				HttpResponseMessage response = httpClient.GetAsync(String.Concat(_endpoint, "/", id)).Result;
				return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
			}
		}

		public T Get<T>(NameValueCollection parms)
		{
			using (HttpClient httpClient = NewHttpClient())
			{
				String urlRequest = String.Concat(_endpoint, ToQueryString(parms));
				HttpResponseMessage response = httpClient.GetAsync(urlRequest).Result;
				return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
			}
		}

		public string Post<T>(T data)
		{
			using (HttpClient httpClient = NewHttpClient())
			{
				String obj = JsonConvert.SerializeObject(data);
				HttpRequestMessage requestMessage = new HttpRequestMessage();
				requestMessage.Method = HttpMethod.Post;
				requestMessage.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PostAsync(_endpoint, requestMessage.Content).Result;
				return result.Headers.Location.Segments[3].ToString();
			}
		}

		public string Put<T>(int id, T data)
		{
			using (HttpClient httpClient = NewHttpClient())
			{
				HttpRequestMessage requestMessage = new HttpRequestMessage();
				requestMessage.Method = HttpMethod.Put;
				requestMessage.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PutAsync(String.Concat(_endpoint, "/", id), requestMessage.Content).Result;
				return result.Content.ReadAsStringAsync().Result;
			}
		}

		public string Delete(int id)
		{
			using (HttpClient httpClient = NewHttpClient())
			{
				HttpResponseMessage result = httpClient.DeleteAsync(String.Concat(_endpoint, "/", id)).Result;
				return result.Content.ToString();
			}
		}

		protected HttpClient NewHttpClient()
		{
			HttpClient newClient = new HttpClient();
			return newClient;
		}

		protected string ToQueryString(NameValueCollection nvc)
		{
			return "?" + string.Join("&", Array.ConvertAll(nvc.AllKeys, key => string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(nvc[key]))));
		}

	}

}