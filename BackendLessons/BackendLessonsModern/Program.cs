using BackendLessons;
using BackendLessonsModern;

//// 3. Value and Reference types

EmployeeStruct currentEmployee = new EmployeeStruct(25, "Pablo");
currentEmployee.IsDeleted = true;

static void ReceiveEmployee(EmployeeStruct employee, string name, bool isDeleted)
{
    employee.IsDeleted = isDeleted;
    employee.Name = name;
    employee.ShowInformation();
}

ReceiveEmployee(currentEmployee, "Pedro", false);

currentEmployee.ShowInformation();


/// Enum
///// 

//byte employeeFromDatabase = 3;

//WorkerEnum worker = WorkerEnum.Manager;
//WorkerEnum workerFromDB = (WorkerEnum)employeeFromDatabase;
//bool correctEnum = Enum.IsDefined(typeof(WorkerEnum), workerFromDB);

//Console.WriteLine(worker);


///// SQL  (int, varchar(50))
///// Admin, Supervisor, Employee
///// 1       2           3



//////Console.WriteLine("Hello, World Modern!");
///


UserProfile user = new UserProfile(8, 9);





