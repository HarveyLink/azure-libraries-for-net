using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Rest;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace ManageStorageAccountNew
{
    public class Program
    {
        /**
         * Azure Storage sample for managing storage accounts -
         *  - Create a storage account
         *  - Get | regenerate storage account access keys
         *  - Create another storage account
         *  - List storage accounts
         *  - Delete a storage account.
         */

        private static readonly string GroupName = "TestMigrationRG";
        private static readonly string DefaultLocation = "eastus2";
        private static readonly string DefaultSkuName = SkuName.StandardGRS;
        private static readonly string DefaultKind = Kind.Storage;
        private static readonly string AccountName1 = "TestMigartionAccount1";
        private static readonly string AccountName2 = "TestMigartionAccount2";
        private static readonly string SubscriptionId = Environment.GetEnvironmentVariable("SubscriptionId");
        private static readonly string ClientId = Environment.GetEnvironmentVariable("ClientId");
        private static readonly string ServicePrincipalPassword = Environment.GetEnvironmentVariable("ServicePrincipalPassword");
        private static readonly string AzureTenantId = Environment.GetEnvironmentVariable("AzureTenantId");

        public static void RunSample(ResourceManagementClient resourcesClient)
        {
            try
            {
                // ============================================================
                // Create a storage account
                Utilities.Log("Creating a Storage Account");

                Dictionary<string, string> DefaultTags = new Dictionary<string, string>
                {
                    {"key1","value1"},
                    {"key2","value2"}
                };
                StorageAccountCreateParameters parameters = new StorageAccountCreateParameters
                {
                    Location = DefaultLocation,
                    Tags = DefaultTags,
                    Sku = new Microsoft.Azure.Management.Storage.Models.Sku { Name = DefaultSkuName },
                    Kind = DefaultKind,
                };

                StorageManagementClient storageClient;
                storageClient = new StorageManagementClient(new TokenCredentials(GetToken()));
                storageClient.SubscriptionId = SubscriptionId;
                storageClient.BaseUri = new Uri(""); 

                var account = storageClient.StorageAccounts.Create(GroupName, AccountName1, parameters);

                Utilities.Log("Created a Storage Account:");
                Utilities.Log($"{account.Name} created @ {account.CreationTime}");

                // ============================================================
                // Get | regenerate storage account access keys

                Utilities.Log("Getting storage account access keys");

                var storageAccountKeys = storageClient.StorageAccounts.ListKeys(GroupName, AccountName1);
                StorageAccountKey key1 = storageAccountKeys.Keys.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key1"));
                StorageAccountKey key2 = storageAccountKeys.Keys.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key2"));

                Utilities.Log($"Key {key1.KeyName} = {key1.Value}");
                Utilities.Log($"Key {key2.KeyName} = {key2.Value}");

                Utilities.Log("Regenerating first storage account access key");

                var regenKeys = storageClient.StorageAccounts.RegenerateKey(GroupName, AccountName1, "key2");
                key2 = storageAccountKeys.Keys.First(
                    t => StringComparer.OrdinalIgnoreCase.Equals(t.KeyName, "key2"));

                Utilities.Log($"Key {key2.KeyName} = {key2.Value}");

                // ============================================================
                // Create another storage account

                Utilities.Log("Creating a 2nd Storage Account");

                var account2 = storageClient.StorageAccounts.Create(GroupName, AccountName2, parameters);

                Utilities.Log("Created a Storage Account:");
                Utilities.Log($"{account2.Name} created @ {account2.CreationTime}");

                // ============================================================
                // Update storage account by enabling encryption

                Utilities.Log($"Enabling encryption for the storage account: {account2.Name}");

                var updatedParameters = new StorageAccountUpdateParameters
                {
                    Encryption = new Encryption()
                    {
                        Services = new EncryptionServices { Blob = new EncryptionService { Enabled = true }, File = new EncryptionService { Enabled = true } },
                        KeySource = KeySource.MicrosoftStorage
                    }
                };
                account2 = storageClient.StorageAccounts.Update(GroupName, AccountName2, updatedParameters);

                Utilities.Log($"Encryption status of the service {account2.Encryption}");

                // ============================================================
                // List storage accounts

                Utilities.Log("Listing storage accounts");

                var accounts = storageClient.StorageAccounts.ListByResourceGroup(GroupName);

                foreach (var item in accounts)
                {
                    Utilities.Log($"Storage Account {item.Name} created @ {item.CreationTime}");
                }

                // ============================================================
                // Delete a storage account

                Utilities.Log($"Deleting a storage account - {accounts.ElementAt(0).Name} created @ {accounts.ElementAt(0).CreationTime}");

                storageClient.StorageAccounts.Delete(GroupName, AccountName1);

                Utilities.Log("Deleted storage account");
            }
            finally
            {
                if (resourcesClient.ResourceGroups.Get(GroupName) != null)
                {
                    Utilities.Log("Deleting Resource Group: " + GroupName);
                    resourcesClient.ResourceGroups.Delete(GroupName);
                    Utilities.Log("Deleted Resource Group: " + GroupName);
                }
                else
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
            }
        }

        public static void Main(string[] args)
        {
            try
            {
                GetTest();
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }

        public static void GetTest()
        {
            // Create a resource group
            Utilities.Log("Creating a Resource Group");

            ResourceManagementClient resourcesClient = new ResourceManagementClient(new TokenCredentials(GetToken()));
            resourcesClient.SubscriptionId = SubscriptionId;
            var resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
               GroupName,
               new ResourceGroup
               {
                   Location = DefaultLocation
               });

            Utilities.Log($"Resource Group Created {resourceGroup.Name} ");

            // Run Sample
            RunSample(resourcesClient);
        }

        public static string GetToken()
        {
            ClientCredential cc = new ClientCredential(ClientId, ServicePrincipalPassword);
            var context = new AuthenticationContext("https://login.windows.net/" + AzureTenantId);
            var result = context.AcquireTokenAsync("https://management.azure.com/", cc);
            if (result == null)
            {
                throw new InvalidOperationException("Failed to obtain the token");
            }

            return result.Result.AccessToken;
        }
    }
}
