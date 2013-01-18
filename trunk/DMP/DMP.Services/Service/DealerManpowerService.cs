using System;
using System.Collections.Generic;
using System.Linq;
using DMP.Repository;
using DMP.Services.Interface;

namespace DMP.Services.Service {
    public class DealerManpowerService : IDealerManpowerService {

        private readonly IRepository<DealerManpower> manpowerRepo;
        private readonly IRepository<Month> monthRepo;
        private readonly IRepository<ProductVarient> productVariantRepo;

        public DealerManpowerService(IRepository<DealerManpower> manpowerRepo, IRepository<Month> monthRepo, IRepository<ProductVarient> variantRepo) {
            this.manpowerRepo = manpowerRepo;
            this.monthRepo = monthRepo;
            productVariantRepo = variantRepo;
        }

        public DealerManpower GetDealerManpower(int id) {
            return manpowerRepo.Single(x => x.Id == id);
        }

        public void AddDealerManpower(IEnumerable<DealerManpower> manpowers) {
            foreach (var manpower in manpowers) {
                manpowerRepo.Add(manpower);
            }
            manpowerRepo.SaveChanges();
        }

        public void UpdateDealerManpower(DealerManpower manpower) {
            var oldManpower = GetDealerManpower(manpower.Id);
            oldManpower.Name = manpower.Name;
            oldManpower.Type = manpower.Type;
            oldManpower.Description = manpower.Description;
            oldManpower.DealerId = manpower.DealerId;
            oldManpower.UserId = manpower.UserId;
            oldManpower.ProductId = manpower.ProductId;
            manpowerRepo.SaveChanges();
        }

        public void DeleteDealerManpower(int id) {
            var state = GetDealerManpower(id);
            manpowerRepo.Delete(state);
            manpowerRepo.SaveChanges();
        }

        public IEnumerable<DealerManpower> GetAllDealerManpowers() {
            return manpowerRepo.GetAll().Where(x => x.ObjectInfo.DeletedDate == null);
        }

        public IEnumerable<DealerManpower> FindDealerManpowers(Func<DealerManpower, bool> predicate) {
            return manpowerRepo.Find(predicate).Where(x => x.ObjectInfo.DeletedDate == null);
        }

        public Month FindMonthById(int id) {
            var month = monthRepo.Single(x => x.Id == id);
            if (month != null) {
                return month;
            }
            return null;
        }

        public ProductVarient FindProductById(int id) {
            var variant = productVariantRepo.Single(x => x.Id == id);
            if (variant != null) {
                return variant;
            }
            return null;
        }
    }
}