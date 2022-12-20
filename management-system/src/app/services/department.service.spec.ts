import { HttpClientTestingModule, HttpTestingController } from "@angular/common/http/testing";
import { TestBed } from "@angular/core/testing";
import { Department } from "../model/department.model";
import { DepartmentService } from "./department.service";

describe('DepartmentService', () => {
    let service : DepartmentService;
    let httpMock: HttpTestingController;
    
    beforeEach(() => {
        TestBed.configureTestingModule({
            // declarations:[DepartmentService],
            imports : [
                HttpClientTestingModule
            ]
        });
        service = TestBed.inject(DepartmentService);
        httpMock = TestBed.get(HttpTestingController);
    });

    it('should create departmentservice', () => {
        expect(service).toBeTruthy();
    });

    it('should return getDepartmentList', () => {
        const department = [{
            id: 1,
            name: "IT Dept",
            isActive: true,
        }] as Department[];
        service.getDepartmentList().subscribe((res) => {
            expect(res).toBe(department);
          });
          const req = httpMock.expectOne('https://localhost:7253/api/Department');
          expect(req.request.method).toBe('GET');
          req.flush(department);
    });

    it('should return getActiveDepartmentList', () => {
        const department = [{
            id: 1,
            name: "IT Dept",
            isActive: true,
        }] as Department[];
        service.getActiveDepartmentList().subscribe((res) => {
            expect(res).toBe(department);
          });
          const req = httpMock.expectOne('https://localhost:7253/api/Department/active');
          expect(req.request.method).toBe('GET');
          req.flush(department);
    });

    it('should delete department', () => {
        service.deleteDepartment(1).subscribe((data: any) => {
            expect(data.id).toBe(1);
        });
        const req = httpMock.expectOne(`https://localhost:7253/api/Department/1`);
        expect(req.request.method).toBe('DELETE');
        req.flush({
            id: 1
        });
        httpMock.verify();
    });
})