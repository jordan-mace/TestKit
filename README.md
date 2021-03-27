[![Nuget](https://img.shields.io/nuget/v/TestKit.Bootstrap?style=flat-square)](https://www.nuget.org/packages/TestKit.Bootstrap/)
![GitHub Workflow Status](https://img.shields.io/github/workflow/status/jordan-mace/TestKit/.NET?style=flat-square)
# TestKit
TestKit is a collection of libraries to provide simple, powerful Selenium selectors

## Purpose
The purpose of this project is to provide easy to use selectors for use with Selenium.

* Button
* Checkbox
* Input
* RadioButton
* And more

## How to use

TestKit selectors can be used as follows

```
[Test]
public void BootstrapButtons()
{
    _driver.Navigate().GoToUrl("https://getbootstrap.com/");
    _driver.FindElement(Button.WithHint("Get started")).Click();
}
```