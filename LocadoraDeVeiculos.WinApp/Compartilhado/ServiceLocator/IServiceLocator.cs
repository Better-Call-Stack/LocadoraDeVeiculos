﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDeVeiculos.WinApp.Compartilhado.ServiceLocator
{
    public interface IServiceLocator
    {
        T Get<T>() where T : ControladorBase;
    }
}
