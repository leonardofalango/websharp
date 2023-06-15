import { TestBed } from '@angular/core/testing';

import { CompleteNewsService } from './complete-news.service';

describe('CompleteNewsService', () => {
  let service: CompleteNewsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CompleteNewsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
