import { browser, by, element, Ptor } from 'protractor';

export class AppPage {
  navigateTo() {
    return browser.get('/');
  }

  getParagraphText() {
    return element(by.css('app-root a')).getText();
  }

  getRows(){
    let rows = element.all(by.css('.user-item'));

    return rows;
  }

  getFirstName(){
    return element.all(by.css('tr td.login-name')).first().getText();
  }

  clickFirstPerson() {
    element.all(by.css('.user-item')).first().click();
  }

  waitForURLContain(urlExpected: string, timeout: number) {
    try {
        const condition = browser.ExpectedConditions;
        browser.wait(condition.urlContains(urlExpected), timeout);
    } catch (e) {
        console.error('URL sem texto', e);
    };
}
}
