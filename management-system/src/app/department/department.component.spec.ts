import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DepartmentService } from '../services/department.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { DepartmentComponent } from './department.component';
import { Department } from '../model/department.model';
import { of } from 'rxjs';

describe('DepartmentComponent', () => {
  let component: DepartmentComponent;
  let fixture: ComponentFixture<DepartmentComponent>;
  let mockDeptService: DepartmentService;
  let expectedResult: Department[];

  beforeEach(async () => {
      TestBed.configureTestingModule({
      declarations: [ DepartmentComponent ],
      imports : [
        HttpClientTestingModule,
        FormsModule,
        ReactiveFormsModule
      ],
      providers : [
        DepartmentService
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DepartmentComponent);
    component = fixture.componentInstance;
    mockDeptService = TestBed.inject(DepartmentService);
    fixture.detectChanges();
    component.departmentList = expectedResult;

    expectedResult = [{
      id: 1,
      name: "IT Dept",
      isActive: true,
    },
    {
      id: 2,
      name: "CSE",
      isActive: true,
    }];
  });

  it('should create department component', () => {
    expect(component).toBeTruthy();
  });

  it('should display department list', () => {

    spyOn(mockDeptService, 'getDepartmentList').and.returnValue(of(expectedResult));
    component.refreshDepartmentList();
    expect(component.departmentList[0].id).toEqual(expectedResult[0].id);

  });

  it('should display only active department data', () => {

    spyOn(mockDeptService, 'getActiveDepartmentList').and.returnValue(of(expectedResult));
    component.onShowActiveOnly();
    expect(component.departmentList[0].isActive).toEqual(expectedResult[0].isActive);

  });

  it('should delete department data by id', () => {

    spyOn(mockDeptService, 'deleteDepartment').and.returnValue(of(true));
    component.deleteDepartment(expectedResult[1].id);
    expect(component.departmentList.length).toBe(1);

  });


  
});
