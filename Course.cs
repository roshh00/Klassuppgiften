class Course
{
    public string Name { get; }
    public int MaxSeats { get; }

    private readonly List<Student> students = new List<Student>();

    // man titta på listan men inte ändra den direkt.
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

    // Till exempel Matematik 2/5 platser.
    public override string ToString()
    {
        return $"{Name} ({students.Count}/{MaxSeats} platser)";
    }
}
