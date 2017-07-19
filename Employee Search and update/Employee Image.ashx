<%@ WebHandler Language="C#" Class="Employee_Image" %>

   using System.IO;
using System.Linq;
using System.Web;

public class Employee_Image : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string id = context.Request.QueryString["id"];
        context.Response.ContentType = "image/jpg";
        context.Response.ContentType = "image/jpeg";
        Stream strm = ShowEmpImage(id);

        var buffer = new byte[4096];
        int byteSeq = strm.Read(buffer, 0, 4096);
        while (byteSeq > 0)
        {
            context.Response.OutputStream.Write(buffer, 0, byteSeq);
            byteSeq = strm.Read(buffer, 0, 4096);
        }
    }

    public bool IsReusable
    {
        get { return false; }
    }

    public Stream ShowEmpImage(string id)
    {
        var context1 = new SWISDataContext();
        Employee r = (from a in context1.Employees where a.VarEmployeeid == id select a).First();
        return new MemoryStream(r.VarPicture.ToArray());
    }
}