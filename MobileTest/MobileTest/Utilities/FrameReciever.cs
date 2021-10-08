using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace MobileTest.Utilities
{
    public class FrameReciever
    {
        private readonly HttpClient _httpClient;
        private const string _requestUrl = "mobile?channelid={0}&oneframeonly=true&login={1}";

        public FrameReciever(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<byte[]> GetFrameByteArray(string channelId, string login)
        {
            var requestUrl = string.Format(_requestUrl, channelId, login);

            var responseByteArr = await _httpClient.GetByteArrayAsync(requestUrl);

            var frameBytes = GetBinJpg(responseByteArr);

            return frameBytes;
        }

        private byte[] GetBinJpg(byte[] buffer)
        {
            using(MemoryStream memoryStream = new MemoryStream(buffer))
            {
                using(BinaryReader reader = new BinaryReader(memoryStream))
                {
                    byte previousByte = reader.ReadByte();
                    byte currentByte;
                    List<byte> frameBytes = new List<byte>();
                    bool isFrameStarted = false;

                    for (int i = 1; i < buffer.Length; i++)
                    {
                        currentByte = reader.ReadByte();

                        if (previousByte == 255 && currentByte == 216)
                            isFrameStarted = true;

                        if (isFrameStarted)
                            frameBytes.Add(previousByte);

                        if (previousByte == 255 && currentByte == 217)
                        {
                            frameBytes.Add(currentByte);
                            return frameBytes.ToArray();
                        }

                        previousByte = currentByte;
                    }
                }
            }

            throw new Exception("not jpeg");
        }

    }
}
