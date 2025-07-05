import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PositionManagement } from './position-management';

describe('PositionManagement', () => {
  let component: PositionManagement;
  let fixture: ComponentFixture<PositionManagement>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PositionManagement]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PositionManagement);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
