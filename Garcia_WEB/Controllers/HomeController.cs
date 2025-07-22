using Microsoft.AspNetCore.Mvc;
using Garcia_WEB.Models; 
using System;
using System.Collections.Generic;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        string studentName = "Erich Mae A. Garcia";
        int score = 87;
        bool isPassed = (score >= 75);
        DateTime examDate = DateTime.Now;
        decimal tuitionFee = 15500.75m;

        ViewBag.StudentName = studentName;
        ViewBag.Score = score;
        ViewBag.IsPassed = isPassed;
        ViewBag.ExamDate = examDate;
        ViewBag.TuitionFee = tuitionFee;

        string grade = (score >= 90) ? "A" :
                       (score >= 80) ? "B" :
                       (score >= 75) ? "C" : "F";

        string message = isPassed ? "Congratulations, you passed!" : "Better luck next time.";

        ViewBag.Grade = grade;
        ViewBag.Message = message;

        string[] courses = { "Web Systems", "OOP", "DBMS", "UI/UX", "Networking" };
        ViewBag.CourseList = string.Join(", ", courses);
        ViewBag.CourseCount = courses.Length;

        ViewBag.NetFee = ComputeNetFee(tuitionFee, 10);

        ViewBag.Today = DateTime.Now.ToString("MMMM dd, yyyy");

        var student = new Student { Name = "Erich Mae A. Garcia", Age = 21, Course = "Web Systems" };
        ViewBag.Student = student;

        var students = new List<Student>
        {
            new Student { Name = "Faye Aquino", Age = 20, Course = "Web Systems" },
            new Student { Name = "Allen Lumantas", Age = 21, Course = "OOP" },
            new Student { Name = "Aldia Arieta", Age = 22, Course = "DBMS" }
        };
        ViewBag.Students = students;

        return View();
    }

    private decimal ComputeNetFee(decimal tuition, decimal discountPercent)
    {
        return tuition - (tuition * discountPercent / 100);
    }

    public IActionResult AboutMe()
    {
        return View();
    }
}
