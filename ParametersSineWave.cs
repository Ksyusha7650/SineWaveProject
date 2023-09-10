namespace SineWaveProject;

public record ParametersSineWave(double A, double Fd, double Fs, int N)
{
    public List<double> GenerateSignal()
    {
        var amountPoints = (int)(Fd * N);
        var signal = new List<double>();
        var t = 0.0;
        for (var i = 0; i <= amountPoints; i++)
        {
            signal.Add(A * Math.Sin(2 * Math.PI * Fs * t));
            t += Math.PI * 2;
        }
        return signal;
    }
}