import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TitleAbstractListComponent } from './title-abstract-list.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { Title } from '@angular/platform-browser';
import { TitleAbstractService } from '../title-abstract.service';
import { of } from 'rxjs';

describe('TitleAbstractListComponent', () => {
  let component: TitleAbstractListComponent;
  let fixture: ComponentFixture<TitleAbstractListComponent>;
  let mockService: jasmine.SpyObj<TitleAbstractService>;

  const mockTitleAbstracts = [
    {
      orderNo: 'ORD-12345',
      searchDate: '2025-05-02T21:55:24.736',
      effectiveDate: '2025-05-02T21:55:24.736',
      client: 'Bank of America',
      clientRefNo: 'AE-5678',
      productType: 'Current Owner Search',
      propertyAddress: '247 Glenn Avenue, Canonsburg, PA 15317',
      titleAbstractID: 1,
    },
  ];

  beforeEach(async () => {
    const serviceSpy = jasmine.createSpyObj('TitleAbstractService', [
      'getTitleAbstracts',
    ]);
    await TestBed.configureTestingModule({
      imports: [TitleAbstractListComponent, HttpClientTestingModule],
      providers: [{ provide: TitleAbstractService, useValue: serviceSpy }],
    }).compileComponents();

    mockService = TestBed.inject(
      TitleAbstractService
    ) as jasmine.SpyObj<TitleAbstractService>;
    mockService.getTitleAbstracts.and.returnValue(of(mockTitleAbstracts));

    fixture = TestBed.createComponent(TitleAbstractListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should fetch title abstracts on init', () => {
    mockService.getTitleAbstracts.and.returnValue(of(mockTitleAbstracts));

    component.ngOnInit();

    expect(mockService.getTitleAbstracts).toHaveBeenCalled();
    expect(component.titleAbstracts).toEqual(mockTitleAbstracts);
  });
});
