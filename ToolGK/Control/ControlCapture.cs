namespace ToolGK.Control
{
    internal class ControlCapture
    {
        public void CaptureImageByUrl(string url, string saveImage, int i)
        {
            var obj = new WebsitesScreenshot.WebsitesScreenshot();
            var result = obj.CaptureWebpage(url);
            if (result == WebsitesScreenshot.WebsitesScreenshot.Result.Captured)
            {
                obj.ImageFormat = WebsitesScreenshot.WebsitesScreenshot.ImageFormats.JPG;
                obj.SaveImage(saveImage + "//" + i + ".png");
            }
            obj.Dispose();
        }
    }
}
