import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CalculoCdbComponent } from './calculo-cdb.component';

describe('CalculadoraCdbComponent', () => {
  let component: CalculoCdbComponent;
  let fixture: ComponentFixture<CalculoCdbComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CalculoCdbComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(CalculoCdbComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
