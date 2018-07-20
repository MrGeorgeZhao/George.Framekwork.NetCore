using Consul;
using System;
using Xunit;

namespace George.Framework.Consul.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            using (var consulClient = new ConsulClient(c => c.Address = new Uri("http://192.168.0.122:8500")))
            {
                var services = consulClient.Agent.Services().Result.Response;
                foreach (var service in services.Values)
                {
                    System.Diagnostics.Debug.WriteLine($"id={service.ID},name={service.Service},ip={service.Address},port={service.Port} ");
                }
            }

        }
    }
}
