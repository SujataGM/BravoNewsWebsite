using BravoNews.Data;
using Microsoft.AspNetCore.Mvc;
using BravoNews.Models.ViewModels;
using BravoNews.Services;

namespace BravoNews.ViewComponents
{
    public class AdvertisementRightViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;
        private readonly IStorageService _storageService;
        public AdvertisementRightViewComponent(ApplicationDbContext db, IStorageService storageService)
        {
            _db = db;
            _storageService = storageService;
        }
        public IViewComponentResult Invoke()
        {
            dbAdvertisementVM dbAdvertisement = new dbAdvertisementVM();
            string blobPath = "news-images-sm";

            dbAdvertisement.dbAdvertisement = _db.Articles.OrderByDescending(x => x).Where(x => x.CategoryId == 15).Take(6).ToList();

            foreach (var item in dbAdvertisement.dbAdvertisement)
            {
                item.ImageLink = _storageService.GetBlob(item.FileName, blobPath, "/" + item.CategoryId);

            }
            //var dbAdvertisement = _db.Articles.Where(x => x.CategoryId == 15).ToList();
            return View("AdRight", dbAdvertisement);
        }
    }
}
