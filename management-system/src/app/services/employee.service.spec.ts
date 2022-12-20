import { HttpClientTestingModule, HttpTestingController } from "@angular/common/http/testing";
import { TestBed } from "@angular/core/testing";
import { Employee } from "../model/employee.model";
import { EmployeeService } from "./employee.service";

describe('EmployeeService', () => {
    let service : EmployeeService;
    let httpMock: HttpTestingController;

    beforeEach(() => {
        TestBed.configureTestingModule({
            imports : [
                HttpClientTestingModule
            ]
        });
        service = TestBed.inject(EmployeeService);
        httpMock = TestBed.get(HttpTestingController);

    });

    it('should create employeeservice', () => {
        expect(service).toBeTruthy();
    });

    it('using pending for pending test', () => {
        pending();
    });

    xit('using xit for pending test', () => {
    });

    it('should return all employee', () => {
        const employee = [{
            firstName: 'Aditti',
            lastName: 'Patel',
            email: 'a@a.com',
            dateOfBirth: '05/04/2002',
            joinedDate:  new Date(),
            id: 1,
            age: 19,
            isActive: false,
            departmentId: 2
        }] as Employee[];
        service.getEmployeeList().subscribe((res) => {
            expect(res).toBe(employee);
          });
          const req = httpMock.expectOne('https://localhost:7253/api/Employee');
          expect(req.request.method).toBe('GET');
          req.flush(employee);
    });

    it('should create employee', () => {
        const employee = {
            firstName: "Aditi",
            lastName: "Patel",
            email: "a@a.com",
            dateOfBirth: "05/04/2002",
            id: 1,
            age: 19,
            isActive: false,
            departmentId: 2
        } as Employee;
        service.addEmployee(employee).subscribe((data: any) => {
            expect(data.id).toBe(1);
        });
        const req = httpMock.expectOne(`https://localhost:7253/api/Employee`);
        expect(req.request.method).toBe('POST');
        req.flush({
            id: 1
        });
        httpMock.verify();
    });

    it('should delete employee', () => {
        service.deleteEmployee(1).subscribe((data: any) => {
            expect(data.id).toBe(1);
        });
        const req = httpMock.expectOne(`https://localhost:7253/api/Employee/1`);
        expect(req.request.method).toBe('DELETE');
        req.flush({
            id: 1
        });
        httpMock.verify();
    });

    it('should update employee', () => {
        const employee = {
            firstName: "Aditi",
            lastName: "Patel",
            email: "a@a.com",
            dateOfBirth: "05/04/2002",
            id: 1,
            age: 19,
            isActive: false,
            departmentId: 2
        } as Employee;
        service.updateEmployee(employee).subscribe((data: any) => {
            expect(data.id).toBe(1);
        });
        const req = httpMock.expectOne(`https://localhost:7253/api/Employee`);
        expect(req.request.method).toBe('PUT');
        req.flush({
            id: 1
        });
        httpMock.verify();
    });
})