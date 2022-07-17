using System;
using System.ComponentModel;
using System.Diagnostics;

namespace BookSearcherApp
{
    public abstract class DataIO : IDisposable
    {
        public const int MAX_VALUE = DataIOProgressBar.MAX_VALUE;
        public const int DIV_VALUE = DataIOProgressBar.DIV_VALUE;
        private const double DIV = MAX_VALUE / 100.0;
        private bool disposed = false;

        private Stopwatch StopWatch;
        private TimeSpan elapsed;
        private int currentProgress;
        private DataIOProgressBar progressBar;

        public int Progress => currentProgress;

        public string CurrentProgress
        {
            get {
                if (StopWatch != null)
                {
                    elapsed = StopWatch.Elapsed;
                }
                var time = elapsed.ToString(@"hh\:mm\:ss\.fff");
                var percentValue = currentProgress / DIV;
                var percent = percentValue.ToString("F2").PadLeft(5);
                return $"{percent}% - {time}";
            }
        }

        public bool IsRunning { get; private set; }

        public DataIO()
        {
            IsRunning = false;
        }

        ~DataIO()
        {
            Dispose(true);
        }

        protected void StartIO(BackgroundWorker backgroundWorker, DataIOProgressBar progressBar)
        {
            IsRunning = true;
            _ = progressBar.BeginInvoke((Action)(() => progressBar.Maximum = MAX_VALUE));
            this.progressBar = progressBar;
            StopWatch = Stopwatch.StartNew();
            currentProgress = 0;
            elapsed = TimeSpan.Zero;
            backgroundWorker?.ReportProgress(currentProgress);
        }

        protected void StopIO()
        {
            StopWatch.Stop();
            currentProgress = MAX_VALUE;
            progressBar.BeginInvoke((Action)(() => {
                progressBar.Value = MAX_VALUE;
                progressBar.Text = CurrentProgress;
                }));
            Close();
            IsRunning = false;
        }

        protected void ReportProgress(int progress)
        {
            // Debug.WriteLine($"progress = {progress} / currentProgress = {currentProgress}");
            if (progress < currentProgress || progress < (progressBar == null ? 0 : progressBar.Minimum))
            {
                return;
            }
            if (progress > MAX_VALUE || progress > (progressBar == null ? MAX_VALUE : progressBar.Maximum))
            {
                return;
            }
#if false
            if (progress - currentProgress > DIV_VALUE)
            {
                backgroundWorker?.ReportProgress(progress);
            }
#endif
            currentProgress = progress;
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Close();
                }
                disposed = true;
            }
        }

        protected abstract void Close();
    }
}
