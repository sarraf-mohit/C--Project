using System.Xml;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LoginProject
{
    class LoginTest
    {
        private IWebDriver driver;
        private LoginPage login;
        string xmlFilePath = "C:\\Users\\mohit.sarraf\\source\\repos\\LoginProject\\LoginProject\\TestData.xml";

        // Create an instance of XmlDocument
        XmlDocument xmlDocument = new XmlDocument();

        public static void Main()
        {
            LoginTest loginTest = new LoginTest();
            loginTest.Setup();
            loginTest.Login();
        }

        public void Setup()
        {
            driver = new ChromeDriver();

            // Load the XML document
            xmlDocument.Load(xmlFilePath);

            // Extract the XML document
            XmlNode urlNode = xmlDocument.SelectSingleNode("/TestData/Site");
            string url = urlNode.SelectSingleNode("Url")?.InnerText;

            driver.Navigate().GoToUrl(url);
            login = new LoginPage(driver);
        }

        public void Login()
        {
            login.GoToLogin();

            // Load the XML document
            xmlDocument.Load(xmlFilePath);

            // Extract the XML document
            XmlNode userNode = xmlDocument.SelectSingleNode("/TestData/User");
            string username = userNode.SelectSingleNode("Username")?.InnerText;
            string password = userNode.SelectSingleNode("Password")?.InnerText;

            login.LoginApplication(username, password);
        }
    }
}
