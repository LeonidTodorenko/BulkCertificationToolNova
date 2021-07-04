using System;
using System.Collections.Concurrent;
using System.IO;
using System.IO.Pipes;
using System.Security.Principal;

namespace BulkCertificationToolNova
{
    internal class PipesManager : IDisposable
    {
        private readonly String _pipeName;

        private ConcurrentStack<String> _fileNames;
        private NamedPipeServerStream _server;
        private Boolean _stop;

        public PipesManager(String pipeName)
        {
            _pipeName = pipeName;
        }

        /// <summary>
        /// Start pipe server to get messages from client
        /// </summary>
        public void StartServer(ConcurrentStack<String> fileNames)
        {
            _fileNames = fileNames;

            try
            {
                _server = new NamedPipeServerStream(_pipeName, PipeDirection.InOut, 1, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
                _server.BeginWaitForConnection(WaitForConnectionCallBack, _server);
            }
            catch
            {
                // ignore
            }
        }

        /// <summary>
        /// Create pipe client and send message to server
        /// </summary>
        public void SendClientMessage(string message)
        {
            using (var pipe = new NamedPipeClientStream(".", _pipeName,
                PipeDirection.InOut, PipeOptions.Asynchronous, TokenImpersonationLevel.Impersonation))
            {
                pipe.Connect();

                using (StreamWriter writer = new StreamWriter(pipe))
                {
                    writer.WriteLine(message);
                    writer.Flush();
                }
            }
        }

        public void Dispose()
        {
            if (_server == null)
            {
                return;
            }

            if (!_server.IsConnected)
            {
                _stop = true;
                ConnectSelf();
            }

            _server.Close();
            _server = null;
        }

        #region Private

        private void WaitForConnectionCallBack(IAsyncResult iar)
        {
            try
            {
                // Get the pipe
                var pipeServer = (NamedPipeServerStream)iar.AsyncState;

                // End waiting for the connection
                pipeServer.EndWaitForConnection(iar);

                //while there is no stop command - write data
                if (!_stop)
                {
                    using (var reader = new StreamReader(pipeServer))
                    {
                        var fileName = reader.ReadLine();
                        _fileNames.Push(fileName);
                    }
                }

                // Kill original sever and create new wait server
                pipeServer.Close();
                pipeServer = null;

                //if there is no stop command - start new server
                if (_stop)
                {
                    return;
                }

                pipeServer = new NamedPipeServerStream(_pipeName, PipeDirection.InOut, 1,
                    PipeTransmissionMode.Message, PipeOptions.Asynchronous);

                // Recursively wait for the connection again and again....
                pipeServer.BeginWaitForConnection(WaitForConnectionCallBack, pipeServer);
            }
            catch
            {
                // ignore
            }
        }

        private void ConnectSelf()
        {
            using (var pipe = new NamedPipeClientStream(".", _pipeName, PipeDirection.InOut,
                PipeOptions.Asynchronous, TokenImpersonationLevel.Impersonation))
            {
                pipe.Connect();
            }
        }

        #endregion
    }
}
