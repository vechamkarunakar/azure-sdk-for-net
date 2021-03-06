// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.14.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.DataLake.Store
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// Creates a Data Lake Store filesystem management client.
    /// </summary>
    public partial class DataLakeStoreFileSystemManagementClient : ServiceClient<DataLakeStoreFileSystemManagementClient>, IDataLakeStoreFileSystemManagementClient, IAzureClient
    {
        /// <summary>
        /// Initializes a new instance of the DataLakeStoreFileSystemManagementClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Gets Azure subscription credentials.
        /// </param>
        /// <param name='userAgentAssemblyVersion'>
        /// Optional. The version string that should be sent in the user-agent header for all requests. The default is the current version of the SDK.
        /// </param>
        /// <param name='adlsFileSystemDnsSuffix'>
        /// Optional. The dns suffix to use for all requests for this client instance. The default is 'azuredatalakestore.net'.
        /// </param>
        /// <param name='clientTimeoutInMinutes'>
        /// Optional. The maximum amount of time the client will wait for the server to respond to a request. The default is five minutes.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        public DataLakeStoreFileSystemManagementClient(ServiceClientCredentials credentials, string userAgentAssemblyVersion = "", string adlsFileSystemDnsSuffix = DataLakeStoreCustomizationHelper.DefaultAdlsFileSystemDnsSuffix, int clientTimeoutInMinutes = 5, params DelegatingHandler[] handlers) : this(credentials, handlers)
        {
            this.AdlsFileSystemDnsSuffix = adlsFileSystemDnsSuffix;
            DataLakeStoreCustomizationHelper.UpdateUserAgentAssemblyVersion(this, userAgentAssemblyVersion);

            // for filesystem operations, it is up to the caller to utilize cancellation tokens to enforce granular
            // timeouts. Otherwise the client will overall timeout after the specified number of minutes (default is five).
            this.HttpClient.Timeout = TimeSpan.FromMinutes(clientTimeoutInMinutes);
        }

        /// <summary>
        /// Initializes a new instance of the DataLakeStoreFileSystemManagementClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Gets Azure subscription credentials.
        /// </param>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='userAgentAssemblyVersion'>
        /// Optional. The version string that should be sent in the user-agent header for all requests. The default is the current version of the SDK.
        /// </param>
        /// <param name='adlsFileSystemDnsSuffix'>
        /// Optional. The dns suffix to use for all requests for this client instance. The default is 'azuredatalakestore.net'.
        /// </param>
        /// <param name='clientTimeoutInMinutes'>
        /// Optional. The maximum amount of time the client will wait for the server to respond to a request. The default is five minutes.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The delegating handlers to add to the http client pipeline.
        /// </param>
        public DataLakeStoreFileSystemManagementClient(ServiceClientCredentials credentials, HttpClientHandler rootHandler, string userAgentAssemblyVersion = "", string adlsFileSystemDnsSuffix = DataLakeStoreCustomizationHelper.DefaultAdlsFileSystemDnsSuffix, int clientTimeoutInMinutes = 5, params DelegatingHandler[] handlers) : this(credentials, rootHandler, handlers)
        {
            this.AdlsFileSystemDnsSuffix = adlsFileSystemDnsSuffix;
            DataLakeStoreCustomizationHelper.UpdateUserAgentAssemblyVersion(this, userAgentAssemblyVersion);

            // for filesystem operations, it is up to the caller to utilize cancellation tokens to enforce granular
            // timeouts. Otherwise the client will overall timeout after the specified number of minutes (default is five).
            this.HttpClient.Timeout = TimeSpan.FromMinutes(clientTimeoutInMinutes);
        }
    }
}
