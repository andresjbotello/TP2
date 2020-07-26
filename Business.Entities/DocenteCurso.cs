using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        private TiposCargos _Cargo;
        private int _IDCurso;
        private int _IDDocente;

        public TiposCargos Cargo { get => _Cargo; set => _Cargo = value; }
        public int IDCurso { get => _IDCurso; set => _IDCurso = value; }
        public int IDDocente { get => _IDDocente; set => _IDDocente = value; }

        public enum TiposCargos
        {
            Teoria, Practica, AuxiliarTeoria, AuxiliarPractica
        }

        public void SetTipoCargoById(int id)
        {
            switch (id)
            {
                case (int)TiposCargos.Teoria:
                    this.Cargo = TiposCargos.Teoria;
                    break;
                case (int)TiposCargos.Practica:
                    this.Cargo = TiposCargos.Practica;
                    break;
                case (int)TiposCargos.AuxiliarTeoria:
                    this.Cargo = TiposCargos.AuxiliarTeoria;
                    break;
                case (int)TiposCargos.AuxiliarPractica:
                    this.Cargo = TiposCargos.AuxiliarPractica;
                    break;
                default:
                    throw new Exception("No existe el cargo especificado: " + id.ToString());
            }
        }

        public int GetIDTipoCargo()
        {
            switch (this.Cargo)
            {
                case TiposCargos.Teoria:
                    return 0;
                case TiposCargos.Practica:
                    return 1;
                case TiposCargos.AuxiliarTeoria:
                    return 2;
                case TiposCargos.AuxiliarPractica:
                    return 3;
                default:
                    throw new Exception("No existe el tipo persona especificado: " + this.Cargo.ToString());
            }
        }
    }
}
