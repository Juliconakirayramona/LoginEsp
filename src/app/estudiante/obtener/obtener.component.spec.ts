import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ObtenerComponentEst } from './obtener.componentEst';

describe('ObtenerComponent', () => {
  let component: ObtenerComponentEst;
  let fixture: ComponentFixture<ObtenerComponentEst>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ObtenerComponentEst]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ObtenerComponentEst);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
