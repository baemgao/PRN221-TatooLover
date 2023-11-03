using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class ServiceDAO
    {
        public List<Service> GetServices()
        {
            List<Service> services = new List<Service>();

            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    services = context.Services
                        .Include(s => s.Studio)
                        .OrderByDescending(s => s.Status == 1)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return services;
        }

        public List<Service> GetServiceByStudioId(int studioId)
        {
            List<Service> services = new List<Service>();

            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    services = context.Services
                        .Include(s => s.Studio)
                        .Include(s => s.ArtistDetails)
                        .ThenInclude(s => s.Artist)
                        .Where(s => s.StudioId == studioId)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return services;
        }

        public void UpdateServiceStatus(int serviceId)
        {
            try
            {
                Studio studio;
                using (var context = new Prn221TatooLoverContext())
                {
                    Service service = GetServices().Where(s => s.ServiceId == serviceId).FirstOrDefault();
                    int status = (service.Status == 1) ? 0 : 1;
                    service.Status = status;
                    context.Update(service);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int AddService(Service service, int artistId)
        {
            try
            {
                using (var context = new Prn221TatooLoverContext())
                {
                    // Thêm dịch vụ (Service) vào CSDL
                    Service service1 = GetServices().Where(s => s.Code == service.Code).FirstOrDefault();
                    if (service1 != null)
                    {
                        context.Services.Add(service);
                        int serviceId = context.SaveChanges(); // Lưu thay đổi để lấy ServiceID sau khi thêm

                        // Tạo một ArtistDetail mới để gán dịch vụ cho nghệ sĩ
                        var artistDetail = new ArtistDetail();
                        artistDetail.ArtistId = artistId;
                        artistDetail.ServiceId = serviceId;

                        context.ArtistDetails.Add(artistDetail);
                        context.SaveChanges(); // Lưu thay đổi để gán dịch vụ cho nghệ sĩ
                        
                        return serviceId;
                    }
                    else
                        return -1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
