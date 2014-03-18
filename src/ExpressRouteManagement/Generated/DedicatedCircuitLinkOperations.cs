// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Management.ExpressRoute;
using Microsoft.WindowsAzure.Management.ExpressRoute.Models;

namespace Microsoft.WindowsAzure.Management.ExpressRoute
{
    internal partial class DedicatedCircuitLinkOperations : IServiceOperations<ExpressRouteManagementClient>, Microsoft.WindowsAzure.Management.ExpressRoute.IDedicatedCircuitLinkOperations
    {
        /// <summary>
        /// Initializes a new instance of the DedicatedCircuitLinkOperations
        /// class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal DedicatedCircuitLinkOperations(ExpressRouteManagementClient client)
        {
            this._client = client;
        }
        
        private ExpressRouteManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.WindowsAzure.Management.ExpressRoute.ExpressRouteManagementClient.
        /// </summary>
        public ExpressRouteManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// The New Dedicated Circuit Link operation creates a new dedicated
        /// circuit link.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard express route gateway response including an HTTP status
        /// code and request ID.
        /// </returns>
        public async System.Threading.Tasks.Task<Microsoft.WindowsAzure.Management.ExpressRoute.Models.ExpressRouteOperationResponse> BeginNewAsync(string serviceKey, string vnetName, CancellationToken cancellationToken)
        {
            // Validate
            if (serviceKey == null)
            {
                throw new ArgumentNullException("serviceKey");
            }
            if (vnetName == null)
            {
                throw new ArgumentNullException("vnetName");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serviceKey", serviceKey);
                tracingParameters.Add("vnetName", vnetName);
                Tracing.Enter(invocationId, this, "BeginNewAsync", tracingParameters);
            }
            
            // Construct URL
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            string url = "/" + this.Client.Credentials.SubscriptionId + "/services/networking/dedicatedcircuits/" + serviceKey + "/vnets/" + vnetName + "?api-version=1.0";
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Post;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2011-10-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.Accepted)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    ExpressRouteOperationResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new ExpressRouteOperationResponse();
                    XDocument responseDoc = XDocument.Parse(responseContent);
                    
                    XElement gatewayOperationAsyncResponseElement = responseDoc.Element(XName.Get("GatewayOperationAsyncResponse", "http://schemas.microsoft.com/windowsazure"));
                    if (gatewayOperationAsyncResponseElement != null && gatewayOperationAsyncResponseElement.IsEmpty == false)
                    {
                        XElement idElement = gatewayOperationAsyncResponseElement.Element(XName.Get("ID", "http://schemas.microsoft.com/windowsazure"));
                        if (idElement != null && idElement.IsEmpty == false)
                        {
                            string idInstance = idElement.Value;
                            result.OperationId = idInstance;
                        }
                    }
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// The Remove Dedicated Circuit Link operation deletes an existing
        /// dedicated circuit link.
        /// </summary>
        /// <param name='serviceKey'>
        /// Service key representing the dedicated circuit.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard express route gateway response including an HTTP status
        /// code and request ID.
        /// </returns>
        public async System.Threading.Tasks.Task<Microsoft.WindowsAzure.Management.ExpressRoute.Models.ExpressRouteOperationResponse> BeginRemoveAsync(string serviceKey, string vnetName, CancellationToken cancellationToken)
        {
            // Validate
            if (serviceKey == null)
            {
                throw new ArgumentNullException("serviceKey");
            }
            if (vnetName == null)
            {
                throw new ArgumentNullException("vnetName");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serviceKey", serviceKey);
                tracingParameters.Add("vnetName", vnetName);
                Tracing.Enter(invocationId, this, "BeginRemoveAsync", tracingParameters);
            }
            
            // Construct URL
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            string url = "/" + this.Client.Credentials.SubscriptionId + "/services/networking/dedicatedcircuits/" + serviceKey + "/vnets/" + vnetName + "?api-version=1.0";
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Delete;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2011-10-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.Accepted)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    ExpressRouteOperationResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new ExpressRouteOperationResponse();
                    XDocument responseDoc = XDocument.Parse(responseContent);
                    
