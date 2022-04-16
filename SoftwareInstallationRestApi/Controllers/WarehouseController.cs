using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SoftwareInstallationContracts.BindingModels;
using SoftwareInstallationContracts.BusinessLogicsContracts;
using SoftwareInstallationContracts.ViewModels;

namespace SoftwareInstallationRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WarehouseController : Controller
    {
        private readonly IWarehouseLogic warehouseLogic;
        private readonly IComponentLogic componentLogic;
        public WarehouseController(IWarehouseLogic warehouseLogic, IComponentLogic componentLogic)
        {
            this.warehouseLogic = warehouseLogic;
            this.componentLogic = componentLogic;
        }
        [HttpGet]
        public List<WarehouseViewModel> GetWarehouseList() => warehouseLogic.Read(null)?.ToList();
        [HttpGet]
        public WarehouseViewModel GetWarehouse(int warehouseId) => warehouseLogic.Read(new WarehouseBindingModel { Id = warehouseId })?[0];
        [HttpGet]
        public List<ComponentViewModel> GetComponentsList() => componentLogic.Read(null)?.ToList();
        [HttpPost]
        public void CreateUpdateWarehouse(WarehouseBindingModel model) => warehouseLogic.CreateOrUpdate(model);
        [HttpPost]
        public void DeleteWarehouse(WarehouseBindingModel model) => warehouseLogic.Delete(model);
        [HttpPost]
        public void AddComponentWarehouse(WarehouseComponentsBindingModel model) =>
            warehouseLogic.AddComponent(new WarehouseBindingModel { Id = model.WarehouseId }, model.ComponentId, model.Count);
    }
}
