class Course
{
    public string Name { get; }
    public int MaxSeats { get; }

    private readonly List<Student> students = new List<Student>();

    // listan kan bara ändras via Enroll/Remove
    // så att kursens och studentens listor alltid stämmer överens
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

    // Anmäler en studerande. Reglerna (dubbletter)
    // ligger i Student.Join, så det blir exakt samma resultat från båda hållen.
    public bool Enroll(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student));
        }

        return student.Join(this);
    }

    // Tar bort en studerande ur kursen. Är hen inte anmäld kraschar ingenting.
    public bool Remove(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException(nameof(student));
        }

        return student.Leave(this);
    }

    // Används bara av Student för att uppdatera kursens egen lista,
    // efter att Student redan har kontrollerat reglerna.
    internal void AddStudent(Student student)
    {
        students.Add(student);
    }

    internal void RemoveStudent(Student student)
    {
        students.Remove(student);
    }

    // T.ex. "Matematik (2/5 platser)".
    public override string ToString()
    {
        return $"{Name} ({students.Count}/{MaxSeats} platser)";
    }
}
