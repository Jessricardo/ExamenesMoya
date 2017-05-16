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
    public class LVAdapter : BaseAdapter<EstudianteListDto>
    {
        private Activity context;
        private List<EstudianteListDto> items;

        public LVAdapter(Activity context, List<EstudianteListDto> pasteles)
        {
            this.context = context;
            this.items = pasteles;
        }
        public override EstudianteListDto this[int position]
        {
            get
            {
                return items[position];
            }
        }

        public override int Count
        {
            get
            {
                return items.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            if (view == null) // no view to re-use, create new
                view = context.LayoutInflater.Inflate(Resource.Layout.LVItem, null);
			view.FindViewById<TextView>(Resource.Id.textNumero).Text = item.NumeroControl;
            view.FindViewById<TextView>(Resource.Id.textNombre).Text = item.Nombre;
            view.FindViewById<TextView>(Resource.Id.textCalificacion).Text = item.Calificacion.ToString();
            view.FindViewById<TextView>(Resource.Id.textGrupo).Text = item.Grupo;
            // view.FindViewById<ImageView>(Resource.Id.textColor).SetImageResource(item.ImageResourceId);
            return view;
        }
    }
}