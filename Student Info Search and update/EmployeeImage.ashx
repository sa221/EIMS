<%@ WebHandler Language="C#" Class="EmployeeImage" %>

using System.IO;
using System.Linq;
using System.Web;

public class EmployeeImage : IHttpHandler
{
    SWISDataContext db = new SWISDataContext();
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

        var existId = from c in db.Employees
                                     where c.VarEmployeeid == id
                                     select c.VarEmployeeid;

        if (existId.FirstOrDefault() != null)
        {
            Employee r = (from a in db.Employees where a.VarEmployeeid == id select a).First();
            if (image.Equals("0"))
            {
                if (r.VarPicture != null)
                {
                    return new MemoryStream(r.VarPicture.ToArray());
                }
                return null;
            }
        }
        return null;
    }
}


