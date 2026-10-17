using System;

Course csharp = new Course("C# Grundkurs", 3);
Course databaser = new Course("Databaser", 2);
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
VisaAllt();

Rubrik("3. Avanmälan åt båda hållen");
anna.Leave(databaser);     // via studenten
csharp.Remove(bilal);      // via kursen
VisaAllt();

Rubrik("4. Ta bort någon som inte är anmäld (ingen krasch)");
david.Leave(webb);
webb.Remove(david);
bilal.Leave(csharp);       // Bilal avanmäldes redan i steg 3

Rubrik("5. Ogiltiga värden");
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
        Console.WriteLine($"{course}: {string.Join(", ", course.Students)}");
    }

    foreach (Student student in new[] { anna, bilal, cecilia, david })
    {
        Console.WriteLine($"{student}: {string.Join(", ", student.Courses)}");
    }
}
