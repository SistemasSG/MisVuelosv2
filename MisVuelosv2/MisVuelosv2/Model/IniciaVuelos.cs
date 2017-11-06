using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisVuelosv2.Model
{
    public class IniciaVuelos
    {
        public async static void GetIniciaVuelos()
        {
            try
            {
                List<Vuelos> v = new List<Vuelos>();
                v = App.Database.GetVuelosAsync().Result.ToList();
                Random rnd = new Random();
                if (v.Count == 0)
                {
                    List<Aerolineas> aerolineas = App.Database.GetAerolineas();
                    List<Ciudades> destinos = App.Database.GetCiudades();
                    string _origen;
                    string _destino;
                    string _aerolinea;

                    foreach (var item_a in aerolineas)
                    {
                        for (int i = 1; i < 10; i++) //Dias
                        {
                            foreach (var item_o in destinos)
                            {
                                foreach (var item_d in destinos)
                                {
                                    if (item_d.ciudad.Trim() != item_o.ciudad.Trim())
                                    {
                                        _origen = item_o.ciudad;
                                        _destino = item_d.ciudad;
                                        _aerolinea = item_a.aerolinea;
                                        DateTime FechaInicial;
                                        switch (item_a.aerolinea.Trim())
                                        {
                                            case "Aserca":
                                                {
                                                    FechaInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, 45, 0);
                                                }
                                            break;
                                            case "Conviasa":
                                                {
                                                    FechaInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 5, 15, 0);
                                                }
                                            break;
                                            case "Laser":
                                                {
                                                    FechaInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 7, 30, 0);
                                                }
                                            break;
                                            case "Venezolana":
                                                {
                                                    FechaInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0);
                                                }
                                            break;
                                            case "Avior":
                                                {
                                                    FechaInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 5, 0, 0);
                                                }
                                            break;
                                            default:
                                                FechaInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 5, 0, 0);
                                                break;
                                        }
                                        
                                        DateTime fec_sal = FechaInicial.AddDays(i);

                                        
                                        await App.Database.RegistrarVuelo(new Vuelos
                                        {
                                            aerolinea = _aerolinea,
                                            asientos = 120,
                                            asientos_dis = 120,
                                            fecha = fec_sal,
                                            origen = _origen,
                                            destino = _destino,
                                            precio = 150 *
                                            (fec_sal.DayOfWeek == DayOfWeek.Friday || fec_sal.DayOfWeek == DayOfWeek.Saturday || fec_sal.DayOfWeek == DayOfWeek.Sunday ? 1.30m : 1.00m) 

                                        });

                                        await App.Database.RegistrarVuelo(new Vuelos
                                        {
                                            aerolinea = _aerolinea,
                                            asientos = 120,
                                            asientos_dis = 120,
                                            fecha = fec_sal.AddHours(4),
                                            origen = _origen,
                                            destino = _destino,
                                            precio = 150 *
                                            (fec_sal.DayOfWeek == DayOfWeek.Friday || fec_sal.DayOfWeek == DayOfWeek.Saturday || fec_sal.DayOfWeek == DayOfWeek.Sunday ? 1.30m : 1.00m) 
                                        });

                                        await App.Database.RegistrarVuelo(new Vuelos
                                        {
                                            aerolinea = _aerolinea,
                                            asientos = 120,
                                            asientos_dis = 120,
                                            fecha = fec_sal.AddHours(9),
                                            origen = _origen,
                                            destino = _destino,
                                            precio = 150 *
                                            (fec_sal.DayOfWeek == DayOfWeek.Friday || fec_sal.DayOfWeek == DayOfWeek.Saturday || fec_sal.DayOfWeek == DayOfWeek.Sunday ? 1.30m : 1.00m) * 1.10m
                                        });

                                        await App.Database.RegistrarVuelo(new Vuelos
                                        {
                                            aerolinea = _aerolinea,
                                            asientos = 120,
                                            asientos_dis = 120,
                                            fecha = fec_sal.AddHours(15),
                                            origen = _origen,
                                            destino = _destino,
                                            precio = 150 *
                                            (fec_sal.DayOfWeek == DayOfWeek.Friday || fec_sal.DayOfWeek == DayOfWeek.Saturday || fec_sal.DayOfWeek == DayOfWeek.Sunday ? 1.30m : 1.00m) * 1.10m
                                        });

                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
