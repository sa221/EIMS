<%@ WebHandler Language="C#" Class="MyPhoto" %>

using System.IO;
using System.Linq;
using System.Web;

public class MyPhoto : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string id = context.Request.QueryString["id"];
        string imageNo = context.Request.QueryString["image"];
        context.Response.ContentType = "image/jpg";
        context.Response.ContentType = "image/jpeg";
        Stream strm = ShowEmpImage(id, imageNo);
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

    public Stream ShowEmpImage(string id, string image)
    {
        var context1 = new SWISDataContext();
        IQueryable<string> existId = from c in context1.StudentDocs
            where c.VarStudentID == id
            select c.VarStudentID;

        if (existId.FirstOrDefault() != null)
        {
            StudentDoc r = (from a in context1.StudentDocs where a.VarStudentID == id select a).First();
            if (image.Equals("0"))
            {
                if (r.ImgStudentPircture != null)
                {
                    return new MemoryStream(r.ImgStudentPircture.ToArray());
                }
                return null;
            }
            if (image.Equals("1"))
            {
                if (r.ImgBirthcertificate != null)
                {
                    return new MemoryStream(r.ImgBirthcertificate.ToArray());
                }
                return null;
            }
            if (image.Equals("2"))
            {
                if (r.ImgAdmissionForm != null)
                {
                    return new MemoryStream(r.ImgAdmissionForm.ToArray());
                }
                return null;
            }
        }
        return null;
    }
}