                    XElement gatewayOperationAsyncResponseElement = responseDoc.Element(XName.Get("GatewayOperationAsyncResponse", "http://schemas.microsoft.com/windowsazure"));
                    if (gatewayOperationAsyncResponseElement != null && gatewayOperationAsyncResponseElement.IsEmpty == false)
                    {
                        XElement idElement = gatewayOperationAsyncResponseElement.Element(XName.Get("ID", "http://schemas.microsoft.com/windowsazure"));
                        if (idElement != null && idElement.IsEmpty == false)
                        {
                            string idInstance = idElement.Value;
                            result.OperationId = idInstance;
                        }
                    }
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// The Get Dedicated Circuit Link operation retrieves the specified
        /// dedicated circuit link.
        /// </summary>
        /// <param name='serviceKey'>
        /// The service key representing the circuit.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The Get Dedicated Circuit Link operation response.
        /// </returns>
        public async System.Threading.Tasks.Task<Microsoft.WindowsAzure.Management.ExpressRoute.Models.DedicatedCircuitLinkGetResponse> GetAsync(string serviceKey, string vnetName, CancellationToken cancellationToken)
        {
            // Validate
            if (serviceKey == null)
            {
                throw new ArgumentNullException("serviceKey");
            }
            if (vnetName == null)
            {
                throw new ArgumentNullException("vnetName");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serviceKey", serviceKey);
                tracingParameters.Add("vnetName", vnetName);
                Tracing.Enter(invocationId, this, "GetAsync", tracingParameters);
            }
            
            // Construct URL
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            string url = "/" + this.Client.Credentials.SubscriptionId + "/services/networking/dedicatedcircuits/" + serviceKey + "/vnets/" + vnetName + "?api-version=1.0";
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2011-10-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    DedicatedCircuitLinkGetResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new DedicatedCircuitLinkGetResponse();
                    XDocument responseDoc = XDocument.Parse(responseContent);
                    
                    XElement dedicatedCircuitLinkElement = responseDoc.Element(XName.Get("DedicatedCircuitLink", "http://schemas.microsoft.com/windowsazure"));
                    if (dedicatedCircuitLinkElement != null && dedicatedCircuitLinkElement.IsEmpty == false)
                    {
                        AzureDedicatedCircuitLink dedicatedCircuitLinkInstance = new AzureDedicatedCircuitLink();
                        result.DedicatedCircuitLink = dedicatedCircuitLinkInstance;
                        
                        XElement stateElement = dedicatedCircuitLinkElement.Element(XName.Get("State", "http://schemas.microsoft.com/windowsazure"));
                        if (stateElement != null && stateElement.IsEmpty == false)
                        {
                            DedicatedCircuitLinkState stateInstance = (DedicatedCircuitLinkState)Enum.Parse(typeof(DedicatedCircuitLinkState), stateElement.Value, true);
                            dedicatedCircuitLinkInstance.State = stateInstance;
                        }
                        
                        XElement vnetNameElement = dedicatedCircuitLinkElement.Element(XName.Get("VnetName", "http://schemas.microsoft.com/windowsazure"));
                        if (vnetNameElement != null && vnetNameElement.IsEmpty == false)
                        {
                            string vnetNameInstance = vnetNameElement.Value;
                            dedicatedCircuitLinkInstance.VnetName = vnetNameInstance;
                        }
                    }
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// The List Dedicated Circuit Links operation retrieves a list of
        /// Vnets that are linked to the circuit with the specified service
        /// key.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List Dedicated Circuit Link operation response.
        /// </returns>
        public async System.Threading.Tasks.Task<Microsoft.WindowsAzure.Management.ExpressRoute.Models.DedicatedCircuitLinkListResponse> ListAsync(string serviceKey, CancellationToken cancellationToken)
        {
            // Validate
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serviceKey", serviceKey);
                Tracing.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            string url = "/" + this.Client.Credentials.SubscriptionId + "/services/networking/dedicatedcircuits/" + serviceKey + "/vnets?api-version=1.0";
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2011-10-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    DedicatedCircuitLinkListResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new DedicatedCircuitLinkListResponse();
                    XDocument responseDoc = XDocument.Parse(responseContent);
                    
                    XElement dedicatedCircuitLinksSequenceElement = responseDoc.Element(XName.Get("DedicatedCircuitLinks", "http://schemas.microsoft.com/windowsazure"));
                    if (dedicatedCircuitLinksSequenceElement != null && dedicatedCircuitLinksSequenceElement.IsEmpty == false)
                    {
                        foreach (XElement dedicatedCircuitLinksElement in dedicatedCircuitLinksSequenceElement.Elements(XName.Get("DedicatedCircuitLink", "http://schemas.microsoft.com/windowsazure")))
                        {
                            AzureDedicatedCircuitLink dedicatedCircuitLinkInstance = new AzureDedicatedCircuitLink();
                            result.DedicatedCircuitLinks.Add(dedicatedCircuitLinkInstance);
                            
                            XElement stateElement = dedicatedCircuitLinksElement.Element(XName.Get("State", "http://schemas.microsoft.com/windowsazure"));
                            if (stateElement != null && stateElement.IsEmpty == false)
                            {
                                DedicatedCircuitLinkState stateInstance = (DedicatedCircuitLinkState)Enum.Parse(typeof(DedicatedCircuitLinkState), stateElement.Value, true);
                                dedicatedCircuitLinkInstance.State = stateInstance;
                            }
                            
                            XElement vnetNameElement = dedicatedCircuitLinksElement.Element(XName.Get("VnetName", "http://schemas.microsoft.com/windowsazure"));
                            if (vnetNameElement != null && vnetNameElement.IsEmpty == false)
                            {
                                string vnetNameInstance = vnetNameElement.Value;
                                dedicatedCircuitLinkInstance.VnetName = vnetNameInstance;
                            }
                        }
                    }
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// The New Dedicated Circuit Link operation creates a new dedicated
        /// circuit link.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The Get Dedicated Circuit Link operation response.
        /// </returns>
        public async System.Threading.Tasks.Task<Microsoft.WindowsAzure.Management.ExpressRoute.Models.DedicatedCircuitLinkGetResponse> NewAsync(string serviceKey, string vnetName, CancellationToken cancellationToken)
        {
            ExpressRouteManagementClient client = this.Client;
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serviceKey", serviceKey);
                tracingParameters.Add("vnetName", vnetName);
                Tracing.Enter(invocationId, this, "NewAsync", tracingParameters);
            }
            try
            {
                if (shouldTrace)
                {
                    client = this.Client.WithHandler(new ClientRequestTrackingHandler(invocationId));
                }
                
                cancellationToken.ThrowIfCancellationRequested();
                ExpressRouteOperationResponse originalResponse = await client.DedicatedCircuitLink.BeginNewAsync(serviceKey, vnetName, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                ExpressRouteOperationStatusResponse result = await client.GetOperationStatusAsync(originalResponse.OperationId, cancellationToken).ConfigureAwait(false);
                int delayInSeconds = 30;
                while (result.Status == ExpressRouteOperationStatus.InProgress)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await TaskEx.Delay(delayInSeconds * 1000, cancellationToken).ConfigureAwait(false);
                    cancellationToken.ThrowIfCancellationRequested();
                    result = await client.GetOperationStatusAsync(originalResponse.OperationId, cancellationToken).ConfigureAwait(false);
                    delayInSeconds = 10;
                }
                
                if (result.Status == ExpressRouteOperationStatus.Failed)
                {
                    string exStr = "A new dedicated circuit link could not be created due to an internal server error.";
                    throw new ArgumentException(exStr);
                }
                cancellationToken.ThrowIfCancellationRequested();
                DedicatedCircuitLinkGetResponse getResult = await client.DedicatedCircuitLink.GetAsync(serviceKey, vnetName, cancellationToken).ConfigureAwait(false);
                if (shouldTrace)
                {
                    Tracing.Exit(invocationId, result);
                }
                
                return getResult;
            }
            finally
            {
                if (client != null && shouldTrace)
                {
                    client.Dispose();
                }
            }
        }
        
        /// <summary>
        /// The Remove Dedicated Circuit Link operation deletes an existing
        /// dedicated circuit link.
        /// </summary>
        /// <param name='serviceKey'>
        /// Service Key associated with the dedicated circuit.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself.  If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request.  If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request, and also includes error
        /// information regarding the failure.
        /// </returns>
        public async System.Threading.Tasks.Task<Microsoft.WindowsAzure.Management.ExpressRoute.Models.ExpressRouteOperationStatusResponse> RemoveAsync(string serviceKey, string vnetName, CancellationToken cancellationToken)
        {
            ExpressRouteManagementClient client = this.Client;
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serviceKey", serviceKey);
                tracingParameters.Add("vnetName", vnetName);
                Tracing.Enter(invocationId, this, "RemoveAsync", tracingParameters);
            }
            try
            {
                if (shouldTrace)
                {
                    client = this.Client.WithHandler(new ClientRequestTrackingHandler(invocationId));
                }
                
                cancellationToken.ThrowIfCancellationRequested();
                ExpressRouteOperationResponse originalResponse = await client.DedicatedCircuitLink.BeginRemoveAsync(serviceKey, vnetName, cancellationToken).ConfigureAwait(false);
                cancellationToken.ThrowIfCancellationRequested();
                ExpressRouteOperationStatusResponse result = await client.GetOperationStatusAsync(originalResponse.OperationId, cancellationToken).ConfigureAwait(false);
                int delayInSeconds = 30;
                while (result.Status == ExpressRouteOperationStatus.InProgress)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    await TaskEx.Delay(delayInSeconds * 1000, cancellationToken).ConfigureAwait(false);
                    cancellationToken.ThrowIfCancellationRequested();
                    result = await client.GetOperationStatusAsync(originalResponse.OperationId, cancellationToken).ConfigureAwait(false);
                    delayInSeconds = 10;
                }
                
                if (shouldTrace)
                {
                    Tracing.Exit(invocationId, result);
                }
                
                return result;
            }
            finally
            {
                if (client != null && shouldTrace)
                {
                    client.Dispose();
                }
            }
        }
    }
}