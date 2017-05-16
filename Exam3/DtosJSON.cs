using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Exam3
{
    public class EstudianteListDto
    {
        public string NumeroControl { get; set; }
        public string Nombre { get; set; }
        public int Asistencia { get; set; }
        public int Calificacion { get; set; }
        public string NukedBy { get; set; }
        public string Grupo { get; set; }


    }

    public class EstudianteAsistioDto
    {
        public string NumeroControl { get; set; }
        public int PIN { get; set; }
    }

    public class EstudiantePutDto
    {
        public string NumeroControl { get; set; }
        public int Calificacion { get; set; }
        public int PIN { get; set; }
    }

    public class EstudianteDeleteDto
    {
        public string NumeroControl { get; set; }
        public string ControlToNuke { get; set; }
        public int PIN { get; set; }
    }
}