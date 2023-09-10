using System.Drawing.Imaging;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace SineWaveProject.Controllers;

[ApiController]
[Route("[controller]")]
public class SignWaveController : ControllerBase
{
    [HttpPost]
    public IActionResult GetSignal(ParametersSineWave parameters)
    {
        var signal = parameters.GenerateSignal();
        var image = ImageMaker.GenerateSignalImage(signal.ToArray());
        var assemblyPath = Assembly.GetEntryAssembly()!.Location;
        var imagePath = Path.GetDirectoryName(assemblyPath) + "\\image.png";
        image.Save(imagePath, ImageFormat.Png);
        return File(
            new FileStream(imagePath, FileMode.Open, FileAccess.Read),
            "application/octet-stream",
            Path.GetFileName(imagePath)
            );
    }
}