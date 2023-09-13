import { TestBed } from '@angular/core/testing';

import { ServceCatalogoService } from './servce-catalogo.service';

describe('ServceCatalogoService', () => {
  let service: ServceCatalogoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServceCatalogoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
