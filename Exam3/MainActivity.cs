using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using System.Collections.Generic;

namespace Exam3
{
    [Activity(Label = "Exam3", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private EstudiantesService service;
        ListView lv;
        private LVAdapter adapter;
		public List<EstudianteListDto> estudiantes;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            service = new EstudiantesService();
            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);

            lv = FindViewById<ListView>(Resource.Id.listView1);
            lv.ItemClick += Lv_ItemClick;

        }

        protected override async void OnResume()
        {
            base.OnResume();
            if (lv != null)
            {
                estudiantes = await service.LeerEstudiantes();

                adapter = new LVAdapter(this, estudiantes);
                lv.Adapter = adapter;
            }
        }

     

        private void Lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var detallesIntent = new Intent(this, typeof(DetallesActivity));
			detallesIntent.PutExtra("estudiante", estudiantes[e.Position].NumeroControl);
            StartActivity(detallesIntent);
        }
    }
}

