import { TestBed } from '@angular/core/testing';

import { KategoryService } from './kategory.service';

describe('KategoryService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: KategoryService = TestBed.get(KategoryService);
    expect(service).toBeTruthy();
  });
});
