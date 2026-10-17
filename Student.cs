class Student
{
    public string Name { get; }

    private readonly List<Course> courses = new List<Course>();

    public IReadOnlyList<Course> Courses => courses;

    public Student(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Studentens namn får inte vara tomt.");
        }

        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}
