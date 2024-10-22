using NAudio.Wave;
using System;
using System.Threading.Tasks;

namespace SnakeMaduussTARpv23.Services
{
    public class SoundPlayer : IDisposable
    {
        private IWavePlayer _waveOutEvent;
        private AudioFileReader _audioFileReader;

        public void Play(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            try
            {
                _waveOutEvent = new WaveOutEvent();
                _audioFileReader = new AudioFileReader(filePath);
                _waveOutEvent.Init(_audioFileReader);
                _waveOutEvent.Play();

                _waveOutEvent.PlaybackStopped += (sender, args) =>
                {
                    Dispose();
                };
            }
            catch (Exception ex)
            {
                // Обработка исключений, связанных с воспроизведением
                Console.WriteLine($"Error playing sound: {ex.Message}");
                Dispose(); // Освобождаем ресурсы, если произошла ошибка
            }
        }

        public void PlayAsync(string filePath)
        {
            Task.Run(() => Play(filePath));
        }

        public void Dispose()
        {
            if (_waveOutEvent != null)
            {
                _waveOutEvent.Stop();
                _waveOutEvent.Dispose();
                _waveOutEvent = null;
            }

            if (_audioFileReader != null)
            {
                _audioFileReader.Dispose();
                _audioFileReader = null;
            }
        }
    }
}
