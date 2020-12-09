import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { SelectedServicesPage } from './selected-services.page';

describe('SelectedServicesPage', () => {
  let component: SelectedServicesPage;
  let fixture: ComponentFixture<SelectedServicesPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SelectedServicesPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(SelectedServicesPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
