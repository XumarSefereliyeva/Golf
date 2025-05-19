using Golf.BL.Exceptions;
using Golf.BL.ViewModels;
using Golf.DAL.Contexts;
using Golf.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golf.BL.Services
{
    public class GolfPrService
    {
        private readonly AppDbContext _context;

        public GolfPrService(AppDbContext context)
        {
            _context= context;
        }

        public void Create(GolfPrVM golfVM)
        {
            GolfPr newgolf= new GolfPr();
            newgolf.Price = golfVM.Price;
            newgolf.Description = golfVM.Description;
            newgolf.Location = golfVM.Location;
            newgolf.Name = golfVM.Name;

            string FileName = Path.GetFileNameWithoutExtension(golfVM.ImgUrl.FileName);
            string extension = Path.GetExtension(golfVM.ImgUrl.FileName);
            string FullName = FileName + Guid.NewGuid().ToString() + extension;
            newgolf.ImgUrl = FullName;

            string UploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "admin", "assets", "image");
            UploadPath = Path.Combine(UploadPath, FullName);
            using FileStream stream = new FileStream(UploadPath, FileMode.Create);
            golfVM.ImgUrl.CopyTo(stream);
            _context.golfs.Add(newgolf);
            _context.SaveChanges();
        }
        public List<GolfPr> GetAllGolf()
        {
            List<GolfPr> golfs = _context.golfs.ToList();
            return golfs;
        }
        public GolfPr GetGolfById(int id)
        {
            GolfPr? golf = _context.golfs.Find(id);
            if(golf == null)
            {
                throw new GolfException("Tapilmadi");
            }
            return golf;
        }

        public GolfPrVM GetGolfbyIdLikeVM(int id)
        {
            var item = _context.golfs.Find(id);
            return new GolfPrVM()
            {
                Name = item.Name,
                Description = item.Description,
                Price = item.Price,
                Location = item.Location,
                ImageName = item.ImgUrl
            };
        }

        public void Update(int id,GolfUpdateVM updateVM)
        {
            GolfPr golf = _context.golfs.Find(id);
            if (golf == null)
            {
                throw new GolfException("Tapilmadi");
            }
            golf.Description = updateVM.Description;
            golf.Price = updateVM.Price;
            golf.Location = updateVM.Location;
            golf.Name = updateVM.Name;

            if (updateVM.ImgUrl != null)
            {
                string FileName = Path.GetFileNameWithoutExtension(updateVM.ImgUrl.FileName);
                string extension = Path.GetExtension(updateVM.ImgUrl.FileName);
                string FullName = FileName + Guid.NewGuid().ToString() + extension;
                golf.ImgUrl = FullName;

                string UploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "admin", "assets", "image");
                if (!Directory.Exists(UploadPath))
                {
                    Directory.CreateDirectory(UploadPath);
                }

                UploadPath = Path.Combine(UploadPath, FullName);
                using FileStream stream = new FileStream(UploadPath, FileMode.Create);
                updateVM.ImgUrl.CopyTo(stream);
            }

            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            GolfPr? golf = _context.golfs.Find(id);
            if (golf == null)
            {
                throw new GolfException("Tapilmadi");
            }
            _context.golfs.Remove(golf);
            _context.SaveChanges();
        }
    }
}
