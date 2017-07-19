<%@ WebHandler Language="C#" Class="Image2" %>

using System.IO;
using System.Linq;
using System.Web;

public class Image2 : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string id = context.Request.QueryString["id"];
        context.Response.ContentType = "image/jpg";
        context.Response.ContentType = "image/jpeg";

        Stream strm = ShowEmpImage1(id);
        if (strm != null)
        {
            var buffer = new byte[4096];
            int byteSeq = strm.Read(buffer, 0, 4096);
            while (byteSeq > 0)
            {
                context.Response.OutputStream.Write(buffer, 0, byteSeq);
                byteSeq = strm.Read(buffer, 0, 4096);
            }
        }
    }

    public bool IsReusable
    {
        get { return false; }
    }

    public Stream ShowEmpImage1(string id)
    {
        var context1 = new SWISDataContext();
        StudentDoc r = (from a in context1.StudentDocs where a.VarStudentID == id select a).First();

        if (r.ImgBirthcertificate != null)
        {
            return new MemoryStream(r.ImgBirthcertificate.ToArray());
        }
        return null;
    }
}