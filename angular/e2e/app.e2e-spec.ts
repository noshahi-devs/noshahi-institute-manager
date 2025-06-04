import { NIMTemplatePage } from './app.po';

describe('NIM App', function() {
  let page: NIMTemplatePage;

  beforeEach(() => {
    page = new NIMTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
