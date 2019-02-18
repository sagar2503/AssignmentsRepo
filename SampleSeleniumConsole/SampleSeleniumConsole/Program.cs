using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;
using System.Collections.Generic;
using OpenQA.Selenium.Remote;



namespace SampleSeleniumConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //GmailLogin();

            /*
            InternetExplorerDriver iedriver = new InternetExplorerDriver("C:\\Software\\");

            iedriver.Navigate().GoToUrl("https://www.google.com/");

            System.Diagnostics.Process[] p = System.Diagnostics.Process.GetProcessesByName("iexplore");
            if (p.Length > 0)
            {
                //Do Something
                //SetForegroundWindow(p[p.Length-1].MainWindowHandle);
                iedriver.SwitchTo().Window("Google - Internet Explorer");
                //InternetExplorerDriver iedriver = new InternetExplorerDriver(@"C:\Software\");                
            }
            else //Not Found
            {
                Console.WriteLine("Window Not Found!");
            }
            */

            string strafterPKIverified = string.Empty;
            strafterPKIverified = "https://admingate-emea.saacon.net/Citrix/XenApp/auth/login.aspx";
            Program obj = new Program();            
            obj.Opensacconwithcredential(strafterPKIverified);            

        }

        private static void GmailLogin()
        {
            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // 2. Go to the "Google" homepage
            driver.Navigate().GoToUrl("http://www.gmail.co.in");


            //ChromeWebElement myEmail = (ChromeWebElement)driver.FindElementByName("email");
            var EmaiID = driver.FindElementById("identifierId");
            EmaiID.SendKeys("sagar.a.joshi@gmail.com");

            var btnnext = driver.FindElementById("identifierNext");

            //ChromeWebElement btnnext = (ChromeWebElement)driver.FindElementsByClassName("RveJvd snByac").First();
            btnnext.Click();

            var txtpassword = driver.FindElementById("password");
            txtpassword.Click();
            txtpassword.SendKeys("");

            var btnpasswordNext = driver.FindElementById("passwordNext");
            btnpasswordNext.Click();
            //myEmail.SendKeys("anihurpade");
        }

        public void opensacconhomepage()
        {
            string strInitialsacconurl = string.Empty;
            strInitialsacconurl = "https://fidm.access.it-solutions.atos.net/auth/Login?GASF=CERTIFICATE&GAREASONCODE=-1&GARESOURCEID=ga^default^global^resource&GAURI=https://fidm.access.it%2Dsolutions.atos.net/GetAccess/Pmda%3FMDURI%3DaHR0cHM6Ly9hZG1pbmdhdGUtZW1lYS5zYWFjb24ubmV0L0NpdHJpeC9YZW5BcHAvYXV0aC9sb2dpbi5hc3B4%26SD%3D.saacon.net%26GARESOURCEID%3DAdmingateEmeaR2%26APPID%3DAdmingateEmeaR2";


            ChromeDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            // 1. Go to the "saccon" homepage
            driver.Navigate().GoToUrl(strInitialsacconurl);



            //ChromeWebElement myEmail = (ChromeWebElement)driver.FindElementByName("email");
            var butPKI_LOGIN = driver.FindElementById("PKI_LOGIN");
            butPKI_LOGIN.Click();

        }

        public bool checkurl(string strafterPKIverified)
        {
            bool RVal = false;


            IWebDriver driverurl = new ChromeDriver();
            String currentURL = driverurl.Url;

            if (currentURL.Contains(strafterPKIverified))
            {
                RVal = true;
            }

            return RVal;
        }

        public void Opensacconwithcredential(string strafterPKIverified)
        {
            string strDasID = string.Empty;
            string strsacconpassword = string.Empty;
            var doc = new XmlDocument();
            doc.Load(@"mycre.xml");

            var root = doc.DocumentElement;

            if (root == null)
                return;

            var books = root.SelectNodes("saccon");
            if (books == null)
                return;

            foreach (XmlNode book in books)
            {               
                strDasID = book.SelectSingleNode("dasid").InnerText;
                strsacconpassword = book.SelectSingleNode("password").InnerText;                
            }

            ChromeOptions co = new ChromeOptions();
            //co.AddArguments("--disable-notifications");
            ChromeDriver driver = new ChromeDriver();           
            
            
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(strafterPKIverified);
            
            var PKI = driver.FindElementByName("PKI_LOGIN");

            PKI.Click();



            //PKI.SendKeys(Keys.Enter);

            var saaconUserId = driver.FindElementById("user");
            saaconUserId.SendKeys("a647245");
            var saaconPwd = driver.FindElementById("password");
            saaconPwd.SendKeys("December@25032004");

            var saaconbtnLogin = driver.FindElementById("btnLogin");
            saaconbtnLogin.Click();

            var folderLink_21 = driver.FindElementById("folderLink_21");
            folderLink_21.Click();

            var folderLink_44 = driver.FindElementById("folderLink_44");
            folderLink_44.Click();

            var downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            DirectoryInfo dinfo2 = new DirectoryInfo(downloadsFolder);

            var originalICAfileCount = dinfo2.GetFiles("*.ica").Count();
                          

            var idCitrix = driver.FindElementById("idCitrix.MPS.App.AdmingateSaaconV2.BMW_0020Europe_0020Farm_0020managed_0020by_0020customer_005fDE");
            idCitrix.Click();

            while(true)
            {
                var newICAfileCount = dinfo2.GetFiles("*.ica").Count();
                if (newICAfileCount > originalICAfileCount)
                    break;
            
            }
            
            var myFile = (from f in dinfo2.GetFiles("*.ica")
                          orderby f.LastWriteTime descending
                          select f.FullName).First();

            InternetExplorerDriver iedriver = new InternetExplorerDriver("C:\\Software\\");

            iedriver.Navigate().GoToUrl("https://www.google.com/");

            int windowhandles1 = iedriver.WindowHandles.Count;
           
            Console.WriteLine("Before Windowhandles"+ windowhandles1.ToString());

            Console.WriteLine("Window Name" + iedriver.WindowHandles[0].ToString());

            Process.Start(myFile);

            System.Threading.Thread.Sleep(10000);

            //WinClient uICitrixAccessGatewayIClient = this.UICitrixAccessGatewayIWindow.UICitrixAccessGatewayIClient;

            //IntPtr hWnd = FindWindow("", "Untitled - Notepad");
            //if (hWnd.ToInt32() > 0) //If found
            //{
            //    //Do Something
            //}
            //else //Not Found
            //{
            //    Console.WriteLine("Window Not Found!");
            //}
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        // Find window by Caption only. Note you must pass IntPtr.Zero as the first parameter.
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
