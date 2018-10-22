Simple App using angular and .net core to render contents of google api to the browser. 

For secuirty reason I've left off my api key. To execute successfully open up the appsettings.json file and supply your own api key. 

There are two e2e test for the ui, using protractor. 
1) check the validity of the home screen. 
2) using navigation controls, switch to the search books tab, then checking for loading image using protractor.

To run this application:

In debug mode I use visual studio's standard settings, for IIS Express.
Requirements are .netcore, and npm. 