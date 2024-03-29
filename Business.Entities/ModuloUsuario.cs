﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class ModuloUsuario : BusinessEntity
    {
        private int _IdUsuario;
        private int _IdModulo;
        private bool _PermiteAlta;
        private bool _PermiteBaja;
        private bool _PermiteModificacion;
        private bool _PermiteConsulta;

        public int IdUsuario { get => _IdUsuario; set => _IdUsuario = value; }
        public int IdModulo { get => _IdModulo; set => _IdModulo = value; }
        public bool PermiteAlta { get => _PermiteAlta; set => _PermiteAlta = value; }
        public bool PermiteBaja { get => _PermiteBaja; set => _PermiteBaja = value; }
        public bool PermiteModificacion { get => _PermiteModificacion; set => _PermiteModificacion = value; }
        public bool PermiteConsulta { get => _PermiteConsulta; set => _PermiteConsulta = value; }
    }
}
