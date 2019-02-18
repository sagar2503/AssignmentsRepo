using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Deploying_Reports_in_Reporting_Services_Programmatically.localhost;
using System.Xml.Linq;
using System.ComponentModel;
using System.Web.Services.Protocols;
using System.IO;

namespace Deploying_Reports_in_Reporting_Services_Programmatically
{
    class Program
    {
        static void Main(string[] args)
        {
            DeployReports();
        }

        /// <summary>
        /// Deploys Reports, DataSources, and Reports in Reporting Services by values configured in the application configuration file.
        /// </summary>
        private static void DeployReports()
        {
            CreateFolders(
                ConfigurationSettings.AppSettings["FoldersXMLFilePath"]);
            CreateDataSources(
                ConfigurationSettings.AppSettings["DataSourcesXMLFilePath"]);
            CreateReports(Report.GetReports(
               ConfigurationSettings.AppSettings["ReportsXMLFilePath"]));
        }

        /// <summary>
        /// Creates Folder in Reporting Services.
        /// </summary>
        /// <param name="folderXMLFilePath">XML file path holds folder information.</param>
        private static void CreateFolders(string folderXMLFilePath)
        {
            ReportingService reportingServicesClient =
                new ReportingService();
            reportingServicesClient.Credentials = System.Net.CredentialCache.DefaultCredentials;

            XDocument xmlDoc = XDocument.Load(folderXMLFilePath);

            try
            {
                var result = from c in xmlDoc.Descendants("Folder")
                             select new
                             {
                                 name = (string)c.Element("Name").Value,
                                 parentFolder = (string)c.Element("ParentFolder").Value
                             };

                foreach (var row in result)
                {
                    reportingServicesClient.CreateFolder(row.name, row.parentFolder, null);
                    Logging.Log(string.Format("Folder {0} created successfully", row.name));
                }
            }
            catch (Exception er)
            {
                Logging.Log(er.Message);
            }
        }

        /// <summary>
        /// Creates Data Sources in Reporting Services.
        /// </summary>
        /// <param name="datasourceXMLFilePath">XML file path holds Data Sources information.</param>
        private static void CreateDataSources(string datasourceXMLFilePath)
        {
            ReportingService reportingServicesClient =
                new ReportingService();
            reportingServicesClient.Credentials = System.Net.CredentialCache.DefaultCredentials;

            DataSourceDefinition tempDataSource;
            XDocument xmlDoc = XDocument.Load(datasourceXMLFilePath);

            try
            {
                var result = from c in xmlDoc.Descendants("DataSource")
                             select new
                             {
                                 name = (string)c.Element("Name").Value,
                                 folder = (string)c.Element("Folder").Value,
                                 description = (string)c.Element("Description").Value,
                                 hideInListView = (string)c.Element("HideInListView").Value,
                                 enabled = (string)c.Element("Enabled").Value,
                                 connectionString = (string)c.Element("ConnectionString").Value,
                                 extension = (string)c.Element("Extension").Value,
                                 credentialRetrieval = (string)c.Element("CredentialRetrieval").Value,
                                 windowsCredentials = (string)c.Element("WindowsCredentials").Value,
                                 impersonateUser = (string)c.Element("ImpersonateUser").Value,
                                 impersonateUserSpecified = (string)c.Element("ImpersonateUserSpecified").Value,
                                 prompt = (string)c.Element("Prompt").Value,
                                 userName = (string)c.Element("UserName").Value,
                                 password = (string)c.Element("Password").Value,
                                 enabledSpecified = (string)c.Element("EnabledSpecified").Value
                             };

                foreach (var row in result)
                {
                    CredentialRetrievalEnum credentialRetrieval;
                    EnumConverter ec =
                        new EnumConverter(typeof(CredentialRetrievalEnum));

                    credentialRetrieval = (CredentialRetrievalEnum)ec.ConvertFromString(row.credentialRetrieval);

                    tempDataSource = new DataSourceDefinition();
                    tempDataSource.CredentialRetrieval = credentialRetrieval;
                    tempDataSource.ConnectString = row.connectionString;
                    tempDataSource.Enabled = bool.Parse(row.enabled);
                    tempDataSource.EnabledSpecified = bool.Parse(row.enabledSpecified);
                    tempDataSource.Extension = row.extension;
                    tempDataSource.ImpersonateUserSpecified = bool.Parse(row.impersonateUserSpecified);
                    tempDataSource.ImpersonateUser = bool.Parse(row.impersonateUser);
                    tempDataSource.Prompt = row.prompt;
                    tempDataSource.WindowsCredentials = bool.Parse(row.windowsCredentials);
                    //tempDataSource.UserName = row.userName;
                    //tempDataSource.Password = row.password;

                    try
                    {
                        reportingServicesClient.CreateDataSource(row.name, row.folder, true, tempDataSource,
                            null);

                        Logging.Log(string.Format("Data Source {0} has created successfully", row.name));
                    }

                    catch (SoapException e)
                    {
                        Logging.Log(e.Detail.InnerXml.ToString());
                    }
                }
            }
            catch (Exception er)
            {
                Logging.Log(er.Message);
            }
        }

        /// <summary>
        /// Creates Reports in Reporting Services.
        /// </summary>
        /// <param name="reports">XML file path holds Reports information.</param>
        private static  void CreateReports(Report[] reports)
        {
            ReportingService rsc =
                new ReportingService();

            rsc.Credentials = System.Net.CredentialCache.DefaultCredentials;

            foreach (Report aReport in reports)
            {

                Byte[] definition = null;
                Warning[] warnings = null;

                try
                {
                    FileStream stream = File.OpenRead(aReport.Path);
                    definition = new Byte[stream.Length];
                    stream.Read(definition, 0, (int)stream.Length);
                    stream.Close();
                }

                catch (IOException e)
                {
                    Logging.Log(e.Message);
                }

                try
                {
                    rsc.CreateReport(aReport.Name, aReport.Folder, true, definition, null);

                    #region Setting Report Data Source
                    DataSourceReference reference = new DataSourceReference();
                    reference.Reference = aReport.DataSource;
                    DataSource[] dataSources = new DataSource[1];
                    DataSource ds = new DataSource();
                    ds.Item = (DataSourceDefinitionOrReference)reference;
                    ds.Name = aReport.DataSource.Split('/').Last();
                    dataSources[0] = ds;
                    rsc.SetReportDataSources(aReport.Folder + "/" + aReport.Name, dataSources);
                    #endregion

                    if (warnings != null)
                    {
                        foreach (Warning warning in warnings)
                        {
                            Logging.Log(string.Format("Report: {0} has warnings", warning.Message));
                        }
                    }
                    else
                        Logging.Log(string.Format("Report: {0} created successfully with no warnings", aReport.Name));
                }

                catch (SoapException e)
                {
                    Logging.Log(e.Detail.InnerXml.ToString());
                }
            }
        }
    }
}
