using System;
using System.Management.Automation;
using Ayehu.Sdk.ActivityCreation.Interfaces;
using Ayehu.Sdk.ActivityCreation.Extension;
using System.Management.Automation.Runspaces;
using System.Security;
using System.Collections.Generic;
using System.IO;
using System.Data;

namespace Ayehu.Sdk.ActivityCreation
{
    public class ActivityClass : IActivity
    {
        public string HostName = null;
        public string UserName = null;
        public string Password = null;


        public string Name = null;
        public string IsSnapshot =null;


        private Dictionary<string, object> CreateParameters()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            if(IsSnapshot=="Yes")
                parameters.Add("VMSnapshot", Name );
            else
                parameters.Add("VMName", Name );
           
            return parameters;
        }
        public ICustomActivityResult Execute()
        {
            string command = "Get-VMMemory";
            using (RemotePowershell rp = new RemotePowershell(UserName, Password, HostName))
            {
                PowerShell ps = rp.powerShell;
                var results = ps.AddCommand(command)
                    .AddParameters(CreateParameters())
                    .Invoke();
                if (rp.HasError)
                {
                    throw new Exception(rp.ErrorMessage);
                }
                if(results.Count!=1)
                    throw new Exception("Can't get virtual machine information");
                string state = results[0].Properties["state"].Value.ToString();
                return this.GenerateActivityResult(SuccessResult(state));
            }

        }

        private DataTable SuccessResult(string state)
        {
            DataTable dt = new DataTable("resultSet");
            dt.Columns.Add("Result", typeof(string));
            dt.Rows.Add(state);
            return dt;
        }


    }
    class RemotePowershell : IDisposable
    {
        private Runspace runspace;
        public PowerShell powerShell;
        public RemotePowershell(string username, string password, string host)
        {
            runspace = RunspaceFactory.CreateRunspace(CreateConnection(username, password, host));

            runspace.Open();
            powerShell = PowerShell.Create();
            powerShell.Runspace = runspace;
        }
        WSManConnectionInfo CreateConnection(string username, string password, string host)
        {
            SecureString securePassword = new SecureString();
            foreach (char c in password)
            {
                securePassword.AppendChar(c);
            }
            PSCredential creds = new PSCredential(username, securePassword);

            WSManConnectionInfo connectionInfo = new WSManConnectionInfo();
            connectionInfo.ComputerName = host;
            connectionInfo.Credential = creds;
            connectionInfo.SkipCACheck = true;
            connectionInfo.SkipCNCheck = true;
            return connectionInfo;

        }
        public void Dispose()
        {
            try
            {
                powerShell.Dispose();
                runspace.Dispose();
            }
            catch
            {
            }

        }
        public bool HasError
        {
            get
            {
                return powerShell.Streams.Error.Count > 0;
            }
        }
        public string ErrorMessage
        {
            get
            {
                if (!HasError)
                {
                    return null;
                }
                StringWriter sw = new StringWriter();
                foreach (var error in powerShell.Streams.Error)
                {
                    sw.WriteLine(error.ToString());
                }
                return sw.ToString();
            }
        }
    }


}
