# AvaTrade

The repository contains the test automation UI project for the site https://www.avatrade.com/.

## Concepts Included

* Page Object pattern
* Test configuration is set through config.json file
* Screenshots are created in case of test failures

## Tools

* C#
* nUnit
* Selenium Webdriver

## Requirements

In order to use this project you need to have the following installed locally:

* .net 7
* Chrome and Chromedriver (UI tests use Chrome by default, can be changed in config)

## Usage
TestCases are located in `\AvaTrade\AvaTrade\TestCases` folder

The project is broken into separate modules: Framework, AvaTrade (WebAutomation) and AvaTradeMobile (Android Automation).

To run tests, navigate to `AvaTrade` directory and run: `dotnet test --filter "Category = SignUp"`

If test is failed screenshot is located in `\AvaTrade\AvaTrade\TestResult` folder