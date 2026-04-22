namespace BackendLessonsModern
{
    struct EmployeeStruct
    {
        // Fields
        private int _age;

        // propiedad
        public bool IsDeleted { get; set; }
        public string Name { get; set; }

        public EmployeeStruct(int age, string name)
        {
            _age = age;
            Name = name;
        }

        public void ShowInformation()
        {
            Console.WriteLine($"Employee: {Name}, age: {_age}, isDeleted: {IsDeleted}");
        }

    }
}
