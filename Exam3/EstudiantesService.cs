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
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Exam3
{
    public class EstudiantesService
    {
        HttpClient client;
        // Para mas detalles puedes ir a 
        //https://developer.xamarin.com/guides/xamarin-forms/cloud-services/consuming/rest/
        public EstudiantesService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

        }


		//5484---------PIN


        private const string BASEURL = "http://ne2exam2v1.azurewebsites.net/api/Exam3/";
       // private const string BASEURL = "http://ne2exam2v2.azurewebsites.net/api/Exam3/";
        //private const string BASEURL = "http://ne2exam2v3.azurewebsites.net/api/Exam3/";
        public async Task<List<EstudianteListDto>> LeerEstudiantes()
        {
            var uri = new Uri(BASEURL);
  
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<EstudianteListDto>>(content);
            }

            return new List<EstudianteListDto>();
        }

        public async Task<EstudianteListDto> LeerUnEstudiante(string control)
        {
             var uri = new Uri("http://ne2exam2v1.azurewebsites.net/api/Exam3/"+control);

			var response = await client.GetAsync(uri);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				return JsonConvert.DeserializeObject<EstudianteListDto>(content);
			}

			return new EstudianteListDto();
        }

        public async Task<bool> MarcarAsistencia(EstudianteAsistioDto datos)
        {
            string baseurl = "http://ne2exam2v1.azurewebsites.net/api/Exam3/";
			var Client = new HttpClient();
			Client.MaxResponseContentBufferSize = 256000;

			var uril = new Uri(baseurl);
			var json = JsonConvert.SerializeObject(datos);
			StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await Client.PostAsync(uril, content);
			if (response.IsSuccessStatusCode)
			{
				return true;
			}
			else
			{
				return false;
			}
        }

        public async Task<bool> PonerMiCalificacion(EstudiantePutDto datos)
        {
            //Hacer un PUT y pasar datos como json. 
            return await Task.FromResult(false);
        }

        public async Task<bool> IrPorEl100(EstudianteDeleteDto datos)
        {
            //Hacer un DELETE y pasar datos como json. 
            return await Task.FromResult(false);
        }
    }

    
}