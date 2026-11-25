using System;

namespace StudentApp
{
    static class StudentManager
    {
        public static bool ChangeStatusById(Student[] students, int id, StudyStatus newStatus)
        {
            if (students == null || students.Length == 0)
            {
                Console.WriteLine("Список студентов пуст!");
                return false;
            }

            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].Id == id)
                {
                    return students[i].ChangeStatus(newStatus);
                }
            }

            Console.WriteLine("Студент с Id " + id + " не найден!");
            return false;
        }
    }
}
