import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { SimpleCMSComponent } from './components/simple-cms.component';
import { SimpleCMSService } from '@decision-tree.Plugins/simple-cms';
import { of } from 'rxjs';

describe('SimpleCMSComponent', () => {
  let component: SimpleCMSComponent;
  let fixture: ComponentFixture<SimpleCMSComponent>;
  const mockSimpleCMSService = jasmine.createSpyObj('SimpleCMSService', {
    sample: of([]),
  });
  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [SimpleCMSComponent],
      providers: [
        {
          provide: SimpleCMSService,
          useValue: mockSimpleCMSService,
        },
      ],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SimpleCMSComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
