using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FlickTrap.Web.Controllers
{
    public class ImageController : Controller
    {
        public ActionResult Index(int width, string path)
        {
            var placeHolder = Url.Content( "~/Content/images/Flying-Film-Reel.jpg" );
            if( path == "" )
                path = placeHolder;
                
            //get file bytes
            var original = path.Contains("http://")
                               ? GetImageFromUrl(path)
                               : Image.FromFile(Server.MapPath(path));

            //resize image
            if( original == null )
                original = Image.FromFile( Server.MapPath( placeHolder ) );
            var resized = ResizeImage(original, width);

            //convert and return
            var converter = new ImageConverter();
            return File((byte[]) converter.ConvertTo(resized, typeof (byte[]))
                        , GetMimeType(path));
        }

        static Image GetImageFromUrl( string path )
        {
            try
            {
                var req = WebRequest.Create(path);
                var response = req.GetResponse();
                using( var stream = response.GetResponseStream() )
                {
                    var original = Image.FromStream(stream);
                    return original;
                }
            }
            catch
            {
                return null;
            }
        }

        public Image ResizeImage( Image fullsizeImage, int newWidth )
        {
            // Prevent using images internal thumbnail
            fullsizeImage.RotateFlip( System.Drawing.RotateFlipType.Rotate180FlipNone );
            fullsizeImage.RotateFlip( System.Drawing.RotateFlipType.Rotate180FlipNone );

            var newHeight = fullsizeImage.Height * newWidth / fullsizeImage.Width;
            
            var newImage = fullsizeImage.GetThumbnailImage( newWidth, newHeight, null, IntPtr.Zero );

            // Clear handle to original file so that we can overwrite it if necessary
            fullsizeImage.Dispose();

            // Save resized picture
            return newImage;
        }

        private string GetMimeType( string fileName )
        {
            var mimeType = "application/unknown";
            var ext = System.IO.Path.GetExtension( fileName ).ToLower();
            
            if( Session[ "mimetypefor" + ext ] != null )
                return Session["mimetypefor" + ext].ToString();

            var regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey( ext );
            if( regKey != null && regKey.GetValue( "Content Type" ) != null )
                mimeType = regKey.GetValue( "Content Type" ).ToString();
            
            Session["mimetypefor" + ext] = mimeType;
            return mimeType;
        }

    }
}
