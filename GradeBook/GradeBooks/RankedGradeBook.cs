using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            int twentyPctStudents = (int) Math.Ceiling(Students.Count * .2);
            int countA = twentyPctStudents;
            int countB = countA + twentyPctStudents;
            int countC = countB + twentyPctStudents;
            int countD = countC + twentyPctStudents;

            int countover = 0;

            foreach (var student in Students )
            {
                if (student.AverageGrade >= averageGrade)
                {
                    countover=countover+1;
                }
            }

            if (countover <= countA)
                return 'A';
            else if (countover <= countB)
                return 'B';
            else if (countover <= countC)
                return 'C';
            else if (countover <= countD)
                return 'D';
            
            return 'F';

        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            int studentsWithGrades = 0;

            foreach (var student in Students)
            {
                if (student.Grades.Count > 0)
                {
                    studentsWithGrades = studentsWithGrades + 1;
                }
            }

            if (studentsWithGrades < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
