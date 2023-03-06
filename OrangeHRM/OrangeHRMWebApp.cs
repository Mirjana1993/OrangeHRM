using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace OrangeHRM
{
    [Trait("Category", "Smoke")]
    public class OrangeHRMWebApp
    {
        private const string HomeUrl = "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";
        private const string MyInfoUrl = "https://opensource-demo.orangehrmlive.com/web/index.php/pim/viewPersonalDetails/empNumber/7";
        private const string HomeTitle = "OrangeHRM";

        [Fact]
        public void LoginForTheFirstTime()
        {
            using (IWebDriver driver = new ChromeDriver())
            {

                driver.Navigate().GoToUrl(MyInfoUrl);

                driver.Manage().Window.Maximize();

                DemoHelper.Pause();

                driver.FindElement(By.XPath("//input[@placeholder='Username']")).SendKeys("Admin");
                DemoHelper.Pause();

                driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("admin123");
                DemoHelper.Pause();

                driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                DemoHelper.Pause();
                driver.FindElement(By.XPath("//span[normalize-space()='My Info']")).Click();
                DemoHelper.Pause();


                Assert.Equal(MyInfoUrl, driver.Url);

            }
        }
        [Fact]
        public void AddEmergencyContact()
        {
            using (IWebDriver driver = new ChromeDriver())
            {

                driver.Navigate().GoToUrl(MyInfoUrl);

                driver.Manage().Window.Maximize();

                DemoHelper.Pause();

                driver.FindElement(By.XPath("//input[@placeholder='Username']")).SendKeys("Admin");
                DemoHelper.Pause();

                driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("admin123");
                DemoHelper.Pause();

                driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                DemoHelper.Pause();
                driver.FindElement(By.XPath("//span[normalize-space()='My Info']")).Click();
                DemoHelper.Pause();

                driver.FindElement(By.XPath("//a[normalize-space()='Emergency Contacts']")).Click();
                DemoHelper.Pause();

                IWebElement button = driver.FindElement(By.CssSelector(".oxd-button.oxd-button--medium.oxd-button--text"));
                button.Click();
                DemoHelper.Pause();

                driver.FindElements(By.ClassName("oxd-input"))[1].SendKeys("Anna");
                DemoHelper.Pause();

                driver.FindElements(By.ClassName("oxd-input"))[2].SendKeys("Wife");
                DemoHelper.Pause();

                driver.FindElements(By.ClassName("oxd-input"))[4].SendKeys("070123456");
                DemoHelper.Pause();

                driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                DemoHelper.Pause(4000);

                IWebElement Name = driver.FindElement(By.XPath("//div[contains(text(),'Anna')]"));
                IWebElement Relationship = driver.FindElement(By.XPath("//div[contains(text(),'Wife')]"));
                IWebElement Mobile = driver.FindElement(By.XPath("//div[contains(text(),'070123456')]"));

                Assert.Equal("Anna", Name.Text);
                Assert.Equal("Wife", Relationship.Text);
                Assert.Equal("070123456", Mobile.Text);
            }
        }
        [Fact]
        public void AddDependentsWithoutFillingTheRequiredFields()
        {
            using (IWebDriver driver = new ChromeDriver())
            {

                driver.Navigate().GoToUrl(MyInfoUrl);

                driver.Manage().Window.Maximize();

                DemoHelper.Pause();

                driver.FindElement(By.XPath("//input[@placeholder='Username']")).SendKeys("Admin");
                DemoHelper.Pause();

                driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("admin123");
                DemoHelper.Pause();

                driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                DemoHelper.Pause();
                driver.FindElement(By.XPath("//span[normalize-space()='My Info']")).Click();
                DemoHelper.Pause();

                driver.FindElement(By.XPath("//a[normalize-space()='Dependents']")).Click();
                DemoHelper.Pause();

                IWebElement button = driver.FindElement(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--text' and @data-v-7e88b27e and @data-v-3dab643a]"));
                button.Click();
                DemoHelper.Pause();

                driver.FindElements(By.ClassName("oxd-input"))[1].SendKeys("Ema");
                DemoHelper.Pause();

                driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                DemoHelper.Pause(4000);

                IWebElement Name = driver.FindElement(By.XPath("//div[contains(text(),'Ema')]"));

                Assert.Equal("Ema", Name.Text);
            }
        }
        [Fact]
        public void AddMultipleWorkExperiences()
        {
            using (IWebDriver driver = new ChromeDriver())
            {

                driver.Navigate().GoToUrl(MyInfoUrl);

                driver.Manage().Window.Maximize();

                DemoHelper.Pause();

                driver.FindElement(By.XPath("//input[@placeholder='Username']")).SendKeys("Admin");
                DemoHelper.Pause();

                driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("admin123");
                DemoHelper.Pause();

                driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                DemoHelper.Pause();
                driver.FindElement(By.XPath("//span[normalize-space()='My Info']")).Click();
                DemoHelper.Pause();

                driver.FindElement(By.XPath("//a[normalize-space()='Qualifications']")).Click();
                DemoHelper.Pause();

                IWebElement button = driver.FindElement(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--text' and @data-v-7e88b27e and @data-v-3dab643a]"));
                button.Click();
                DemoHelper.Pause();

                driver.FindElements(By.ClassName("oxd-input"))[1].SendKeys("IT Labs");
                DemoHelper.Pause();

                driver.FindElements(By.ClassName("oxd-input"))[2].SendKeys("Junior Tester");
                DemoHelper.Pause();

                driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                DemoHelper.Pause();

                IWebElement button2 = driver.FindElement(By.XPath("//button[@class='oxd-button oxd-button--medium oxd-button--text' and @data-v-7e88b27e and @data-v-3dab643a]"));
                button.Click();
                DemoHelper.Pause();

                driver.FindElements(By.ClassName("oxd-input"))[1].SendKeys("One Inside");
                DemoHelper.Pause();

                driver.FindElements(By.ClassName("oxd-input"))[2].SendKeys("QA Engineer");
                DemoHelper.Pause();

                driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                DemoHelper.Pause(4000);

                IWebElement Company = driver.FindElement(By.XPath("//div[contains(text(),'IT Labs')]"));
                IWebElement JobTitle = driver.FindElement(By.XPath("//div[contains(text(),'Junior Tester')]"));
                IWebElement Company2 = driver.FindElement(By.XPath("//div[contains(text(),'One Inside')]"));
                IWebElement JobTitle2 = driver.FindElement(By.XPath("//div[contains(text(),'QA Engineer')]"));

                Assert.Equal("IT Labs", Company.Text);
                Assert.Equal("Junior Tester", JobTitle.Text);
                Assert.Equal("One Inside", Company2.Text);
                Assert.Equal("QA Engineer", JobTitle2.Text);
            }
        }
        [Fact]
        public void AddEmergencyContactWithInvalidDataType()
        {
            using (IWebDriver driver = new ChromeDriver())
            {

                driver.Navigate().GoToUrl(MyInfoUrl);

                driver.Manage().Window.Maximize();

                DemoHelper.Pause();

                driver.FindElement(By.XPath("//input[@placeholder='Username']")).SendKeys("Admin");
                DemoHelper.Pause();

                driver.FindElement(By.XPath("//input[@placeholder='Password']")).SendKeys("admin123");
                DemoHelper.Pause();

                driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                DemoHelper.Pause();
                driver.FindElement(By.XPath("//span[normalize-space()='My Info']")).Click();
                DemoHelper.Pause();

                driver.FindElement(By.XPath("//a[normalize-space()='Emergency Contacts']")).Click();
                DemoHelper.Pause();

                IWebElement button = driver.FindElement(By.CssSelector(".oxd-button.oxd-button--medium.oxd-button--text"));
                button.Click();
                DemoHelper.Pause();

                driver.FindElements(By.ClassName("oxd-input"))[1].SendKeys("Mila");
                DemoHelper.Pause();

                driver.FindElements(By.ClassName("oxd-input"))[2].SendKeys("Wife");
                DemoHelper.Pause();

                driver.FindElements(By.ClassName("oxd-input"))[4].SendKeys("aaa");
                DemoHelper.Pause();

                driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                DemoHelper.Pause(4000);

                IWebElement Name = driver.FindElement(By.XPath("//div[contains(text(),'Mila')]"));
                IWebElement Relationship = driver.FindElement(By.XPath("//div[contains(text(),'Wife')]"));
                //IWebElement Mobile = driver.FindElement(By.XPath("//div[contains(text(),'aaa')]"));
                
                // Act
                IWebElement errorMessage = driver.FindElement(By.ClassName("oxd-input-field-error-message"));

                // Assert
                Assert.Equal("Mila", Name.Text);
                Assert.Equal("Wife", Relationship.Text);
                Assert.True(errorMessage.Displayed);
                Assert.Equal("Invalid input data type", errorMessage.Text);

                

                //Assert.False(Mobile.Displayed);





            }
        }




    }
}