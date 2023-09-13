import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NevoRegistroComponent } from './nevo-registro.component';

describe('NevoRegistroComponent', () => {
  let component: NevoRegistroComponent;
  let fixture: ComponentFixture<NevoRegistroComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NevoRegistroComponent]
    });
    fixture = TestBed.createComponent(NevoRegistroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
