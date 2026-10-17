// En studerande. En studerande kan gå flera kurser.
class Student
{
    public string Name { get; }

    private readonly List<Course> courses = new List<Course>();

    // Skrivskyddad vy, se kommentaren i Course.
    public IReadOnlyList<Course> Courses => courses;

    public Student(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Studentens namn får inte vara tomt.");
        }

        Name = name;
    }

    // Går med i en kurs. Det är här reglerna sitter:
    //  1. samma kurs får inte hamna två gånger (inga dubbletter)
    //  2. kursen får inte vara full (MaxSeats)
    // Går allt bra uppdateras BÅDA sidor: kursens Students och studentens Courses.
    // Returnerar true om studenten gick med, annars false (och säger till varför).
    public bool Join(Course course)
    {
        if (course == null)
        {
            throw new ArgumentNullException(nameof(course));
        }

        if (courses.Contains(course))
        {
            Console.WriteLine($"{Name} är redan anmäld till {course.Name}.");
            return false;
        }

        if (course.Students.Count >= course.MaxSeats)
        {
            Console.WriteLine($"Kursen är full: {course.Name} har bara {course.MaxSeats} platser, {Name} kom inte med.");
            return false;
        }

        courses.Add(course);
        course.AddStudent(this);   // håller kursens sida i synk
        return true;
    }

    // Lämnar en kurs och uppdaterar båda sidor.
    // Är studenten inte anmäld händer inget mer än att vi säger till (ingen krasch).
    public bool Leave(Course course)
    {
        if (course == null)
        {
            throw new ArgumentNullException(nameof(course));
        }

        if (!courses.Remove(course))
        {
            Console.WriteLine($"{Name} är inte anmäld till {course.Name}.");
            return false;
        }

        course.RemoveStudent(this);   // håller kursens sida i synk
        return true;
    }

    // Skriver ut studentens schema: vilka kurser hen går.
    public void Schedule()
    {
        Console.WriteLine($"Schema för {Name} (antal kurser: {courses.Count}):");

        if (courses.Count == 0)
        {
            Console.WriteLine("  (inga kurser)");
        }

        for (int i = 0; i < courses.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {courses[i].Name}");
        }
    }

    public override string ToString()
    {
        return Name;
    }
}
