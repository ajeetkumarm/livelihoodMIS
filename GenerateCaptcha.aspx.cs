using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GenerateCaptcha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();

        Session["captcha"]= Request.QueryString["captcha"];
        
        int height=31;
        int width=75;
         Bitmap bmp=new Bitmap(width,height);

        RectangleF rectf=new RectangleF();
        Graphics g=Graphics.FromImage(bmp);
      
        g.Clear(Color.LightBlue);
        g.SmoothingMode = SmoothingMode.AntiAlias;

        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;

        //g.DrawString(Session("captcha"), New Font("Thaoma", 12, FontStyle.Italic Or FontStyle.Strikeout), Brushes.Blue, rectf)
      //  g.DrawString(Session("captcha"), New Font("Thaoma", 12, FontStyle.Italic Or FontStyle.Strikeout), Brushes.Blue, rectf);
        g.DrawString(Convert.ToString(Session["captcha"]), new Font("Thaoma",12,FontStyle.Bold),Brushes.Red,rectf);

        g.DrawRectangle(new Pen(Color.Red), 0, 0, width, height);
        //g.DrawRectangle(new Pen(Color.Red, 0), rect);
        g.Flush();
        Response.ContentType = "image/jpeg";
        bmp.Save(Response.OutputStream, ImageFormat.Jpeg);
        g.Dispose();
        bmp.Dispose();
    }
}