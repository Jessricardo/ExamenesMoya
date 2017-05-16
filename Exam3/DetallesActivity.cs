using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Exam3
{
    [Activity(Label = "DetallesActivity")]
    public class DetallesActivity : Activity
    {
		public string id;
		public Button btnAsistencia;
		public TextView txtNombre, text2, text3;
        private EstudiantesService service;
        public DetallesActivity()
        {

        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            service = new EstudiantesService();
            // Create your application here
            SetContentView(Resource.Layout.Detalles);
			id = Intent.GetStringExtra("estudiante");
			txtNombre = FindViewById<TextView>(Resource.Id.textNombre);
			text2 = FindViewById<TextView>(Resource.Id.text2);
			text3 = FindViewById<TextView>(Resource.Id.text3);
			btnAsistencia = FindViewById<Button>(Resource.Id.btn2);
			//Obtener referneicas a bototnes y campos de texto 
			// Aconfigurar Clicks de botones para realizar acciones subsecuentes. 
			// para el ultimo ejercicio es nescesario agregar 1 boton mas al view y campo de texto. 

			btnAsistencia.Click += Asistenciar;
        }
		public async void Asistenciar(object sender, EventArgs e)
		{
			EstudianteAsistioDto estudiantado = new EstudianteAsistioDto();
			estudiantado.NumeroControl = id;
			estudiantado.PIN = 5484;
			var bandera = await service.MarcarAsistencia(estudiantado);
			if (bandera)
			{
				Toast.MakeText(this, "Asistencia", ToastLength.Long).Show();
				var detallesIntent = new Intent(this, typeof(MainActivity));
				StartActivity(detallesIntent);
			}
			else {
				Toast.MakeText(this, "Error", ToastLength.Long).Show();
			}

		}
		protected override async void OnResume()
        {
            base.OnResume();

            var estudiante = await service.LeerUnEstudiante(id);

			txtNombre.Text = estudiante.Nombre;
			text2.Text = estudiante.Calificacion.ToString();
			text3.Text = estudiante.Grupo;


        }
    }
}