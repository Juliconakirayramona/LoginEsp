import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarComponentEst } from './agregar.componentEst';

describe('AgregarComponent', () => {
  let component: AgregarComponentEst;
  let fixture: ComponentFixture<AgregarComponentEst>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AgregarComponentEst]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AgregarComponentEst);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
