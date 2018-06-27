﻿


/**
* Autogenerated file at 27/06/2018 12:03:01 PM
*
* Right click on Clients.tt and choose 'Run Custom Tool' to regenerate
*/
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Linq;
using System.Net;
using System.Web;

 
namespace SampleClient.WebProxies {

	public partial class ThingClient : ClientBase{

		public ThingClient() : base()
		{
		}


				/**
		* 
		*/
		public virtual async Task<SharedEntities.Thing> GetAsync(System.Int32 id)
		{

			//build parameters
			var dictionary = new Dictionary<string, object>();
	
							dictionary.Add("id",GetParameterValue( id));

			 
			var queryString = BuildQueryString(dictionary);
			var response = await HttpClient.GetAsync("api/thing?" + queryString );


            EnsureSuccess(response);
			
			var result = await response.ReadContentAsAsync<SharedEntities.Thing>();
			return result;
			
		}

		 
	 
		/**
		* 
		*/
		public virtual async Task<SharedEntities.Thing> PostAsync(SharedEntities.Thing data)
		{
			var response = await HttpClient.PostAsJsonAsync("api/thing", data);

            EnsureSuccess(response);
						var result = await response.ReadContentAsAsync<SharedEntities.Thing>();
			return result;
			
		}
		 
	 
		/**
		* 
		*/
		public virtual async Task<System.Boolean> DeleteAsync(System.Int32 id)
		{
			//build parameters
			var dictionary = new Dictionary<string, object>();
			
				dictionary.Add("id",GetParameterValue(id));
			 
			var queryString = BuildQueryString(dictionary);
			var response = await HttpClient.DeleteAsync("api/thing?" + queryString );
            EnsureSuccess(response);
						var result = await response.ReadContentAsAsync<System.Boolean>();
			return result;
			
		}
		
	}//end class


	/// <summary>
	/// Client configuration.
	/// </summary>
	public static partial class Configuration
	{
		/// <summary>
		/// Web Api Base Address.
		/// </summary>
		public static string MyWebApiProxyBaseAddress = "http://localhost:56070/";
	}


	public static class HttpResponseMessageExtensions
	{
		public static Task<T> ReadContentAsAsync<T>(this HttpResponseMessage response)
		{
			return response.Content.ReadAsAsync<T>();
		}
	}

	/// <summary>
	/// Client base class.
	/// </summary>
	public abstract partial class ClientBase : IDisposable
	{
		/// <summary>
		/// Gests the HttpClient.
		/// </summary>
		public HttpClient HttpClient { get; set; }

		/// <summary>
		/// Dispose the HttpClient when this instance disposes
		/// </summary>
		public bool DisposeHttpClient{get;set;}

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientBase"/> class.
        /// </summary>
        public ClientBase()
        {
			DisposeHttpClient = true;
            HttpClient = new HttpClient()
            {
                BaseAddress = new Uri(Configuration.MyWebApiProxyBaseAddress)
            };   
		}

		/// <summary>
		/// Ensures that response has a valid (200 - OK) status code
		/// </summary>
		public virtual void EnsureSuccess(HttpResponseMessage response)
		{			
			if (response.IsSuccessStatusCode)				
				return;
													
			var content = response.Content.ReadAsStringAsync().Result;
            var message = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(content)
            };
            throw new System.Web.Http.HttpResponseException(message);		
		}


	protected string BuildQueryString(Dictionary<string, object> dictionary)
        {
            var pairs = new List<string>();
            foreach(var kvp in dictionary)
            {
                if(kvp.Value != null && kvp.Value.GetType().IsArray)
                {
                    foreach(object item in (System.Collections.IEnumerable)kvp.Value)
                    {
                        pairs.Add(string.Format("{0}={1}", kvp.Key, EncodeParam(item)));
                    }
                }
                else
                {
                    pairs.Add(string.Format("{0}={1}", kvp.Key, EncodeParam(kvp.Value)));
                }
            }


            return string.Join("&", pairs.ToArray());
        }

		protected string GetParameterValue<T>(T value)
        {
            if (value == null)
            {
                return "";
            }
            else
            {
                return value.ToString();
            }
        }
        protected string GetParameterValue(DateTime? value)
        {
            if (value == null)
            {
                return "";
            }
            else
            {
                return value.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
            }
        }
        protected string GetParameterValue(DateTime value)
        {
               return value.ToString("s", System.Globalization.CultureInfo.InvariantCulture);
        }

		/// <summary>
		/// Encode the input parameter as a string
		/// </summary>
		protected string EncodeParam<T>(T value) 
		{
			if(value == null){
				return "";
			}else{
				return System.Net.WebUtility.UrlEncode(value.ToString());
			}
		}
		
		/// <summary>
		/// Encode the input parameter as a string
		/// </summary>
		protected string EncodeParam(DateTime value) 
		{
			return System.Net.WebUtility.UrlEncode(value.ToString("s", System.Globalization.CultureInfo.InvariantCulture));
		}

				/// <summary>
		/// Encode the input parameter as a string
		/// </summary>
		protected string EncodeParam(DateTime? value) 
		{
			if(value == null){
				return "";
			}else{
				return System.Net.WebUtility.UrlEncode(value.Value.ToString("s", System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		
		/// <summary>
		/// Encode the input parameter as a string
		/// </summary>
		protected string EncodeParam(DateTimeOffset value)
		{
			return System.Net.WebUtility.UrlEncode(value.ToString("s", System.Globalization.CultureInfo.InvariantCulture));
		}
		
		/// <summary>
		/// Releases the unmanaged resources and disposes of the managed resources.       
		/// </summary>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing && HttpClient != null && DisposeHttpClient)
			{
				HttpClient.Dispose();
				HttpClient = null;
			}
		}
		
		/// <summary>
		/// Releases the unmanaged resources and disposes of the managed resources.       
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		/// <summary>
		/// Destructor
		/// </summary>
		~ClientBase() 
		{
			Dispose(false);
		}
	}

}//end namespace

