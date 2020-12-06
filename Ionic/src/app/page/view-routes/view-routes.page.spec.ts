import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { ViewRoutesPage } from './view-routes.page';

describe('ViewRoutesPage', () => {
  let component: ViewRoutesPage;
  let fixture: ComponentFixture<ViewRoutesPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewRoutesPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(ViewRoutesPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
