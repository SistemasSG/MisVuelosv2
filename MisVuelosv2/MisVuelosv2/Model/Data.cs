﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisVuelosv2.Model
{
    public class Vuelos
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string aerolinea { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public int? asientos { get; set; }
        public int? asientos_dis { get; set; }
        public DateTime? fecha { get; set; }
        public decimal precio { get; set; }
    }

    public class Clientes
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Nombre { get; set; }
        public int Cedula { get; set; }
        public int Edad { get; set; }
    }

    public class Reservaciones
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string reserva { get; set; }
        public int id_vuelo { get; set; }
        public int id_cliente { get; set; }
        public int asientos { get; set; }
        public decimal pago { get; set; }
        public DateTime fecha { get; set; }
    }

    public class Ciudades
    {
        public string ciudad { get; set; }
    }

    public class Aerolineas
    {
        public string aerolinea { get; set; }
    }

    public class Datos_reserva
    {
        //Reserva
        public string reserva { get; set; }
        public int id_vuelo { get; set; }
        public int id_cliente { get; set; }
        public int asientos { get; set; }
        public decimal pago { get; set; }
        public DateTime fecha { get; set; }

        //Vuelo
        public string aerolinea { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public DateTime? fecha_vuelo { get; set; }

        //Cliente
        public string Nombre { get; set; }
        public int Cedula { get; set; }
        public int Edad { get; set; }
    }
}
