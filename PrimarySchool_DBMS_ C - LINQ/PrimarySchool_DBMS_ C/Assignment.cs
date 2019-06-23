using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimarySchool_DBMS__C
{
    class Assignment
    {
        public int AssignmentID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SubmissionDateTime { get; set; }
        public Course CourseId { get; set; }
        public List<Assignment_Student> AssignmentPerStudent { get; set; }


        public Assignment(int assignmentId, string title, string description, DateTime submissionDateTime, Course course, List<Assignment_Student> list_Assignment_Student)
        {
            AssignmentID = assignmentId;
            Title = title;
            Description = description;
            SubmissionDateTime = submissionDateTime;
            CourseId = course;
            //AssignmentPerStudent = list_Assignment_Student;
        }


    }
}
