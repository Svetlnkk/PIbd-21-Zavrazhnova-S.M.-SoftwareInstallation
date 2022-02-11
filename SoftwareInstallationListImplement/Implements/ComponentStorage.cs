using SoftwareInstallationContracts.BindingModels;
using SoftwareInstallationContracts.StoragesContracts;
using SoftwareInstallationContracts.ViewModels;
using SoftwareInstallationListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareInstallationListImplement.Implements
{
   public class ComponentStorage : IComponentStorage
    {
        private readonly DataListSingleton _source;

        public ComponentStorage()
        {
            _source = DataListSingleton.GetInstance();
        }

        public List<ComponentViewModel> GetFullList()
        {
            var result = new List<ComponentViewModel>();
            foreach (var component in _source.Components)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }

        public List<ComponentViewModel> GetFilteredList(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<ComponentViewModel>();
            foreach (var component in _source.Components)
            {
                if (component.ComponentName.Contains(model.ComponentName))
                {
                    result.Add(CreateModel(component));
                }
            }
            return result;
        }

        public ComponentViewModel GetElement(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            foreach (var component in _source.Components)
            {
                if (component.Id == model.Id || component.ComponentName == model.ComponentName)
                {
                    return CreateModel(component);
                }
            }

            return null;
        }

        public void Insert(ComponentBindingModel model)
        {
            var tmpComponent = new Component { Id = 1 };
            foreach (var component in _source.Components)
            {
                if (component.Id >= tmpComponent.Id)
                {
                    tmpComponent.Id = component.Id + 1;
                }
            }
            _source.Components.Add(CreateModel(model, tmpComponent));
        }

        public void Update(ComponentBindingModel model)
        {
            Component tmpComponent = null;
            foreach (var component in _source.Components)
            {
                if (component.Id == model.Id)
                {
                    tmpComponent = component;
                }
            }
            if (tmpComponent == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tmpComponent);
        }

        public void Delete(ComponentBindingModel model)
        {
            for (int i = 0; i < _source.Components.Count; ++i)
            {
                if (_source.Components[i].Id == model.Id.Value)
                {
                    _source.Components.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        private static Component CreateModel(ComponentBindingModel model, Component component)
        {
            component.ComponentName = model.ComponentName;
            return component;
        }

        private static ComponentViewModel CreateModel(Component component)
        {
            return new ComponentViewModel
            {
                Id = component.Id,
                ComponentName = component.ComponentName
            };
        }
    }
}
