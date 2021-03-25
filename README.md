# TestKit
TestKit is a collection of libraries to provide simple, powerful Selenium selectors


## How to use

TestKit selectors can be used as follows

```
[Test]
public void BootstrapButtons()
{
    _driver.Navigate().GoToUrl("https://getbootstrap.com/");
    _driver.FindElement(BootstrapButton.WithHint("Get started")).Click();
}
```