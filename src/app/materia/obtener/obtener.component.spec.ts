import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ObtenerComponentM } from './obtener.component';

describe('ObtenerComponent', () => {
  let component: ObtenerComponentM;
  let fixture: ComponentFixture<ObtenerComponentM>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ObtenerComponentM]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ObtenerComponentM);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
