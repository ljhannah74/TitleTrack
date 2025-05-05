import { TestBed } from '@angular/core/testing';

import { TitleAbstractService } from './title-abstract.service';
import {
  HttpClientTestingModule,
  HttpTestingController,
} from '@angular/common/http/testing';
import { TitleAbstract } from '../models/title-abstract';
import { HttpClient } from '@angular/common/http';

describe('TitleAbstractService', () => {
  let service: TitleAbstractService;
  let httpMock: HttpTestingController;

  const mockTitleAbstracts: TitleAbstract[] = [
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

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [TitleAbstractService],
    });
    service = TestBed.inject(TitleAbstractService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should fetch title abstracts from the API', () => {
    service.getTitleAbstracts().subscribe((titleAbstracts) => {
      expect(titleAbstracts).toEqual(mockTitleAbstracts);
      expect(titleAbstracts.length).toBe(1);
      expect(titleAbstracts[0].client).toBe('Bank of America');
    });

    const req = httpMock.expectOne(service['apiUrl']);
    expect(req.request.method).toBe('GET');
    req.flush(mockTitleAbstracts); // Simulate a successful response
  });

  it('should handle an empty response', () => {
    service.getTitleAbstracts().subscribe((titleAbstracts) => {
      expect(titleAbstracts).toEqual([]);
    });

    const req = httpMock.expectOne(service['apiUrl']);
    expect(req.request.method).toBe('GET');
    req.flush([]); // Simulate an empty response
  });

  it('should handle HTTP errors gracefully', () => {
    const errorMessage = 'Failed to fetch data';

    service.getTitleAbstracts().subscribe(
      () => fail('Expected an error, not title abstracts'),
      (error) => {
        expect(error.status).toBe(500);
        expect(error.statusText).toBe('Internal Server Error');
      }
    );

    const req = httpMock.expectOne(service['apiUrl']);
    expect(req.request.method).toBe('GET');
    req.flush(errorMessage, {
      status: 500,
      statusText: 'Internal Server Error',
    });
  });
});
