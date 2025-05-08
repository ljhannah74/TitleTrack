import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TitleAbstractDetailsComponent } from './title-abstract-details.component';

describe('TitleAbstractDetailsComponent', () => {
  let component: TitleAbstractDetailsComponent;
  let fixture: ComponentFixture<TitleAbstractDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TitleAbstractDetailsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TitleAbstractDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
