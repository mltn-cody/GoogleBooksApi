import { AppPage } from './app.po';
import { browser, by, element } from 'protractor';

describe('App', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  it('should display welcome message', () => {
    page.navigateToHome();
    expect(page.getMainHeading()).toEqual('Hello, Rob!');
  });

  it('should display loading', () => {
    page.navigateToSearch();
    page.search();
    expect(element(by.css('.loading')).isPresent()).toBe(true);
  });
});
