using System;
using System.IO;
using System.Net;

class Program
{
    static void Main()
    {
        string ftpHost = "172.19.12.252";
        int ftpPort = 21;
        string ftpUname = "richard";
        string ftpPass = "123456789";
        string archivoLocal = "Archivo1.txt";
        string archivoRemoto = "archivo_remoto.txt";

        FtpWebRequest request = (FtpWebRequest)WebRequest.Create($"ftp://{ftpHost}:{ftpPort}/{archivoRemoto}");
        request.Method = WebRequestMethods.Ftp.UploadFile;
        request.Credentials = new NetworkCredential(ftpUname, ftpPass);

        using (Stream archivoStream = File.OpenRead(archivoLocal))
        using (Stream ftpStream = request.GetRequestStream())
        {
            archivoStream.CopyTo(ftpStream);
        }

        Console.WriteLine("Archivo subido correctamente.");
    }
}
