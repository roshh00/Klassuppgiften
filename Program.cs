using System;

Course csharp = new Course("C# Grundkurs", 3);
Course databaser = new Course("Databaser", 2);   // liten kurs, för att visa kapacitet
Course webb = new Course("Webbutveckling", 3);

Student anna = new Student("Anna");
Student bilal = new Student("Bilal");
Student cecilia = new Student("Cecilia");
Student david = new Student("David");

Rubrik("1. Anmälan åt båda hållen");
csharp.Enroll(anna);       // via kursen
bilal.Join(csharp);        // via studenten
anna.Join(databaser);
databaser.Enroll(bilal);
webb.Enroll(anna);
VisaAllt();

Rubrik("2. Dubbelanmälan ger inga dubbletter");
csharp.Enroll(anna);       // samma väg igen
anna.Join(csharp);         // andra vägen
anna.Join(csharp);         // och en gång till
csharp.RollCall();
anna.Schedule();

Rubrik("3. Full kurs säger nej (Databaser har 2 platser)");
cecilia.Join(databaser);   // plats 3 av 2 -> nej
databaser.Enroll(david);   // också nej
databaser.RollCall();
cecilia.Schedule();        // Databaser ska INTE finnas här

Rubrik("4. Avanmälan åt båda hållen");
anna.Leave(databaser);     // via studenten
csharp.Remove(bilal);      // via kursen
VisaAllt();

Rubrik("5. En plats har blivit ledig, nu kommer Cecilia med");
cecilia.Join(databaser);
databaser.RollCall();
cecilia.Schedule();

Rubrik("6. Ta bort någon som inte är anmäld (ingen krasch)");
david.Leave(webb);
webb.Remove(david);
bilal.Leave(csharp);       // Bilal avanmäldes redan i steg 4

Rubrik("7. Ogiltiga värden");
try
{
    Course ingenPlats = new Course("Tom kurs", 0);
}
catch (ArgumentOutOfRangeException exception)
{
    Console.WriteLine($"Fel: {exception.Message}");
}

try
{
    csharp.Enroll(null);
}
catch (ArgumentNullException)
{
    Console.WriteLine("Fel: kan inte anmäla null.");
}

void Rubrik(string text)
{
    Console.WriteLine();
    Console.WriteLine($"=== {text} ===");
}

void VisaAllt()
{
    foreach (Course course in new[] { csharp, databaser, webb })
    {
        Console.WriteLine(course);   // ToString, t.ex. "Databaser (2/2 platser)"
        course.RollCall();
    }

    foreach (Student student in new[] { anna, bilal, cecilia, david })
    {
        student.Schedule();
    }
}
