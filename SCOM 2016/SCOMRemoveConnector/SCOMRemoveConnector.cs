using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using Ayehu.Sdk.ActivityCreation.Extension;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Microsoft.EnterpriseManagement;
using Microsoft.EnterpriseManagement.Configuration;
using Microsoft.EnterpriseManagement.ConnectorFramework;

namespace CustomActivities
{

    public class ScomRemoveConnector : IActivity
    {
        public string Server;
        public string Domain;
        public string Username;
        public string Password;
        public string ConnectorName;

        public ICustomActivityResult Execute()
        {
            try
            {
                if (string.IsNullOrEmpty(Server) || Server.Trim().Equals(string.Empty))
                {
                    throw new Exception("Server is missing");
                }

                if (string.IsNullOrEmpty(Username) || Username.Trim().Equals(string.Empty))
                {
                    throw new Exception("Username is missing");
                }

                if (string.IsNullOrEmpty(Password) || Password.Trim().Equals(string.Empty))
                {
                    throw new Exception("Password is missing");
                }

                if (string.IsNullOrEmpty(Domain) || Domain.Trim().Equals(string.Empty))
                {
                    throw new Exception("Domain is missing");
                }

                if (string.IsNullOrEmpty(ConnectorName) || ConnectorName.Trim().Equals(string.Empty))
                {
                    throw new Exception("Connector Name is missing");
                }

                var returnedResultBuilder = new List<string>();

                var secureString = new SecureString();
                foreach (var ch in Password)
                {
                    secureString.AppendChar(ch);
                }

                var connectionSettings = new ManagementGroupConnectionSettings(Server)
                {
                    ServerName = Server,
                    UserName = Username,
                    Domain = Domain,
                    Password = secureString
                };

                var managementGroup = new ManagementGroup(connectionSettings);

                try
                {
                    var connectorName = ConnectorName;
                    var connectors = managementGroup.ConnectorFramework.GetConnectors()
                        .Where(monitoringConnector => monitoringConnector.Name.Equals(string.Format("{0} Connector", ConnectorName)))
                        .ToList();

                    if (connectors.Any())
                    {
                        connectors.ForEach(connector => RemoveConnector(managementGroup, connector));
                    }
                    else
                    {
                        returnedResultBuilder.Add(string.Format("Connector \"{0} Connector\" does not exist", ConnectorName));
                    }

                    var managementPacks = managementGroup.ManagementPacks.GetManagementPacks()
                        .Where(managementPack => managementPack.Name.Equals(string.Format("{0}.Integration.Library", connectorName)))
                        .ToList();

                    if (managementPacks.Any())
                    {
                        managementPacks.ForEach(managementPack => RemoveManagementPack(managementGroup, managementPack));
                    }
                    else
                    {
                        returnedResultBuilder.Add(string.Format("ManagementPack \"{0}.Integration.Library\" does not exist", connectorName));
                    }
                }

                catch (Exception ex)
                {
                    // ignored
                }

                return this.GenerateActivityResult(returnedResultBuilder.Count > 0 ? string.Join(", ", returnedResultBuilder) : "Success");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        private static void RemoveManagementPack(EnterpriseManagementGroup managementGroup, ManagementPack managementPack)
        {
            managementGroup.ManagementPacks.UninstallManagementPack(managementPack);
        }

        public void RemoveConnector(ManagementGroup managementGroup, MonitoringConnector monitoringConnector)
        {
            var subscriptions = managementGroup.ConnectorFramework.GetConnectorSubscriptions();
            foreach (var subscription in subscriptions)
            {
                managementGroup.ConnectorFramework.DeleteConnectorSubscription(subscription);
            }

            try
            {
                monitoringConnector.Uninitialize();
            }
            catch (Exception)
            {
                // ignored
            }

            try
            {
                managementGroup.ConnectorFramework.Cleanup(monitoringConnector);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }

}