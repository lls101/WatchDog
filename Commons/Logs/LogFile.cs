using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace HZDZ.Core
{
    /// <summary>
    /// File based logger.
    /// </summary>
    public class LogFile : LogBase, ILog, IDisposable
    {
        private string _filepathUnique;
        private StreamWriter _writer;
        private int _iterativeFlushCount = 0;
        private int _iterativeFlushPeriod = 4;
        private object _lockerFlush = new object();
        private int _maxFileSizeInMegs = 20*1024;
        //private bool _rollFile = true;
        private string _set_dir = string.Empty;

        private object safeWrite = new object();

        /// <summary>
        /// Initialize with path of the log file.
        /// </summary>
        /// <param name="name">Name of application.</param>
        /// <param name="filepath">File path, can contain substitutions.</param>
        public LogFile()
        {
        }
      

        /// <summary>
        /// Initialize log file.
        /// </summary>
        /// <param name="name">Name of application.</param>
        /// <param name="filepath">File path, can contain substitutions. e.g. "%yyyy%.</param>
        /// <param name="date">Date to use in the name of the log file.</param>
        /// <param name="env">Environment name to put into the name of the log file.</param>
        /// <param name="rollFile">True to roll file once max size is reached.</param>
        /// <param name="maxSizeInMegs">Maximum size in megabytes.</param>
        public LogFile(string filepath, string filename, string name= "Application", string env="")
            : base(name)
        {
            //_rollFile = rollFile;
            _set_dir = filepath;//LogHelper.BuildLogFileName(filepath, name, date, env);

            var tmp = Path.Combine(_set_dir, "log");
            if (!Directory.Exists(tmp))
            {
                Directory.CreateDirectory(tmp);
            }

            _filepathUnique = Path.Combine(tmp, filename);


            _writer = new StreamWriter(_filepathUnique, true);
        }


        /// <summary>
        /// The full path to the log file.
        /// </summary>
        public string FilePath
        {
            get { return _filepathUnique; }
        }


        /// <summary>
        /// Log the event to file.
        /// </summary>
        /// <param name="logEvent">Event to log.</param>
        public override void Log(LogEvent logEvent)
        {
            string finalMessage = logEvent.FinalMessage;
            if (string.IsNullOrEmpty(finalMessage))
                finalMessage = BuildMessage(logEvent);
            
            lock (safeWrite)
            {
                //_writer.WriteLine(finalMessage);
                _writer.Write(finalMessage + Environment.NewLine);
            }

            FlushCheck();
        }


        /// <summary>
        /// Flush the output.
        /// </summary>
        public override void Flush()
        {
            _writer.Flush();
        }


        /// <summary>
        /// Shutsdown the logger.
        /// </summary>
        public override void ShutDown()
        {
            Dispose();
        }


        #region IDisposable Members
        /// <summary>
        /// Flushes the data to the file.
        /// </summary>
        public void Dispose()
        {
            try
            {
                if (_writer != null)
                {
                    _writer.Flush();
                    _writer.Close();
                    _writer.Dispose();
                    _writer = null;
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion


        /// <summary>
        /// Destructor to close the writer
        /// </summary>
        ~LogFile()
        {
            Dispose();
        }


        /// <summary>
        /// Flush the data and check file size for rolling.
        /// </summary>
        private void FlushCheck()
        {
            lock (_lockerFlush)
            {
                // This is to flush the writer periodically after every N number of times.
                if (_iterativeFlushCount % _iterativeFlushPeriod == 0)
                {
                    _writer.Flush();
                    _iterativeFlushCount = 1;
                }
                else
                    _iterativeFlushCount++;

                // This rolls the log file. e.g. Creates a new log file if the current one
                // exceeds a logfile size.
                int filesize = 0;
                try
                {
                    filesize = FileHelper.GetSizeInMegs(_filepathUnique);
                }
                catch (Exception ex)
                {
                    filesize = -1;
                    Console.WriteLine("file size = " + ex.Message);
                }
                //Console.WriteLine("file = " + _filepathUnique + " size = " + filesize);

                if ((filesize > _maxFileSizeInMegs) || (filesize == -1))
                {
                    try
                    {
                        lock (safeWrite)
                        {
                            _writer.Flush();
                            _writer.Close();
                            _writer.Dispose();
                            _writer = null;

                            var tmp_file = DateTime.Now.ToString("yyyy-MM-dd-HH") + ".log";

                            _filepathUnique = Path.Combine(_set_dir, "log", tmp_file);

                            _writer = new StreamWriter(_filepathUnique, false);

                            Console.WriteLine("newfile = " + _filepathUnique);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
