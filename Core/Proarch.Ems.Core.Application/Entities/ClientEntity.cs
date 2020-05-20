using Proarch.Ems.Core.Application.Common;
using Proarch.Ems.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proarch.Ems.Core.Application.Entities
{
    public class ClientEntity : Entity
    {
        public string Name { get; set; }

        public bool IsExisted { get; set; }


        public static implicit operator ClientEntity(ClientModel model)
        {
            if (model == null)
                return null;

            return new ClientModel
            {
                Name = model.Name,
                Id = model.Id,
                IsExisted = model.IsExisted,
            };
        }
    }

}
