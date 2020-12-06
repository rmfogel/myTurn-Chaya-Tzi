import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { MapResultPage } from './map-result.page';

describe('MapResultPage', () => {
  let component: MapResultPage;
  let fixture: ComponentFixture<MapResultPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MapResultPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(MapResultPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
