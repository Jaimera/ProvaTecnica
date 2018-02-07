import { AppPage } from './app.po';
import { browser } from 'protractor';
import { Ptor } from 'protractor/built/ptor';

describe('web-site App', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  it('Deve mostrar header com nome da solução', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('Prova Pratica');
  });

  it ('Deve redirecionar para listagem de usuarios', () => {
    page.navigateTo();
    page.waitForURLContain('/users', 30000);
    expect(browser.getCurrentUrl()).toContain('/users');
  });

  it ('Deve listar ao menos 5 usuarios', () => {
    page.navigateTo();
    page.waitForURLContain('/users', 30000);

    page.getRows().then(t => {
      expect(t.length).toBeGreaterThan(5);
    });
  });

  it ('Deve ir para details com o nome do primeiro usuario na url', () => {
    page.navigateTo();
    page.waitForURLContain('/users', 30000);

    page.getFirstName().then(nome => {
      page.clickFirstPerson();
      
      browser.getCurrentUrl().then(function(url: string) {
        expect(url.endsWith(nome)).toBe(true);
      });
    });
  })
});
