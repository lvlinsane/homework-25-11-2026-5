using System;

namespace StudentApp
{
    struct Student
    {
        public int Id { get; }
        public string FullName { get; }
        public int Age { get; }
        public string Group { get; }
        public double AverageGrade { get; }
        public StudyStatus Status { get; private set; }
        public EducationLevel Level { get; }

        public Student(int id, string fullName, int age, string group, double averageGrade, EducationLevel level)
        {
            if (age < 16 || age > 60)
            {
                throw new ArgumentException("Возраст должен быть от 16 до 60 лет!");
            }

            if (averageGrade < 0 || averageGrade > 100)
            {
                throw new ArgumentException("Средний балл должен быть от 0 до 100!");
            }

            if (!Enum.IsDefined(typeof(EducationLevel), level))
            {
                throw new ArgumentException("Неверный уровень образования!");
            }

            Id = id;
            FullName = fullName;
            Age = age;
            Group = group;
            AverageGrade = averageGrade;
            Level = level;
            Status = StudyStatus.Active;
        }

        public bool ChangeStatus(StudyStatus newStatus)
        {
            if (!Enum.IsDefined(typeof(StudyStatus), newStatus))
            {
                Console.WriteLine(FullName + ": ошибка, такого статуса не существует!");
                return false;
            }

            switch (Status)
            {
                case StudyStatus.Active:
                    switch (newStatus)
                    {
                        case StudyStatus.AcademicLeave:
                            Status = newStatus;
                            Console.WriteLine(FullName + ": переведён в академический отпуск.");
                            return true;
                        case StudyStatus.Graduated:
                            Status = newStatus;
                            Console.WriteLine(FullName + ": обучение завершено.");
                            return true;
                        case StudyStatus.Expelled:
                            Status = newStatus;
                            Console.WriteLine(FullName + ": отчислен.");
                            return true;
                        default:
                            Console.WriteLine(FullName + ": студент уже имеет статус Active.");
                            return false;
                    }

                case StudyStatus.AcademicLeave:
                    if (newStatus == StudyStatus.Active)
                    {
                        Status = newStatus;
                        Console.WriteLine(FullName + ": возвращён из академического отпуска.");
                        return true;
                    }

                    Console.WriteLine(FullName + ": из академического отпуска можно только вернуться к обучению (Active).");
                    return false;

                case StudyStatus.Graduated:
                    Console.WriteLine(FullName + ": обучение завершено, статус изменить нельзя!");
                    return false;

                case StudyStatus.Expelled:
                    Console.WriteLine(FullName + ": студент отчислен, статус изменить нельзя!");
                    return false;

                default:
                    Console.WriteLine(FullName + ": неизвестный текущий статус!");
                    return false;
            }
        }

        public string GetStatusDescription()
        {
            switch (Status)
            {
                case StudyStatus.Active:
                    return "Студент учится";
                case StudyStatus.AcademicLeave:
                    return "Студент в академическом отпуске";
                case StudyStatus.Graduated:
                    return "Студент закончил обучение";
                case StudyStatus.Expelled:
                    return "Студент отчислен";
                default:
                    return "Неизвестный статус";
            }
        }

        public string GetLevelDescription()
        {
            switch (Level)
            {
                case EducationLevel.Bachelor:
                    return "Бакалавриат";
                case EducationLevel.Master:
                    return "Магистратура";
                case EducationLevel.Doctoral:
                    return "Докторантура";
                default:
                    return "Неизвестный уровень";
            }
        }

        public void DisplayInfo()
        {
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("ФИО: " + FullName);
            Console.WriteLine("Возраст: " + Age);
            Console.WriteLine("Группа: " + Group);
            Console.WriteLine("Средний балл: " + AverageGrade);
            Console.WriteLine("Уровень образования: " + GetLevelDescription());
            Console.WriteLine("Статус: " + GetStatusDescription());
            Console.WriteLine("-----------------------");
        }
    }
}
