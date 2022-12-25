namespace ProyectoFDI.v1.Code
{
    public class APIConsumer
    {
        public static Models.Deportistum[] Deportistas(string apiUrl)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = api.DownloadString(apiUrl);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Deportistum[]>(json);
        }

        public static Models.Deportistum Deportista(string apiUrl, int id)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = api.DownloadString(apiUrl + "/" + id);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Deportistum>(json);
        }

        public static void GuardarDeportista(string apiUrl, int id, Models.Deportistum deportista)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(deportista);
            api.UploadString(apiUrl + "/" + id, "PUT", json);
        }

        public static Models.Deportistum CrearDeportista(string apiUrl, Models.Deportistum deportista)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(deportista);
            json = api.UploadString(apiUrl, "POST", json);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Deportistum>(json);
        }

        public static void BorrarDeportista(string apiUrl, int id)
        {
            var api = new System.Net.WebClient();
            api.Headers.Add("Content-Type", "application/json");
            api.UploadString(apiUrl + "/" + id, "DELETE", "");
        }

    }
}
