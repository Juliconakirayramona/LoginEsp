import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarComponentM } from './agregar.component';

describe('AgregarComponent', () => {
  let component: AgregarComponentM;
  let fixture: ComponentFixture<AgregarComponentM>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AgregarComponentM]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AgregarComponentM);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
