// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace PSRule.Rules.Azure.Data
{
    public sealed class CloudEnvironment
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "gallery")]
        public string Gallery { get; set; }

        [JsonProperty(PropertyName = "graph")]
        public string Graph { get; set; }

        [JsonProperty(PropertyName = "portal")]
        public string Portal { get; set; }

        [JsonProperty(PropertyName = "graphAudience")]
        public string GraphAudience { get; set; }

        [JsonProperty(PropertyName = "activeDirectoryDataLake")]
        public string ActiveDirectoryDataLake { get; set; }

        [JsonProperty(PropertyName = "batch")]
        public string Batch { get; set; }

        [JsonProperty(PropertyName = "media")]
        public string Media { get; set; }

        [JsonProperty(PropertyName = "sqlManagement")]
        public string SqlManagement { get; set; }

        [JsonProperty(PropertyName = "vmImageAliasDoc")]
        public string VmImageAliasDoc { get; set; }

        [JsonProperty(PropertyName = "resourceManager")]
        public string ResourceManager { get; set; }

        [JsonProperty(PropertyName = "authentication")]
        public CloudEnvironmentAuthentication Authentication { get; set; }

        [JsonProperty(PropertyName = "suffixes")]
        public CloudEnvironmentSuffixes Suffixes { get; set; }
    }

    public sealed class CloudEnvironmentAuthentication
    {
        [JsonProperty(PropertyName = "loginEndpoint")]
        public string loginEndpoint { get; set; }

        [JsonProperty(PropertyName = "audiences")]
        public string[] audiences { get; set; }

        [JsonProperty(PropertyName = "tenant")]
        public string tenant { get; set; }

        [JsonProperty(PropertyName = "identityProvider")]
        public string identityProvider { get; set; }
    }

    public sealed class CloudEnvironmentSuffixes
    {
        [JsonProperty(PropertyName = "acrLoginServer")]
        public string acrLoginServer { get; set; }

        [JsonProperty(PropertyName = "azureDatalakeAnalyticsCatalogAndJob")]
        public string azureDatalakeAnalyticsCatalogAndJob { get; set; }

        [JsonProperty(PropertyName = "azureDatalakeStoreFileSystem")]
        public string azureDatalakeStoreFileSystem { get; set; }

        [JsonProperty(PropertyName = "azureFrontDoorEndpointSuffix")]
        public string azureFrontDoorEndpointSuffix { get; set; }

        [JsonProperty(PropertyName = "keyvaultDns")]
        public string keyvaultDns { get; set; }

        [JsonProperty(PropertyName = "sqlServerHostname")]
        public string sqlServerHostname { get; set; }

        [JsonProperty(PropertyName = "storage")]
        public string storage { get; set; }
    }
}
