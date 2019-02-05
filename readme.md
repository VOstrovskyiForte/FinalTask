# PhpTravel and JsonPlaceholder Test Framework

This framework is developed for testing https://phptravels.com/ and https://jsonplaceholder.typicode.com/ websites. It would be better to create a separate solution for each of these websites, but the task was to create one framework
In root directory, there is bat file for running nunit console and generationg Allure report, all needed system variables should be set before running this bat

Work with XML configuration files is implemented here. Basic settings are loaded from the following files apiconfig.xml and webconfig.xml
### API:
  - **baseurl** - basic URL for requests
  - **environment** - release, debug, etc. Not used in current project because there is only release environment
  - **reportsfolder** - folder where logs are saved

### Web
  - **browser** - selects the browser, works with chrome and firefox
  - **environment** - release, debug, etc. Not used in current project because there is only release environment
  - **baseurl** - basic website URL
  - **reportsfolder** - folder where logs are saved
  - **screenshotsfolder** - path where screenshots will be generated, each test run wll create a folder with current time there

### Framework
Common:
  - **Generator** - generates random values
  - **Folders** - finds path to main folders
  - **Logging** - creating logger, screenshots

API:
  - **Actions** - methods for running specific requests and returning responses
  - **ConfigurationAPI** - contains main API configuration and methods to load settings
  - **Data** - test data classes
  - **Methods** - main methods for sending and deserializing requests
  - **Resources** - list of resources as strings

Web:
  - **ConfigurationWeb** - contains main Web configuration and methods to load settings
  - **Data** - test data classes
  - **Drivers** - creating and working with WebDriver
  - **JavaScript** - additional using JavaScriptExecutor
  - **Navigation** - opening specific pages and navigation
  
Only basic webelements and methods are implemented as it is a simple framework. Page objects contain elements needed for running tests. Other elements can be added if needed

After running, a log will be saved to file with current time in its name, it can be found in reports folder set in configs. Screenshots of failed tests can be found in a folder with current time in its name. These paths can be configured in config files