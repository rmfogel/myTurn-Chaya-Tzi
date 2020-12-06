import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { CreateRoutePage } from './create-route.page';

describe('CreateRoutePage', () => {
  let component: CreateRoutePage;
  let fixture: ComponentFixture<CreateRoutePage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateRoutePage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(CreateRoutePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
