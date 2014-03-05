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
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
    internal partial class CrossConnectionOperations : IServiceOperations<ExpressRouteManagementClient>, Microsoft.WindowsAzure.Management.ExpressRoute.ICrossConnectionOperations
    {
        /// <summary>
        /// Initializes a new instance of the CrossConnectionOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal CrossConnectionOperations(ExpressRouteManagementClient client)
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
        /// The New Cross Connection operation provisions a cross connection
        /// for as dedicated circuit.
        /// </summary>
        /// <param name='serviceKey'>
        /// Service key of the dedicated circuit.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard express route gateway response including an HTTP status
        /// code and request ID.
        /// </returns>
        public async System.Threading.Tasks.Task<Microsoft.WindowsAzure.Management.ExpressRoute.Models.ExpressRouteOperationResponse> BeginNewAsync(string serviceKey, CancellationToken cancellationToken)
        {
            // Validate
            if (serviceKey == null)
            {
                throw new ArgumentNullException("serviceKey");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serviceKey", serviceKey);
                Tracing.Enter(invocationId, this, "BeginNewAsync", tracingParameters);
            }
            
            // Construct URL
            string url = new Uri(this.Client.BaseUri, "/").AbsoluteUri + this.Client.Credentials.SubscriptionId + "/services/networking/dedicatedcircuits/" + serviceKey + "/crossconnection?api-version=1.0";
            
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
                    if (gatewayOperationAsyncResponseElement != null)
                    {
                        XElement idElement = gatewayOperationAsyncResponseElement.Element(XName.Get("ID", "http://schemas.microsoft.com/windowsazure"));
                        if (idElement != null)
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
        /// The Update Cross Connection operation updates an existing cross
        /// connection.
        /// </summary>
        /// <param name='serviceKey'>
        /// The service key representing the relationship between Azure and the
        /// customer.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Update CrossConnection operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A standard express route gateway response including an HTTP status
        /// code and request ID.
        /// </returns>
        public async System.Threading.Tasks.Task<Microsoft.WindowsAzure.Management.ExpressRoute.Models.ExpressRouteOperationResponse> BeginUpdateAsync(string serviceKey, CrossConnectionUpdateParameters parameters, CancellationToken cancellationToken)
        {
            // Validate
            if (serviceKey == null)
            {
                throw new ArgumentNullException("serviceKey");
            }
            if (serviceKey.Length > 36)
            {
                throw new ArgumentOutOfRangeException("serviceKey");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serviceKey", serviceKey);
                tracingParameters.Add("parameters", parameters);
                Tracing.Enter(invocationId, this, "BeginUpdateAsync", tracingParameters);
            }
            
            // Construct URL
            string url = new Uri(this.Client.BaseUri, "/").AbsoluteUri + this.Client.Credentials.SubscriptionId + "/services/networking/dedicatedcircuits/" + serviceKey + "/crossconnection?api-version=1.0";
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Put;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2011-10-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Serialize Request
                string requestContent = null;
                XDocument requestDoc = new XDocument();
                
                XElement updateCrossConnectionElement = new XElement(XName.Get("UpdateCrossConnection", "http://schemas.microsoft.com/windowsazure"));
                requestDoc.Add(updateCrossConnectionElement);
                
                XElement operationElement = new XElement(XName.Get("Operation", "http://schemas.microsoft.com/windowsazure"));
                operationElement.Value = ExpressRouteManagementClient.UpdateCrossConnectionOperationToString(parameters.Operation);
                updateCrossConnectionElement.Add(operationElement);
                
                if (parameters.ProvisioningError != null)
                {
                    XElement provisioningErrorElement = new XElement(XName.Get("ProvisioningError", "http://schemas.microsoft.com/windowsazure"));
                    provisioningErrorElement.Value = parameters.ProvisioningError;
                    updateCrossConnectionElement.Add(provisioningErrorElement);
                }
                
                requestContent = requestDoc.ToString();
                httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
                httpRequest.Content.Headers.ContentType = new MediaTypeHeaderValue("application/xml");
                
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
                        CloudException ex = CloudException.Create(httpRequest, requestContent, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
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
                    if (gatewayOperationAsyncResponseElement != null)
                    {
                        XElement idElement = gatewayOperationAsyncResponseElement.Element(XName.Get("ID", "http://schemas.microsoft.com/windowsazure"));
                        if (idElement != null)
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
        /// The Get Cross Connection operation retrieves the Cross Connection
        /// information for the Dedicated Circuit with the specified service
        /// key.
        /// </summary>
        /// <param name='serviceKey'>
        /// The servicee key representing the dedicated circuit.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The Get Cross Connection Operation Response.
        /// </returns>
        public async System.Threading.Tasks.Task<Microsoft.WindowsAzure.Management.ExpressRoute.Models.CrossConnectionGetResponse> GetAsync(string serviceKey, CancellationToken cancellationToken)
        {
            // Validate
            if (serviceKey == null)
            {
                throw new ArgumentNullException("serviceKey");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serviceKey", serviceKey);
                Tracing.Enter(invocationId, this, "GetAsync", tracingParameters);
            }
            
            // Construct URL
            string url = new Uri(this.Client.BaseUri, "/").AbsoluteUri + this.Client.Credentials.SubscriptionId + "/services/networking/dedicatedcircuits/" + serviceKey + "/crossconnection?api-version=1.0";
            
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
                    CrossConnectionGetResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new CrossConnectionGetResponse();
                    XDocument responseDoc = XDocument.Parse(responseContent);
                    
                    XElement crossConnectionElement = responseDoc.Element(XName.Get("CrossConnection", "http://schemas.microsoft.com/windowsazure"));
                    if (crossConnectionElement != null)
                    {
                        XElement bandwidthElement = crossConnectionElement.Element(XName.Get("Bandwidth", "http://schemas.microsoft.com/windowsazure"));
                        if (bandwidthElement != null)
                        {
                            int bandwidthInstance = int.Parse(bandwidthElement.Value, CultureInfo.InvariantCulture);
                            result.Bandwidth = bandwidthInstance;
                        }
                        
                        XElement provisioningStateElement = crossConnectionElement.Element(XName.Get("ProvisioningState", "http://schemas.microsoft.com/windowsazure"));
                        if (provisioningStateElement != null)
                        {
                            string provisioningStateInstance = provisioningStateElement.Value;
                            result.ProvisioningState = provisioningStateInstance;
                        }
                        
                        XElement primaryAzurePortElement = crossConnectionElement.Element(XName.Get("PrimaryAzurePort", "http://schemas.microsoft.com/windowsazure"));
                        if (primaryAzurePortElement != null)
                        {
                            string primaryAzurePortInstance = primaryAzurePortElement.Value;
                            result.PrimaryAzurePort = primaryAzurePortInstance;
                        }
                        
                        XElement secondaryAzurePortElement = crossConnectionElement.Element(XName.Get("SecondaryAzurePort", "http://schemas.microsoft.com/windowsazure"));
                        if (secondaryAzurePortElement != null)
                        {
                            string secondaryAzurePortInstance = secondaryAzurePortElement.Value;
                            result.SecondaryAzurePort = secondaryAzurePortInstance;
                        }
                        
                        XElement sTagElement = crossConnectionElement.Element(XName.Get("STag", "http://schemas.microsoft.com/windowsazure"));
                        if (sTagElement != null)
                        {
                            int sTagInstance = int.Parse(sTagElement.Value, CultureInfo.InvariantCulture);
                            result.STag = sTagInstance;
                        }
                        
                        XElement statusElement = crossConnectionElement.Element(XName.Get("Status", "http://schemas.microsoft.com/windowsazure"));
                        if (statusElement != null)
                        {
                            string statusInstance = statusElement.Value;
                            result.Status = statusInstance;
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
        /// The List Cross Connection operation retrieves a list of cross
        /// connections owned by the provider.
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The List Cross Connection operation response.
        /// </returns>
        public async System.Threading.Tasks.Task<Microsoft.WindowsAzure.Management.ExpressRoute.Models.CrossConnectionListResponse> ListAsync(CancellationToken cancellationToken)
        {
            // Validate
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                Tracing.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string url = new Uri(this.Client.BaseUri, "/").AbsoluteUri + this.Client.Credentials.SubscriptionId + "/services/networking/crossconnections?api-version=1.0";
            
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
                    CrossConnectionListResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new CrossConnectionListResponse();
                    XDocument responseDoc = XDocument.Parse(responseContent);
                    
                    XElement crossConnectionsSequenceElement = responseDoc.Element(XName.Get("CrossConnections", "http://schemas.microsoft.com/windowsazure"));
                    if (crossConnectionsSequenceElement != null)
                    {
                        foreach (XElement crossConnectionsElement in crossConnectionsSequenceElement.Elements(XName.Get("CrossConnection", "http://schemas.microsoft.com/windowsazure")))
                        {
                            CrossConnectionListResponse.CrossConnection crossConnectionInstance = new CrossConnectionListResponse.CrossConnection();
                            result.CrossConnections.Add(crossConnectionInstance);
                            
                            XElement bandwidthElement = crossConnectionsElement.Element(XName.Get("Bandwidth", "http://schemas.microsoft.com/windowsazure"));
                            if (bandwidthElement != null)
                            {
                                int bandwidthInstance = int.Parse(bandwidthElement.Value, CultureInfo.InvariantCulture);
                                crossConnectionInstance.Bandwidth = bandwidthInstance;
                            }
                            
                            XElement primaryAzurePortElement = crossConnectionsElement.Element(XName.Get("PrimaryAzurePort", "http://schemas.microsoft.com/windowsazure"));
                            if (primaryAzurePortElement != null)
                            {
                                string primaryAzurePortInstance = primaryAzurePortElement.Value;
                                crossConnectionInstance.PrimaryAzurePort = primaryAzurePortInstance;
                            }
                            
                            XElement provisioningStateElement = crossConnectionsElement.Element(XName.Get("ProvisioningState", "http://schemas.microsoft.com/windowsazure"));
                            if (provisioningStateElement != null)
                            {
                                string provisioningStateInstance = provisioningStateElement.Value;
                                crossConnectionInstance.ProvisioningState = provisioningStateInstance;
                            }
                            
                            XElement secondaryAzurePortElement = crossConnectionsElement.Element(XName.Get("SecondaryAzurePort", "http://schemas.microsoft.com/windowsazure"));
                            if (secondaryAzurePortElement != null)
                            {
                                string secondaryAzurePortInstance = secondaryAzurePortElement.Value;
                                crossConnectionInstance.SecondaryAzurePort = secondaryAzurePortInstance;
                            }
                            
                            XElement sTagElement = crossConnectionsElement.Element(XName.Get("STag", "http://schemas.microsoft.com/windowsazure"));
                            if (sTagElement != null)
                            {
                                int sTagInstance = int.Parse(sTagElement.Value, CultureInfo.InvariantCulture);
                                crossConnectionInstance.STag = sTagInstance;
                            }
                            
                            XElement statusElement = crossConnectionsElement.Element(XName.Get("Status", "http://schemas.microsoft.com/windowsazure"));
                            if (statusElement != null)
                            {
                                string statusInstance = statusElement.Value;
                                crossConnectionInstance.Status = statusInstance;
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
        /// The New Cross Connection operation provisions a cross connection
        /// for the given azure circuit.
        /// </summary>
        /// <param name='serviceKey'>
        /// Service key of the dedicated circuit.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The Get Cross Connection Operation Response.
        /// </returns>
        public async System.Threading.Tasks.Task<Microsoft.WindowsAzure.Management.ExpressRoute.Models.CrossConnectionGetResponse> NewAsync(string serviceKey, CancellationToken cancellationToken)
        {
            ExpressRouteManagementClient client = this.Client;
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serviceKey", serviceKey);
                Tracing.Enter(invocationId, this, "NewAsync", tracingParameters);
            }
            try
            {
                if (shouldTrace)
                {
                    client = this.Client.WithHandler(new ClientRequestTrackingHandler(invocationId));
                }
                
                cancellationToken.ThrowIfCancellationRequested();
                ExpressRouteOperationResponse originalResponse = await client.CrossConnection.BeginNewAsync(serviceKey, cancellationToken).ConfigureAwait(false);
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
                    string exStr = "A new cross connection could not be provisioned due to an internal server error.";
                    throw new ArgumentException(exStr);
                }
                cancellationToken.ThrowIfCancellationRequested();
                CrossConnectionGetResponse getResult = await client.CrossConnection.GetAsync(serviceKey, cancellationToken).ConfigureAwait(false);
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
        /// The Update Cross Connection operation updates an existing cross
        /// connection.
        /// </summary>
        /// <param name='serviceKey'>
        /// The service key representing the relationship between Azure and the
        /// customer.
        /// </param>
        /// <param name='parameters'>
        /// Parameters supplied to the Update Bgp Peering operation.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The Get Cross Connection Operation Response.
        /// </returns>
        public async System.Threading.Tasks.Task<Microsoft.WindowsAzure.Management.ExpressRoute.Models.CrossConnectionGetResponse> UpdateAsync(string serviceKey, CrossConnectionUpdateParameters parameters, CancellationToken cancellationToken)
        {
            ExpressRouteManagementClient client = this.Client;
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serviceKey", serviceKey);
                tracingParameters.Add("parameters", parameters);
                Tracing.Enter(invocationId, this, "UpdateAsync", tracingParameters);
            }
            try
            {
                if (shouldTrace)
                {
                    client = this.Client.WithHandler(new ClientRequestTrackingHandler(invocationId));
                }
                
                cancellationToken.ThrowIfCancellationRequested();
                ExpressRouteOperationResponse originalResponse = await client.CrossConnection.BeginUpdateAsync(serviceKey, parameters, cancellationToken).ConfigureAwait(false);
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
                    string exStr = "The cross connection could not be updated due to an internal server error.";
                    throw new ArgumentException(exStr);
                }
                cancellationToken.ThrowIfCancellationRequested();
                CrossConnectionGetResponse getResult = await client.CrossConnection.GetAsync(serviceKey, cancellationToken).ConfigureAwait(false);
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
    }
}
