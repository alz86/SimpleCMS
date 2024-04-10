import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowEntryComponent } from './show-entry.component';

describe('ShowEntryComponent', () => {
  let component: ShowEntryComponent;
  let fixture: ComponentFixture<ShowEntryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ShowEntryComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(ShowEntryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
