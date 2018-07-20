using Consul;
using George.Framework.Models;
using System;
using System.Threading.Tasks;

namespace George.Framekwork.Consul
{
    public class ConsulProcessProvider
    {
        public static async Task Register(ConsulSetting consulSetting)
        {
            using (var client = new ConsulClient(cfg => { cfg.Address = new Uri($"{consulSetting.Url}"); cfg.Datacenter = "dc1"; }))
            {
                await client.Agent.ServiceRegister(new AgentServiceRegistration()
                {
                    ID = Guid.NewGuid().ToString(),
                    Name = consulSetting.ServiceName,
                    Address = consulSetting.Ip,
                    Port = consulSetting.ClientPort,
                    Check = new AgentServiceCheck
                    {
                        DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),
                        Interval = TimeSpan.FromSeconds(10),
                        HTTP = $"http://{consulSetting.Ip}:{consulSetting.ClientPort}/api/health",
                        Timeout = TimeSpan.FromSeconds(5)
                    }
                });
            }
        }

        public static async Task DeRegister(ConsulSetting consulSetting)
        {
            using (var client = new ConsulClient(cfg => { cfg.Address = new Uri($"{consulSetting.Url}"); cfg.Datacenter = "dc1"; }))
            {
                await client.Agent.ServiceDeregister(consulSetting.ServiceId);
            }
        }
    }
}


