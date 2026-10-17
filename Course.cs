class Course
{
    public string Name { get; }
    public int MaxSeats { get; }

    private readonly List<Student> students = new List<Student>();

    public IReadOnlyList<Student> Students => students;

    public Course(string name, int maxSeats)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Kursens namn får inte vara tomt.");
        }

        if (maxSeats < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(maxSeats), maxSeats, "Kursen måste ha minst en plats.");
        }

        Name = name;
        MaxSeats = maxSeats;
    }

    // Anmäler en studerande om det finns plats
    // ligger i Student.Join, så det blir exakt samma resultat från båda hållen
    public bool Enroll(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student));
        }

        return student.Join(this);
    }

    public bool Remove(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student));
        }

        return student.Leave(this);
    }

    // Skriver ut vilka som går kursen
    public void RollCall()
    {
        Console.WriteLine($"Deltagare i {Name} ({students.Count}/{MaxSeats}):");

        if (students.Count == 0)
        {
            Console.WriteLine("  (inga anmälda)");
        }

        for (int i = 0; i < students.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {students[i].Name}");
        }
    }

    // Används bara av Student för att uppdatera kursens egen lista
    // efter att Student redan har kontrollerat reglerna
    internal void AddStudent(Student student)
    {
        students.Add(student);
    }

    internal void RemoveStudent(Student student)
    {
        students.Remove(student);
    }

    public override string ToString()
    {
        return $"{Name} ({students.Count}/{MaxSeats} platser)";
    }
}
