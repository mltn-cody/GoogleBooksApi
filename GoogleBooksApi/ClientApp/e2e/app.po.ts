import { browser, by, element } from 'protractor';

export class AppPage {
  navigateToHome() {
    return browser.get('/');
  }

  navigateToSearch() {
    return browser.get('/fetch-data');
  }

  search() {
    let searchField = element(by.id('search_field'));
    searchField.clear();
    searchField.sendKeys("C#");
    element(by.buttonText('search')).click();

  }

  getMainHeading() {
    return element(by.css('app-root h1')).getText();
  }
}
