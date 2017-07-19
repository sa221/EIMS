<%@ WebHandler Language="C#" Class="Image3" %>

using System.IO;
using System.Linq;
using System.Web;

public class Image3 : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string id = context.Request.QueryString["id"];
        context.Response.ContentType = "image/jpg";
        context.Response.ContentType = "image/jpeg";

        Stream strm = ShowEmpImage(id);
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

    public Stream ShowEmpImage(string id)
    {
        var context1 = new SWISDataContext();
        IQueryable<string> existId = from c in context1.StudentDocs
            where c.VarStudentID == id
            select c.VarStudentID;

        if (existId.FirstOrDefault() != null)
        {
            StudentDoc r = (from a in context1.StudentDocs where a.VarStudentID == id select a).First();

            if (r.ImgAdmissionForm != null)
            {
                return new MemoryStream(r.ImgAdmissionForm.ToArray());
            }
            return null;
        }
        return null;
    }
}