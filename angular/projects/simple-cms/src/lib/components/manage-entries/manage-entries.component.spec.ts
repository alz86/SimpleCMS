import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageEntriesComponent } from './manage-entries.component';

describe('ManageEntriesComponent', () => {
  let component: ManageEntriesComponent;
  let fixture: ComponentFixture<ManageEntriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ManageEntriesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ManageEntriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
