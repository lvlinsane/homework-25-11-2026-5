using System;

namespace StudentApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[]
            {
                new Student(1, "Иванов Иван Иванович", 18, "ИС-11", 85.5, EducationLevel.Bachelor),
                new Student(2, "Петрова Анна Сергеевна", 19, "ИС-12", 92, EducationLevel.Bachelor),
                new Student(3, "Сидоров Пётр Алексеевич", 23, "МГ-21", 78.3, EducationLevel.Master),
                new Student(4, "Козлова Мария Олеговна", 25, "ДК-31", 95.7, EducationLevel.Doctoral),
                new Student(5, "Смирнов Максим Андреевич", 20, "ИС-13", 54, EducationLevel.Bachelor)
            };

            Console.WriteLine("===== Начальные данные =====");
            StudentAnalyzer.PrintAll(students);

            Console.WriteLine("===== Смена статусов =====");
            StudentManager.ChangeStatusById(students, 1, StudyStatus.AcademicLeave);
            StudentManager.ChangeStatusById(students, 1, StudyStatus.Active);
            StudentManager.ChangeStatusById(students, 1, StudyStatus.Graduated);
            StudentManager.ChangeStatusById(students, 1, StudyStatus.Active);
            Console.WriteLine();

            StudentManager.ChangeStatusById(students, 2, StudyStatus.Expelled);
            StudentManager.ChangeStatusById(students, 2, StudyStatus.Active);
            Console.WriteLine();

            StudentManager.ChangeStatusById(students, 3, StudyStatus.AcademicLeave);
            StudentManager.ChangeStatusById(students, 3, StudyStatus.Graduated);
            Console.WriteLine();

            StudentManager.ChangeStatusById(students, 4, StudyStatus.Active);
            StudentManager.ChangeStatusById(students, 5, (StudyStatus)10);
            StudentManager.ChangeStatusById(students, 99, StudyStatus.Expelled);
            Console.WriteLine();

            Console.WriteLine("===== Свой вариант =====");
            Console.Write("Введите Id студента: ");
            int id;

            if (int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("0 - Active");
                Console.WriteLine("1 - AcademicLeave");
                Console.WriteLine("2 - Graduated");
                Console.WriteLine("3 - Expelled");
                Console.Write("Введите новый статус: ");
                int number;

                if (int.TryParse(Console.ReadLine(), out number) && Enum.IsDefined(typeof(StudyStatus), number))
                {
                    StudentManager.ChangeStatusById(students, id, (StudyStatus)number);
                }
                else
                {
                    Console.WriteLine("Ошибка: введён неверный статус!");
                }
            }
            else
            {
                Console.WriteLine("Ошибка: Id должен быть числом!");
            }

            Console.WriteLine();
            Console.WriteLine("===== Итоговые данные =====");
            StudentAnalyzer.PrintAll(students);
            StudentAnalyzer.PrintCountByStatus(students);

            Console.ReadKey();
        }
    }
}
